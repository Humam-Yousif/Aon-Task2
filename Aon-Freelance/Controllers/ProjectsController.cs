using Aon_Freelance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aon_Freelance.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private static List<Project> Projects = new List<Project>();

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            return Ok(Projects);
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody] Project project)
        {
            Projects.Add(project);
            return CreatedAtAction(nameof(GetProject), new { Id = project.Id }, Projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetProject(int id)
        {
            Project project = Projects.FirstOrDefault(project => project.Id == id);
            if (project == null)
            {
                return NotFound("The requested data is not found !");
            }
            return Ok(project);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id) 
        {
            Project project = Projects.FirstOrDefault(project => project.Id == id);
            if (project == null)
            {
                return NotFound("The requested data is not found !");
            }
            Projects.Remove(project);
            return Ok("Project is deleted");
        }
    }
}
