using BudgetingTool.Logic.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BudgetingTool.Logic
{
    public class JsonBudget : IBudget
    {
        public IEnumerable<IncomeBudgetItem> IncomeBudgetItems { get; private set; }

        public IEnumerable<OutcomeBudgetItem> OutcomeBudgetItems { get; private set; }

        [JsonConstructor]
        public JsonBudget(IEnumerable<IncomeBudgetItem> incomeBudgetItems, IEnumerable<OutcomeBudgetItem> outcomeBudgetItems)
        {
            IncomeBudgetItems = incomeBudgetItems;
            OutcomeBudgetItems = outcomeBudgetItems;
        }

        public void SaveBudget(string saveLocation)
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(this, options);

            File.WriteAllText($@"{saveLocation}", json);
        }

        public static JsonBudget LoadBudget(string filepath)
        {
            return JsonSerializer.Deserialize<JsonBudget>(File.ReadAllText(filepath));
        }
    }
}
