using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Models
{
    [Table("Users")]
    public class User{
        [Column("id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("Password")]
        public string Password { get; set; }


    }
}

