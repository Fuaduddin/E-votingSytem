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
        public AppointmentModel Appointment { get; set; }
        public UserModel UserDetails { get; set; }



        // Extra Feautures
        public List<string> AppointmentSubjectList { get; set; }
    }
}
