using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VYMSolucion.Comun
{
    public class Utilitarios
    {
        /// <summary>
        /// Clase que permite serializar/deserializar objetos T
        /// </summary>
        public static class SerializadorAut
        {
            /// <summary>
            /// Serializa un objeto usando DataContractSerializer
            /// </summary>
            /// <typeparam name="T">Tipo de dato a serealizar</typeparam>
            /// <param name="data">Dato a serializar</param>
            /// <param name="listaTipos">Lista de tipos</param>
            /// <returns>Cadena string tipo xml con el dato serializado</returns>
            public static string Serialize<T>(T data, List<Type> listaTipos)
            {
                //creo un stream para almacenar los datos
                using (var memoryStream = new MemoryStream())
                {
                    //creo un serializador
                    var serializer = new DataContractSerializer(typeof(T), listaTipos);

                    //serializo los datos
                    serializer.WriteObject(memoryStream, data);
                    //los convierto en string
                    return Encoding.UTF8.GetString(memoryStream.ToArray());
                }
            }

            /// <summary>
            /// Serializa un objeto usando DataContractSerializer
            /// </summary>
            /// <typeparam name="T">Tipo de dato a serealizar</typeparam>
            /// <param name="data">Dato a serializar</param>
            /// <returns>Cadena string tipo xml con el dato serializado</returns>
            public static string Serialize<T>(T data)
            {
                //creo un stream para almacenar los datos
                using (var memoryStream = new MemoryStream())
                {
                    //creo un serializador
                    var serializer = new DataContractSerializer(typeof(T));

                    //serializo los datos
                    serializer.WriteObject(memoryStream, data);
                    //los convierto en string
                    return Encoding.UTF8.GetString(memoryStream.ToArray());
                }
            }

            /// <summary>
            /// Deserealiza un XML string en un objeto de tipo T
            /// </summary>
            /// <typeparam name="T">Tipo de dato</typeparam>
            /// <param name="xml">string a deserealizar</param>
            /// <param name="listTipos">Lista de tipos conocidos para la serializacion</param>
            /// <returns>Objeto serializado</returns>
            public static T Deserialize<T>(string xml, List<Type> listTipos)
            {
                //Crea un stream en memoria
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                {
                    //crea el serializador
                    var serializer = new DataContractSerializer(typeof(T), listTipos);
                    //deserealiza
                    var theObject = (T)serializer.ReadObject(stream);
                    //retorna el objeto 
                    return theObject;
                }
            }

            /// <summary>
            /// Deserealiza un XML string en un objeto de tipo T
            /// </summary>
            /// <typeparam name="T">Tipo de dato</typeparam>
            /// <param name="xml">string a deserealizar</param>
            /// <returns>Objeto serializado</returns>
            public static T Deserialize<T>(string xml)
            {
                //Crea un stream en memoria
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                {
                    //crea el serializador
                    var serializer = new DataContractSerializer(typeof(T));
                    //deserealiza
                    var theObject = (T)serializer.ReadObject(stream);
                    //retorna el objeto 
                    return theObject;
                }
            }
        }

        /// <summary>
        /// Utilidades de Cryptografia
        /// </summary>
        public class Crypto
        {
            /// <summary>
            /// Encripta datos serializados
            /// </summary>
            /// <param name="datos">datos tipo xml</param>
            /// <returns>string</returns>
            public static string Encriptar(string datos)
            {
                //creo una semilla
                var semilla = unchecked((int)DateTime.Now.Ticks);
                _rnd = new Random(semilla);

                //creo pass y salt para encriptacion
                var password = new StringBuilder(GenerarCaracteresAleatorios(20));
                var salt = new StringBuilder(GenerarCaracteresAleatorios(10));

                //encripto los datos, pasando un password y un salt
                var encriptado = new StringBuilder(Encriptar(datos, password.ToString(), salt.ToString(), 5));

                //retorna los datos usados para la encriptacion
                return encriptado.Append(password).Append(salt).Append(GenerarCaracteresAleatorios(10)).ToString();
            }

            /// <summary>
            /// Encripta un string
            /// </summary>
            /// <param name="dato">string a encriptar</param>
            /// <param name="pass">Password - psuedo-random password del que se derivara el password real</param>
            /// <param name="salt">Salt -  valor a ser usado en la derivacion del password</param>
            /// <param name="iterations">Numero de iteracciones usadas para generar el password.</param>
            /// <returns></returns>
            public static string Encriptar(string dato, string pass, string salt, int iterations)
            {
                // convierte el salt en array
                byte[] saltValueBytes = Encoding.UTF32.GetBytes(salt);

                // convierte el dato en array
                byte[] origTextBytes = Encoding.UTF32.GetBytes(dato);

                // Crea un password para la key que sera generada
                var pwd = new Rfc2898DeriveBytes(pass, saltValueBytes, iterations);

                // Genera un Vector de inicio
                byte[] initVectorBytes = pwd.GetBytes(16);

                // Use el Password para generar un pseudo-random para la clave de encryptación  
                // Especifica el tamaño de la llave en bytes (no en bits)
                byte[] keyBytes = pwd.GetBytes(256 / 8);

                byte[] cipherTextBytes;

                // Crea el objeto Encryptador (sin inicializar)
                using (var symKey = new RijndaelManaged())
                {
                    symKey.Padding = PaddingMode.PKCS7;

                    // Modo de encriptacion: Cipher Block Chaining
                    symKey.Mode = CipherMode.CBC;

                    // Genera el encriptacion desde un key y un vector
                    using (ICryptoTransform encryptor = symKey.CreateEncryptor(keyBytes, initVectorBytes))
                    {
                        // Define el MemoryStream donde van a guardarese los datos encriptados
                        using (var memstr = new MemoryStream())
                        {
                            // Define el Cryptography Stream
                            using (var crypstr = new CryptoStream(memstr, encryptor, CryptoStreamMode.Write))
                            {
                                // inicia la encriptacion
                                crypstr.Write(origTextBytes, 0, origTextBytes.Length);

                                // finaliza la encriptacion
                                crypstr.FlushFinalBlock();

                                // Convierte los datos del memoryStream a una array
                                cipherTextBytes = memstr.ToArray();

                                // Cierra los Streams
                                memstr.Close();
                                crypstr.Close();
                            }
                        }
                    }
                }

                // Convierte los datos encriptados en string base64 encode
                string cipherText = Convert.ToBase64String(cipherTextBytes);

                // Returna el string encriptado
                return cipherText;
            }



            /// <summary>
            /// Desencripta datos
            /// Los ultimos 40 caracteres tienen información del pass y del salt
            /// </summary>
            /// <param name="datos"></param>
            /// <returns></returns>
            public static string Desencriptar(string datos)
            {
                //verifica el tamaño de los datos, debe ser mayor a 40 caracteres
                if (datos.Length < 40)
                    return string.Empty;
                //Envio a desencryptar extrayendo los datos, pass, salt
                return Desencriptar(datos.Substring(0, datos.Length - 40), datos.Substring(datos.Length - 40, 20), datos.Substring(datos.Length - 20, 10), 5);
            }

            /// <summary>
            /// Crea el string de resultado de la Desencriptacion
            /// </summary>
            /// <param name="datos">Datos</param>
            /// <param name="pass">Password</param>
            /// <param name="salt">Salt</param>
            /// <param name="iterations">Numero de Iteracciones </param>
            /// <returns></returns>
            public static string Desencriptar(string datos, string pass, string salt, int iterations)
            {
                // Convierte el salt Byte Arrays
                byte[] saltValueBytes = Encoding.UTF32.GetBytes(salt);

                // Convierte los datos en Byte Array
                string fixedString = datos.Replace(" ", "+");
                byte[] encryptedStringBytes = Convert.FromBase64String(fixedString);

                // Crea un password para la key que sera generada
                var pwd = new Rfc2898DeriveBytes(pass, saltValueBytes, iterations);

                // Genera el Init Vector
                byte[] initVectorBytes = pwd.GetBytes(16);

                // Usa el Password para generar el pseudo-random bytes para la key de encriptacion
                // Especifica el tamaño de la llave en bytes (no en bits)
                byte[] keyBytes = pwd.GetBytes(256 / 8);

                byte[] origTextBytes;
                int decryptedByteCount;

                // Crea el objeto Encryptador (sin inicializar)
                using (var symKey = new RijndaelManaged())
                {
                    // Modo de Padding Encryption 
                    symKey.Padding = PaddingMode.PKCS7;

                    // Seteo el modo de encrypcion: Cipher Block Chaining
                    symKey.Mode = CipherMode.CBC;

                    // Genera el encriptacion desde un key y un vector
                    using (ICryptoTransform decryptor = symKey.CreateDecryptor(keyBytes, initVectorBytes))
                    {
                        // Define el MemoryStream donde estarán los datos encriptados
                        using (var memstr = new MemoryStream(encryptedStringBytes))
                        {
                            // Define el Cryptography Stream
                            using (var crypstr = new CryptoStream(memstr, decryptor, CryptoStreamMode.Read))
                            {
                                // Asignar el búfer suficiente para almacenar los datos
                                origTextBytes = new byte[datos.Length];

                                // Inicia a desencriptar
                                decryptedByteCount = crypstr.Read(origTextBytes, 0, origTextBytes.Length);

                                // Cierra Streams
                                memstr.Close();
                                crypstr.Close();
                            }
                        }
                    }
                }

                // Convierte los datos desencriptados en string base64 encode
                string plainText = Encoding.UTF32.GetString(origTextBytes, 0, decryptedByteCount);

                // Return string desencriptado
                return plainText;
            }

            /// <summary>
            /// variable para generar letras y numeros aleatorios
            /// </summary>
            private static Random _rnd;

            /// <summary>
            /// Genera cadena de letras aleatorias
            /// </summary>
            /// <param name="n">n numero de letras</param>
            /// <returns></returns>
            public static string GenerarCaracteresAleatorios(int n)
            {
                var s = new StringBuilder();

                for (int i = 1; i <= n; i++)
                {
                    var ini = 97;
                    var fin = 122;
                    // desde la letra a minúscula (97)
                    // hasta la letra z en minúsculas (122)
                    if (i % 3 == 0)
                    {
                        ini = 65;
                        fin = 90;
                    }
                    if (i % 2 == 0)
                    {
                        ini = 48;
                        fin = 122;
                    }
                    var c = (char)(_rnd.Next(ini, fin));
                    // lo añadimos a la cadena
                    s.Append(c);
                }
                return s.ToString();
            }

            /// <summary>
            /// Genera numeros aleatorios en un rango dado
            /// </summary>
            /// <param name="minimo">Valor minimo</param>
            /// <param name="maximo">Valor maximo</param>
            /// <returns></returns>
            public static int GenerarValorAleatorio(int minimo, int maximo)
            {
                var semilla = unchecked((int)DateTime.Now.Ticks);
                _rnd = new Random(semilla);

                return _rnd.Next(minimo, maximo);
            }

            /// <summary>
            /// obtiene el hash de un key (dato)
            /// </summary>
            /// <param name="key">Dato</param>
            /// <param name="salt">Salt</param>
            /// <param name="iteraciones">numero de iteracciones</param>
            /// <returns></returns>
            public static string ObtenerHash(string key, string salt, int iteraciones)
            {
                var objPass = new Rfc2898DeriveBytes(key, Encoding.UTF8.GetBytes(salt), iteraciones % 10 + 5);
                return Convert.ToBase64String(objPass.GetBytes(64));
            }

        }

        public static void SetValor(Object objeto, string propiedad, object valor)
        {
            PropertyInfo propertyInfo = objeto.GetType().GetProperty(propiedad);
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(objeto, Convert.ChangeType(valor, propertyInfo.PropertyType), null);
            }
        }

        public class CadenasAletorias
        {
            /// <summary>
            /// obtengo un strig randomico con una dimension
            /// </summary>
            /// <param name="dimension"></param>
            /// <returns></returns>
            public static string GenerarStringRandomico(int dimension)
            {
                StringBuilder builder = new StringBuilder();
                Random random = new Random();
                char ch;
                for (int i = 0; i < dimension; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    builder.Append(ch);
                }

                return builder.ToString();
            } 
        }

    }
}
