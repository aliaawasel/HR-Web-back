using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HR_System.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public int GroupID { get; set; }


        [ForeignKey("GroupID")]

        public virtual Group Group { get; set; }
    }
}
