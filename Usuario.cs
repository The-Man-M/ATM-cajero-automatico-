using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM__cajero_automatico_
{
    internal class Usuario
    {
        //declaramos variables de tipo privada
        string Nombre_de_usuario = "";
        string DUI = "";
        string Contraseña = "";
        double Saldo = 0;
        bool cuenta_creada = false;

        //Método para crear la cuenta
        public void Crear_cuenta()
        {
            //verificamos que la cuenta este creada
            if (this.cuenta_creada)//Si la cuenta esta creada
            {

                Console.WriteLine("Cuenta ya creada");
            }
            else//Si la cuenta no esta creada
            {
                //Pedimos los datos y los guardamos el la variable respectiva
                Console.WriteLine("Ingrese el nombre de usuario\n");
                this.Nombre_de_usuario = Console.ReadLine();
                Console.WriteLine("Ingrese numero de DUI\n");
                this.DUI = Console.ReadLine();
                Console.WriteLine("Ingrese su contraseña\n");
                this.Contraseña = Console.ReadLine();
                Console.WriteLine("Ingrese saldo inicial\n");
                while (!double.TryParse(Console.ReadLine(), out Saldo) || Saldo < 0)//validamos que no ingrese números negativos ni caracter
                {
                    Console.WriteLine("Ingrese saldo valido\nIngrese saldo inicial\n");
                }

                cuenta_creada = true;//Cambiamos el valor para que ya no se puede crear otra cuenta

            }
        }

        //Método para verificar si la cuenta esta creada o no
        public bool Get_cuenta_creada()
        {
            return this.cuenta_creada;
        }

        //Método para mostrar el saldo
        public double Get_Saldo()
        {
            return this.Saldo;
            
        }

        //Método para el retiro de efectivo
        public void Retiro_de_efectivo(double retiro)
        {
            if (this.Saldo>=retiro)//Validamos que el saldo sea mayor que el retiro
            {
                this.Saldo -= retiro; 
            }
            else//En caso sea menor mostramos el mensaje siguiente
            {
              
                Console.WriteLine("No cuenta con el saldo necesario para hacer tal retiro");
            }
        }

        //Método para el ingreso de efectivo
        public void Ingreso_de_efectivo(double ingreso)
        {
            this.Saldo += ingreso;
        }

        //Metodo para mostrar los datos de la cuenta
        public void Get_Datos_de_la_cuenta()
        {
            Console.WriteLine("Nombre: " + this.Nombre_de_usuario);
            Console.WriteLine("DUI: " + this.DUI);
            Console.WriteLine("Saldo: " + this.Saldo);
        }

    }
}
