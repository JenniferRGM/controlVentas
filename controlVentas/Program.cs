using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlVentas
{
    internal class Program
    {
        static void Main(string[] args)
        {
         //Almacena las ventas registradas
         List<Venta> ventas = new List<Venta>();
            string continuar;

            //Variables
            int entradasSol = 0, entradasSombra = 0, entradasPreferencial = 0;
            int acumuladoSol = 0, acumuladoSombra = 0, acumuladoPreferencial = 0;

            do
            {
                //Solicita y lee los datos de la venta
                Console.WriteLine("Por favor ingrese el número de factura: ");
                int numFactura = int.Parse(Console.ReadLine());
                Console.WriteLine("Por favor ingrese la cedula: ");
                string cedula = Console.ReadLine();
                Console.WriteLine("Por favor ingrese el nombre: ");
                string nombre = Console.ReadLine();

                //Lee y valida la localidad
                int localidad;
                do
                {
                    Console.WriteLine("Por favor ingrese la localidad que desea (1. SOL NORTE/SUR, 2. SOMBRA ESTE /OESTE, 3. PREFERENCIAL): ");
                    localidad = int.Parse(Console.ReadLine());
                } while (localidad < 1 || localidad > 3);

                // lee y valida la cantidad de entradas
                int cantEntradas;
                do
                {
                    Console.WriteLine("Ingrese la cantidad de entradas a comprar(*Solamente máximo 4 por persona): ");
                    cantEntradas = int.Parse(Console.ReadLine());

                } while (cantEntradas < 1 || cantEntradas > 4);

                //crea una nueva venta y se agrega a la lista

                Venta venta = new Venta(numFactura, cedula, nombre, localidad, cantEntradas);
                ventas.Add(venta);

                //Actualiza las estadisticas con la localidad
                if (localidad == 1)
                {
                    entradasSol += cantEntradas;
                    acumuladoSol += venta.Subtotal;

                }
                else if (localidad == 2)
                {
                    entradasSombra += cantEntradas;
                    acumuladoSombra += venta.Subtotal;
                }
                else if (localidad == 3)
                {
                    entradasPreferencial += cantEntradas;
                    acumuladoPreferencial += venta.Subtotal;
                }
                //Pregunta para saber si se desea otra venta
                Console.WriteLine("¿Deseas ingresar otra compra? (SI/NO): ");
                continuar = Console.ReadLine().ToUpper();

            } while (continuar == "SI");

            //Muestra las compras realizadas
            Console.WriteLine("Ventas realizadas: ");
            //itera la venta realizada
            foreach (var venta in ventas)
            {
                Console.WriteLine(venta);
            }
            //Muestra la estadistica
            Console.WriteLine("\nESTADÍSTICAS: ");
            Console.WriteLine($"Cantidad de entradas localidad SOL NORTE/SUR: {entradasSol}");
            Console.WriteLine($"Dinero acumulado en localidad SOL NORTE/SUR: {acumuladoSol} colones");
            Console.WriteLine($"Cantidad de entradas en la localidad SOMBRA ESTE/OESTE: {entradasSombra}");
            Console.WriteLine($"Dinero acumulado en localidad SOMBRA ESTE/OESTE: {acumuladoSombra} colones");
            Console.WriteLine($"Cantidad de entradas en localidad PREFERENCIAL: {entradasPreferencial}");
            Console.WriteLine($"Dinero acumulado en localidad PREFERENCIAL: {acumuladoPreferencial} colones");
        }
    }
    class Venta
    {
        public int NumeroFactura { get; }
        public string Cedula { get; }
        public string Nombre { get; }
        public string NombreLocalidad { get; }
        public int CantidadEntradas { get; }
        public int Subtotal { get; }
        public int CargosPorServicios { get; }
        public int TotalAPagar { get; }

        //Clase venta
        public Venta(int numeroFactura, string cedula, string nombre, int localidad, int cantidadEntradas)
        {
            NumeroFactura = numeroFactura;
            Cedula = cedula;
            Nombre = nombre;
            CantidadEntradas = cantidadEntradas;

            //Asigna nombre de la localidad y precio por entrada segun ubicacion
            if (localidad == 1)
            {
                NombreLocalidad = "SOL NORTE/SUR";
                Subtotal = 10500 * cantidadEntradas;

            }
            else if (localidad == 2)
            {
                NombreLocalidad = "SOMBRA ESTE/OESTE";
                Subtotal = 20500 * cantidadEntradas;
            }
            else
            {
                throw new Exception("Localidad no válida");
            }
            //Calcula los cargod por servicios y el total
            CargosPorServicios = 1000 * cantidadEntradas;
            TotalAPagar = Subtotal + CargosPorServicios;
        }
        //Muestra la informacion de la compra 
        public override string ToString()
        {
            return $"Factura: {NumeroFactura}, Cedula: {Cedula}, Nombre: {Nombre}, Localidad: {NombreLocalidad}, Entradas: {CantidadEntradas}, Subtotal: {Subtotal}, Cargos por servicios: {CargosPorServicios}, Total a pagar: {TotalAPagar}";


        }
    }
    }
