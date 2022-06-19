using ProjectWFA.DAO;
using ProjectWFA.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace ProjectWFA
{
    public partial class QuanLiBan : Form
    {
        private AccountDTO loginAccount;
        private object txbPassWord;

        public AccountDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; changeAccount(loginAccount.Type); }
        }

        public QuanLiBan(AccountDTO acc)
        {
            InitializeComponent();

            this.LoginAccount = acc;

            LoadTable();
            LoadCategory();
            LoadComboBoxTable(cbSwitchTable);
        }
        #region Method

        void changeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }

        void LoadTable()
        {
            flpTable.Controls.Clear();

            List<TableDTO> tablelist = TableDAO.Instance.LoadTableList();

            foreach (TableDTO table in tablelist)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };

                btn.Text = table.Name + Environment.NewLine + table.Status;
                btn.Click += Btn_Click;
                btn.Tag = table;

                switch (table.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.DarkSeaGreen;
                        break;
                    default: btn.BackColor = Color.Red;
                        break;
                }

                flpTable.Controls.Add(btn);
            }
        }
        void ShowBill(int id)
        {
            lsvBill.Items.Clear();

            List<Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);

            float totalPrice = 0;

            foreach (Menu billInfo in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(billInfo.FoodName.ToString());
                lsvItem.SubItems.Add(billInfo.Count.ToString());
                lsvItem.SubItems.Add(billInfo.Price.ToString());
                lsvItem.SubItems.Add(billInfo.TotalPrice.ToString());
                totalPrice += billInfo.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }

            CultureInfo culture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = culture;
            txbTotalPrice.Text = totalPrice.ToString("c", culture);

            

        }

        void LoadCategory()
        {
            List<CategoryDTO> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";
        }

        void LoadFoodListByCategoryID(int id)
        {
            List<FoodDTO> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "Name";   
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            TableDTO table = lsvBill.Tag as TableDTO;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableD(table.ID);
            int foodID = (cbFood.SelectedItem as FoodDTO).ID;
            int count = (int)nmFoodCount.Value;

            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
            }

            ShowBill(table.ID);

            LoadTable();
        }

        void LoadComboBoxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }

        #endregion

        #region Events
        private void Btn_Click(object? sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as TableDTO).ID;

            lsvBill.Tag = (sender as Button).Tag;

            ShowBill(tableID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableDTO table = lsvBill.Tag as TableDTO;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableD(table.ID);
            int discount = (int)nmDiscount.Value;

            double totalPrice = double.Parse(txbTotalPrice.Text, NumberStyles.Currency, new CultureInfo("vi-VN"));
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;

            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có muốn thanh toán hóa đơn cho bàn {0}\nTổng tiền - (Tổng tiền / 100) x Giảm giá = {1} - ({1} / 100) x {2} = {3}", table.Name, totalPrice, discount, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, discount, (float)finalTotalPrice);
                    ShowBill(table.ID);

                    LoadTable();
                }
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaiKhoanCaNhan a = new TaiKhoanCaNhan(LoginAccount);

            a.UpdateAccount += f_UpdateAccount ;

            a.ShowDialog();
        }

        private void f_UpdateAccount(object? sender, AccountEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin a = new Admin();

            a.loginAccount = LoginAccount;

            a.InsertFood += f_InsertFood;
            a.DeleteFood1 += f_DeleteFood;
            a.UpdateFood += f_UpdateFood;

            a.ShowDialog();
        }

        private void f_UpdateFood(object? sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as CategoryDTO).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as TableDTO).ID);
        }

        private void f_DeleteFood(object? sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as CategoryDTO).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as TableDTO).ID);
            LoadTable();
        }

        private void f_InsertFood(object? sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as CategoryDTO).ID);
            if(lsvBill.Tag != null)
               ShowBill((lsvBill.Tag as TableDTO).ID); throw new NotImplementedException();
        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            int id1 = (lsvBill.Tag as TableDTO).ID;

            int id2 = (cbSwitchTable.SelectedItem as TableDTO).ID;

            if (MessageBox.Show(String.Format("Bạn có muốn chuyển {0} qua {1} không?", (lsvBill.Tag as TableDTO).Name, (cbSwitchTable.SelectedItem as TableDTO).Name), "Thông báo!", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(id1, id2);

                LoadTable();
            }         
        }

        #endregion

        private void cbCategory_Select(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            CategoryDTO selected = cb.SelectedItem as CategoryDTO;
            id = selected.ID;

            LoadFoodListByCategoryID(id);
        }

        private void lsvBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
