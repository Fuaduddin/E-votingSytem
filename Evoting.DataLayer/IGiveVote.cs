using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.DataLayer
{
    public interface IGiveVote
    {
         List<CandidateModel> GetZoneAreaCandidate(int ElectionID, int ZoneID, int AreaID);
        bool GiveVote(GiveVoteModel Vote);
        List<GiveVoteModel> GiveVoteList();


        // Election Results
        ElectionResultDetailsModel ElectionResultDetails(int ELectionID);
    }
}
