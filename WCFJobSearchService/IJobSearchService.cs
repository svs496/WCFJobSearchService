using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFJobSearchService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IJobSearchService
    {

        [OperationContract]
        List<JobDTO> GetAllJobs();

        [OperationContract]
        List<JobDTO> GetJobsByRole(int roleId);

        [OperationContract]
        List<RoleDTO> GetAllJobRoles();

        // TODO: Add your service operations here
    }

    [DataContract]
    public class JobDTO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string CompanyLocation { get; set; }
        [DataMember]
        public Nullable<int> RoleId { get; set; }
        [DataMember]
        public string PrimarySkill { get; set; }
        [DataMember]
        public int NumberOfVacancies { get; set; }

        [DataMember]
        public string RoleName{ get; set; }
    }

    [DataContract]
    public class RoleDTO
    {
        [DataMember]
        public int RoleID { get; set; }
        [DataMember]
        public string RoleName { get; set; }
    }

}
