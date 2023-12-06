using Evoting.DataLayer;
using Evoting.Models;
using Evoting.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.DataLayerSQL
{
    public class StaffSettingSQLProvider: IStaffSettingsController
    {
        // Voter 
        public bool AddNewVoter(VoterModel Voter)
        {
            bool IsAdded = true;
            try
            {
                HttpResponseMessage ResponseADD = GlobalSettingsWebAPI.WebApiClient.PostAsJsonAsync("Voters", Voter).Result;
              //  IsAdded = ResponseADD.Content.ReadAsAsync<bool>().Result;
            }
            catch (Exception ex)
            {
                IsAdded = false;
                throw new Exception(ex.Message);
            }
            return IsAdded;
        }
        public List<VoterModel> GetAllVoter()
        {
            List<VoterModel> Voters= new List<VoterModel>();
            try
            {
                HttpResponseMessage ResponseGetAll = GlobalSettingsWebAPI.WebApiClient.GetAsync("Voters").Result;
                Voters= ResponseGetAll.Content.ReadAsAsync<List<VoterModel>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Voters;
        }
        public bool UpdateVoter(VoterModel Voter)
        {
            bool IsUpdated = true;
            try
            {

            }
            catch (Exception ex)
            {
                IsUpdated = false;
                throw new Exception(ex.Message);
            }
            return IsUpdated;
        }
        public VoterModel GetSingleVoter(int id)
        {
            VoterModel Voter = new VoterModel();
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Voter;
        }
        public bool DeleteVoter(int id)
        {
            bool IsDeleted = true;
            try
            {

            }
            catch (Exception ex)
            {
                IsDeleted = false;
                throw new Exception(ex.Message);
            }
            return IsDeleted;
        }

        // Candidate

        public int AddNewCandidate(CandidateModel Candidate)
        {
            int candidateID;
            try
            {
                HttpResponseMessage ResponseADDED = GlobalSettingsWebAPI.WebApiClient.PostAsJsonAsync("Candidates", Candidate).Result;
                candidateID=ResponseADDED.Content.ReadAsAsync<int>().Result;
            }
            catch (Exception ex)
            {
               
                throw new Exception(ex.Message);
            }
            return candidateID;
        }
        public List<CandidateModel> GetAllCandidate()
        {
            List<CandidateModel> Voters = new List<CandidateModel>();
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Voters;
        }
        public bool UpdateCandidate(CandidateModel Candidate)
        {
            bool IsUpdated = true;
            try
            {

            }
            catch (Exception ex)
            {
                IsUpdated = false;
                throw new Exception(ex.Message);
            }
            return IsUpdated;
        }
        public CandidateModel GetSingleCandidate(int id)
        {
            CandidateModel Candidate = new CandidateModel();
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Candidate;
        }
        public bool DeleteCandidate(int id)
        {
            bool IsDeleted = true;
            try
            {

            }
            catch (Exception ex)
            {
                IsDeleted = false;
                throw new Exception(ex.Message);
            }
            return IsDeleted;
        }

        // Admin
        public bool AddNewAdmin(AdminModel Admin)
        {
            bool IsAdded = true;
            try
            {
                HttpResponseMessage ResponseADD = GlobalSettingsWebAPI.WebApiClient.PostAsJsonAsync("Admins", Admin).Result;

            }
            catch (Exception ex)
            {
                IsAdded = false;
                throw new Exception(ex.Message);
            }
            return IsAdded;
        }
        public List<AdminModel> GetAllAdmin()
        {
            List<AdminModel> Voters = new List<AdminModel>();
            try
            {
                HttpResponseMessage ResponseGetAll = GlobalSettingsWebAPI.WebApiClient.GetAsync("Admins").Result;
                Voters= ResponseGetAll.Content.ReadAsAsync<List<AdminModel>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Voters;
        }
        public bool UpdateAdmin(AdminModel Admin)
        {
            bool IsUpdated = true;
            try
            {

            }
            catch (Exception ex)
            {
                IsUpdated = false;
                throw new Exception(ex.Message);
            }
            return IsUpdated;
        }
        public AdminModel GetSingleAdmin(int id)
        {
            AdminModel Admin = new AdminModel();
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Admin;
        }
        public bool DeleteAdmin(int id)
        {
            bool IsDeleted = true;
            try
            {

            }
            catch (Exception ex)
            {
                IsDeleted = false;
                throw new Exception(ex.Message);
            }
            return IsDeleted;
        }

        // User
        public int AddNewUser(UserModel User)
        {
            int IsAdded=0;
            try
            {
                HttpResponseMessage ResponseADD = GlobalSettingsWebAPI.WebApiClient.PostAsJsonAsync("Users", User).Result;
               /// IsAdded = ResponseADD.Content.ReadAsAsync<int>().Result;
            }
            catch (Exception ex)
            {
                //IsAdded = false;
                throw new Exception(ex.Message);
            }
            return IsAdded;
        }
        public List<UserModel> GetAllUser()
        {
            List<UserModel> Users = new List<UserModel>();
            try
            {
                HttpResponseMessage ResponseGetAll = GlobalSettingsWebAPI.WebApiClient.GetAsync("Users").Result;
                Users = ResponseGetAll.Content.ReadAsAsync<List<UserModel>>().Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Users;
        }
        public bool UpdateUser(UserModel user)
        {
            bool IsUpdated = true;
            try
            {
                HttpResponseMessage ResponseGetAll = GlobalSettingsWebAPI.WebApiClient.PutAsJsonAsync("Users/"+user.UserIDNo.ToString(),user).Result;
            }
            catch (Exception ex)
            {
                IsUpdated = false;
                throw new Exception(ex.Message);
            }
            return IsUpdated;
        }
        //public VoterModel GetSingleUser(int id)
        //{
        //    VoterModel Voter = new VoterModel();
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return Voter;
        //}
        //public bool DeleteUser(int id)
        //{
        //    bool IsDeleted = true;
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        IsDeleted = false;
        //        throw new Exception(ex.Message);
        //    }
        //    return IsDeleted;
        //}
    }
}
