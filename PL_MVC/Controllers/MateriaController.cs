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

            if (Session["ListaImagenes"] != null)
            {
                materia.MateriaImagen = new ML.MateriaImagen();
                materia.MateriaImagen.MateriasImagenes = new List<object>();
                materia.MateriaImagen.MateriasImagenes = Session["ListaImagenes"] as List<object>; //1//UNBOXING

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
             //   materia.Action = "Add";
            }
            else
                if (IdMateria > 0) //Update
            {
              //  materia.Action = "Update";
                ML.Result result = BL.Materia.GetById(IdMateria.Value);

                if (result.Correct == true)
                {
                    materia = (ML.Materia)result.Object; //Unboxing
                    materia.Semestre.Semestres = resultSemestre.Objects; //llenando el drop down list

                }
                //GetById
            }
            if (Session["ListaImagenes"] != null)
            {
                materia.MateriaImagen = new ML.MateriaImagen();
                materia.MateriaImagen.MateriasImagenes = new List<object>();
                materia.MateriaImagen.MateriasImagenes = Session["ListaImagenes"] as List<object>; //1//UNBOXING

            }
            return View(materia);
        }

        [HttpPost]
        public ActionResult Formulario(ML.Materia materia, HttpPostedFileBase imgMateriaInput, string Action)
        {
            ML.Result result = new ML.Result();

            if(Action == "Cargar")
            {
                if (imgMateriaInput.ContentLength > 0)
                {
                    MemoryStream target = new MemoryStream();
                    imgMateriaInput.InputStream.CopyTo(target);
                    byte[] data = target.ToArray();

                    materia.MateriaImagen.Imagen = data;

                }


                if (Session["ListaImagenes"] == null)
                {

                    materia.MateriaImagen.MateriasImagenes = new List<object>();
                    materia.MateriaImagen.MateriasImagenes.Add(materia.MateriaImagen);//Id, Descripcion, Imagen
                    Session["ListaImagenes"] = materia.MateriaImagen.MateriasImagenes; //Boxing

                }
                else
                {
                    materia.MateriaImagen.MateriasImagenes = Session["ListaImagenes"] as List<object>; //1//UNBOXING

                    materia.MateriaImagen.MateriasImagenes.Add(materia.MateriaImagen); //2 //Lista

                    Session["ListaImagenes"] = materia.MateriaImagen.MateriasImagenes; //Boxing

                }

            }

            else
            {
                if (materia.IdMateria == 0)
                {
                    result = BL.Materia.AddSP(materia); //1.- Materia 

                    int IdMateria = 2; //recuperar el id de la materia
                                       //2.- Agregar las imágenes


                    foreach (ML.MateriaImagen materiaImagen in materia.MateriaImagen.MateriasImagenes)
                    {
                        //  BL.MateriaImagen.Add(materiaImagen);//Agregar normal
                    }




                }
                else
                {
                    result = BL.Materia.Update(materia);

                    foreach (ML.MateriaImagen materiaImagen in materia.MateriaImagen.MateriasImagenes)
                    {
                        if (materiaImagen.IdMateriaImagen == 0)
                        {
                            //BL.MateriaImagen.Add(materiaImagen);
                        }
                    }
                }



                if (result.Correct) //result.Correct 
                {
                    return RedirectToAction("GetAll");
                }
            }

           


            return View(materia);
        }

        public ActionResult Delete(int IdMateria)
        {
            BL.Materia.DeleteSP(IdMateria);
            //return View("GetAll");
            return RedirectToAction("GetAll");
        }

        public ActionResult DeleteImagen(int IdMateriaImagen, string Descripcion, int IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            materia.MateriaImagen = new ML.MateriaImagen();
            materia.MateriaImagen.MateriasImagenes = new List<object>();

            if(IdMateriaImagen == 0) // El elemento existe solo en la sesión 
                //Eliminarlo de la sesion
            {

                
                materia.MateriaImagen.MateriasImagenes = Session["ListaImagenes"] as List<object>; //1//UNBOXING

                foreach(ML.MateriaImagen materiaImagen in materia.MateriaImagen.MateriasImagenes)
                {
                    if(materiaImagen.IdMateriaImagen == IdMateriaImagen && materiaImagen.Descripcion == Descripcion)
                    {
                        materia.MateriaImagen.MateriasImagenes.Remove(materiaImagen);
                        break;
                    }
                }


            }
            else //El elemento si existe en la base de datos // Eliminar BD
            {
                //BL.MateriaImagen.Delete(IdMateriaImagen)
            }

            
            return RedirectToAction("Formulario", new { IdMateria = IdMateria } ); //GET
        }


        public ActionResult DropDownList()
        {

            ML.Materia materia = new ML.Materia();

            ML.Result resultPlanteles = BL.Plantel.GetAll();

            if (resultPlanteles.Correct == true)
            {
                materia.Grupo = new ML.Grupo(); //usuario.Direccion
                materia.Grupo.Plantel = new ML.Plantel(); //Usuario.Direccion.Colonia
                                                          //usuario.Direccion.Colonia.Municipio
                                                          //usuario.Direccion.Colonia.Municipio.Estado
                materia.Grupo.Plantel.Planteles = resultPlanteles.Objects;
            }


            return View(materia);

        }


        public JsonResult GrupoGetByIdPlantel(int IdPlantel)
        {
            ML.Result result = BL.Grupo.GetByIdPlantel(IdPlantel);

            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }


}