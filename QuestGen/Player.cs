using QuestManagement.Abstract;
using QuestManagement.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGen
{
  public class Player : QuestPerformerAbstract
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
      inventory["Zombie shit"] = 9;

    }
    public override Coordinates GetCurrentLocation()
    {
      return location;
    }

    public override int GetKillCount(string monsterName)
    {
      int count = 0;
      killTracker.TryGetValue(monsterName, out count);

      return count;
    }

    public override int GetItemCount(string itemName)
    {
      int count = 0;
      inventory.TryGetValue(itemName, out count);
      return count;
    }

    public void KillMonster(string name)
    {
      if (killTracker.ContainsKey(name))
      {
        killTracker[name] += 1;
      }
      else
      {
        killTracker[name] = 1;
      }
      OnStateChanged();
    }

    public void Move(int deltaX, int deltaY)
    {
      location.X += deltaX;
      location.Y += deltaY;
      Console.WriteLine("Player move! New location is {0} : {1} ", location.X, location.Y);
      OnStateChanged();
    }

    public void AddItemToInventory(string name)
    {
      if (inventory.ContainsKey(name))
      {
        inventory[name] += 1;
      }
      else
      {
        inventory[name] = 1;
      }
      OnStateChanged();
    }

  }
}
