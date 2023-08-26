namespace ATM__cajero_automatico_
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
        static int pepe(double retiro)
        {
            if (retiro > 0 && retiro <= 15)
            {
                return 0;
            }
            else if (retiro > 15 && retiro <= 50)
            {
                return 1;
            }
            else if (retiro > 50 && retiro <= 100)
            {
                return 2;
            }
            else if (retiro > 100)
            {
                return 3;
            }
            else { return 4; }
        }
        static void Billetes(int i)
        {
            int Billetes_de_uno = 0;
            int Billetes_de_cinco = 0;
            int Billetes_de_diez = 0;
            int Billetes_de_veinte = 0;
            int Billetes_de_cincuanta = 0;
            switch (i)
            {
                case 0:




                    break;
                case 1: break;
                case 2: break;
                case 3: break;
                case 4: break;
                default: break;

            }
        }
    }
}