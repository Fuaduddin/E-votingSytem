using Evoting.DataLayerSQL;
using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.BusinessLayer
{
    public class StaffManager
    {
        // Voter
        public static bool AddNewVoter(VoterModel Voter)
        {
            StaffSettingSQLProvider provider= new StaffSettingSQLProvider();
            var OutPut = provider.AddNewVoter(Voter);
            return OutPut;
        }
        public static List<VoterModel> GetAllVoter()
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var OutPut = provider.GetAllVoter();
            return OutPut;
        }
        public static bool DeleteVoter(int id)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var OutPut = provider.DeleteVoter(id);
            return OutPut;
        }
        public static VoterModel GetSingleVoter(int id)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var OutPut = provider.GetSingleVoter(id);
            return OutPut;
        }
        public static bool UpdateVoter(VoterModel Voter)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var OutPut = provider.UpdateVoter(Voter);
            return OutPut;
        }
        // Candidate
        public static bool AddNewCandidate(CandidateModel Candidate)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var OutPut = provider.AddNewCandidate(Candidate);
            return OutPut;
        }
        public static List<CandidateModel> GetAllCandidate()
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var OutPut = provider.GetAllCandidate();
            return OutPut;
        }
        public static bool DeleteCandidate(int id)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var OutPut = provider.DeleteCandidate(id);
            return OutPut;
        }
        public static CandidateModel GetSingleCandiate(int id)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var OutPut = provider.GetSingleCandidate(id);
            return OutPut;
        }
        public static bool UpdateCandidate(CandidateModel Candidate)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var OutPut = provider.AddNewCandidate(Candidate);
            return OutPut;
        }
        // Admin
        public static bool AddNewAdmin(AdminModel Admin)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var OutPut = provider.AddNewAdmin(Admin);
            return OutPut;
        }
        public static List<AdminModel> GetAllAdmin()
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var OutPut = provider.GetAllAdmin();
            return OutPut;
        }
        public static bool DeleteAdmin(int id)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var OutPut = provider.DeleteAdmin(id);
            return OutPut;
        }
        public static AdminModel GetSingleAdmin(int id)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var OutPut = provider.GetSingleAdmin(id);
            return OutPut;
        }
        public static bool UpdateAdmin(AdminModel Admin)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var OutPut = provider.UpdateAdmin(Admin);
            return OutPut;
        }

        // User 
        public static int AddNewUser(UserModel User)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var OutPut = provider.AddNewUser(User);
            return OutPut;
        }
        //public static List<AdminModel> GetAllUser()
        //{
        //    StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
        //    var OutPut = provider.GetAllUser();
        //    return OutPut;
        //}
        //public static bool DeleteUser(int id)
        //{
        //    StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
        //    var OutPut = provider.DeleteUser(id);
        //    return OutPut;
        //}
        //public static AdminModel GetSingleUser(int id)
        //{
        //    StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
        //    var OutPut = provider.GetSingleUser(id);
        //    return OutPut;
        //}
        //public static bool UpdateUser(AdminModel Admin)
        //{
        //    StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
        //    var OutPut = provider.AddNewUser(Admin);
        //    return OutPut;
        //}
    }
}
