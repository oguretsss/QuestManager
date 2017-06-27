using QuestGen.Infrastructure;
using QuestManager.Concrete;
using QuestManager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGen
{
  public class QuestTester
  {
    static List<Quest> quests;
    static Player player;

    static void Main()
    {
      GameLog l = new GameLog();
      GameLog.instance.Log("Howdy ho!");

      quests = new List<Quest>();
      player = new Player();

      InitQuests();
      Console.ReadKey();
    }


    private static void InitQuests()
    {
      Quest first = new Quest(player);
      first.QuestDescription = "This is the first test quest, where you should find certain item, then reach certain location and then kill some shitty monsters!";
      first.QuestName = "My very first quest";
      first.ReceivedLocation = new Coordinates(2, 15);
      first.Reward = "A shiny new smartphone";
      first.Steps = new List<QuestStep>();

      GetItem a = new GetItem("Collect {0} pieces of {1}", "Zombie shit", 10);
      a.Description = "Get some zombie shit";
      a.ItemName = "Zombie shit";
      a.ItemAmount = 10;
      first.Steps.Add(a);

      ReachCertainLocation b = new ReachCertainLocation("You should take those zombie shit pieces to the city of Shittown, which is located at {0}; {1}", new Coordinates(10, 12));
      b.Description = "Go to the Shittown";
      first.Steps.Add(b);

      KillMonsters c = new KillMonsters("Kill {0} {1}", "Bandit", 15);
      c.Description = "Kill monsters";
      first.Steps.Add(c);

      GameLog.instance.Log("Quests initialized!");
      GameLog.instance.Log(first.ToString());
    }
  }
}
