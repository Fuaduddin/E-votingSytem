using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using E_Voting.Restful.API.Models.DB;
using Evoting.Models;

namespace E_Voting.Restful.API.Controllers
{
    public class AdminAssignmentsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/AdminAssignments/5
        [ResponseType(typeof(AdminAssignment))]
        public async Task<IHttpActionResult> GetAdminAssignment(int id)
        {
            AdminAssignment adminAssignment = await db.AdminAssignments.FindAsync(id);
            if (adminAssignment == null)
            {
                return NotFound();
            }

            return Ok(adminAssignment);
        }

        // PUT: api/AdminAssignments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdminAssignment(int id, AdminAssignment adminAssignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adminAssignment.AssignmentID)
            {
                return BadRequest();
            }

            db.Entry(adminAssignment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminAssignmentExists(id))
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

        // POST: api/AdminAssignments
        [ResponseType(typeof(AdminAssignment))]
        public async Task<IHttpActionResult> PostAdminAssignment(AdminAssignment adminAssignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AdminAssignments.Add(adminAssignment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = adminAssignment.AssignmentID }, adminAssignment);
        }

        // DELETE: api/AdminAssignments/5
        [ResponseType(typeof(AdminAssignment))]
        public async Task<IHttpActionResult> DeleteAdminAssignment(int id)
        {
            AdminAssignment adminAssignment = await db.AdminAssignments.FindAsync(id);
            if (adminAssignment == null)
            {
                return NotFound();
            }

            db.AdminAssignments.Remove(adminAssignment);
            await db.SaveChangesAsync();

            return Ok(adminAssignment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdminAssignmentExists(int id)
        {
            return db.AdminAssignments.Count(e => e.AssignmentID == id) > 0;
        }


        // Custome Controller Methods
        // GET: api/AdminAssignments
        public List<AssignmentAppointment> GetAdminAssignments()
        {
            var Admins= db.Admins;
            var Appointments= db.Appointments;
            var AssignAppointment = db.AdminAssignments;
            var AdminAssignmentList = (from appointment in Appointments
                                       join
                                       assignmentappointment in AssignAppointment on
                                       appointment.AppointmentID equals assignmentappointment.AppointmentID
                                       join
                                       admin in Admins on assignmentappointment.AdminID equals admin.AdminID
                                       select new AssignmentAppointment
                                       {
                                           AssignmentID= assignmentappointment.AppointmentID,
                                           AdminID = assignmentappointment.AdminID,
                                           AppointmentID = assignmentappointment.AppointmentID,
                                           AssignmentIssueDate = assignmentappointment.AssignmentIssueDate,
                                           AssignmentFixedDate = assignmentappointment.AssignmentFixedDate,
                                           AssignmentUpdate = assignmentappointment.AssignmentUpdate,
                                           Admin=new AdminModel()
                                           {
                                               AdminName= admin.AdminName,
                                               AdminID= admin.AdminID
                                           },
                                           Appointment= new AppointmentAnnoucementModel()
                                           {
                                               AppointmentID= appointment.AppointmentID,
                                               AppointmentSubject= appointment.AppointmentSubject,
                                               AppointmentDetails = appointment.AppointmentDetails,
                                               UserPhoneNumber = appointment.UserPhoneNumber,
                                               UserEmaul = appointment.UserEmaul,
                                               AssignToAdmin =(int) appointment.AssignToAdmin,
                                               AssignmentUpdate =(int) appointment.AssignmentUpdate
                                           }
                                       }).ToList();
            return AdminAssignmentList;
        }
    }
}