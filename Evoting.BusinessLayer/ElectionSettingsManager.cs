using Evoting.DataLayerSQL;
using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.BusinessLayer
{
   public static class ElectionSettingsManager
    {
        // Election Type
        public static bool AddNewElectionType(ElectionModel electiontype)
        {
            ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
            bool IsAdded = provider.AddNewElectionType(electiontype);
            return IsAdded;
        }
        public static bool DeleteElectionType(int id)
        {
            ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
            bool IsDeleted = provider.DeleteElectionType(id);
            return IsDeleted;
        }
        public static List<ElectionModel> GetAllElectionType()
        {
            ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
            var partylist = provider.GetAllElectionType();
            return partylist;
        }

        // Zone
        public static bool AddNewZone(zoneModel zone)
        {
            ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
            bool IsAdded = provider.AddNewZone(zone);
            return IsAdded;
        }
        public static zoneModel GetSingleZone(int id)
        {
            ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
            zoneModel IsAdded = provider.GetSingleZone(id);
            return IsAdded;
        }
        public static bool DeleteZone(int id)
        {
            ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
            bool IsDeleted = provider.DeleteZone(id);
            return IsDeleted;
        }
        public static List<zoneModel> GetAllZone()
        {
            ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
            var zone = provider.GetAllZone();
            return zone;
        }

        // Area
        public static bool AddNewArea(areamodel area)
        {
            ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
            bool IsAdded = provider.AddNewArea(area);
            return IsAdded;
        }
        public static bool DeleteArea(int id)
        {
            ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
            bool IsDeleted = provider.DeleteArea(id);
            return IsDeleted;
        }
        public static List<areamodel> GetAllArea()
        {
            ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
            var area = provider.GetAllArea();
            return area;
        }
        public static areamodel GetSingleArea(int id)
        {
            ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
            var area = provider.GetSIngleArea(id);
            return area;
        }
        public static bool UpdateArea(areamodel areadetails)
        {
            ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
            var area = provider.UpdateArea(areadetails);
            return area;
        }

        // ElectionDetails
        //public static bool AddNewElectionDetails(ElectionDetailsModel electiondetails)
        //{
        //    ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
        //    bool IsAdded = provider.AddNewArea(area);
        //    return IsAdded;
        //}
        //public static bool DeleteElectionDetails(int id)
        //{
        //    ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
        //    bool IsDeleted = provider.DeleteArea(id);
        //    return IsDeleted;
        //}
        //public static List<ElectionDetailsModel> GetAllElectionDetails()
        //{
        //    ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
        //    var area = provider.GetAllArea();
        //    return area;
        //}
        //public static ElectionDetailsModel GetSingleElectionDetails(int id)
        //{
        //    ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
        //    var area = provider.GetSIngleArea(id);
        //    return area;
        //}
        //public static bool UpdateElectionDetails(ElectionDetailsModel areadetails)
        //{
        //    ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
        //    var area = provider.UpdateArea(areadetails);
        //    return area;
        //}

    }
}
