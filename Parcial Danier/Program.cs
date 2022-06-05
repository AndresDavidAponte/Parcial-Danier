namespace ArchivosBinarios
{
    class Program
    {
        static void EscribirArchivo(string nomarch)
        {
            FileStream fs = null;
            BinaryWriter bw = null;
            try
            {
                fs = new FileStream(nomarch, FileMode.Create, FileAccess.Write);
                bw = new BinaryWriter(fs);

                Random r = new Random();
                int n = 5, i = 0;
                int val;
                
                do
                {
                    val = r.Next(10, 100);
                    Console.WriteLine("Dato insertado en el archivo: " + val);
                    bw.Write(val);
                    i++;
                } while (i < n);
                Console.WriteLine("Presione Enter para volver al menú");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
            finally
            {
                if (bw != null)
                {
                    fs.Close();
                    bw.Close();
                }
            }
        }

//#########################################################################################
        static void Agregar_a_Archivo(string nomarch)
        {
            FileStream fs = null;
            BinaryWriter bw = null;
            try
            {
                fs = new FileStream(nomarch, FileMode.Append, FileAccess.Write);
                bw = new BinaryWriter(fs);

                Random r = new Random();
                int n = 5, i = 0;
                int val;

                do
                {
                    val = r.Next(10, 100);
                    Console.WriteLine("Dato insertado en el archivo: " + val);
                    bw.Write(val);
                    i++;
                } while (i < n);
                Console.WriteLine("Presione Enter para volver al menú");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
            finally
            {
                if (bw != null)
                {
                    fs.Close();
                    bw.Close();
                }
            }
        }

//#########################################################################################
        static void Leer(string nomarch)
        {
            //Alternativa sin crear el objeto FileStream
            //FileStream fs = null;
            BinaryReader br = null;
            try
            {
                //fs = new FileStream(nomarch, FileMode.Open, FaileAcces.Read);
                if (File.Exists(nomarch))
                {
                    //fs = new BinaryReader(fs);
                    br = new BinaryReader(new FileStream(nomarch, FileMode.Open, FileAccess.Read));
                    int val;
                    do
                    {
                        val = br.ReadInt32();
                        Console.WriteLine("Datos: " + val);
                    } while (true);
                    Console.WriteLine("Presione Enter para volver al menú");
                }
                else
                {
                    Console.WriteLine("El archivo no existe");
                    Console.WriteLine("Presione Enter para volver al menú");
                }
            }
            catch (EndOfStreamException)
            {
                Console.WriteLine("Fin del archivo");
            }
            finally
            {
                if (br != null)
                {
                    //fs.close();
                    br.Close();
                }
            }
        }

//#########################################################################################
        static void Eliminar(String nomarch)
        {
            FileStream fs = null;
            BinaryWriter bw = null;
            try
            {
                fs = new FileStream(nomarch, FileMode.Append, FileAccess.Write);
                bw = new BinaryWriter(fs);


                bool result = File.Exists(nomarch);
                if (result == true)
                {
                    Console.WriteLine("Archivo Encontrado");
                    bw.Close();
                    File.Delete(nomarch);
                    Console.WriteLine("Archivo Eliminado Correctamente");
                }
                else
                {
                    Console.WriteLine("Archivo no encontrado");
                }
                Console.WriteLine("Presione Enter para volver al menú");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
            finally
            {
                if (bw != null)
                {
                    fs.Close();
                    bw.Close();
                }
            }
        }

//#########################################################################################
        public static int Menu()
        {
            Console.Clear();
            Console.WriteLine("Que desea realizar");

            Console.WriteLine("1.Crear un archivo");
            Console.WriteLine("2.Leer un archivo"); 
            Console.WriteLine("3.Agregar datos al archivo");
            Console.WriteLine("4.Eliminar un archivo");
            Console.WriteLine("5.Salir");
            int resp = Convert.ToInt32(Console.ReadLine());
            if (resp < 0 | resp > 5)
            {
                Console.WriteLine("\nOpcion no valida.");
                Console.ReadLine();
            }
            return resp;
        }

//#########################################################################################
        static void Main(string[] args)
        {
            /*string est = ".lgst";
            string path = "C:\\Archivos\\";
            string cad;
            string nom_Archivo = path + cadena + est;*/
            int r;
            do
            {
                r = Menu();
                switch (r)
                {
                    case 1:
                        Console.Write("Introduzca el nombre del archivo: ");
                        string archivo = Console.ReadLine() + ".txt";
                        EscribirArchivo(archivo);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Write("Introduzca el nombre del archivo: ");
                        string archivo1 = Console.ReadLine() + ".txt";
                        Leer(archivo1);
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Write("Introduzca el nombre del archivo: ");
                        string archivo2 = Console.ReadLine() + ".txt";
                        Agregar_a_Archivo(archivo2);
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Write("Introduzca el archivo a eliminar: ");
                        string archivo3 = Console.ReadLine() + ".txt";
                        Eliminar(archivo3);
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("Gracias por usar el programa.");
                        break;

                }
            } while (r != 5);
        }
    }
}