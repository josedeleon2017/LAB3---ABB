using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAB_2___ABB.Models;
using System.IO;
using LAB_2___ABB.Helpers;

namespace LAB_2___ABB.Controllers
{
    public class MedicineController : Controller
    {
        // GET: Medicine
        public ActionResult Index()
        {
            return View(Storage.Instance.MedicineList);
        }

        // GET: Medicine/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Medicine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicine/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Medicine/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Medicine/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Medicine/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Medicine/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //CSV reader on Tree
        public ActionResult CSV()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CSV(HttpPostedFileBase postedfile)
        {
            string FilePath;
            if (postedfile != null)
            {
                string Path = Server.MapPath("~/Data/");
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
                FilePath = Path + System.IO.Path.GetFileName(postedfile.FileName);
                postedfile.SaveAs(FilePath);
                string csvData = System.IO.File.ReadAllText(FilePath);
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        try
                        {
                            var medicine = new MedicineModel
                            {
                                Id = Convert.ToInt32(row.Split(',')[0]),
                                Name = row.Split(',')[1],
                            };
                            //SAVE MEDICINE ON THE TREE
                            MedicineModel.Add(medicine);

                        }
                        catch
                        {
                        }
                    }
                }
            }          
            return RedirectToAction("Index");
        }

        

    }
}
