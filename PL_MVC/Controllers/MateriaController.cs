using System;
using System.Collections.Generic;
using System.IO;
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

            materia.Semestre = new ML.Semestre();

            ML.Result resultSemestre = BL.Semestre.GetAll();

            materia.Semestre.Semestres = resultSemestre.Objects; //llenando el drop down list

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
                    materia.Semestre.Semestres = resultSemestre.Objects; //llenando el drop down list

                }
                //GetById
            }

            return View(materia);
        }

        [HttpPost]
        public ActionResult Formulario(ML.Materia materia, HttpPostedFileBase imgMateriaInput)
        {
            ML.Result result = new ML.Result();

            if(imgMateriaInput.ContentLength > 0)
            {
                //Convierto http post file base (Vista) to Byte Array

                //me dio un archivo
                MemoryStream target = new MemoryStream();
                imgMateriaInput.InputStream.CopyTo(target);
                byte[] data = target.ToArray();

                materia.Imagen = data;

            }

            if (materia.IdMateria == 0)
            {
                result = BL.Materia.AddSP(materia);
            }
            else
            {
                result = BL.Materia.Update(materia);
            }

            if(result.Correct) //result.Correct 
            {
                return RedirectToAction("GetAll");
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