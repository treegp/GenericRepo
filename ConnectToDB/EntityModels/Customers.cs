using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToDB.EntitiyModels
{
    [Table("Customers")]
    public class Customers
    {
        [Column(true,true,true)]
        public int Id { get; set; }
        [Column(true)]
        public string FirstName { get; set; }
        [Column(true)]
        public string LastName { get; set; }
        [Column()]
        public string Email { get; set; }
        [Column()]
        public string Telephone { get; set; }
        [Column()]
        public string Mobile { get; set; }
        [Column()]
        public string Address { get; set; }
    }
}
