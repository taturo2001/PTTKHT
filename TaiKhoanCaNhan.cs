using ProjectWFA.DAO;
using ProjectWFA.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectWFA
{
    public partial class TaiKhoanCaNhan : Form
    {
        private AccountDTO loginAccount;

        public AccountDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; changeAccount(loginAccount); }
        }

        public TaiKhoanCaNhan(AccountDTO acc)
        {
            InitializeComponent();

            LoginAccount = acc;
        }

        void changeAccount(AccountDTO acc)
        {
            txbUserName.Text = LoginAccount.UserName;
            txbDisplayName.Text = LoginAccount.DisplayName;

        }

        void UpdateAccountInfo()
        {
            string displayName = txbDisplayName.Text;
            string password = txbPassWord.Text;
            string newpass = txbNewPassWord.Text;
            string reenterPass = txbReEnterPass.Text;
            string userName = txbUserName.Text;

            if (!newpass.Equals(reenterPass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu!");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(userName, displayName, password, newpass))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    if(updateAccount != null)
                    {
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập lại mật khẩu!");
                }
            }
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
           add { updateAccount += value; }
           remove { updateAccount -= value; }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }
        #region LinhTinh
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        private void txbNewPassWord_TextChanged(object sender, EventArgs e)
        {

        }

    }

    public class AccountEvent:EventArgs
    {
        private AccountDTO acc;

        public AccountDTO Acc { get => acc; set => acc = value; }

        public AccountEvent(AccountDTO acc)
        {
            this.Acc = acc;
        }
    }
}
