using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;

namespace BL
{
    public class Grupo
    {
        public static ML.Result GetByIdPlantel(int IdPlantel)  // Stored procedure
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand("GrupoGetByIdPlantel", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPlantel", IdPlantel);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dataTable = new DataTable();

                    da.Fill(dataTable); //
                    if (dataTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (DataRow row in dataTable.Rows)
                        {
                            ML.Grupo grupo = new ML.Grupo();
                            grupo.IdGrupo = Convert.ToByte(row[0].ToString());
                            grupo.Nombre = (row[1].ToString());
                            result.Objects.Add(grupo);
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
    }
}
