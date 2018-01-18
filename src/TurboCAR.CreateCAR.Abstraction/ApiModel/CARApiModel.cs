using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.CreateCAR.Model;

namespace TurboCAR.CreateCAR.ApiModel
{
    public class CARApiModel
    {
        public string BorrowerName { get; set; }
        public string CIF { get; set; }
        public CARTypes CarType { get; set; }
        public string TeamCode { get; set; }
        public string Department { get; set; }
        public DateTime CreatedDate { get; set; }
        public string DealTeamLeaderId { get; set; }
        public string CARAssociateId { get; set; }
        public string CARRMId { get; set; }
        public string CARSCOId { get; set; }
    }
}
