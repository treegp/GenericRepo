using System;
using System.Windows.Forms;


namespace GenericRepo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            var products = new ConnectToDB.GenericRepository<ConnectToDB.EntitiyModels.Products>("Data Source=.;Initial Catalog=ShopDb;Integrated Security=SSPI");

            var i = products.Insert(new ConnectToDB.EntitiyModels.Products
            {
                Title = "tst",
                Price = 1000
            });

            if (i == 1)
                MessageBox.Show("Added");
            else
                MessageBox.Show("Somthing wrong");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var products = new ConnectToDB.GenericRepository<ConnectToDB.EntitiyModels.Products>("Data Source=.;Initial Catalog=ShopDb;Integrated Security=SSPI");

            var i = products.Delete(new ConnectToDB.EntitiyModels.Products
            {
                Id = 8
            });

            if (i == 1)
                MessageBox.Show("Deleted");
            else
                MessageBox.Show("Entity not found");
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            var products = new ConnectToDB.GenericRepository<ConnectToDB.EntitiyModels.Customers>("Data Source=.;Initial Catalog=ShopDb;Integrated Security=SSPI");

            var i = products.Find(8);
            
            if (i.FirstName != null)
                MessageBox.Show("Found");
            else
                MessageBox.Show("Entity not found");
        }
    }
}
