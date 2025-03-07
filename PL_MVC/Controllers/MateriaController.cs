using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Usuario
        public ActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();

            ML.Result result = BL.Materia.GetAll();

            if (result.Correct)
            {
                materia.Materias = result.Objects;
            }

            return View(materia);
        }

        //Nombre, Creditos, Descripcion, Costo

        [HttpGet]
        public ActionResult Formulario(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();

            if (IdMateria == 0) //Add
            {

            }
            else
                if (IdMateria > 0) //Update
            {
                ML.Result result = BL.Materia.GetById(IdMateria.Value);

                if (result.Correct == true)
                {
                    materia = (ML.Materia)result.Object; //Unboxing
                }
                //GetById
            }

            return View(materia);
        }

        [HttpPost]
        public ActionResult Formulario(ML.Materia materia)
        {
            if (materia.IdMateria == 0)
            {
                BL.Materia.AddSP(materia);
            }
            else
            {
                BL.Materia.Update(materia);
            }


            return View();
        }

        public ActionResult Delete(int IdMateria)
        {
            BL.Materia.DeleteSP(IdMateria);
            //return View("GetAll");
            return RedirectToAction("GetAll");
        }
    }


}