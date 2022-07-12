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
            var items = new ConnectToDB.GenericRepository<ConnectToDB.EntityModels.Users>("Data Source=.;Initial Catalog=ShopDb;Integrated Security=SSPI");

            var i = items.Insert(new ConnectToDB.EntityModels.Users
            {
                UserName="client"
                

            });

            if (i == 1)
                MessageBox.Show("Added");
            else
                MessageBox.Show("Somthing wrong");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var products = new ConnectToDB.GenericRepository<ConnectToDB.EntityModels.Products>("Data Source=.;Initial Catalog=ShopDb;Integrated Security=SSPI");

            var i = products.Delete(new ConnectToDB.EntityModels.Products
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
            var products = new ConnectToDB.GenericRepository<ConnectToDB.EntityModels.Products>("Data Source=.;Initial Catalog=ShopDb;Integrated Security=SSPI");

            var i = products.Find(8);

            if (i != null)
                MessageBox.Show("Found");
            else
                MessageBox.Show("Entity not found");
        }



        private void GetAllButton_Click(object sender, EventArgs e)
        {
            var products = new ConnectToDB.GenericRepository<ConnectToDB.EntityModels.Products>("Data Source=.;Initial Catalog=ShopDb;Integrated Security=SSPI");

            var i = products.GetAll();

            if (i != null)
                MessageBox.Show("Found");
            else
                MessageBox.Show("Entity not found");
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            var products = new ConnectToDB.GenericRepository<ConnectToDB.EntityModels.Products>("Data Source=.;Initial Catalog=ShopDb;Integrated Security=SSPI");

            var product = products.Find(2);

            product.Title = "Headphone";


            var i = products.Update(product);

            MessageBox.Show("Updated ");

        }
    }
}
