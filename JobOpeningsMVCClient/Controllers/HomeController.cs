using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace JobOpeningsMVCClient.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            using (JobSearchService.JobSearchServiceClient client = new JobSearchService.JobSearchServiceClient())
            {
                var results = client.GetAllJobRoles();

                ViewBag.VBRolesList = new SelectList(results, "RoleID", "RoleName");

                return View();
            }
        }

        public PartialViewResult AllOpenings(int? page)
        {
            try
            {
                int pageSize = 3;
                int pageNumber = (page ?? 1);

                using (JobSearchService.JobSearchServiceClient client = new JobSearchService.JobSearchServiceClient())
                {
                    var results = client.GetAllJobs();

                    return PartialView("_AllOpenings", results.ToPagedList(pageNumber, pageSize));

                }
            }
            catch
            {
                throw;
            }
        }


        public PartialViewResult GetOpeningsByRole(int roleId)
        {
            try
            {
                using (JobSearchService.JobSearchServiceClient client = new JobSearchService.JobSearchServiceClient())
                {
                    var results = client.GetJobsByRole(roleId);

                    return PartialView("_OpeningsByRoles", results);
                }
            }
            catch 
            {
                throw;
            }
        }
    }
}