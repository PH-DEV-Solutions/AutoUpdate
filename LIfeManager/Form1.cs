using System.Data.SqlClient;
using System.Configuration;
using Markdig; // Importuj Markdig pro převod Markdown na HTML
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Newtonsoft.Json;
using Microsoft.Web.WebView2.Core;
using Microsoft.CognitiveServices.Speech.Audio;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Metadata;
using System;
using System.Windows.Forms;
using System.Diagnostics;
using Windows.ApplicationModel;
using Windows.System;

namespace LIfeManager
{


    public partial class mainContentPanel : Form
    {
        // Přidání nové proměnné pro sledování změn v richTextBoxMe
        private System.Threading.Timer sendTimer;
        private const int delayBeforeSend = 2000; // 2 sekundy čekání po poslední změně
        private Microsoft.CognitiveServices.Speech.SpeechRecognizer azureRecognizer;



        public mainContentPanel()
        {
            InitializeComponent();
            LoadImages();
            InitializeWebView(); // Inicializace WebView
            InitializeWebViewDiscordOrion(); // Inicializace WebView
            CheckDatabaseConnection(); // Zavolání metody pro kontrolu připojení k databázi
            SetLabelsForDates();
            LoadActivities(); // Zavolání metody pro načtení aktivit

            InitializeAzureSpeechRecognition(); // Inicializace Azure Speech SDK

            // Přidání event handleru pro změnu textu v richTextBoxMe
            richTextBoxMe.TextChanged += richTextBoxMe_TextChanged;
            // Připojení metody pro vykreslování
            this.Paint += DrawAnimationsPaintEvent;
        }

        private void richTextBoxMe_TextChanged(object sender, EventArgs e)
        {
            if (sendTimer != null)
            {
                sendTimer.Dispose();
            }

            sendTimer = new System.Threading.Timer(state =>
            {
                this.Invoke(new Action(() =>
                {
                    btnSendToGpt_Click(btnSendToGpt, EventArgs.Empty);
                }));
            }, null, delayBeforeSend, System.Threading.Timeout.Infinite);
        }

        private void mainContentPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (azureRecognizer != null)
            {
                azureRecognizer.Dispose();
            }
        }

        /// <summary>
        /// Inicializace Azure Speech SDK pro rozpoznávání řeči
        /// </summary>
        /// <summary>
        /// Inicializace Azure Speech SDK pro rozpoznávání řeči
        /// </summary>
        private async void InitializeAzureSpeechRecognition()
        {
            try
            {
                // MessageBox.Show("Inicializuji Azure Speech SDK...");

                // Nastavení konfigurace Azure a češtiny
                var azureConfig = SpeechConfig.FromSubscription("5sV3nUtZ3it4XPjItdIvKGmjzacM5HkoHQLqlmzaFCPvIFU780igJQQJ99BCAC5RqLJXJ3w3AAAYACOGHf6S", "westeurope");
                azureConfig.SpeechRecognitionLanguage = "cs-CZ"; // Nastavení jazyka na češtinu



                var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
                azureRecognizer = new SpeechRecognizer(azureConfig, audioConfig);

                azureRecognizer.Recognized += (sender, e) =>
                {
                    if (e.Result.Reason == ResultReason.RecognizedSpeech && !string.IsNullOrEmpty(e.Result.Text))
                    {
                        this.Invoke(new Action(() =>
                        {
                            string recognizedText = e.Result.Text.ToLower(); // Převeď na malá písmena
                            richTextBoxCrossroads.AppendText(recognizedText + Environment.NewLine);

                            // Kontrola deaktivace na 2 minuty
                            if (recognizedText.Contains("konec relace"))
                            {
                                PauseMicrophoneForTwoMinutes();
                                return;
                            }

                            // Kontrola aktivace
                            if (recognizedText.Contains("orion") || recognizedText.Contains("oryon") || recognizedText.Contains("ori") || recognizedText.Contains("ory"))
                            {
                                if (!isMicrophonePaused)
                                {
                                    isListeningToMe = true;
                                    lbl_activatedgpt.Text = "GPT Aktivován"; // Zobrazí stav
                                }
                                return;
                            }

                            // Kontrola deaktivace
                            if (recognizedText.Contains("díky") || recognizedText.Contains("děkuju"))
                            {
                                if (!isMicrophonePaused)
                                {
                                    isListeningToMe = false;
                                    lbl_activatedgpt.Text = "GPT Deaktivován"; // Zobrazí stav
                                }
                                return;
                            }

                            // Přidaná kontrola: pokud je řečeno "domluveno", aktivuje se mikrofon
                            if (recognizedText.Contains("domluveno"))
                            {
                                ResumeMicrophone();
                                return;
                            }

                            // Posílání do richTextBoxMe, pokud je aktivováno a mikrofon není pauznutý
                            if (isListeningToMe && !isMicrophonePaused)
                            {
                                richTextBoxMe.AppendText(recognizedText + Environment.NewLine);
                            }
                        }));
                    }
                };

                await azureRecognizer.StartContinuousRecognitionAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Neočekávaná chyba při inicializaci Azure Speech SDK: {ex.Message}");
            }
        }

