using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWFA.DAO;
using ProjectWFA.DTO;

namespace ProjectWFA
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text;
            string password = txbPassWord.Text;
            if (Loginn(username, password))
            {
                AccountDTO loginAccount = AccountDAO.Instance.GetAccountByUserName(username);
                QuanLiBan ftm = new QuanLiBan(loginAccount);
                this.Hide();
                ftm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Wrong username or password!", "Attention: ");
            }
        }

        bool Loginn(string username, string password)
        {
            return AccountDAO.Instance.Login(username,password);
        }

        private void txbUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Do you want to exit?","Attention: ", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}