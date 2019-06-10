using System.Collections.Generic;
using System.Text;

namespace CashMachine
{
    public class CashExchanger
    {
        private int[] banknotes;
        private List<string> listOfCombinations;
        
        public CashExchanger(int[] banknotes)
        {
            this.banknotes = banknotes;
            listOfCombinations = new List<string>();
        }

        public List<string> Exchange(int sum)
        {
            listOfCombinations.Clear();
            MakeCombinations(sum, banknotes.Length - 1, "");
            return listOfCombinations;
        }

        private void MakeCombinations(int sum, int coinIndex, string combination)
        {
            if (sum < 0)
            {
                return;
            }

            if (sum == 0)
            {
                listOfCombinations.Add(combination);
                return;
            }

            if (coinIndex == 0)
            {
                int inclusionNumber = sum / banknotes[coinIndex];
                if (sum % banknotes[coinIndex] == 0)
                {
                    listOfCombinations.Add(combination + LastCombination(inclusionNumber, coinIndex));
                    return;
                }

                return;
            }

            for (int i = 0; i <= sum/banknotes[coinIndex]; i++)
            {
                MakeCombinations(sum - i * banknotes[coinIndex], coinIndex - 1, combination + LastCombination(i, coinIndex));
            }

        }

        private string LastCombination(int numberOfInclusion, int index)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < numberOfInclusion; i++)
            {
                stringBuilder.Append(banknotes[index].ToString()).Append(" ");
            }

            return stringBuilder.ToString();
        }
    }
}