﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using E_Voting.Restful.API.Models.DB;
using Evoting.Models;

namespace E_Voting.Restful.API.Controllers
{
    public class PartiesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Parties/5
        [ResponseType(typeof(Party))]
        public IHttpActionResult GetParty(int id)
        {
            Party party = db.Parties.Find(id);
            if (party == null)
            {
                return NotFound();
            }

            return Ok(party);
        }

        // PUT: api/Parties/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParty(int id, Party party)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != party.PartyID)
            {
                return BadRequest();
            }

            db.Entry(party).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Parties
        [ResponseType(typeof(Party))]
        public IHttpActionResult PostParty(Party party)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Parties.Add(party);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = party.PartyID }, party);
        }

        // DELETE: api/Parties/5
        [ResponseType(typeof(Party))]
        public IHttpActionResult DeleteParty(int id)
        {
            Party party = db.Parties.Find(id);
            if (party == null)
            {
                return NotFound();
            }

            db.Parties.Remove(party);
            db.SaveChanges();

            return Ok(party);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PartyExists(int id)
        {
            return db.Parties.Count(e => e.PartyID == id) > 0;
        }


        // Custome API Controller Method

        public List<PartyModel> GetParties()
        {
            List<PartyModel> PartyList = new List<PartyModel>();
            foreach (var party in db.Parties)
            {
                var PartyDetails = new PartyModel()
                {
                    PartyID = party.PartyID,
                    PartyName = party.PartyName,
                    PartySymbol = party.PartySymbol
                };
                PartyList.Add(PartyDetails);
            }
            return PartyList;
        }
    }
}