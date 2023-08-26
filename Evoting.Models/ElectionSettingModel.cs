using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.Models
{
    public class ElectionSettingModel
    {
        //public int ElectionID { get; set; }
        //public string ElectionName { get; set; }
    }
    public class ElectionModel
    {
        public int ElectionID { get; set; }
        [Required(ErrorMessage = "Please Enter Election Name")]
        public string ElectionName { get; set; }
    }
    public class zoneModel
    {
        public int ZoneId { get; set; }
        [Required(ErrorMessage = "Please Enter Zone Name")]
        public string ZoneName { get; set; }

        //public  List<Admin> Admins { get; set; }
        //public  Area Area { get; set; }
        //public List<Candidate> Candidates { get; set; }
        //public List<Election_Detail> Election_Details { get; set; }
        //public List<Voter> Voters { get; set; }
    }

    public class areamodel
    {
        public int AreaID { get; set; }
        public string AreaTitle { get; set; }
        public int ZoneID { get; set; }
        public string AreaName { get; set; }

        //public virtual ICollection<Admin> Admins { get; set; }
        //public virtual Zone Zone { get; set; }

        //public virtual ICollection<Candidate> Candidates { get; set; }

        //public virtual ICollection<Voter> Voters { get; set; }
    }
    public class ElectionDetailsModel
    {
        public int ElectionID { get; set; }
        public string ElectionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ZoneID { get; set; }
        public string ElectionDetails { get; set; }
        public string ElectionStatus { get; set; }
        public int AreaID { get; set; }
        public int ElectionType { get; set; }

        //public virtual Area Area { get; set; }
        //public virtual ElectionType ElectionType1 { get; set; }
        //public virtual Zone Zone { get; set; }
      
        //public virtual ICollection<ElectionCandidate> ElectionCandidates { get; set; }
       
        //public virtual ICollection<Result> Results { get; set; }
       
        //public virtual ICollection<Vote> Votes { get; set; }
    }
}
