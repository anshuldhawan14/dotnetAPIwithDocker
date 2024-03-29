using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserWebAPI.Models
{
    [Table("User", Schema ="dbo")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("User_Id")]
        public int UserId { get; set; }

        [Column("User_Name")]
        public string UserName { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Phone_Number")]
        public string PhoneNumber { get; set; }
    }
}
