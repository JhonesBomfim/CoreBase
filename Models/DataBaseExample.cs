using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreBase.Models
{
    public class Manager
    {
        [Key]
        public int Id { get; set; }

        [StringLength(512)]
        public string? Usename { get; set; }

        [StringLength(56)]
        public string? Password { get; set; }

    }
}
