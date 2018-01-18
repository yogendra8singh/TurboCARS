using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.GetCARs.Model;

namespace TurboCAR.GetCARs.Abstraction.ApiModel
{
    public class CARApiModel
    {
        public string Id { get; set; }
        public string Borrower { get; set; }
        public string CARType { get; set; }
        public string TeamName { get; set; }
        public string Status { get; set; }
        public string CreationDate { get; set; }
        public string Activity { get; set; }
    }
}
