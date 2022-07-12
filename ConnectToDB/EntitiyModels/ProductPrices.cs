using System;
namespace ConnectToDB.EntityModels
{
    [Table("dbo")]
    public class ProductPrices
    {
        [Column(true,true,true)]
        public int Id { get; set; }

        [Column(true,false,false)]
        public int ProductId { get; set; }

        [Column(true,false,false)]
        public DateTime Date { get; set; }

        [Column(true,false,false)]
        public int Price { get; set; }

    }
}
