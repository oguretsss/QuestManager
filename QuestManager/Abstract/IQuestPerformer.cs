using QuestManager.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestManager.Abstract
{
  public interface IQuestPerformer
  {
    Coordinates GetCurrentLocation();
    int GetItemCount(string itemName);
    int GetKillCount(string monsterName);
  }
}
