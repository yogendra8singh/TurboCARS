using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurboCAR.GetCARs.Model
{
    public class CreditActionRequest
    {
        public string CIF { get; set; }
        public string Borrower { get; set; }

        public CARTypes CARType { get; set; }

        public CARTeam Team { get; set; }
        public string CARID { get; set; }
        public DateTime CreationDate { get; set; }
        public string ActivityStatus { get; set; }
    }

    public enum CARTypes
    {
        None = 0,
        NewLoan = 1,
        BusinessRisk = 2,
        CorrectionCar = 3,
        ChargeOffRequest = 4
    }

    public enum CARStatus
    {
        New = 0,
        Approved = 1,
        Rejected = 2
    }

    public class CARTeam
    {
        public int TeamId { get; set; }
        public string Name { get; set; }

        public List<TeamMember> Members { get; set; }

        public string Department { get; set; }
    }

    public class TeamMember
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
    }
}
