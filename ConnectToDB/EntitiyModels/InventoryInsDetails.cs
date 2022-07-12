using System;
namespace ConnectToDB.EntityModels
{
    [Table("dbo")]
    public class InventoryInsDetails
    {
        [Column(true,false,true)]
        public long InventoryInsHeaderId { get; set; }

        [Column(true,false,true)]
        public int ProductId { get; set; }

        [Column(true,false,false)]
        public decimal Amount { get; set; }

        [Column(true,false,false)]
        public decimal TotalPrice { get; set; }

    }
}
