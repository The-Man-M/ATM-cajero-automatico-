namespace ATM__cajero_automatico_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double retiro = 0, ingreso = 0;

            Usuario xd = new Usuario();
            int Menu = 0;
            do
            {

                Console.WriteLine("Menu\n1. Retiro de efectivo\n2. Ingreso de efectivo\n3. Consultar saldo\n4. Crear cualta\n5. Datos de la cuenta\n6. Salir");
                while (!int.TryParse(Console.ReadLine(), out Menu) || Menu < 0)//validamos que no ingrese números negativos ni caracter
                {
                    Console.WriteLine("Ingrese dato valido\nMenu\n1. Retiro de efectivo\n2. Ingreso de efectivo\n3. Consultar saldo\n 4. Crear cualta\n5. Datos de la cuenta\n6. Salir\n");
                }
                if (xd.Get_cuenta_creada())
                {
                    if (Menu == 1)
                    {
                        Console.WriteLine("Ingrese saldo a retirar\n");

                        while (!double.TryParse(Console.ReadLine(), out retiro) || retiro < 0)//validamos que no ingrese números negativos ni caracter
                        {
                            Console.WriteLine("Ingrese saldo valido\nIngrese saldo a retirar\n");
                        }
                        xd.Retiro_de_efectivo(retiro);

                    }
                    else if (Menu == 2)
                    {
                        Console.WriteLine("Ingrese saldo a ingresar\n");

                        while (!double.TryParse(Console.ReadLine(), out ingreso) || ingreso < 0)//validamos que no ingrese números negativos ni caracter
                        {
                            Console.WriteLine("Ingrese saldo valido\nIngrese saldo a ingresar\n");
                        }
                        xd.Retiro_de_efectivo(retiro);
                    }
                    else if (Menu == 3)
                    {
                        xd.Get_Saldo();
                    }
                    else if (Menu == 5)
                    {
                        xd.Get_Datos_de_la_cuenta();
                    }
                }
                else if (!xd.Get_cuenta_creada()&& Menu!=6)
                {
                    if (Menu == 4)
                    {
                        xd.Crear_cuenta();
                    }
                    else
                    {
                        Console.WriteLine("Primero debe crear una cuenta");
                        
                    }
                }
                Console.ReadKey();
            } while (Menu!=6);
        }
        static void Rango(double retiro)
        {
            if (retiro > 0 && retiro <= 15)
            {
                Billetes_1(retiro);
            }
            else if (retiro > 15 && retiro <= 50)
            {
                Billetes_2(retiro);

            }
            else if (retiro > 50 && retiro <= 100)
            {
                Billetes_3(retiro);

            }
            else if (retiro > 100)
            {
                billetes_4(retiro);
            }
            else { }
        }
        static void Billetes_1(double retiro)
        {
            int Billetes_de_uno = 0;
            int Billetes_de_cinco = 0;

            Billetes_de_cinco = Convert.ToInt16(((double)Math.Round(retiro * 0.50)) / 5);
            Billetes_de_uno = Convert.ToInt16((double)(retiro)) - (Billetes_de_cinco * 5);

            Console.WriteLine(Billetes_de_cinco);
            Console.WriteLine(Billetes_de_uno);
        }
        static void Billetes_2(double retiro)
        {
            int Billetes_de_uno = 0;
            int Billetes_de_cinco = 0;
            int Billetes_de_diez = 0;

            Billetes_de_diez = Convert.ToInt16(((double)Math.Round(retiro * 0.75)) / 10);
            Billetes_de_cinco = Convert.ToInt16((((double)Math.Round((retiro - Billetes_de_diez * 10) * 0.5)) / 5));
            Billetes_de_uno = Convert.ToInt16((double)(retiro) - ((Billetes_de_cinco * 5) + (Billetes_de_diez * 10)));


            Console.WriteLine(Billetes_de_diez);
            Console.WriteLine(Billetes_de_cinco);
            Console.WriteLine(Billetes_de_uno);
        }
        static void Billetes_3(double retiro)
        {
            int Billetes_de_uno = 0;
            int Billetes_de_cinco = 0;
            int Billetes_de_diez = 0;
            int Billetes_de_veinte = 0;

            Billetes_de_veinte = Convert.ToInt16(((double)Math.Round(retiro * 0.5)) / 20);
            Billetes_de_diez = Convert.ToInt16(((double)Math.Round((retiro - Billetes_de_veinte * 20) * 0.75)) / 10);
            Billetes_de_cinco = Convert.ToInt16((((double)Math.Round((retiro - ((Billetes_de_veinte * 20) + (Billetes_de_diez * 10)) * 0.55)) / 5)));
            Billetes_de_uno = Convert.ToInt16((double)(retiro) - (((Billetes_de_veinte * 20) + (Billetes_de_diez * 10) + (Billetes_de_cinco * 5))));


            Console.WriteLine(Billetes_de_veinte);
            Console.WriteLine(Billetes_de_diez);
            Console.WriteLine(Billetes_de_cinco);
            Console.WriteLine(Billetes_de_uno);
        }
        static void billetes_4(double retiro)
        {
            int Billetes_de_uno = 0;
            int Billetes_de_cinco = 0;
            int Billetes_de_diez = 0;
            int Billetes_de_veinte = 0;

            Billetes_de_veinte = Convert.ToInt16(((double)Math.Round(retiro * 0.5)) / 20);
            Billetes_de_diez = Convert.ToInt16(((double)Math.Round(retiro * 0.40)) / 10);
            Billetes_de_cinco = Convert.ToInt16((((double)Math.Round((retiro * 0.1)) / 5)));
            Billetes_de_uno = Convert.ToInt16((double)(retiro) - (((Billetes_de_veinte * 20) + (Billetes_de_diez * 10) + (Billetes_de_cinco * 5))));


            Console.WriteLine(Billetes_de_veinte);
            Console.WriteLine(Billetes_de_diez);
            Console.WriteLine(Billetes_de_cinco);
            Console.WriteLine(Billetes_de_uno);

        }
    }
}
