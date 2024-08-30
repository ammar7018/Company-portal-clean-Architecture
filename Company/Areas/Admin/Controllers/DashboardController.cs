using Company.Domain.Entities;
using Company.Domain.ModelVM;
using Company.Domain.Utilities;
using Company.Infrastructure.Repository;
using Company.Infrastructure.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using System.Text.Json;

namespace Company.Web.Areas.Admin.Controllers
{
	[Authorize(Roles =SD.Role_Admin)]
    [Area("Admin")]
    public class DashboardController : Controller
    {
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public DashboardController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = db;
			_webHostEnvironment = webHostEnvironment;
		}


		public IActionResult Index()
        {
			DashboardVM VM;

			IEnumerable<Project> tmp = _unitOfWork.Project.GetAll(includeProp: "applicationUsers");

			VM = new()
			{
				ProjectsList =tmp.ToList(),
				count_freelancer = 0,
				count_NotAssigned = tmp.Where(x=>(x.status==SD.ProjectNotAssigned|| x.status == null)).Count(),
				count_Inprocess=tmp.Where(x=>x.status==SD.ProjectInProcess).Count()
			};
			
			return View(VM);
        }

	}

}

