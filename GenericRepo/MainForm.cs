using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            
        }
    }
}
