using Evoting.DataLayerSQL;
using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.BusinessLayer
{
    public class GiveVoteManager
    {
        public static List<CandidateModel> GetZoneAreaWiseCandidate(int ELectionID, int ZoneID, int AreaID)
        {
            GiveVoteSQLProvider Provider = new GiveVoteSQLProvider();
            var CandidateList=Provider.GetZoneAreaCandidate(ELectionID,ZoneID, AreaID);
            return CandidateList;
        }
        public static bool GiveVote(GiveVoteModel vote)
        {
            GiveVoteSQLProvider Provider =new GiveVoteSQLProvider();
            var GiveVote = Provider.GiveVote(vote);
            return GiveVote;
        }
        public static List<GiveVoteModel> GiveVoteList()
        {
            GiveVoteSQLProvider Provider = new GiveVoteSQLProvider();
            var GiveVote = Provider.GiveVoteList();
            return GiveVote;
        }

        // Results
        public static ElectionResultDetailsModel ElectionResultDetails(int AsignZoneID)
        {
            GiveVoteSQLProvider Provider = new GiveVoteSQLProvider();
            var GiveVote = Provider.ElectionResultDetails(AsignZoneID);
            return GiveVote;
        }
        public static bool PublishElectionResultDetails(VotingResultModel Result)
        {
            GiveVoteSQLProvider Provider = new GiveVoteSQLProvider();
            var GiveVote = Provider.PublishElectionResultDetails(Result);
            return GiveVote;
        }
        public static ElectionResultDetailsModel GetAllCandidateElectionResultDetails()
        {
            GiveVoteSQLProvider Provider = new GiveVoteSQLProvider();
            var GiveVote = Provider.GetAllCandidateElectionResultDetails();
            return GiveVote;
        }
    }
}
