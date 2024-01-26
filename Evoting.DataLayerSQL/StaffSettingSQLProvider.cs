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
                HttpResponseMessage ResponseUpdate = GlobalSettingsWebAPI.WebApiClient.PutAsJsonAsync("Voters/" + Voter.VoterID.ToString(), Voter).Result;
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
                HttpResponseMessage ResponseGetSingle = GlobalSettingsWebAPI.WebApiClient.GetAsync("Voters/" + id.ToString()).Result;
                Voter = ResponseGetSingle.Content.ReadAsAsync<VoterModel>().Result;
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
                HttpResponseMessage ResponseDelete = GlobalSettingsWebAPI.WebApiClient.DeleteAsync("Voters/" + id.ToString()).Result;
            }
            catch (Exception ex)
            {
                IsDeleted = false;
                throw new Exception(ex.Message);
            }
            return IsDeleted;
        }
        public bool ActiveVoter(int id)
        {
            bool IsActivated = true;
            try
            {
                HttpResponseMessage ResponseDelete = GlobalSettingsWebAPI.WebApiClient.DeleteAsync("ActivateProfile/" + id.ToString()).Result;
            }
            catch (Exception ex)
            {
                IsActivated = false;
                throw new Exception(ex.Message);
            }
            return IsActivated;
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
                HttpResponseMessage ResponseGetAll = GlobalSettingsWebAPI.WebApiClient.GetAsync("Candidates").Result;
                Voters = ResponseGetAll.Content.ReadAsAsync<List<CandidateModel>>().Result;
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
                HttpResponseMessage ResponseUpdate = GlobalSettingsWebAPI.WebApiClient.PutAsJsonAsync("Candidates" + Candidate.CandidateID.ToString(), Candidate).Result;
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
                HttpResponseMessage ResponseGetAll = GlobalSettingsWebAPI.WebApiClient.GetAsync("Candidates").Result;
                Candidate = ResponseGetAll.Content.ReadAsAsync<CandidateModel>().Result;
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
                HttpResponseMessage ResponseDelete = GlobalSettingsWebAPI.WebApiClient.GetAsync("Candidates/" + id.ToString()).Result;
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
                HttpResponseMessage ResponseUpdate = GlobalSettingsWebAPI.WebApiClient.PutAsJsonAsync("Admins/" + Admin.AdminID.ToString(), Admin).Result;
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
                HttpResponseMessage ResponseGetAll = GlobalSettingsWebAPI.WebApiClient.GetAsync("Admins").Result;
                Admin = ResponseGetAll.Content.ReadAsAsync<AdminModel>().Result;
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
                HttpResponseMessage ResponseDelete = GlobalSettingsWebAPI.WebApiClient.GetAsync("Admins/"+id.ToString()).Result;
            }
            catch (Exception ex)
            {
                IsDeleted = false;
                throw new Exception(ex.Message);
            }
            return IsDeleted;
        }
        public bool ActiveCandidate(int id)
        {
            bool IsActivated = true;
            try
            {
                HttpResponseMessage ResponseDelete = GlobalSettingsWebAPI.WebApiClient.DeleteAsync("ActivateProfile/" + id.ToString()).Result;
            }
            catch (Exception ex)
            {
                IsActivated = false;
                throw new Exception(ex.Message);
            }
            return IsActivated;
        }
        // User
        public int AddNewUser(UserModel User)
        {
            int IsAdded=0;
            try
            {
                HttpResponseMessage ResponseADD = GlobalSettingsWebAPI.WebApiClient.PostAsJsonAsync("Users", User).Result;
            }
            catch (Exception ex)
            {
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
    }
}
