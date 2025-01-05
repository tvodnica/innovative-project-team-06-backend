using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace StructSureBackend.Models
{
    public class Project
    {
        public Project()
        {
             
        }
        public Project(string title, string description, int userId, User user)
        {
            this.Title = title;
            this.Description = description;
            this.UserId = userId;
            this.User = user;
            this.Punctures = new List<Puncture>();
            this.Finished = false;
        }

        [Key]
        public int ProjectId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Puncture> Punctures { get; set; }
        public bool Finished { get; set; }
    }

    public class ProjectDTO
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
