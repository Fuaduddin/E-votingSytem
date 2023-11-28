using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evoting.Models;


namespace Evoting.Models
{
    public class CustomerViewModel
    {
        public AppointmentAnnoucementModel Appointment { get; set; }
        public UserModel UserDetails { get; set; }



        // Extra Feautures
        public List<Options> genders { get; set; }
        public List<Options> AppointmentSubject { get; set; }
        public List<Options> ElectionStatus { get; set; }
    }
}
