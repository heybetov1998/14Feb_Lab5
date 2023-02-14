namespace _14Feb_Lab5
{
    internal class Atm
    {
        private int _moneyCount;
        internal double CardBalance { get; private set; }
        internal Dictionary<int, int> Moneys { get; set; } = new()
        {
            {500, 100 },
            {200, 100 },
            {100, 100 },
            {50, 100 },
            {20, 100 },
            {10, 100 },
            {5, 1 },
            {1, 0 }
        };

        internal Atm(double cardBalance)
        {
            CardBalance = cardBalance;
        }

        internal void IncreaseCardBalance(int amount)
        {
            CardBalance += amount;
            StringHelpers.WriteLineColored("Kartinizin balansi artirildi\n", ConsoleColor.Green);
        }

        internal void ShowCardBalance()
        {
            StringHelpers.WriteLineColored($"Balans: {CardBalance}AZN\n", ConsoleColor.Gray);
        }

        internal void WithdrawMoney(int amount)
        {
            Dictionary<int, int> deletedAmount = new();

            if (amount > CardBalance)
            {
                StringHelpers.WriteLineColored("Kartda yeteri qeder mebleg yoxdur\n", ConsoleColor.Red);
                return;
            }

            foreach (var keyValuePair in Moneys)
            {
                if (amount >= keyValuePair.Key && keyValuePair.Value >= (amount / keyValuePair.Key))
                {
                    _moneyCount = amount / keyValuePair.Key;
                    amount -= keyValuePair.Key * _moneyCount;
                    deletedAmount.Add(keyValuePair.Key, _moneyCount);
                }
            }

            if (amount != 0)
            {
                StringHelpers.WriteLineColored("Bankomatda chixarmaq istediyiniz meblege uygun vesait yoxdur\n", ConsoleColor.Red);
                return;
            }

            foreach (var keyValuePair in deletedAmount)
            {
                Moneys[keyValuePair.Key] -= keyValuePair.Value;
                CardBalance -= keyValuePair.Key * keyValuePair.Value;
                StringHelpers.WriteLineColored($"{keyValuePair.Key}AZN x {keyValuePair.Value}", ConsoleColor.Gray);
            }
            StringHelpers.WriteLineColored("Meblegi goture bilersiniz\n", ConsoleColor.Green);
        }
    }
}
