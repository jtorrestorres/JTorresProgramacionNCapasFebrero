using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        // Métodos con el query dentro de 
        public static ML.Result GetAll()  // Stored procedure
        {
            ML.Result result = new ML.Result();

            try
            {
                //1 Importar librerías
                //2 Gestiona Recursos  //Garbage Collector
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand("MateriaGetAll", conn);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dataTable = new DataTable();

                    da.Fill(dataTable); //
                    if (dataTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (DataRow row in dataTable.Rows)
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = Convert.ToInt32(row[0].ToString());
                            materia.Nombre = (row[1].ToString());
                            materia.Creditos = Convert.ToByte((row[2].ToString()));
                            materia.Descripcion = ((row[3].ToString()));
                            materia.Costo = (Convert.ToDecimal(row[4].ToString()));

                            materia.Semestre = new ML.Semestre();
                            materia.Semestre.IdSemestre = (Convert.ToByte(row[5].ToString()));
                            materia.Semestre.Nombre = (row[6].ToString());

                            materia.Imagen = row[7].ToString() != "" ? (byte[])row[7] : null;//operador ternario


                            result.Objects.Add(materia);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                    // conn.Close();
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public static ML.Result GetById(int IdMateria)  // Stored procedure
        {
            ML.Result result = new ML.Result();

            try
            {
                //1 Importar librerías
                //2 Gestiona Recursos  //Garbage Collector
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand("MateriaGetById", conn);
                    cmd.Parameters.AddWithValue("@IdMateria", IdMateria);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dataTable = new DataTable();

                    da.Fill(dataTable); //
                    if (dataTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();

                        DataRow row = dataTable.Rows[0];

                        ML.Materia materia = new ML.Materia();
                        materia.IdMateria = Convert.ToInt32(row[0].ToString());
                        materia.Nombre = (row[1].ToString());
                        materia.Creditos = Convert.ToByte((row[2].ToString()));
                        materia.Descripcion = ((row[3].ToString()));
                        materia.Costo = (Convert.ToDecimal(row[4].ToString()));
                        materia.Semestre = new ML.Semestre();
                        materia.Semestre.IdSemestre = Convert.ToByte((row[5].ToString()));
                        materia.Imagen = row[6].ToString() != "" ? (byte[])row[6] : null;//operador ternario

                        result.Object = materia; //boxing

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                    // conn.Close();
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public static ML.Result Add(ML.Materia materia)  // Stored procedure
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Materia]([Nombre],[Creditos],[Descripcion],[Costo])VALUES (@Nombre, @Creditos, @Descripcion,@Costo)", conn);
                    cmd.Parameters.AddWithValue("@Nombre", materia.Nombre);
                    cmd.Parameters.AddWithValue("@Creditos", materia.Creditos);
                    cmd.Parameters.AddWithValue("@Descripcion", materia.Descripcion);
                    cmd.Parameters.AddWithValue("@Costo", materia.Costo);
                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }


        public static ML.Result AddSP(ML.Materia materia)  // Stored procedure
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand("MateriaAdd", conn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", materia.Nombre);
                    cmd.Parameters.AddWithValue("@Creditos", materia.Creditos);
                    cmd.Parameters.AddWithValue("@Descripcion", materia.Descripcion);
                    cmd.Parameters.AddWithValue("@Costo", materia.Costo);
                    cmd.Parameters.AddWithValue("@IdSemestre", materia.Semestre.IdSemestre);
                    cmd.Parameters.AddWithValue("@Imagen", materia.Imagen);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result Update(ML.Materia materia)  // Stored procedure
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand("MateriaUpdate", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", materia.Nombre);
                    cmd.Parameters.AddWithValue("@Creditos", materia.Creditos);
                    cmd.Parameters.AddWithValue("@Descripcion", materia.Descripcion);
                    cmd.Parameters.AddWithValue("@Costo", materia.Costo);
                    cmd.Parameters.AddWithValue("@IdSemestre", materia.Semestre.IdSemestre);
                    cmd.Parameters.AddWithValue("@Imagen", materia.Imagen);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result Delete(ML.Materia materia)  // Stored procedure
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand("MateriaDelete", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdMateria", materia.IdMateria);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result DeleteSP(int idMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "MateriaDelete";
                    command.Connection = context;

                    command.Parameters.AddWithValue("@IdMateria", idMateria);

                    context.Open();

                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el usuario que quieres eliminar";
                    }
                }


            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result GetAllEFLinq()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JTorresProgramacionNCapasFebreroEntities context = new DL.JTorresProgramacionNCapasFebreroEntities())
                {
                    //consulta

                    //var listMaterias = (from materiaDB in context.Materias
                    //                    select materiaDB).ToList(); //SELECT * FROM

                    var listMaterias = (from materiaDB in context.Materias
                                        join semestreDB in context.Semestres on materiaDB.IdSemestre equals semestreDB.IdSemestre
                                        select new
                                        {
                                            IdMateria = materiaDB.IdMateria,
                                            MateriaNombre = materiaDB.Nombre,
                                            Descripcion = materiaDB.Descripcion,
                                            Creditos = materiaDB.Creditos,
                                            Costo = materiaDB.Costo,
                                            IdSemestre = materiaDB.IdSemestre,
                                            SemestreNombre = semestreDB.Nombre
                                        }).ToList();

                    if (listMaterias != null && listMaterias.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in listMaterias)
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = obj.IdMateria;
                            materia.Nombre = obj.MateriaNombre;

                            result.Objects.Add(materia);
                        }

                    }



                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }


        public static ML.Result GetByIdEFLinq(int IdMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JTorresProgramacionNCapasFebreroEntities context = new DL.JTorresProgramacionNCapasFebreroEntities())
                {
                    //consulta

                    //var listMaterias = (from materiaDB in context.Materias
                    //                    select materiaDB).ToList(); //SELECT * FROM

                    var materiabyId = (from materiaDB in context.Materias
                                       join semestreDB in context.Semestres on materiaDB.IdSemestre equals semestreDB.IdSemestre
                                       where materiaDB.IdMateria == IdMateria 
                                       select new
                                       {
                                           IdMateria = materiaDB.IdMateria,
                                           MateriaNombre = materiaDB.Nombre,
                                           Descripcion = materiaDB.Descripcion,
                                           Creditos = materiaDB.Creditos,
                                           Costo = materiaDB.Costo,
                                           IdSemestre = materiaDB.IdSemestre,
                                           SemestreNombre = semestreDB.Nombre
                                       }).SingleOrDefault();

                    if (materiabyId != null)
                    {
                        result.Objects = new List<object>();


                        ML.Materia materia = new ML.Materia();
                        materia.IdMateria = materiabyId.IdMateria;
                        materia.Nombre = materiabyId.MateriaNombre;

                        result.Object = materia;
                    }



                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }


        public static ML.Result AddEFLinq(ML.Materia materia)
        {
            ML.Result result = new ML.Result();





            try
            {
                using (DL.JTorresProgramacionNCapasFebreroEntities context = new DL.JTorresProgramacionNCapasFebreroEntities())
                {

                    DL.Materia materiaDB = new DL.Materia();

                    materiaDB.Nombre = materia.Nombre;
                    materiaDB.Descripcion = materia.Descripcion;                   

                    context.Materias.Add(materiaDB);

                    int RowsAffected = context.SaveChanges();

                    if(RowsAffected > 0 )
                    {
                        result.Correct = true;
                        
                    }
                    else
                    {
                        result.Correct=false;
                        result.ErrorMessage = "No se pudo agregar la materia";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }


    }
}
