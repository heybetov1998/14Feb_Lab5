namespace _14Feb_Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Atm unibank = new(1271);
            string command;
            int insertedAmount;
            int amount;

            do
            {

                StringHelpers.WriteLineColored("[1] Balansi artir", ConsoleColor.Yellow);
                StringHelpers.WriteLineColored("[2] Pul chixar", ConsoleColor.Yellow);
                StringHelpers.WriteLineColored("[3] Balansi goster\n", ConsoleColor.Yellow);
                StringHelpers.WriteColored(">>>>> ", ConsoleColor.Blue);
                command = Console.ReadLine().Trim().ToLower();

                switch (command)
                {
                    case "1":
                        Console.Clear();

                        StringHelpers.WriteColored("Meblegi daxil et: ", ConsoleColor.Yellow);
                        insertedAmount = int.Parse(Console.ReadLine());

                        unibank.IncreaseCardBalance(insertedAmount);
                        break;
                    case "2":
                        Console.Clear();

                        StringHelpers.WriteColored("Meblegi daxil et: ", ConsoleColor.Yellow);
                        amount = int.Parse(Console.ReadLine());

                        unibank.WithdrawMoney(amount);
                        break;
                    case "3":
                        Console.Clear();
                        unibank.ShowCardBalance();
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            } while (command != "quit");
        }
    }
}