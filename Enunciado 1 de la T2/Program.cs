using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enunciado_1_de_la_T2
{
    //Registrar la lista de dueños considerando el nombre, dirección y teléfono
    class Owner
    {
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string numero_telefonico { get; set; }
    }

    class Program
    {
        static List<Owner> dueños = new List<Owner>();
        static List<Pet> mascotas = new List<Pet>();

        
        static void RegisterOwner()
        {
            Console.WriteLine("Ingrese el nombre del dueño:");
            string name = Console.ReadLine();
            Console.WriteLine("Ingrese la dirección del dueño:");
            string address = Console.ReadLine();
            Console.WriteLine("Ingrese el número de teléfono del dueño:");
            string phoneNumber = Console.ReadLine();

            Owner owner = new Owner { nombre = name, direccion = address, numero_telefonico = phoneNumber };
            dueños.Add(owner);

            Console.WriteLine("Dueño registrado con éxito.");
        }
        
        //Registrar una lista de mascotas.
        class Pet
        {
            public string nombre_p { get; set; }
            public int edad { get; set; }
            public string raza { get; set; }
            public Owner dueño { get; set; }
        }

        static void RegisterPet()
        {
            if (dueños.Count == 0)
            {
                Console.WriteLine("Primero debe registrar un dueño.");
                return;
            }

            Console.WriteLine("Ingrese el nombre de la mascota:");
            string name = Console.ReadLine();
            Console.WriteLine("Ingrese la edad de la mascota:");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
            {
                Console.WriteLine("Edad inválida. Intente de nuevo:");
            }
            Console.WriteLine("Ingrese la raza de la mascota:");
            string breed = Console.ReadLine();

            Console.WriteLine("Seleccione al dueño de la lista:");

            for (int i = 0; i < dueños.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dueños[i].nombre}");
            }

            int ownerIndex;
            while (!int.TryParse(Console.ReadLine(), out ownerIndex) || ownerIndex < 1 || ownerIndex > dueños.Count)
            {
                Console.WriteLine("Opción inválida. Intente de nuevo:");
            }

            Pet pet = new Pet
            {
                nombre_p = name,
                edad = age,
                raza = breed,
                dueño = dueños[ownerIndex - 1]
            };

            mascotas.Add(pet);

            Console.WriteLine("Mascota registrada con éxito.");
        }

        //Buscar una mascota ingresando solo su nombre, y que indique si se encuentra registrada o no.

        static void SearchPetByName()
        {
            Console.WriteLine("Ingrese el nombre de la mascota a buscar:");
            string name = Console.ReadLine();

            Pet pet = mascotas.FirstOrDefault(p => p.nombre_p.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (pet != null)
            {
                Console.WriteLine($"La mascota '{name}' está registrada.");
            }
            else
            {
                Console.WriteLine($"La mascota '{name}' no está registrada.");
            }
        }

        // seleccion de busqueda para registro
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Registrar dueño");
                Console.WriteLine("2. Registrar mascota");
                Console.WriteLine("3. Buscar mascota por nombre");
                Console.WriteLine("4. Salir");
                Console.Write("Opción: ");

                int option;
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            RegisterOwner();
                            break;
                        case 2:
                            RegisterPet();
                            break;
                        case 3:
                            SearchPetByName();
                            break;
                        case 4:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Intente de nuevo.");
                }

                Console.WriteLine();
            }
        }
    }
}
