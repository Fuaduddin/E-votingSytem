using Evoting.DataLayerSQL;
using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.BusinessLayer
{
    public class AppointmentManager
    {
        public static bool AddNewAppointment(AppointmentModel appointment)
        {
            AppointmentSQLProvider provider = new AppointmentSQLProvider();
            bool IsAdded = provider.AddNewAppointment(appointment);
            return IsAdded;
        }
        public static bool DeleteAppointment(int id)
        {
            AppointmentSQLProvider provider = new AppointmentSQLProvider();
            bool IsDeleted = provider.DeleteAppointment(id);
            return IsDeleted;
        }
        public static List<AppointmentModel> GetAllAppointment()
        {
            AppointmentSQLProvider provider = new AppointmentSQLProvider();
            var area = provider.GetAllAppointment();
            return area;
        }
        public static AppointmentModel GetSingleAppointment(int id)
        {
            AppointmentSQLProvider provider = new AppointmentSQLProvider();
            var area = provider.GetSIngleAppointment(id);
            return area;
        }
        //public static bool UpdateAppointment(AppointmentModel areadetails)
        //{
        //    AppointmentSQLProvider provider = new AppointmentSQLProvider();
        //    var area = provider.UpdateAppointment(areadetails);
        //    return area;
        //}
    }
}
