using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFJobSearchService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class JobSearchService : IJobSearchService
    {
        public List<RoleDTO> GetAllJobRoles()
        {
            try
            {

                using (var dbContext = new JobDBContext())
                {
                    List<RoleDTO> rolesList = new List<RoleDTO>();

                    RoleDTO dto;

                    var roles = dbContext.JobRoles.ToList(); 

                    foreach(var obj in roles)
                    {
                        dto = new RoleDTO();
                        dto.RoleID = obj.RoleID;
                        dto.RoleName = obj.RoleName;
                        rolesList.Add(dto);
                    }

                    return rolesList;
                }
                   
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public List<JobDTO> GetAllJobs()
        {
            try
            {
                using (var dbContext = new JobDBContext())
                {
                    List<JobDTO> JobDTOList = new List<JobDTO>();
                    JobDTO dto;

                    var AllJobs = dbContext.Jobs.ToList();
                    var roles = dbContext.JobRoles.ToList(); 

                    foreach (var obj in AllJobs)
                    {
                        dto = new JobDTO();
                        dto.ID = obj.ID;
                        dto.NumberOfVacancies = obj.NumberOfVacancies;
                        dto.PrimarySkill = obj.PrimarySkill;
                        dto.RoleId = obj.RoleId;
                        dto.CompanyLocation = obj.CompanyLocation;
                        dto.CompanyName = obj.CompanyName;
                        dto.RoleName = roles.Where(p => p.RoleID == obj.RoleId).Select( s => s.RoleName).Single();
                        JobDTOList.Add(dto);
                    }

                    return JobDTOList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<JobDTO> GetJobsByRole(int roleId)
        {
            try
            {
                using (var dbContext = new JobDBContext())
                {
                    List<JobDTO> ListJobs = new List<JobDTO>();
                    JobDTO dto = new JobDTO();

                    var jobByRoles = dbContext.Jobs.Where(a => a.RoleId == roleId)
                                            .ToList();


                    var roles = dbContext.JobRoles.ToList();

                    foreach (var obj in jobByRoles)
                    {
                        dto = new JobDTO();
                        dto.ID = obj.ID;
                        dto.NumberOfVacancies = obj.NumberOfVacancies;
                        dto.PrimarySkill = obj.PrimarySkill;
                        dto.RoleId = obj.RoleId;
                        dto.CompanyLocation = obj.CompanyLocation;
                        dto.CompanyName = obj.CompanyName;
                        dto.RoleName = roles.Where(p => p.RoleID == obj.RoleId).Select(s => s.RoleName).Single();
                        ListJobs.Add(dto);
                    }

                    return ListJobs;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
