using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.Models
{
    public class CommonModel
    {

    }
    public class Options
    {
        public string label { get; set; }
        public string value { get; set; }
    }
    public class DashBoardModel
    {
        public int TotalZone { get; set; }
        public int TotalArea { get; set; }
        public int TotalElection { get; set; }
        public int TotalVoter { get; set; }
        public int TotalCandiddate{ get; set; }
        public int TotalAdmin { get; set; }
        public int TotalAppointment { get; set; }
    }
}
