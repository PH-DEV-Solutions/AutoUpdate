using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIfeManager
{
    public partial class ActivityForm : Form
    {
        // Veřejné vlastnosti v ActivityForm pro získání nebo nastavení dat
        public string ActivityTitle { get; set; }
        public string ActivityDescription { get; set; }
        public DateTime ActivityDate { get; set; }


        public ActivityForm()
        {
            InitializeComponent();
        }

        // Konstruktor pro předání existujících dat při editaci
        public ActivityForm(string title, string description, DateTime date) : this()
        {
            ActivityTitle = title;
            ActivityDescription = description;
            ActivityDate = date;

            // Přednastavení hodnot ve formuláři
            tb_title.Text = title;
            tb_description.Text = description;
            dtpActivityDate.Value = date;
        }

        private void ActivityForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Nastavení vlastností podle hodnot, které uživatel zadal
            ActivityTitle = tb_title.Text;
            ActivityDescription = tb_description.Text;
            ActivityDate = dtpActivityDate.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
