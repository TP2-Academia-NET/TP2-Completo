using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Logic;
using Business.Entities;


namespace UI.Consola
{
    public class Usuarios
    {
        Business.Logic.UsuarioLogic UsuarioNegocio { get; set; }

        public Usuarios()
        {
            UsuarioNegocio = new Business.Logic.UsuarioLogic();
        }

        public void Menu()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("1– Listado General");
                Console.WriteLine("2– Consulta");
                Console.WriteLine("3– Agregar");
                Console.WriteLine("4- Modificar");
                Console.WriteLine("5- Eliminar");
                Console.WriteLine("6- Salir");
                Console.Write("Opcion: ");

                ConsoleKeyInfo op = Console.ReadKey();

                switch (op.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        ListadoGeneral();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Consultar();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Agregar();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Modificar();
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Eliminar();
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Error al ingresar la opcion");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
        }

        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese ID del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException)
            {
                Console.WriteLine("La ID debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void Agregar()
        {
            Usuario usuario = new Usuario();
            Console.Clear();
            Console.Write("Ingrese Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("\nIngrese apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.Write("\nIngrese nombre de usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("\nIngrese clave: ");
            usuario.Clave = Console.ReadLine();
            Console.Write("\nIngrese email: ");
            usuario.EMail = Console.ReadLine();
            Console.Write("\nIngrese habilitacion de usuario (1-Si/otro-No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", usuario.ID);
        }

        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese ID del usuario a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.Write("Ingrese nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.Write("\nIngrese apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.Write("\nIngrese nombre de usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("\nIngrese clave: ");
                usuario.Clave = Console.ReadLine();
                Console.Write("\nIngrese email: ");
                usuario.EMail = Console.ReadLine();
                Console.Write("\nIngrese habilitacion de usuario (1-Si/otro-No): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);
            }
            catch (FormatException)
            {
                Console.WriteLine("La ID debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese ID del usuario a eliminar ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException)
            {
                Console.WriteLine("La ID debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            Console.WriteLine("\t\tEmail: {0}", usr.EMail);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            // \t dentro de un string representa un TAB
            Console.WriteLine();
        }
    }
}
