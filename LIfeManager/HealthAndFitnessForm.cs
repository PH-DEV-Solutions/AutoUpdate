using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LifeManager;
using Microsoft.Web.WebView2.Core;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System.Speech.Recognition;
using Markdig;

namespace LIfeManager
{
    public partial class HealthAndFitnessForm : Form
    {
        public HealthAndFitnessForm()
        {
            InitializeComponent();
            LoadHealthAndFitnessData();
        }


        private void LoadHealthAndFitnessData()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["LifeManagerDB"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM HealthAndFitness";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);
                    dgvHealthData.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo k chybě při načítání dat o zdraví a fitness: " + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnUploadData_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["LifeManagerDB"].ConnectionString;
                string inputData = tbDataInput.Text;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO HealthAndFitness (DataEntry, EntryDate) VALUES (@DataEntry, @EntryDate)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DataEntry", inputData);
                        command.Parameters.AddWithValue("@EntryDate", DateTime.Now);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data byla úspěšně nahrána do databáze.", "Úspěch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHealthAndFitnessData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo k chybě při nahrávání dat: " + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
