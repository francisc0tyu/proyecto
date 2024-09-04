using System;


class Proyecto
{
    static void Main()
    {
        Console.Write("Bienvenido, ingrese su nombre por favor: ");
        string usuario = Console.ReadLine();

        Console.WriteLine($"Bienvenido {usuario} al programa de la tienda de Miguel :* ");

        List<string> listaProductos = new List<string>();
        List<double> listaPrecios = new List<double>();

        int opcionPrincipal;
        do
        {
            // Mostrar el menú principal
            Console.WriteLine("---------- " +
                "=============MENU------------");
            Console.WriteLine("Seleccione la categoría que le gustaría comprar:(");
            Console.WriteLine("1. Electrónica");
            Console.WriteLine("2. Alimentos");
            Console.WriteLine("3. Salir");
            Console.Write("Ingrese su opción: ");
            opcionPrincipal = int.Parse(Console.ReadLine());

            switch (opcionPrincipal)
            {
                case 1:
                    // Submenú de Electrónica
                    int opcionElectronica;
                    do
                    {
                        Console.WriteLine("\nCategoría: Electrónica");
                        Console.WriteLine("1. Laptop - $1000");
                        Console.WriteLine("2. Smartphone - $700");
                        Console.WriteLine("3. Audífonos - $150");
                        Console.WriteLine("4. Regresar al menú principal");
                        Console.Write("Seleccione un producto: ");
                        opcionElectronica = int.Parse(Console.ReadLine());

                        double precio = 0;
                        double impuesto = 0;

                        switch (opcionElectronica)
                        {
                            case 1:
                                precio = 1000;
                                impuesto = 0.18; // 18% para Laptops
                                break;
                            case 2:
                                precio = 700;
                                impuesto = 0.15; // 15% para Smartphones
                                break;
                            case 3:
                                precio = 150;
                                impuesto = 0.10; // 10% para Audífonos
                                break;
                            case 4:
                                // Regresar al menú principal
                                Console.WriteLine("Regresando al menú principal...");
                                break;
                            default:
                                Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                                continue;
                        }

                        if (opcionElectronica >= 1 && opcionElectronica <= 3)
                        {
                            Console.Write("Ingrese la cantidad que desea comprar (máximo 100): ");
                            int cantidad = int.Parse(Console.ReadLine());

                            if (cantidad > 100)
                            {
                                Console.WriteLine("La cantidad no puede superar 100. Intente de nuevo.");
                                continue;
                            }

                            double precioConImpuesto = precio + (precio * impuesto);
                            double descuento = CalcularDescuento(cantidad);
                            double precioFinal = (precioConImpuesto - (precioConImpuesto * descuento)) * cantidad;

                            // Agregar el producto y el precio final a las listas
                            listaProductos.Add($"{(opcionElectronica == 1 ? "Laptop" : opcionElectronica == 2 ? "Smartphone" : "Audífonos")} x{cantidad}");
                            listaPrecios.Add(precioFinal);

                            Console.WriteLine($"Precio por unidad con impuesto: ${precioConImpuesto:F2}");
                            Console.WriteLine($"Descuento aplicado: {descuento * 100}%");
                            Console.WriteLine($"Precio total por {cantidad} unidades: ${precioFinal:F2}");

                            // Opción para continuar comprando
                            Console.Write("¿Desea seguir comprando? (s/n): ");
                            string seguirComprando = Console.ReadLine().ToLower();
                            if (seguirComprando != "s")
                            {
                                Console.WriteLine("Generando factura final...");
                                MostrarFacturaFinal(listaProductos, listaPrecios);
                                return;
                            }
                        }

                    } while (opcionElectronica != 4); 
                    break;

                case 2:
                    
                    int opcionAlimentos;
                    do
                    {
                        Console.WriteLine("\nCategoría: Alimentos");
                        Console.WriteLine("1. Pan - $2");
                        Console.WriteLine("2. Leche - $1.5");
                        Console.WriteLine("3. 1 Caja de huevos - $3");
                        Console.WriteLine("4. Regresar al menú principal");
                        Console.Write("Seleccione un producto: ");
                        opcionAlimentos = int.Parse(Console.ReadLine());

                        double precio = 0;
                        double impuesto = 0;

                        switch (opcionAlimentos)
                        {
                            case 1:
                                precio = 2;
                                impuesto = 0.05; // 5% para Pan
                                break;
                            case 2:
                                precio = 1.5;
                                impuesto = 0.07; // 7% para Leche
                                break;
                            case 3:
                                precio = 3;
                                impuesto = 0.08; // 8% para Huevos
                                break;
                            case 4:
                                // Regresar al menú principal
                                Console.WriteLine("Regresando al menú principal...");
                                break;
                            default:
                                Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                                continue;
                        }

                        if (opcionAlimentos >= 1 && opcionAlimentos <= 3)
                        {
                            Console.Write("Ingrese la cantidad que desea comprar (máximo 100): ");
                            int cantidad = int.Parse(Console.ReadLine());

                            if (cantidad > 100)
                            {
                                Console.WriteLine("La cantidad no puede superar 100. Intente de nuevo.");
                                continue;
                            }

                            double precioConImpuesto = precio + (precio * impuesto);
                            double descuento = CalcularDescuento(cantidad);
                            double precioFinal = (precioConImpuesto - (precioConImpuesto * descuento)) * cantidad;

                            // Agregar el producto y el precio final a las listas
                            listaProductos.Add($"{(opcionAlimentos == 1 ? "Pan" : opcionAlimentos == 2 ? "Leche" : "Huevos")} x{cantidad}");
                            listaPrecios.Add(precioFinal);

                            Console.WriteLine($"Precio por unidad con impuesto: ${precioConImpuesto:F2}");
                            Console.WriteLine($"Descuento aplicado: {descuento * 100}%");
                            Console.WriteLine($"Precio total por {cantidad} unidades: ${precioFinal:F2}");

                            // Opción para continuar comprando
                            Console.Write("¿Desea seguir comprando? (s/n): ");
                            string seguirComprando = Console.ReadLine().ToLower();
                            if (seguirComprando != "s")
                            {
                                Console.WriteLine("Generando factura final...");
                                MostrarFacturaFinal(listaProductos, listaPrecios);
                                return; // Terminar el programa después de mostrar la factura final
                            }
                        }

                    } while (opcionAlimentos != 4); // Volver al menú principal si elige regresar
                    break;

                case 3:
                    // Salir del programa y mostrar factura final
                    Console.WriteLine("Generando factura final...");
                    MostrarFacturaFinal(listaProductos, listaPrecios);
                    break;

                default:
                    // Opción inválida
                    Console.WriteLine("Opción inválida, por favor intente de nuevo.");
                    break;
            }

        } while (opcionPrincipal != 3); // Continuar hasta que el usuario elija salir
    }

    // Método para calcular el descuento basado en la cantidad
    static double CalcularDescuento(int cantidad)
    {
        if (cantidad >= 50)
        {
            return 0.15; // 15% de descuento para 50 o más productos
        }
        else if (cantidad >= 20)
        {
            return 0.10; // 10% de descuento para 20-49 productos
        }
        else if (cantidad >= 10)
        {
            return 0.05; // 5% de descuento para 10-19 productos
        }
        else
        {
            return 0; // No hay descuento para menos de 10 productos
        }
    }

    
    static void MostrarFacturaFinal(List<string> listaProductos, List<double> listaPrecios)
    {
        Console.WriteLine("\n---------- FACTURA FINAL ----------");
        double total = 0;

        for (int i = 0; i < listaProductos.Count; i++)
        {
            Console.WriteLine($"{listaProductos[i]} - ${listaPrecios[i]:F2}");
            total += listaPrecios[i];
        }

        Console.WriteLine($"----------------------------------");
        Console.WriteLine($"TOTAL A PAGAR: ${total:F2}");
        Console.WriteLine("¡Gracias por su compra!");
    }
}