        /// <summary>
        /// Pauzne mikrofon na určitý čas a poté automaticky obnoví.
        /// </summary>
        private void PauseMicrophoneForTwoMinutes()
        {
            if (isMicrophonePaused)
                return;

            isMicrophonePaused = true;
            countdownSeconds = 120; // Nastavit odpočet na 2 minuty
            lbl_activatedgpt.Text = "Mikrofon pauznut";
            lbl_timer.Visible = true;

            // Zastavit aktuální rozpoznávání
            azureRecognizer.StopContinuousRecognitionAsync();

            // Spustit odpočet pro obnovu
            resumeMicrophoneTimer = new System.Threading.Timer(state =>
            {
                this.Invoke(new Action(() =>
                {
                    if (countdownSeconds > 0)
                    {
                        lbl_timer.Text = $"Zbývá: {countdownSeconds} s";
                        countdownSeconds--;
                    }
                    else
                    {
                        resumeMicrophoneTimer.Dispose();
                        ResumeMicrophone(true); // Obnovení mikrofonu po pauze
                    }
                }));
            }, null, 0, 1000); // Spustí se ihned a pak každou sekundu
        }

        /// <summary>
        /// Obnoví mikrofon a aktualizuje stav.
        /// </summary>
        private async void ResumeMicrophone(bool afterPause = false)
        {
            if (isMicrophonePaused)
            {
                isMicrophonePaused = false;

                if (afterPause)
                {
                    lbl_timer.Visible = false; // Skryje odpočet po pauze
                }

                lbl_activatedgpt.Text = "GPT Aktivován";
                await azureRecognizer.StartContinuousRecognitionAsync();
            }
        }




        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        private const byte VK_ESC = 0x1B; // Kód klávesy Esc

        private const int KEYEVENTF_KEYDOWN = 0x0000; // Stisknutí klávesy
        private const int KEYEVENTF_KEYUP = 0x0002; // Uvolnění klávesy
        private const byte VK_LWIN = 0x5B; // Kód klávesy pro levé Win
        private const byte VK_H = 0x48; // Kód klávesy H



        private string lastMessage = ""; // Proměnná pro uložení poslední zprávy
        private bool isFirstMessage = true; // Proměnná pro sledování první zprávy
        private bool isListeningToMe = false; // Určuje, zda se má zadávat do richTextBoxMe
        private bool isMicrophonePaused = false; // Stav pauzy mikrofonu
        private System.Threading.Timer resumeMicrophoneTimer; // Timer pro obnovení mikrofonu
        private int countdownSeconds = 120; // Počet sekund pro pauzu (2 minuty)

