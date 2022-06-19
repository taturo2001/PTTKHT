using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ProjectWFA.DAO;
using ProjectWFA.DTO;

namespace ProjectWFA
{
    public partial class Admin : Form
    {

        BindingSource foodList = new BindingSource();

        BindingSource accountList = new BindingSource();

        BindingSource MenuList = new BindingSource();

        BindingSource TableList = new BindingSource();

        public AccountDTO loginAccount;

        public Admin()
        {
            InitializeComponent();
            Load();
        }
        private void dtpkFromDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpkToDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txbFoodName_TextChanged(object sender, EventArgs e)
        {

        }
        #region Methods

        List<FoodDTO> SearchFoodByName(string name)
        {
           List<FoodDTO> foodList = FoodDAO.Instance.SearchFoodByName(name);

            return foodList;
        }

        void Load()
        {
            dtgvFood.DataSource = foodList;
            dtgvAccount.DataSource = accountList;
            dtgvCategory.DataSource = MenuList;
            dtgvTable.DataSource = TableList;

            LoadDateTimePickerBill();
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
            LoadListFood();
            LoadAccount();
            LoadMenu();
            LoadMenuTable();
            LoadCategoryIntoComboBox(cbFoodCategory);
            AddFoodBinding();
            AddAccountBinding();
            AddMenuBinding();
            AddMenuTable();
        }

        void AddMenuTable()
        {
            txbTableID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "ID"));
            txbTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Table_name"));
            txbTableStatus.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Status"));
        }
        void LoadMenuTable()
        {
            TableList.DataSource = TableDAO.Instance.GetListTable();
        }

        void AddMenuBinding()
        {
            txbCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "id_FoodMenu"));
            txbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "FoodMenu_name"));
        }
        void LoadMenu()
        {
            MenuList.DataSource = CategoryDAO.Instance.GetListMenu();
        }
        void AddAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nmType.DataBindings.Add(new Binding("value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));

        }
        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
           dtgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }

        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }

        void AddFoodBinding()
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("value", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }

        void LoadCategoryIntoComboBox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }

        void AddAccount(string userName, string displayName, int type)
        {
            if(AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại!");
            }

            LoadAccount();
        }

        void EditAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại!");
            }

            LoadAccount();
        }
        void DeleteAccount(string userName)
        {
            if(loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Không thể xóa tài khoản đang dùng!");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Xóa nhật tài khoản thất bại!");
            }

            LoadAccount();
        }
        void ResetPassWord(string userName)
        {
            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Cập nhật mật khẩu thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật mật khẩu thất bại!");
            }
        }
      
        #endregion

        #region Events
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood1
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }
        #endregion

        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void txbFoodID_textChange(object sender, EventArgs e)
        {
            try
            {
                if (dtgvFood.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                    CategoryDTO category = CategoryDAO.Instance.GetCategoryByID(id);

                    cbFoodCategory.SelectedItem = category;

                    int index = -1;
                    int i = 0;

                    foreach (CategoryDTO row in cbFoodCategory.Items)
                    {
                        if (row.ID == category.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cbFoodCategory.SelectedIndex = index;
                }
            }
            catch { }
        }
        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)nmType.Value;

            AddAccount(userName, displayName, type);
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            DeleteAccount(userName);
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)nmType.Value;

            EditAccount(userName, displayName, type);
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            ResetPassWord(userName);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as CategoryDTO).ID;
            float price = (float)nmFoodPrice.Value;

            if(FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công!");
                LoadListFood();
            }
            else
            {
                MessageBox.Show("Thêm món không thành công!");
            }
        }
        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công!");
                LoadListFood();
            }
            else
            {
                MessageBox.Show("Xóa món không thành công!");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as CategoryDTO).ID;
            float price = (float)nmFoodPrice.Value;
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Cập nhật món thành công!");
                LoadListFood();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công!");
            }
        }

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadMenu();
        }

        private void btnShowTable_Click(object sender, EventArgs e)
        {
            LoadMenuTable();
        }

        private void btnSearchFood_Click(object sender, EventArgs e)
        {
           foodList.DataSource = SearchFoodByName(txbSearchFoodName.Text);
        }

        // Admin Table:

        void AddTable(string name)
        {
            if(TableDAO.Instance.InsertTable(name))
            {
                MessageBox.Show("Thêm bàn thành công!");
            }
            else
            {
                MessageBox.Show("Thêm bàn thất bại!");
            }
            LoadMenuTable();
        }

        void UpdateTable(string name, int id)
        {
            if (TableDAO.Instance.UpdateTable(name, id))
            {
                MessageBox.Show("Cập nhật bàn thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật bàn không thành công!");
            }
            LoadMenuTable();
        }

        void DeleteTable(int id)
        {
            if (TableDAO.Instance.DeleteTable(id))
            {
                MessageBox.Show("Xóa bàn thành công!");           
            }
            else
            {
                MessageBox.Show("Xóa bàn không thành công!");
            }
            LoadMenuTable();
        }
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string name = txbTableName.Text;
            AddTable(name);
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            string name = txbTableName.Text;
            int id = Convert.ToInt32(txbTableID.Text);
            UpdateTable(name, id);
        }
        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbTableID.Text);
            DeleteTable(id);
        }
        // end

        // Admin Category:
        void AddCategory(string name)
        {
            if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm danh mục thành công!");
            }
            else
            {
                MessageBox.Show("Thêm danh mục thất bại!");
            }
            LoadMenu();
        }

        void UpdateCategory(string name, int id)
        {
            if (CategoryDAO.Instance.UpdateCategory(name, id))
            {
                MessageBox.Show("Cập nhật danh mục thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật danh mục không thành công!");
            }
            LoadMenu(); 
        }

        void DeleteCategory(int id)
        {
            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xóa danh mục thành công!");
            }
            else
            {
                MessageBox.Show("Xóa danh mục không thành công!");
            }
            LoadMenu();
        }

        private void btnaAddCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;
            AddCategory(name);
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;
            int id = Convert.ToInt32(txbCategoryID.Text);
            UpdateCategory(name, id);
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbCategoryID.Text);
            DeleteCategory(id);
        }

        private void dtgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // end
    }
}
