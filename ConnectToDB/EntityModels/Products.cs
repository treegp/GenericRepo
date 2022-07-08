using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConnectToDB.EntitiyModels
{
    [Table("Products")]
    public class Products
    {
        [Column(true,true,true)]
        public int Id { get; set; }
        [Column(true)]
        public string Title { get; set; }
        [Column(true)]
        public int Price { get; set; }
        [Column(false,true)]
        public int Tax { get; set; }
    }
}
