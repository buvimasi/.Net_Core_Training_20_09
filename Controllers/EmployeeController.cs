using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Training_Task.ModelEntities;

namespace Training_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ModelDbContext _dbContext;

        public EmployeeController(ModelDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet,Route("GetEmployee")]
        public ActionResult GetEmployee()
        {
            var employees = _dbContext.Employees.Include(s => s.SkillMaps).ThenInclude(s => s.Skills).ToList();

            return new OkObjectResult(employees);
        }

        [HttpGet,Route("GetSkills")]
        public ActionResult GetSkills()
        {
            var skills = _dbContext.Skills.Include(s => s.SkillMaps).ThenInclude(s => s.Employees).ToList();

            return new OkObjectResult(skills);
        }

    }
}
