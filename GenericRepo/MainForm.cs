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

            products.Insert(new ConnectToDB.EntitiyModels.Products
            {
                Title = "tst",
                Price = 1000
            });

            MessageBox.Show("Added");
        }
    }
}
