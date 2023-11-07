﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using E_Voting.Restful.API.Models.DB;
using Evoting.Models;

namespace E_Voting.Restful.API.Controllers
{
    public class ZonesController : ApiController
    {
        private Entities6 db = new Entities6();

        // GET: api/Zones
        //public IQueryable<Zone> GetZones()
        //{
        //    return db.Zones;
        //}

        public List<zoneModel> GetZones()
        {
            List<zoneModel> ZoneList = new List<zoneModel>();
            var zones= db.Zones;
            foreach (var zone in zones)
            {
                var ZoneDetails = new zoneModel
                {
                    ZoneId = zone.ZoneId,
                    ZoneName = zone.ZoneName
                };
                ZoneList.Add(ZoneDetails);
            }
            return ZoneList;
        }

        // GET: api/Zones/5
        [ResponseType(typeof(Zone))]
        public async Task<IHttpActionResult> GetZone(int id)
        {
            Zone zone = await db.Zones.FindAsync(id);
            if (zone == null)
            {
                return NotFound();
            }

            return Ok(zone);
        }

        // PUT: api/Zones/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutZone(int id, Zone zone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zone.ZoneId)
            {
                return BadRequest();
            }

            db.Entry(zone).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZoneExists(id))
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

        // POST: api/Zones
        [ResponseType(typeof(Zone))]
        public async Task<IHttpActionResult> PostZone(Zone zone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zones.Add(zone);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = zone.ZoneId }, zone);
        }

        // DELETE: api/Zones/5
        [ResponseType(typeof(Zone))]
        public async Task<IHttpActionResult> DeleteZone(int id)
        {
            Zone zone = await db.Zones.FindAsync(id);
            if (zone == null)
            {
                return NotFound();
            }

            db.Zones.Remove(zone);
            await db.SaveChangesAsync();

            return Ok(zone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZoneExists(int id)
        {
            return db.Zones.Count(e => e.ZoneId == id) > 0;
        }
    }
}