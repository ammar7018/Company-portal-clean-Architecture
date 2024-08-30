using Company.Domain.Entities;
using Company.Infrastructure.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }

        public IActionResult Index()
        {
            var Services = _unitOfWork.Service.GetAll();
            return View(Services);
        }
        public IActionResult Upsert(int? id)
        {

            if (id == null || id == 0)
            {
                //create
                return View(new Service());
            }
            else
            {
                //update
                Service ServiceObj = _unitOfWork.Service.Get(u => u.Id == id);
                return View(ServiceObj);
            }

        }
        [HttpPost]
        public IActionResult Upsert(Service ServiceObj)
        {
            if (ModelState.IsValid)
            {

                if (ServiceObj.Id == 0)
                {
                    _unitOfWork.Service.Add(ServiceObj);
                }
                else
                {
                    _unitOfWork.Service.Update(ServiceObj);
                }

                _unitOfWork.Save();
                TempData["success"] = "Service created successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {

                return View(ServiceObj);
            }
        }

        [HttpPost]
        public IActionResult Create(Service obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Service.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Service Created Successfully";

                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        #region All API

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Service> objServiceList = _unitOfWork.Service.GetAll().ToList();

            return Json(new { data = objServiceList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Service.Get(u => u.Id == id);

            if (obj!=null)
            {
                _unitOfWork.Service.Remove(obj);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Delete Successful" });
            }

            return Json(new { success = false, message = "Error while deleting" });

        }

        #endregion

    }


}
