﻿using QuestManagement.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestManagement.Concrete
{
  public class GetItem : QuestStep
  {
    public string ItemName { get; set; }
    public int ItemAmount { get; set; }

    public GetItem(string targetDesciption, string itemName, int amount, QuestPerformerAbstract p)
    {
      this.targetDescription = targetDesciption;
      this.ItemName = itemName;
      this.ItemAmount = amount;
      player = p;
    }
    public override void CheckProgress()
    {
      if (Complete) return;
      Complete = player.GetItemCount(ItemName) >= ItemAmount;
    }

    public override string GetTargetDescription()
    {
      return string.Format(targetDescription, ItemAmount, ItemName);
    }
  }
}
