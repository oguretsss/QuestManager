using QuestManager.Abstract;
using QuestManager.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGen
{
  public class Player : IQuestPerformer
  {
    private Coordinates location;
    private Dictionary<string, int> killTracker;
    private Dictionary<string, int> inventory;

    public Player()
    {
      location = new Coordinates(10, 12);

      killTracker = new Dictionary<string, int>();
      killTracker["zombie"] = 9;
      killTracker["Feral mutant"] = 4;
      killTracker["Bandit"] = 2;

      inventory = new Dictionary<string, int>();
      inventory["Uranium battery"] = 2;
      inventory["Dynamite"] = 3;

    }
    public Coordinates GetCurrentLocation()
    {
      return location;
    }

    public int GetKillCount(string monsterName)
    {
      int count = 0;
      killTracker.TryGetValue(monsterName, out count);

      return count;
    }

    public int GetItemCount(string itemName)
    {
      int count = 0;
      inventory.TryGetValue(itemName, out count);
      return count;
    }
  }
}
