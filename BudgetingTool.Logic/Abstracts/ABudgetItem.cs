using BudgetingTool.Logic.Enums;
using BudgetingTool.Logic.Interfaces;
using Newtonsoft.Json;
using System;

namespace BudgetingTool.Logic.Abstracts
{
    [JsonConverter(typeof(BudgetItemConverter))]
    public abstract class ABudgetItem : IBudgetItem
    {
        public IncomeOutcomeEnum IncomeOrOutcome { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public DateTime ItemDate { get; private set; }

        public ABudgetItem(IncomeOutcomeEnum cashType, decimal value, string description, DateTime itemDate)
        {
            IncomeOrOutcome = cashType;
            Value = value;
            Description = description;
            ItemDate = itemDate;
        }

        public void UpdateValue(decimal value) { Value = value; }
        public void UpdateDescription(string description) { Description = description; }
        public void UpdateItemDate(DateTime itemDate) { ItemDate = itemDate; }
    }
}