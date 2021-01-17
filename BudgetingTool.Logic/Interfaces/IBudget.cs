using BudgetingTool.Logic.Abstracts;
using System.Collections.Generic;

namespace BudgetingTool.Logic.Interfaces
{
    public interface IBudget
    {
        List<ABudgetItem> BudgetItems { get; }
        void SaveBudget(string saveLocation);
    }
}