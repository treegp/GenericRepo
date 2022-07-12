using System;
namespace ConnectToDB.EntityModels
{
    [Table("dbo")]
    public class InventoryOutsType
    {
        [Column(true,true,true)]
        public int Id { get; set; }

        [Column(true,false,false)]
        public string Title { get; set; }

        [Column(false,false,false)]
        public string Description { get; set; }

        [Column(true,false,false)]
        public bool IsDeleted { get; set; }

        [Column(false,false,false)]
        public Nullable<DateTime> DeleteDate { get; set; }

        [Column(false,false,false)]
        public Nullable<int> DeleteByUserId { get; set; }

    }
}
