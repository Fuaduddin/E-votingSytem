using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.DataLayer
{
   public interface IElectionSettingsDataLayerProvider
    {
        // Election Type
        bool AddNewElectionType(ElectionModel electiontype);
        bool DeleteElectionType(int id);
        List<ElectionModel> GetAllElectionType();

        //Zone
        bool AddNewZone(zoneModel zone);
        bool DeleteZone(int id);
        List<zoneModel> GetAllZone();
        zoneModel GetSingleZone(int id);

        //Area
        bool AddNewArea(areamodel Area);
        bool DeleteArea(int id);
        List<areamodel> GetAllArea();
        areamodel GetSIngleArea(int id);
        bool UpdateArea(areamodel area);

        // Election Details
        bool AddNewElectionDetails(ElectionDetailsModel electiondetails);
        bool DeleteElectionDetails(int id);
        List<ElectionDetailsModel> GetAllElectionDetails();
        ElectionDetailsModel GetSIngleElectionDetails(int id);
        bool UpdateElectionDetails(ElectionDetailsModel electiondetails);

        //Election Assing
        bool AddNewAssingmentElectionDetails(ElectionAssignmentModel AssingmentElectionDetails);
        List<ElectionAssignmentModel> GetAllAssingElectionDetails();
        bool DeleteAssingElectionDetails(int id);
        ElectionAssignmentModel GetSIngleAssingElectionDetails(int id);
    }
}
