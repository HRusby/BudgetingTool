using BudgetingTool.Logic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetingTool.Logic
{
    public struct BudgetSummary
    {
        public TimePeriodEnum TimePeriod { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public decimal TotalIncome { get; private set; }
        public decimal TotalOutcome { get; private set; }

        public decimal NetChange { get; private set; }

        private Dictionary<IncomeCategoryEnum, decimal> IncomeCategoryTotals;
        private Dictionary<OutcomeCategoryEnum, decimal> OutcomeCategoryTotals;

        public BudgetSummary(
            TimePeriodEnum timePeriod,
            DateTime startDate,
            DateTime endDate,
            decimal totalIncome,
            decimal totalOutcome)
        {
            TimePeriod = timePeriod;
            StartDate = startDate;
            EndDate = endDate;
            TotalIncome = totalIncome;
            TotalOutcome = totalOutcome;
            NetChange = totalIncome - totalOutcome;
            IncomeCategoryTotals = new Dictionary<IncomeCategoryEnum, decimal>();
            OutcomeCategoryTotals = new Dictionary<OutcomeCategoryEnum, decimal>();
        }

        public void AddIncomeCategoryTotal(IncomeCategoryEnum category, decimal value)
        {
            IncomeCategoryTotals.Add(category, value);
        }

        public void AddOutcomeCategoryTotal(OutcomeCategoryEnum category, decimal value)
        {
            OutcomeCategoryTotals.Add(category, value);
        }

        public Dictionary<IncomeCategoryEnum, decimal> GetReadableIncomeCategoryTotals()
        {
            return new Dictionary<IncomeCategoryEnum, decimal>(IncomeCategoryTotals);
        }

        public Dictionary<OutcomeCategoryEnum, decimal> GetReadableOutcomeCategoryTotals()
        {
            return new Dictionary<OutcomeCategoryEnum, decimal>(OutcomeCategoryTotals);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BudgetSummary:");
            sb.AppendLine($"\t Start Date: {StartDate}");
            sb.AppendLine($"\t End Date: {EndDate}");
            sb.AppendLine($"\t Income Total: {TotalIncome}");
            sb.AppendLine($"\t Outcome Total: {TotalOutcome}");
            sb.AppendLine($"\t Net Change: {NetChange}");
            sb.AppendLine($"\t Income Category Totals:");
            foreach (KeyValuePair<IncomeCategoryEnum, decimal> pair in GetReadableIncomeCategoryTotals())
            {
                sb.AppendLine($"\t\t{pair.Key} - £{pair.Value}");
            }

            sb.AppendLine($"\t Outcome Category Totals:");
            foreach (KeyValuePair<OutcomeCategoryEnum, decimal> pair in GetReadableOutcomeCategoryTotals())
            {
                sb.AppendLine($"\t\t{pair.Key} - £{pair.Value}");
            }

            return sb.ToString();
        }
    }
}