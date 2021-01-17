using BudgetingTool.Logic.Abstracts;
using BudgetingTool.Logic.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace BudgetingTool.Logic
{
    public class BudgetItemConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IncomeBudgetItem).IsAssignableFrom(objectType) || typeof(OutcomeBudgetItem).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);

            bool isIncome = jsonObject["IncomeOrOutcome"].Equals(IncomeOutcomeEnum.Income);

            // Using Constructors with default values to create a default object
            ABudgetItem item;
            if (isIncome)
            {
                item = new IncomeBudgetItem(default(IncomeCategoryEnum), default(decimal), default(string), default(DateTime));
            }
            else
            {
                item = new OutcomeBudgetItem(default(OutcomeCategoryEnum), default(decimal), default(string), default(DateTime));
            }

            serializer.Populate(jsonObject.CreateReader(), item);

            return item;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
