using System;
namespace ConnectToDB.EntityModels
{
    [Table("dbo")]
    public class InventoryOutsHeaders
    {
        [Column(true,true,true)]
        public long Id { get; set; }

        [Column(true,false,false)]
        public int InventoryId { get; set; }

        [Column(true,false,false)]
        public int TypeId { get; set; }

        [Column(true,false,false)]
        public string Title { get; set; }

        [Column(false,false,false)]
        public string Description { get; set; }

        [Column(true,false,false)]
        public DateTime Date { get; set; }

        [Column(true,false,false)]
        public bool Accepted { get; set; }

        [Column(false,false,false)]
        public Nullable<DateTime> AcceptDate { get; set; }

        [Column(false,false,false)]
        public Nullable<int> AcceptedByUserId { get; set; }

        [Column(true,false,false)]
        public bool IsDeleted { get; set; }

        [Column(false,false,false)]
        public Nullable<DateTime> DeleteDate { get; set; }

        [Column(false,false,false)]
        public Nullable<int> DeleteByUserId { get; set; }

    }
}
