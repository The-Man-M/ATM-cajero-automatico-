namespace ATM__cajero_automatico_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
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
            else {}
        }
        static void Billetes_1( double retiro)
        {
            int Billetes_de_uno = 0;
            int Billetes_de_cinco = 0;

            Billetes_de_cinco = Convert.ToInt16(((double)Math.Round(retiro * 0.50)) / 5);
            Billetes_de_uno = Convert.ToInt16((double)(retiro)) - (Billetes_de_cinco * 5);

            Console.WriteLine(Billetes_de_cinco);
            Console.WriteLine(Billetes_de_uno);
        }
        static void Billetes_2( double retiro)
        {
            int Billetes_de_uno = 0;
            int Billetes_de_cinco = 0;
            int Billetes_de_diez = 0;

            Billetes_de_diez = Convert.ToInt16(((double)Math.Round(retiro * 0.75)) / 10);
            Billetes_de_cinco = Convert.ToInt16((((double)Math.Round((retiro-Billetes_de_diez*10) * 0.5)) / 5));
            Billetes_de_uno = Convert.ToInt16((double)(retiro)-((Billetes_de_cinco*5)+(Billetes_de_diez*10)));


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
            Billetes_de_cinco = Convert.ToInt16((((double)Math.Round((retiro - ((Billetes_de_veinte * 20)+(Billetes_de_diez * 10)) * 0.55)) / 5)));
            Billetes_de_uno = Convert.ToInt16((double)(retiro) - (((Billetes_de_veinte * 20) + (Billetes_de_diez * 10)+(Billetes_de_cinco * 5))));


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
            Billetes_de_diez = Convert.ToInt16(((double)Math.Round(retiro  * 0.40)) / 10);
            Billetes_de_cinco = Convert.ToInt16((((double)Math.Round((retiro * 0.1)) / 5)));
            Billetes_de_uno = Convert.ToInt16((double)(retiro) - (((Billetes_de_veinte * 20) + (Billetes_de_diez * 10) + (Billetes_de_cinco * 5))));


            Console.WriteLine(Billetes_de_veinte);
            Console.WriteLine(Billetes_de_diez);
            Console.WriteLine(Billetes_de_cinco);
            Console.WriteLine(Billetes_de_uno);

        }
    }
}
