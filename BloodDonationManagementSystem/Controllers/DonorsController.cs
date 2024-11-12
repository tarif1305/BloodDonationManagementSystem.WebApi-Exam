using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using BloodDonationManagementSystem.Models;

namespace BloodDonationManagementSystem.Controllers
{
    public class DonorsController : ApiController
    {
        private DataBase db = new DataBase();

        // GET: api/Donors
        public IQueryable<Donor> GetDonors()
        {
            return db.Donors.Include(d => d.BloodRequests);
        }

        // GET: api/Donors/5
        [ResponseType(typeof(Donor))]
        public async Task<IHttpActionResult> GetDonor(int id)
        {
            Donor donor = await db.Donors.Include(d => d.BloodRequests).SingleOrDefaultAsync(d => d.DonorID == id);
                if (donor == null)
            {
                return NotFound();
            }

            return Ok(donor);
        }

        // PUT: api/Donors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDonor(int id, Donor donor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donor.DonorID)
            {
                return BadRequest();
            }

            db.Entry(donor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonorExists(id))
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
        [Route("~/Upload"), HttpPost]
        public IHttpActionResult Upload()
        {
            var image = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            if (image != null)
            {
                string imageName = "/Essence/pictures/" + image.FileName;

                string filePath = HttpContext.Current.Server.MapPath(imageName);

                image.SaveAs(filePath);

                return Ok(imageName);
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Donors
        [ResponseType(typeof(Donor))]
        public async Task<IHttpActionResult> PostDonor(Donor donor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Donors.Add(donor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = donor.DonorID }, donor);
        }

        // DELETE: api/Donors/5
        [ResponseType(typeof(Donor))]
        public async Task<IHttpActionResult> DeleteDonor(int id)
        {
            Donor donor = await db.Donors.FindAsync(id);
            if (donor == null)
            {
                return NotFound();
            }

            db.Donors.Remove(donor);
            await db.SaveChangesAsync();

            return Ok(donor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonorExists(int id)
        {
            return db.Donors.Count(e => e.DonorID == id) > 0;
        }
    }
}