using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JFloresExamenLeenkenGroupEntities contex = new DL.JFloresExamenLeenkenGroupEntities())
                {
                    var RowsAfected = contex.EstadoGetAll().ToList();

                    result.Objects = new List<object>();


                    foreach (var obj in RowsAfected)
                    {
                        ML.Estado estado = new ML.Estado();
                        estado.IdEstado = obj.IdEstado;
                        estado.Nombre = obj.Estado;
                        
                        result.Objects.Add(estado);
                    }
                    result.Correct = true;

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