        private void SimulateEscKeyPress()
        {
            keybd_event(VK_ESC, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Stisk klávesy Esc
            Thread.Sleep(50); // Krátká prodleva
            keybd_event(VK_ESC, 0, KEYEVENTF_KEYUP, UIntPtr.Zero); // Uvolnění klávesy Esc
        }

        public static bool isDictationActive = false;
        private Bitmap XDZT;



        public static void ToggleDictation(Control textBox)
        {
            // Pokud je diktování již aktivní, neaktivujeme znovu
            if (isDictationActive)
                return;

            // Nastavení fokusu na zadaný textBox (např. richTextBoxMe)
            textBox.Focus();
            Application.DoEvents(); // Aktualizace fokusu

            // Simulace stisknutí kláves Win + H pro spuštění diktování
            keybd_event(VK_LWIN, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Stisk Win
            Thread.Sleep(50); // Krátká prodleva
            keybd_event(VK_H, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Stisk H
            Thread.Sleep(50);

            // Simulace uvolnění kláves Win + H
            keybd_event(VK_H, 0, KEYEVENTF_KEYUP, UIntPtr.Zero); // Uvolnění H
            keybd_event(VK_LWIN, 0, KEYEVENTF_KEYUP, UIntPtr.Zero); // Uvolnění Win

            // Označíme, že diktování je aktivní
            isDictationActive = true;
        }


        // Přidáme novou metodu pro ukončení diktování
        public static void StopDictation()
        {
            // Simulace stisknutí klávesy ESC pro ukončení diktování
            keybd_event(0x1B, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Stisk ESC
            Thread.Sleep(50); // Krátká prodleva
            keybd_event(0x1B, 0, KEYEVENTF_KEYUP, UIntPtr.Zero); // Uvolnění ESC
            Console.WriteLine("Diktování bylo ukončeno.");
        }

        private DateTime? gptPlayingStartTime = null;
        private async void InitializeWebView()
        {
            try
            {
                // Zajistěte, aby WebView2 bylo inicializováno
                await webView.EnsureCoreWebView2Async(null);
                webView.Source = new Uri("https://chatgpt.com/c/67cfffcd-0940-8008-b048-dc083f3c1002");

                // Zpoždění 3 sekundy pro zajištění načtení celé stránky
                await Task.Delay(3000);

                // JavaScript pro pravidelné získávání poslední zprávy z konverzace a detekci tlačítek
                string script = @"
    // Inicializace globální proměnné pro čas přehrávání, pokud ještě není definována
    if (typeof window.gptPlayingTimestamp === 'undefined') {
        window.gptPlayingTimestamp = null;
    }

    let lastMessage = '';
    let isFirstLoad = true; // Flag pro první načtení
    let isPlaying = false; // Stav přehrávání
    const maxRetries = 3; // Maximální počet pokusů
    const retryDelay = 1000; // Prodleva mezi pokusy v milisekundách

    // Funkce, která kontroluje, zda uplynulo 5 sekund od začátku přehrávání,
    // než se odešle zpráva GPT_STOPPED.
    function checkStopLoop() {
        if (!document.querySelector('button[aria-label=""Zastavit""]') && isPlaying) {
            let elapsed = Date.now() - window.gptPlayingTimestamp;
            if (elapsed >= 5000) {
                isPlaying = false;
                window.chrome.webview.postMessage('GPT_STOPPED');
                window.gptPlayingTimestamp = null;
            } else {
                // Zkontroluj znovu za 500 ms
                setTimeout(checkStopLoop, 500);
            }
        }
    }

    // Funkce pro pokus o přehrání
    function attemptPlay(turnElement, attempt) {
        if (attempt >= maxRetries) {
            console.log('Maximální počet pokusů o přehrání dosažen.');
            return;
        }

        let playButton = turnElement.querySelector('button[data-testid=""voice-play-turn-action-button""]');
        if (playButton) {
            playButton.click();
            console.log('Kliknuto na tlačítko přehrání.');
            setTimeout(function() {
                // Pro konzistenci můžete případně upravit selektor zde také
                let stopButton = turnElement.querySelector('button[aria-label=""Stop""]') || turnElement.querySelector('button[aria-label=""Zastavit""]');
                if (stopButton) {
                    console.log('Přehrávání úspěšně spuštěno.');
                } else {
                    console.log('Přehrávání se nepodařilo spustit, pokus ' + (attempt + 1));
                    attemptPlay(turnElement, attempt + 1);
                }
            }, retryDelay);
        } else {
            console.log('Tlačítko přehrání není dostupné. Čekám a zkouším znovu.');
            setTimeout(() => attemptPlay(turnElement, attempt + 1), retryDelay);
        }
    }

    // Hlavní interval pro získávání zpráv a detekci stavu přehrávání
    setInterval(function() {
        let conversationTurns = document.querySelectorAll('[data-testid^=""conversation-turn-""]');
        if (conversationTurns.length > 0) {
            let lastTurn = conversationTurns[conversationTurns.length - 1];
            let messageElement = lastTurn.querySelector('div.markdown.prose p');
            if (messageElement) {
                let message = messageElement.textContent;
                if (message !== lastMessage) {
                    lastMessage = message;
                    try {
                        window.chrome.webview.postMessage(message);
                        console.log('Zpráva byla úspěšně odeslána do C# aplikace');
                        if (!isFirstLoad) {
                            attemptPlay(lastTurn, 0);
                        }
                        isFirstLoad = false;
                    } catch (e) {
                        console.log('Došlo k chybě při odesílání zprávy: ' + e.message);
                    }
                }
            } else {
                console.log('Zpráva nebyla nalezena v posledním turnu');
            }
        } else {
            console.log('Nebyly nalezeny žádné prvky s datovým testID začínajícím na ""conversation-turn-""');
        }

        let playButton = document.querySelector('button[data-testid=""voice-play-turn-action-button""]');
                let stopButton = document.querySelector('button[aria-label=""Zastavit""]');
                if (stopButton && !isPlaying)
                {
                    isPlaying = true;
                    window.gptPlayingTimestamp = Date.now();
                    window.chrome.webview.postMessage('GPT_PLAYING');
                }
                else if (!stopButton && isPlaying)
                {
                   
                    checkStopLoop();
                }
            }, 1000);
            ";


                // Spuštění skriptu ve WebView2
                await webView.CoreWebView2.ExecuteScriptAsync(script);

                webView.CoreWebView2.WebMessageReceived += (sender, args) =>
                {
                    string message = args.WebMessageAsJson.Trim('\"');

                    if (message == "GPT_PLAYING")
                    {
                        ToggleGptSpeakingState(true);
                        gptPlayingStartTime = DateTime.Now;
                        PauseMicrophone();
                    }
                    else if (message == "GPT_STOPPED")
                    {
                        ToggleGptSpeakingState(false);
                        ResumeMicrophone();
                        gptPlayingStartTime = null;
                    }

                    else
                    {
                        message = System.Net.WebUtility.HtmlDecode(message);
                        message = message.Replace("\\n", "\n").Replace("\\\"", "\"").Replace("\\t", "\t");

                        if (isFirstMessage)
                        {
                            isFirstMessage = false;
                            return;
                        }

                        if (message != lastMessage)
                        {
                            lastMessage = message;
                          //  ShowFormattedText(message);
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo k chybě při inicializaci WebView2: {ex.Message}");
            }
        }

        private void webView_CoreWebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            string message = args.WebMessageAsJson.Trim('"');

            // Pokud GPT mluví, zobrazíme GIF
            if (message == "GPT_PLAYING")
            {
                ToggleGptSpeakingState(true);
            }
            // Pokud GPT přestal mluvit, skryjeme GIF
            else if (message == "GPT_STOPPED")
            {
                ToggleGptSpeakingState(false);
            }
        }



        private void PauseMicrophone()
        {
            if (!isMicrophonePaused)
            {
                isMicrophonePaused = true;
                lbl_activatedgpt.Text = "Mikrofon vypnut (Zpracovávám...)";
                azureRecognizer.StopContinuousRecognitionAsync();
            }
        }


        private async void InitializeWebViewDiscordOrion()
        {
            try
            {
                // Inicializace CoreWebView2
                await webViewGPT.EnsureCoreWebView2Async(null);

                // Načti přímo požadovanou URL do webViewGPT
                webViewGPT.CoreWebView2.Navigate("https://discord.com/channels/@me/772908174528217160");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo k chybě při inicializaci WebView2: " + ex.Message);
            }
        }

        private async void ShowFormattedText(string markdownText)
        {
            try
            {
                // Převod Markdown textu na HTML pomocí Markdig
                string htmlContent = Markdown.ToHtml(markdownText);

                // Vložení HTML obsahu do WebView2
                string htmlTemplate = $@"
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset='utf-8'>
                <style>
                    body {{ font-family: Arial, sans-serif; padding: 20px;background: #212121; color: #e2e2e2 }}
                    h2 {{ color: #4CAF50 }}
                </style>
            </head>
            <body>
                {htmlContent}
            </body>
            </html>";

                // Ujisti se, že CoreWebView2 je inicializováno
                if (webViewGPT.CoreWebView2 == null)
                {
                    await webViewGPT.EnsureCoreWebView2Async(null);
                }

                // Načtení HTML obsahu do WebView2
                webViewGPT.CoreWebView2.NavigateToString(htmlTemplate);
            }
            catch (Exception ex)
            {
                //   MessageBox.Show("Došlo k chybě při zobrazení textu: " + ex.Message);
            }
        }


        private void CheckDatabaseConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LifeManagerDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Nastavení zelené barvy indikátoru pro úspěšné připojení
                    statusIndicator.BackColor = Color.Green;
                }
                catch (Exception ex)
                {
                    // Nastavení červené barvy indikátoru pro neúspěšné připojení
                    statusIndicator.BackColor = Color.Red;
                }
            }
        }

        private void SetLabelsForDates()
        {
            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);
            DateTime dayAfterTomorrow = today.AddDays(2);

            // Nastavení textu pro labely s daty
            lbl_today.Text = $"Dnes: {today.ToShortDateString()}";
            lbl_tomorrow_date.Text = $"Zítra: {tomorrow.ToShortDateString()}";
            lbl_tomorrow_tomorrow_date.Text = $"Pozítří: {dayAfterTomorrow.ToShortDateString()}";
        }

        public class ActivityItem
        {
            public int Id { get; set; }
            public string DisplayText { get; set; }

            public override string ToString()
            {
                return DisplayText; // This ensures only the display text is shown in the ListBox
            }
        }

        private void LoadActivities()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LifeManagerDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Title, Description, ActivityDate FROM Activities";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                lb_activities_for_today.Items.Clear();
                lb_activities_for_tomorrow.Items.Clear();
                lb_activities_for_tomorrow_tomorrow.Items.Clear();

                DateTime today = DateTime.Today;
                DateTime tomorrow = today.AddDays(1);
                DateTime dayAfterTomorrow = today.AddDays(2);

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    string description = reader.GetString(2);
                    DateTime activityDate = reader.GetDateTime(3);
                    string formattedActivity = $"{title} - {description}";

                    var activityItem = new ActivityItem { Id = id, DisplayText = formattedActivity };

                    if (activityDate.Date == today)
                    {
                        lb_activities_for_today.Items.Add(activityItem);
                    }
                    else if (activityDate.Date == tomorrow)
                    {
                        lb_activities_for_tomorrow.Items.Add(activityItem);
                    }
                    else if (activityDate.Date == dayAfterTomorrow)
                    {
                        lb_activities_for_tomorrow_tomorrow.Items.Add(activityItem);
                    }
                }
                reader.Close();
            }
        }


        private void btn_addActivity_Click(object sender, EventArgs e)
        {
            ActivityForm addForm = new ActivityForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                string title = addForm.ActivityTitle;
                string description = addForm.ActivityDescription;
                DateTime activityDate = addForm.ActivityDate;

                string connectionString = ConfigurationManager.ConnectionStrings["LifeManagerDB"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Activities (Title, Description, ActivityDate) VALUES (@Title, @Description, @ActivityDate)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Description", description);
                        command.Parameters.AddWithValue("@ActivityDate", activityDate);
                        command.ExecuteNonQuery();
                    }
                }
                LoadActivities();
            }
        }

        private int GetSelectedActivityId(ListBox listBox)
        {
            if (listBox.SelectedItem != null && listBox.SelectedItem is ActivityItem selectedItem)
            {
                return selectedItem.Id;
            }
            throw new InvalidOperationException("No item selected or item does not have an ID.");
        }

        private void btn_editActivity_Click(object sender, EventArgs e)
        {
            ListBox selectedListBox = null;

            if (lb_activities_for_today.SelectedItem != null)
                selectedListBox = lb_activities_for_today;
            else if (lb_activities_for_tomorrow.SelectedItem != null)
                selectedListBox = lb_activities_for_tomorrow;
            else if (lb_activities_for_tomorrow_tomorrow.SelectedItem != null)
                selectedListBox = lb_activities_for_tomorrow_tomorrow;

            if (selectedListBox != null)
            {
                int selectedId = GetSelectedActivityId(selectedListBox);

                string connectionString = ConfigurationManager.ConnectionStrings["LifeManagerDB"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Title, Description, ActivityDate FROM Activities WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", selectedId);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            string title = reader.GetString(0);
                            string description = reader.GetString(1);
                            DateTime activityDate = reader.GetDateTime(2);
                            reader.Close();

                            ActivityForm editForm = new ActivityForm(title, description, activityDate);
                            if (editForm.ShowDialog() == DialogResult.OK)
                            {
                                title = editForm.ActivityTitle;
                                description = editForm.ActivityDescription;
                                activityDate = editForm.ActivityDate;

                                string updateQuery = "UPDATE Activities SET Title = @Title, Description = @Description, ActivityDate = @ActivityDate WHERE Id = @Id";
                                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@Title", title);
                                    updateCommand.Parameters.AddWithValue("@Description", description);
                                    updateCommand.Parameters.AddWithValue("@ActivityDate", activityDate);
                                    updateCommand.Parameters.AddWithValue("@Id", selectedId);
                                    updateCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
                LoadActivities();
            }
        }

        private void btn_removeActivity_Click(object sender, EventArgs e)
        {
            ListBox selectedListBox = null;

            if (lb_activities_for_today.SelectedItem != null)
                selectedListBox = lb_activities_for_today;
            else if (lb_activities_for_tomorrow.SelectedItem != null)
                selectedListBox = lb_activities_for_tomorrow;
            else if (lb_activities_for_tomorrow_tomorrow.SelectedItem != null)
                selectedListBox = lb_activities_for_tomorrow_tomorrow;

            if (selectedListBox != null)
            {
                int selectedId = GetSelectedActivityId(selectedListBox);

                string connectionString = ConfigurationManager.ConnectionStrings["LifeManagerDB"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM Activities WHERE Id = @Id";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@Id", selectedId);
                        DialogResult result = MessageBox.Show("Are you sure you want to delete this activity?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            deleteCommand.ExecuteNonQuery();
                            MessageBox.Show("Activity successfully deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadActivities();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an activity to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private async void btnSendToGpt_Click(object sender, EventArgs e)
        {
            try
            {
                string userText = richTextBoxMe.Text;

                // JavaScript pro odeslání zprávy do GPT
                string script = $@"
            (function() {{
                let inputField = document.getElementById('prompt-textarea');
                if (inputField) {{
                    inputField.textContent = `{userText}`;
                    inputField.dispatchEvent(new Event('input', {{ bubbles: true }}));
                    
                    setTimeout(function() {{
                        let sendButton = document.querySelector('button[aria-label=\""Odeslat\""]') || document.querySelector('button[data-testid=\""send-button\""]');
                        if (sendButton) {{
                            sendButton.click();
                        }}
                    }}, 1000);
                }}
            }})();
        ";

                // Spuštění skriptu ve WebView2
                await webView.CoreWebView2.ExecuteScriptAsync(script);

                // Vyčištění textového pole
                richTextBoxMe.Clear();

                // Vypnutí mikrofonu ihned po odeslání zprávy
                PauseMicrophone();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při odesílání zprávy: {ex.Message}");
            }
        }


        private void btnZdraviAFitness_Click(object sender, EventArgs e)
        {
            // Otevření nového formuláře pro zdraví a fitness
            HealthAndFitnessForm healthForm = new HealthAndFitnessForm();
            healthForm.Show();
        }

        private void mainContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void btnEnableMicrophoneManually_Click(object sender, EventArgs e)
        {
            // Zkontrolujte, jestli je mikrofon pauznutý
            if (isMicrophonePaused)
            {
                // Pokud je mikrofon pauznutý, obnovíme ho
                ResumeMicrophone(true);
            }
            else
            {
                // Pokud není mikrofon pauznutý, zahájíme nové rozpoznávání
                StartListening();
            }
        }

        // Funkce pro začátek poslechu mikrofonu
        private async void StartListening()
        {
            try
            {
                if (azureRecognizer != null)
                {
                    await azureRecognizer.StartContinuousRecognitionAsync();
                    lbl_activatedgpt.Text = "Mikrofon aktivován ručně"; // Ukaž stav mikrofonu
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při spuštění rozpoznávání: {ex.Message}");
            }
        }

        private bool isSpeakingState = false;

        private void DrawAnimationsPaintEvent(object sender, PaintEventArgs e)
        {
            if (isSpeakingState) // Pouze pokud isSpeaking == true
            {
                ImageAnimator.UpdateFrames(XDZT);
                e.Graphics.DrawImage(XDZT, new Point(633, 284)); // Vykresli GIF na dané pozici
            }
        }

        // Nová asynchronní metoda pro zajištění konzistentního zobrazení stavu
        private async Task ShowGptSpeakingStateAsync()
        {
            // Nastav okamžitě stav "Zpracovávám..."
            this.Invoke(new Action(() =>
            {
                lbl_activatedgpt.Text = "Mikrofon vypnut (Zpracovávám...)";
                this.Invalidate();
            }));

            // Počkej 500 ms
            await Task.Delay(500);

            // Pokud je stále GPT aktivní, nastav finální text
            if (isSpeakingState)
            {
                this.Invoke(new Action(() =>
                {
                    lbl_activatedgpt.Text = "Mikrofon vypnut (GPT mluví)";
                    this.Invalidate();
                }));
            }
        }

        // Upravená metoda ToggleGptSpeakingState, která využívá asynchronní metodu
        private void ToggleGptSpeakingState(bool isSpeaking)
        {
            isSpeakingState = isSpeaking;
            if (isSpeaking)
            {
                // Spusť asynchronní metodu – fire and forget
                _ = ShowGptSpeakingStateAsync();
            }
            else
            {
                // Nastav stav, když GPT není aktivní
                this.Invoke(new Action(() =>
                {
                    lbl_activatedgpt.Text = "Mikrofon vypnut (GPT neaktivní)";
                    this.Invalidate();
                }));
            }
        }

        private void LoadImages()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint, true);
            XDZT = Properties.Resources.XDZT;

            ImageAnimator.Animate(XDZT, this.OnFrameChangedHandler);

        }

        private void OnFrameChangedHandler(object? sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
