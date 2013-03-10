using System;

namespace BulgarianLanguage
{
    class Pravopis
    {
        public enum SyllableMakers { а, А, ъ, Ъ, о, О, у, У, е, Е, и, И, ю, Ю, я, Я };
        static void Main()
        {
            Predicate<char> ObrazuvaSrichka = ((x) => Enum.IsDefined(typeof(SyllableMakers), x.ToString())); 
                                                   
            while (true)
            {
                Console.WriteLine("Въведете използвания символ ('и/И' или 'й/Й'): ");
                char ch = (char)Console.Read();
                Console.ReadLine();
                if (ch != 'и' && ch != 'И' && ch != 'й' && ch != 'Й') continue;
                Console.WriteLine("Прочетете думата на срички (може и на ум). Този звук образува ли сричка? (д/н)");
                char yn = (char)Console.Read();
                if (yn == 'д') yn = 'Д';
                Console.ReadLine();
                if ((ObrazuvaSrichka(ch) && yn == 'Д') || (!ObrazuvaSrichka(ch) && yn != 'Д')) Console.WriteLine("Браво! Правилна употреба! Печелите 10 точки!");
                else Console.WriteLine("Използвай другото. -5 точки!");
                Console.WriteLine();
            }
        }
    }
}
