using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StructSureBackend.Models;

namespace StructSureBackend.Controllers
{
    [ApiController]
    [Route("api/project")]
    public class ProjectController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ProjectController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody] Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            return Ok(new { message = "Project created successfully.", projectId = project.ProjectId });
        }

        [HttpGet("{userId}")]
        public IActionResult GetProjects(int userId)
        {
            var projects = _context.Projects.Where(p => p.UserId == userId).ToList();
            return Ok(projects);
        }

        [HttpDelete("{projectId}")]
        public IActionResult DeleteProject(int projectId)
        {
            var project = _context.Projects.Find(projectId);
            if (project == null)
            {
                return NotFound(new { message = "Project not found." });
            }

            _context.Projects.Remove(project);
            _context.SaveChanges();
            return Ok(new { message = "Project deleted successfully." });
        }
    }

    [ApiController]
    [Route("api/puncture")]
    public class PunctureController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PunctureController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddPuncture([FromBody] Puncture puncture)
        {
            _context.Punctures.Add(puncture);
            _context.SaveChanges();
            return Ok(new { message = "Puncture data added successfully.", punctureId = puncture.PunctureId });
        }

        [HttpGet("project/{projectId}")]
        public IActionResult GetPunctures(int projectId)
        {
            var punctures = _context.Punctures.Where(p => p.ProjectId == projectId).ToList();
            return Ok(punctures);
        }
    }
}
