using System.ComponentModel.DataAnnotations;

namespace StructSureBackend.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Puncture> Punctures { get; set; }
    }
}
