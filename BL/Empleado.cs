using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JFloresExamenLeenkenGroupEntities contex = new DL.JFloresExamenLeenkenGroupEntities())
                {
                    int RowsAfected = contex.EmpleadoAdd(empleado.NumeroNomina,empleado.Nombre,empleado.ApellidoPaterno,empleado.ApellidoMaterno,empleado.Estado.IdEstado);


                    if (RowsAfected >= 1)
                    {
                       
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio Un error al ingresar el nuevo empleado ";
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


        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JFloresExamenLeenkenGroupEntities contex = new DL.JFloresExamenLeenkenGroupEntities())
                {
                    int RowsAfected = contex.EmpleadoUpdate(empleado.IdEmpleado,empleado.NumeroNomina, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Estado.IdEstado);


                    if (RowsAfected >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio Un error al actualizar el empleado ";
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

        public static ML.Result Delete(int idEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JFloresExamenLeenkenGroupEntities contex = new DL.JFloresExamenLeenkenGroupEntities())
                {
                    int RowsAfected = contex.EmpleadoDelete(idEmpleado);


                    if (RowsAfected >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio Un error al eliminar el empleado ";
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JFloresExamenLeenkenGroupEntities contex = new DL.JFloresExamenLeenkenGroupEntities())
                {
                    var RowsAfected = contex.EmpleadoGetAll().ToList();

                    result.Objects = new List<object>();


                    foreach (var obj in RowsAfected)
                    {
                        ML.Empleado empleado = new ML.Empleado();
                        empleado.IdEmpleado = obj.IdEmpleado;
                        empleado.NumeroNomina = obj.NumeroNomina;
                        empleado.Nombre = obj.Nombre;
                        empleado.ApellidoPaterno = obj.ApellidoPaterno;
                        empleado.ApellidoMaterno = obj.ApellidoMaterno;
                        empleado.Estado = new ML.Estado();
                        empleado.Estado.IdEstado = obj.IdEstado;
                        empleado.Estado.Nombre = obj.Estado;

                        result.Objects.Add(empleado);
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


        public static ML.Result GetById(int idEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JFloresExamenLeenkenGroupEntities contex = new DL.JFloresExamenLeenkenGroupEntities())
                {
                    var RowsAfected = contex.EmpleadoGetById(idEmpleado).FirstOrDefault();

                    //result.Objects = new List<object>();
                    result.Object = new object();
                    if (RowsAfected != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();
                        empleado.IdEmpleado = RowsAfected.IdEmpleado;
                        empleado.NumeroNomina = RowsAfected.NumeroNomina;
                        empleado.Nombre = RowsAfected.Nombre;
                        empleado.ApellidoPaterno = RowsAfected.ApellidoPaterno;
                        empleado.ApellidoMaterno = RowsAfected.ApellidoMaterno;
                        empleado.Estado = new ML.Estado();
                        empleado.Estado.IdEstado = RowsAfected.IdEstado;
                        empleado.Estado.Nombre = RowsAfected.Estado;


                        result.Object = (empleado);

                        result.Correct = true;
                }
                    else
                {
                    result.Correct = false;
                    result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Aseguradora";
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
