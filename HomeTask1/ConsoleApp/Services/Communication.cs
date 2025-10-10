using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Services
{
    public static class Communication
    {
        public static int MainMenue()
        {
            Console.WriteLine("    1. Добавить животное");
            Console.WriteLine("    2. Добавить инвентарь");
            Console.WriteLine("    3. Узнать общее количество еды");
            Console.WriteLine("    4. Узнать животных, пригодных для контактного зоопарка");
            Console.WriteLine("    5. Провести инвентаризацию");
            Console.WriteLine("    6. Завершить работу");
            Console.Write("Введите номер пункта меню: ");

            int type;
            while (!int.TryParse(Console.ReadLine(), out type) && !(1 <= type && type <= 5))
            {
                Console.Write("Вы ввели неверный пункт меню:");
            }

            return type;
        }

        public static string AnimalsMenue(ref Zoo zoo)
        {
            List<string> animalTypes = zoo.AnimalTypes();
            for (int i = 0; i < animalTypes.Count; ++i)
            {
                Console.WriteLine($"    {i + 1}. {animalTypes[i]}");
            }

            Console.Write("Введите тип животного: ");
            string animalType = Console.ReadLine() ?? "";
            while (!animalTypes.Contains(animalType))
            {
                Console.Write("Введённый вид не содержится в этом зоопарке. Введите снова:");
                animalType = Console.ReadLine() ?? "";
            }

            return animalType;
        }

        public static string ThingsMenue(ref Zoo zoo)
        {
            List<string> thingTypes = zoo.ThingTypes();
            for (int i = 0; i < thingTypes.Count; ++i)
            {
                Console.WriteLine($"    {i + 1}. {thingTypes[i]}");
            }

            Console.Write("Введите тип вещи: ");
            string thingType = Console.ReadLine() ?? "";
            while (thingTypes.Contains(thingType))
            {
                Console.Write("Введённый тип не содержится в этом зоопарке. Введите снова:");
                thingType = Console.ReadLine() ?? "";
            }

            return thingType;
        }

        public static string GetName()
        {
            Console.Write("Введите имя животного: ");
            string name = Console.ReadLine() ?? "";

            return name;
        }

        public static int GetAmountOfFood()
        {
            Console.Write("Введите количество еды: ");
            int amound;
            while (!int.TryParse(Console.ReadLine(), out amound) && !(0 <= amound))
            {
                Console.Write("Введите корректное значение: ");
            }

            return amound;
        }

        public static int GetKindness()
        {
            Console.Write("Введите доброту животного: ");
            int kindness;
            while (!int.TryParse(Console.ReadLine(), out kindness) && !(1 <= kindness && kindness <= 10))
            {
                Console.Write("Введите корректное значение доброты: ");
            }

            return kindness;
        }

        public static int GetNumber()
        {
            Console.Write("Введите количество: ");
            int number;
            while (!int.TryParse(Console.ReadLine(), out number) && !(number >= 0))
            {
                Console.Write("Введите корректное значение: ");
            }

            return number;
        }
    }
}