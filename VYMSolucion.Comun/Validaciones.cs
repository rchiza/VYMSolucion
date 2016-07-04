using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VYMSolucion.Comun
{
    public class Validaciones
    {

        /// <summary>
        /// Valida número de cedula
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public static bool ValidadorDeCedula(String cedula)
        {
            bool cedulaCorrecta = false;

            try
            {
                if(cedula.Length > 10)
                    if (cedula.Length != 13)
                        return false;
                    else
                        cedula = cedula.Substring(0, 10);    

                if (cedula.Length == 10) // ConstantesApp.LongitudCedula
                {
                    int tercerDigito = Int32.Parse(cedula.Substring(2, 1));
                    if (tercerDigito < 6)
                    {
                        // Coeficientes de validación cédula
                        // El decimo digito se lo considera dígito verificador
                        int[] coefValCedula = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
                        int verificador = Int32.Parse(cedula.Substring(9, 1));
                        int suma = 0;
                        int digito = 0;
                        for (int i = 0; i < (cedula.Length - 1); i++)
                        {
                            digito = Int32.Parse(cedula.Substring(i, 1)) * coefValCedula[i];
                            suma += ((digito % 10) + (digito / 10));
                        }

                        if ((suma % 10 == 0) && (suma % 10 == verificador))
                        {
                            cedulaCorrecta = true;
                        }
                        else if ((10 - (suma % 10)) == verificador)
                        {
                            cedulaCorrecta = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                cedulaCorrecta = false;
            }
            
            return cedulaCorrecta;
        }

        /// <summary>
        /// Valida si el formato de fecha es correcto
        /// </summary>
        /// <param name="anio"></param>
        /// <param name="mes"></param>
        /// <param name="dia"></param>
        /// <returns></returns>
        public static bool ValidacionFormatoFecha(int anio, int mes, int dia)
        {
            try
            {
                var fecha = new DateTime(anio, mes, dia);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Valida si la fecha de un registro de menor de edad
        /// Solo se registran mayores o iguales a 18
        /// </summary>
        /// <param name="anio"></param>
        /// <param name="mes"></param>
        /// <param name="dia"></param>
        /// <returns></returns>
        public static bool ValidarFechaMenorEdad(int anio, int mes, int dia)
        {
            try
            {
                //fecha convertida
                var fechaConversion = new DateTime(anio, mes, dia);
                //fecha actual
                var fechaActual = DateTime.Now;
                //fecha comparación
                var fecha = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day).AddYears(-18);

                if (fecha <= fechaConversion)
                    return true;

                return false;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
