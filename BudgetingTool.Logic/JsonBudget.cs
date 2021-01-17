using BudgetingTool.Logic.Abstracts;
using BudgetingTool.Logic.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BudgetingTool.Logic
{
    public class JsonBudget : IBudget
    {
        public List<ABudgetItem> BudgetItems { get; private set; }

        [JsonConstructor]
        public JsonBudget(IEnumerable<ABudgetItem> budgetItems)
        {
            BudgetItems = budgetItems.ToList();
        }

        public void SaveBudget(string saveLocation)
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);

            File.WriteAllText($@"{saveLocation}", json);
        }

        public static JsonBudget LoadBudget(string filepath)
        {
            return JsonConvert.DeserializeObject<JsonBudget>(File.ReadAllText(filepath));
        }

        public void AddBudgetItems(IEnumerable<ABudgetItem> newBudgetItems)
        {
            BudgetItems.AddRange(newBudgetItems);
        }
    }
}