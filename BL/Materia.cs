using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static ML.Result Add(ML.Materia materia)  // Stored procedure
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

                    if(rowsAffected > 0)
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
