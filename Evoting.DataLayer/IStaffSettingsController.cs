using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.DataLayer
{
    public interface IStaffSettingsController
    {
        // Voters
        bool AddNewVoter(VoterModel Voter);
        List<VoterModel> GetAllVoter();
        bool UpdateVoter(VoterModel Voter);
        VoterModel GetSingleVoter(int id);
        bool DeleteVoter(int id);

        // Candidates
        int AddNewCandidate(CandidateModel Candidate);
        List<CandidateModel> GetAllCandidate();
        bool UpdateCandidate(CandidateModel Candidate);
        CandidateModel GetSingleCandidate(int id);
        bool DeleteCandidate(int id);


        // Admin
        bool AddNewAdmin(AdminModel Admin);
        List<AdminModel> GetAllAdmin();
        bool UpdateAdmin(AdminModel Admin);
        AdminModel GetSingleAdmin(int id);
        bool DeleteAdmin(int id);
    }
}
