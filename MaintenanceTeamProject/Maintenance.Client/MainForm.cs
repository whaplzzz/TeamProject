using Maintenance.Client.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maintenance.Client
{
    public partial class MainForm : Form
    {

        private App app;

        public MainForm()
        {
            InitializeComponent();

            app = new App(this);

            cmbReports.SelectedIndex = 0;
        }


       // Отображение выбранного отчета
        private void cmbReports_SelectedIndexChanged(object sender, EventArgs e) {

            if ((cmbReports.SelectedItem as string).Equals("Дневной отчет"))
                txbReport.Text = app.Stub.DailyReport();

            else if ((cmbReports.SelectedItem as string).Equals("Рабочий состав"))
                txbReport.Text = app.Stub.WorkersReport();
        }

        // отправка выбранного отчета
        private void btnSend_Click(object sender, EventArgs e) {

            if ((cmbReports.SelectedItem as string).Equals("Дневной отчет"))
                app.SendDailyRequest();

            else if ((cmbReports.SelectedItem as string).Equals("Рабочий состав")) 
                app.SendStuffRequest();
        }

        // О программе
        private void btnAbout_Click(object sender, EventArgs e) =>
            MessageBox.Show("И так сойдёт!", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);

        // Выход
        private void btnExit_Click(object sender, EventArgs e) =>
            Application.Exit();

    }
}
