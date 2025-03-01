using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                    if(dataTable.Rows.Count > 0 )
                    {
                        result.Objects= new List<object>();

                        foreach (DataRow row in dataTable.Rows)
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = Convert.ToInt32(row[0].ToString());
                            materia.Nombre = (row[1].ToString());
                            materia.Creditos = Convert.ToByte((row[2].ToString()));
                            materia.Descripcion = ((row[3].ToString()));
                            materia.Costo = (Convert.ToDecimal(row[4].ToString()));
                            result.Objects.Add(materia);
                        }                       
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
                using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=JTorresProgramacionNCapasFebrero;User ID=sa;Password=pass@word1;Encrypt=False;"))
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

        public static ML.Result Delete(ML.Materia materia)  // Stored procedure
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=JTorresProgramacionNCapasFebrero;User ID=sa;Password=pass@word1;Encrypt=False;"))
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
    }
}
