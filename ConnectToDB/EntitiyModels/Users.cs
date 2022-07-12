using System;
namespace ConnectToDB.EntityModels
{
    [Table("dbo")]
    public class Users
    {
        [Column(true,true,true)]
        public int Id { get; set; }

        [Column(true,false,false)]
        public string UserName { get; set; }

        [Column(true,false,false)]
        public bool IsDeleted { get; set; }

        [Column(false,false,false)]
        public Nullable<DateTime> DeleteDate { get; set; }

        [Column(false,false,false)]
        public Nullable<int> DeleteByUserId { get; set; }

    }
}
