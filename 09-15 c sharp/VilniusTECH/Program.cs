using TableLibrary;

namespace _09_15_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 16.
            Random random = new Random();
            int count = random.Next(5, 25);
            Miestas[] miestai = new Miestas[count];
            for (int i = 0; i < count; i++)
                miestai[i] = Miestas.CreateRandomCity(i);
            TablePrinter.Print(miestai);
        }

    }
}
