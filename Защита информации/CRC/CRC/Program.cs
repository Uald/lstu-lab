using System;

namespace CRC
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите двоичное число (8 цифр): ");
            String Data = Console.ReadLine();

            // Полином в соответсвии с вариантом
            String SEED = "1000101";

            Console.WriteLine($"Полином: {SEED}");

            // Класс для нахождения контрольной суммы
            Code c_i = new Code(Data, SEED);

            char[] Crc = c_i.get_crc().ToCharArray();
            Array.Reverse(Crc);

            Console.WriteLine("CRC: " + new string(Crc));
        }
    }
}
