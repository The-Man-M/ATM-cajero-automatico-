using System.Net.Sockets;

namespace ATM__cajero_automatico_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaramos variables
            int retiro = 0, ingreso = 0;
            Usuario User = new Usuario();
            int Menu = 0;
            int ticket_numero = 1;

            //Un do While para poder volver al menu
            do
            {
                //Menu en pantalla 
                Console.WriteLine("Menu\n1. Retiro de efectivo\n2. Ingreso de efectivo\n3. Consultar saldo\n4. Crear cuenta\n5. Datos de la cuenta\n6. Salir");
                while (!int.TryParse(Console.ReadLine(), out Menu) || Menu < 0)//validamos que no ingrese números negativos ni caracter
                {
                    Console.WriteLine("Ingrese dato valido\nMenu\n1. Retiro de efectivo\n2. Ingreso de efectivo\n3. Consultar saldo\n 4. Crear cuenta\n5. Datos de la cuenta\n6. Salir\n");
                }

                if (User.Get_cuenta_creada()) //validamos que la cuanta ya este creada
                {
                    //menu
                    if (Menu == 1)//retiro de efectivo
                    {
                        Console.WriteLine("Ingrese saldo a retirar\n");

                        while (!int.TryParse(Console.ReadLine(), out retiro) || retiro < 0)//validamos que no ingrese números negativos ni caracter
                        {
                            Console.WriteLine("Ingrese saldo valido\nIngrese saldo a retirar\n");
                        }

                        //Llamamos a la clase y al método de retiro de efectivo
                        User.Retiro_de_efectivo(retiro);
                        Rango_de_retiro(retiro);
                        
                        Ticket(ticket_numero, "Retiro", User.Get_Saldo(), retiro); //llamamos a la función para generar un ticket
                        ticket_numero++;//Sumamos uno para en numero del ticket

                    }
                    else if (Menu == 2)//Ingreso de efectivo
                    {
                        Console.WriteLine("Ingrese saldo a ingresar\n");

                        while (!int.TryParse(Console.ReadLine(), out ingreso) || ingreso < 0)//validamos que no ingrese números negativos ni caracter
                        {
                            Console.WriteLine("Ingrese saldo valido\nIngrese saldo a ingresar\n");
                        }
                       
                        //Llamamos a la clase y al método de ingreso de efectivo 
                        User.Ingreso_de_efectivo(ingreso);
                        

                        Ticket(ticket_numero,"Ingreso de efectivo",User.Get_Saldo(),ingreso); //llamamos a la función para generar un ticket
                        ticket_numero++; //Sumamos uno para en numero del ticket
                    }
                    else if (Menu == 3) //Mostrar saldo
                    {
                        Console.WriteLine("Saldo: " + User.Get_Saldo()); //Lamamos a la clase y método para mostrar el saldo actual
                    }
                    else if (Menu == 5)//Crear cuenta
                    {
                        User.Get_Datos_de_la_cuenta();//Lamamos a la clase y método para crear la cuenta
                    }
                }
                else if (!User.Get_cuenta_creada() && Menu != 6)// si la cuenta no esta creada y no eligió 6 en el meno 
                {
                    if (Menu == 4)
                    {
                        User.Crear_cuenta(); //Lamamos a la clase y método para crear la cuenta
                    }
                    else
                    {
                        Console.WriteLine("Primero debe crear una cuenta"); //por si eligió otra opción que no sea la de crear cuenta o salir

                    }
                }

                Console.ReadKey();
            } while (Menu != 6);
        }
        static void Rango_de_retiro(double retiro)
        {
            //Rango para ver cuando billetes de cada denominación se tiene que dar 
            if (retiro > 0 && retiro <= 15)
            {
                Billetes_0_a_15(retiro);
            }
            else if (retiro > 15 && retiro <= 50)
            {
                Billetes_15_a_50(retiro);

            }
            else if (retiro > 50 && retiro <= 100)
            {
                Billetes_50_a_100(retiro);

            }
            else if (retiro > 100)
            {
                billetes_100_en_adelante(retiro);
            }
            else { Console.WriteLine("Fuera de rango"); }
        }
        //Función para calcular cuantos billetes se tienen que dar para la cantidad de retiro entre $ 15 a $ 50
        static void Billetes_0_a_15(double retiro)
        {
            //Declaramos variables 
            int Billetes_de_uno = 0;
            int Billetes_de_cinco = 0;
            int Billetes_de_diez = 0;
            int Billetes_de_veinte = 0;
            const double Porcentaje_B_5 = 0.50; 

            Billetes_de_cinco = Convert.ToInt16(((double)Math.Round(retiro * Porcentaje_B_5)) / 5); //Multiplicamos la variable retiro * Porcentaje_B_5 y lo dividimos entre 5 y nos da la cantidad de billetes de a cinco

            Billetes_de_uno = Convert.ToInt16((double)(retiro)) - (Billetes_de_cinco * 5);// convertimos la variable retiro en int y le restamos (billetes_a_cinco * 5) y nos da la cantidad de billetes de a uno

            //Mostramos en pantalla 
            Mostrar_billetes(Billetes_de_veinte, Billetes_de_diez, Billetes_de_cinco, Billetes_de_uno);
        }
        //Función para calcular cuantos billetes se tienen que dar para la cantidad de retiro entre $ 15 a $ 50
        static void Billetes_15_a_50(double retiro)
        {
            //Declaramos variable
            int Billetes_de_uno = 0;
            int Billetes_de_cinco = 0;
            int Billetes_de_diez = 0;
            int Billetes_de_veinte = 0;
            const double porcentaje_10 = 0.75, Porcentaje_B_5 = 0.50;

            //Calculamos los billetes a dar

            Billetes_de_diez = Convert.ToInt16(((double)Math.Round(retiro * porcentaje_10)) / 10); // Multiplicamos la variable retiro* Porcentaje_B_10 y lo dividimos entre 10 y nos da la cantidad de billetes de a diez

            Billetes_de_cinco = Convert.ToInt16((((double)Math.Round((retiro - Billetes_de_diez * 10) * Porcentaje_B_5)) / 5));//Restamos la variable retiro - (Billetes_de_a_diez * 10) y al resultado lo multiplicamos por Porcentaje_B_5 y lo dividimos entre 5 y nos da la cantidad de billetes de a cinco

            Billetes_de_uno = Convert.ToInt16((double)(retiro) - ((Billetes_de_cinco * 5) + (Billetes_de_diez * 10)));//Convertimos la variable tipo double a tipo int luego restamos billetes_de_10 multiplicado por 10 mas billetes_de_5 multiplicado por 5 a la variable retiro y eso da la cantidad de billetes de a 1 


            Mostrar_billetes(Billetes_de_veinte, Billetes_de_diez, Billetes_de_cinco, Billetes_de_uno);
        }
        //Función para calcular cuantos billetes se tienen que dar para la cantidad de retiro entre $ 15 a $ 50
        static void Billetes_50_a_100(double retiro)
        {
            int Billetes_de_uno = 0;
            int Billetes_de_cinco = 0;
            int Billetes_de_diez = 0;
            int Billetes_de_veinte = 0;
            const double  Porcentaje_B_20 = 0.50, Porcentaje_B_10 = 0.75 ,Porcentaje_B_5 = 0.50;

            
            Billetes_de_veinte = Convert.ToInt16(((double)Math.Round(retiro * Porcentaje_B_20)) / 20);//Multiplicamos la variable retiro* Porcentaje_B_20 y lo dividimos entre 20 y nos da la cantidad de billetes de a veinte

            Billetes_de_diez = Convert.ToInt16(((double)Math.Round((retiro - Billetes_de_veinte * 20) * Porcentaje_B_10)) / 10);//Restamos la variable retiro - (Billetes_de_a_veinte * 20) y al resultado lo multiplicamos por Porcentaje_B_10 y lo dividimos entre 10 y nos da la cantidad de billetes de a diez

            Billetes_de_cinco = Convert.ToInt16((((double)Math.Round((retiro - ((Billetes_de_veinte * 20) + (Billetes_de_diez * 10)) * 0.55)) / Porcentaje_B_5)));//Restamos la variable retiro - ((Billetes_de_a_veinte * 20) + (Billetes_de_a_diez * 10) ) y al resultado lo multiplicamos por Porcentaje_B_5 y lo dividimos entre 5 y nos da la cantidad de billetes de a cinco

            Billetes_de_uno = Convert.ToInt16((double)(retiro) - (((Billetes_de_veinte * 20) + (Billetes_de_diez * 10) + (Billetes_de_cinco * 5))));//Convertimos la variable tipo double a tipo int luego le restamos a la variable retiro -((Billetes_de_veinte * 20) + (Billetes_de_diez * 10 ) + (Billetes_de_5 * 5)) y eso da la cantidad de billetes de a 1 

            //Mostramos en pantalla
            Mostrar_billetes(Billetes_de_veinte, Billetes_de_diez, Billetes_de_cinco, Billetes_de_uno);
        }
        //Función para calcular cuantos billetes se tienen que dar para la cantidad de retiro entre $ 15 a $ 50
        static void billetes_100_en_adelante(double retiro)
        {

            int Billetes_de_uno = 0;
            int Billetes_de_cinco = 0;
            int Billetes_de_diez = 0;
            int Billetes_de_veinte = 0;
            const double Porcentaje_B_20 = 0.50, Porcentaje_B_10 = 0.40, Porcentaje_B_5 = 0.10;

            Billetes_de_veinte = Convert.ToInt16(((double)Math.Round(retiro * Porcentaje_B_20)) / 20);//Multiplicamos la variable retiro * Porcentaje_B_20 y lo dividimos entre 20 y nos da la cantidad de billetes de a veinte
            Billetes_de_diez = Convert.ToInt16(((double)Math.Round(retiro * Porcentaje_B_10)) / 10);//Multiplicamos la variable retiro* Porcentaje_B_10 y lo dividimos entre 10 y nos da la cantidad de billetes de a diez
            Billetes_de_cinco = Convert.ToInt16((((double)Math.Round((retiro * Porcentaje_B_5)) / 5)));//Multiplicamos la variable retiro* Porcentaje_B_5 y lo dividimos entre 5 y nos da la cantidad de billetes de a cinco
            Billetes_de_uno = Convert.ToInt16((double)(retiro) - (((Billetes_de_veinte * 20) + (Billetes_de_diez * 10) + (Billetes_de_cinco * 5))));//Convertimos la variable tipo double a tipo int luego le restamos a la variable retiro -((Billetes_de_veinte * 20) + (Billetes_de_diez * 10 ) + (Billetes_de_5 * 5)) y eso da la cantidad de billetes de a 1 

            //Mostramos en pantalla
            Mostrar_billetes(Billetes_de_veinte,Billetes_de_diez,Billetes_de_cinco,Billetes_de_uno);

        }
        //Mostramos la cantidad de billetes a dar
        static void Mostrar_billetes(int Billetes_de_uno, int Billetes_de_cinco,  int Billetes_de_diez, int Billetes_de_veinte)
        {
            //Mostramos en pantalla
            Console.WriteLine("Billetes de a veinte: $ " + Billetes_de_veinte);
            Console.WriteLine("Billetes de a diez: $ " + Billetes_de_diez);
            Console.WriteLine("Billetes de a cinco: $ " + Billetes_de_cinco);
            Console.WriteLine("Billetes de a uno: $ " + Billetes_de_uno);
        }
        //Funcion para imprimir el ticket
        static void Ticket(int i,string Transacción,double Saldo, int Monto)
        {
            DateTime fecha_Hora_Transacción = DateTime.Now; 

            string rutaArchivo = $"C:\\Users\\Carlo\\OneDrive\\Documentos\\txt\\archivo_{i}.txt"; //ruta a la cual se guardara el txt
            string Contenido_del_ticket = $"Ticket\nFecha Hora Transacción: {fecha_Hora_Transacción}\n{Transacción}: {Monto}\nSaldo actual: {Saldo}";

            try
            {
                File.WriteAllText(rutaArchivo, Contenido_del_ticket);
                Console.WriteLine("Archivo de texto creado y guardado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear y guardar el archivo: {ex.Message}");
            }
        }
    }
    
}

