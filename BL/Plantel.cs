using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Plantel
    {
        public static ML.Result GetAll()  // Stored procedure
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand("PlantelGetAll", conn);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dataTable = new DataTable();

                    da.Fill(dataTable); //
                    if (dataTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (DataRow row in dataTable.Rows)
                        {
                            ML.Plantel plantel = new ML.Plantel();
                            plantel.IdPlantel = Convert.ToByte(row[0].ToString());
                            plantel.Nombre = (row[1].ToString());
                            result.Objects.Add(plantel);
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
