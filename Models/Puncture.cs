using System.ComponentModel.DataAnnotations;

namespace StructSureBackend.Models
{
    public class Puncture
    {
        [Key]
        public int PunctureId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public string Images { get; set; } // Base64 strings separated by commas
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        [Required]
        public string Date { get; set; }
    }
}
