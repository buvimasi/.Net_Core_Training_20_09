using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Training_Task.ModelEntities;

namespace Training_Task.Controllers
{
    public class EmployeeViewControllers : Controller
    {
        private readonly ModelDbContext _dbContext;

        public EmployeeViewControllers(ModelDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public IActionResult Index()
        {
            var employees = _dbContext.Employees.Include(s => s.SkillMaps).ThenInclude(s => s.Skills).Select(x => new EmployeeModel
            {
                EmployeeID = x.EmployeeID,
                Email = x.Email,
                Name = x.Name,
                Manager = x.Manager,
                Wfm_Manager = x.Wfm_Manager,
                Skills = x.SkillMaps.Select(y => y.Skills.Name).ToList()
            }).ToList();

            return View(employees);
        }
    }
}
