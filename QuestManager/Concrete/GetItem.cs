using QuestManager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestManager.Concrete
{
  public class GetItem : QuestStep
  {
    public string ItemName { get; set; }
    public int ItemAmount { get; set; }

    public GetItem(string targetDesciption, string itemName, int amount)
    {
      this.targetDescription = targetDesciption;
      this.ItemName = itemName;
      this.ItemAmount = amount;
    }
    public override void CheckProgress(IQuestPerformer p)
    {
      Complete = p.GetItemCount(ItemName) >= ItemAmount;
    }

    public override string GetTargetDescription()
    {
      return string.Format(targetDescription, ItemAmount, ItemName);
    }
  }
}
