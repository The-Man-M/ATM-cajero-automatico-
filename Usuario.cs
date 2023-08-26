using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM__cajero_automatico_
{
    internal class Usuario
    {
        string Nombre_de_usuario = "";
        string DUI = "";
        string Contraseña = "";
        double Saldo = 0;
        bool cuenta_creada = false;

        public void Crear_cuenta()
        {
            if (this.cuenta_creada)
            {

                Console.WriteLine("Cuenta ya creada");
            }
            else
            {
                Console.WriteLine("Ingrese el nombre de usuario\n");
                this.Nombre_de_usuario = Console.ReadLine();
                Console.WriteLine("Ingrese numero de DUI\n");
                this.DUI = Console.ReadLine();
                Console.WriteLine("Ingrese su contraseña\n");
                this.Contraseña = Console.ReadLine();
                Console.WriteLine("Ingrese saldo inicial\n");
                while (!double.TryParse(Console.ReadLine(), out Saldo) || Saldo< 0)//validamos que no ingrese números negativos ni caracter
                {
                    Console.WriteLine("Ingrese saldo valido\nIngrese saldo inicial\n");
                }

                cuenta_creada = true;

            }
        }
        public void Get_Saldo()
        {
            Console.WriteLine(this.Saldo);
        }
        public void Retiro_de_efectivo()
        {
            
        }
        public void Ingreso_de_efectivo()
        {
            
        }

    }
}
