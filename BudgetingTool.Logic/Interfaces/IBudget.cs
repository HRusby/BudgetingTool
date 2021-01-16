using System.Collections.Generic;

namespace BudgetingTool.Logic.Interfaces
{
    public interface IBudget
    {
        IEnumerable<IncomeBudgetItem> IncomeBudgetItems { get; }
        IEnumerable<OutcomeBudgetItem> OutcomeBudgetItems { get; }
        void SaveBudget(string saveLocation);
    }
}