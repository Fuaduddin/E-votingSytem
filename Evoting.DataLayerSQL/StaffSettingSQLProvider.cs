using Evoting.Models;
using Evoting.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.DataLayerSQL
{
    public class StaffSettingSQLProvider
    {
        // Voter 
        public bool AddNewVoter(VoterModel Voter)
        {
            bool IsAdded = true;
            try
            {

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

        public bool AddNewCandidate(CandidateModel Candidate)
        {
            bool IsAdded = true;
            try
            {

            }
            catch (Exception ex)
            {
                IsAdded = false;
                throw new Exception(ex.Message);
            }
            return IsAdded;
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
    }
}
