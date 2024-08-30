using Company.Domain.Entities;
using Company.Domain.ModelVM;
using Company.Domain.Utilities;
using Company.Infrastructure.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace Company.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    [Area("Admin")]

    public class ProjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProjectController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var Projects = _unitOfWork.Project.GetAll(includeProp: "applicationUsers,services");
            return View(Projects);
        }
        public IActionResult Upsert(int? id)
        {
            ProjectVM vm;
            if (id == null || id == 0)
            {
                vm = new()
                {

                    ServiceList = _unitOfWork.Service.GetAll().Select(x => new SelectListItem
                    {
                       Value = x.Id.ToString(),
                        Text = x.Name
                    }),
                    project = new Project()

                };
            }
            else
            {

                var selectedServiceIds = _unitOfWork.ProjectService
    .GetAll(x => x.ProjectId == id)
    .Select(x => x.ServiceId)
    .ToList();

                vm = new()
                {
                    ServiceList = _unitOfWork.Service.GetAll().Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name,
                        Selected = selectedServiceIds.Contains(x.Id)
                    }),
                    servicesID= selectedServiceIds,
                    project = _unitOfWork.Project.Get(x => x.Id == id)
                };
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Upsert(ProjectVM projectVM, IFormFile? file)
        {
            //obj.product.Category = _unitOfWork.Category.Get(x => obj.product.CategoryId == x.ID); 

            if (ModelState.IsValid)
            {

/*              string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null)
                {

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"image\product");

                    if (!string.IsNullOrEmpty(productVM.project.imageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, productVM.product.imageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }

                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productVM.product.imageUrl = @"\image\product\" + fileName;

                }*/

                if (projectVM.project.Id == 0)
                {
                    projectVM.project.CreationDate = DateOnly.FromDateTime(DateTime.Now);
                    projectVM.project.status = SD.ProjectNotAssigned;


                    _unitOfWork.Project.Add(projectVM.project);
                    _unitOfWork.Save();

                    foreach (var item in projectVM.servicesID) {
                        ProjectService obj = new()
                        {
                            ProjectId = projectVM.project.Id,
                            ServiceId = item
                        };
                        _unitOfWork.ProjectService.Add(obj);
                     }
                }
                else
                {
                    var allServiceID = _unitOfWork.ProjectService.GetAll(u => u.ProjectId == projectVM.project.Id);
                    _unitOfWork.ProjectService.RemoveRange(allServiceID);

                    foreach (var item in projectVM.servicesID)
                    {
                        ProjectService obj = new()
                        {
                            ProjectId = projectVM.project.Id,
                            ServiceId = item
                        };
                        _unitOfWork.ProjectService.Add(obj);
                    }

                    _unitOfWork.Project.Update(projectVM.project);
                }


                _unitOfWork.Save();
                TempData["success"] = "Project Created Successfully";

                return RedirectToAction("Index");
            }
            else
            {
                projectVM.ServiceList = _unitOfWork.Service.GetAll().Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
                return View(projectVM);
            }

        }



        #region All API

        [HttpGet]
        public IActionResult GetAll(string status)
        {
            if (status != "All"&&status!=null)
            {
                var objProjectList = _unitOfWork.Project.GetAll(u => u.status == status, includeProp: "applicationUsers,services")
                    .Select(p => new
                    {
                        p.Id,
                        p.Name,
                        p.Description,
                        p.Cost,
                        p.CreationDate,
                        p.EndDate,
                        p.status,
                        Services = p.services.Select(s => s.Name),
                        ProjectWorkers = p.applicationUsers.Select(u => u.Name)
                    }).ToList();
                return Json(new { data = objProjectList });
            }
            else
            {
                var objProjectList = _unitOfWork.Project.GetAll(includeProp: "applicationUsers,services")
                    .Select(p => new
                    {
                        p.Id,
                        p.Name,
                        p.Description,
                        p.Cost,
                        p.CreationDate,
                        p.EndDate,
                        p.status,
                        Services = p.services.Select(s => s.Name),
                        ProjectWorkers = p.applicationUsers.Select(u => u.Name)
                    }).ToList();
                return Json(new { data = objProjectList });

            }
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Project.Get(u => u.Id == id);

            if (obj != null)
            {
                _unitOfWork.Project.Remove(obj);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Delete Successful" });
            }

            return Json(new { success = false, message = "Error while deleting" });

        }

        #endregion

    }
}
