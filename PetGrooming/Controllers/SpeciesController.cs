using System;
using System.Collections.Generic;
using System.Data;
//required for SqlParameter class
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetGrooming.Data;
using PetGrooming.Models;
using System.Diagnostics;

namespace PetGrooming.Controllers
{
    public class SpeciesController : Controller
    {
        private PetGroomingContext db = new PetGroomingContext();
        // GET: Species
        public ActionResult Index()
        {
            return View();
        }

        //TODO: Each line should be a separate method in this class
        // List
        public ActionResult List()
        {
            //what data do we need?
            List<Species> myspecies = db.Species.SqlQuery("Select * from species").ToList();

            return View(myspecies);
        }
        public ActionResult Add()
        {
            
            
            return View();
        }

        [HttpPost]

        public ActionResult Add (string SpeciesName)
        {
            Debug.WriteLine("Value of SpeciesName "+ SpeciesName);
                     
            string query = "insert into Species (Name) values (@SpeciesName)";
            SqlParameter[] sqlparams = new SqlParameter[1]; 
            
            sqlparams[0] = new SqlParameter("@SpeciesName", SpeciesName);
            db.Database.ExecuteSqlCommand(query, sqlparams);
            
            return RedirectToAction("List");
        }


        public ActionResult Delete(int id)
        {

            string query = "delete from species where speciesid=@id";
            SqlParameter sqlparam = new SqlParameter("@id",id);


            db.Database.ExecuteSqlCommand(query, sqlparam);
            return RedirectToAction("List");
        }

        public ActionResult Show(int id)
        {

           
           string query = "Select * from species where SpeciesID = @id";
            SqlParameter sqlparam = new SqlParameter("@id", id);


           Species selectedspecies= db.Species.SqlQuery(query,sqlparam).FirstOrDefault();


            return View(selectedspecies);
        }
        //
        // Show
        // Add
        // [HttpPost] Add
        // Update
        // [HttpPost] Update
        // (optional) delete
        // [HttpPost] Delete
    }
}