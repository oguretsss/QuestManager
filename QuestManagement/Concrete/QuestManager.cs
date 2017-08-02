using System.Collections.Generic;
using QuestManagement.Abstract;

namespace QuestManagement.Concrete
{
  public class QuestManager
  {

    private List<Quest> quests;
    public List<Quest> ActiveQuests;
    private QuestPerformerAbstract player;
    private IGameLog logger;

    public QuestManager(QuestPerformerAbstract p, IGameLog l)
    {
      quests = new List<Quest>();
      ActiveQuests = new List<Quest>();
      player = p;
      logger = l;
      p.OnPlayerStateChanged += CheckProgress;
      GenerateQuests();
    }

    void CheckProgress(QuestPerformerAbstract p)
    {
      ActiveQuests.ForEach(x => x.CheckProgress(p));
    }

    /// <summary>
    /// Load full list of Quests
    /// </summary>
    public void LoadActive()
    {
      logger.Log("Quests initialized!");
    }

    public void GenerateQuests()
    {
      Quest first = new Quest(player);
      first.QuestDescription = "This is the first test quest, where you should find certain item, then reach certain location and then kill some shitty monsters!";
      first.QuestName = "My very first quest";
      first.ReceivedLocation = new Coordinates(2, 15);
      first.Reward = "A shiny new smartphone";

      GetItem a = new GetItem("Collect {0} pieces of {1}", "Zombie shit", 10);
      a.Description = "Get some zombie shit";
      a.ItemName = "Zombie shit";
      first.Steps.Add(a);

      ReachCertainLocation b = new ReachCertainLocation("You should take those zombie shit pieces to the city of Shittown, which is located at {0}; {1}", new Coordinates(10, 12));
      b.Description = "Go to the Shittown";
      first.Steps.Add(b);

      KillMonsters c = new KillMonsters("Kill {0} {1}", "Bandit", 15);
      c.Description = "Kill monsters";
      first.Steps.Add(c);

      quests.Add(first);

      Quest second = new Quest(player);
      second.QuestDescription = "Just a simple quest, to go to to PeeTown and then get some horse hair and bring it back to Location";
      second.QuestName = "Quest number two";
      second.ReceivedLocation = new Coordinates(5, 45);
      second.Reward = "Some gold";

      ReachCertainLocation a2 = new ReachCertainLocation("You should go to PeeTown, which is located at {0}; {1}", new Coordinates(10, 12));
      a2.Description = "Go to the PeeTown";
      second.Steps.Add(a2);

      GetItem b2 = new GetItem("Collect {0} pieces of {1}", "Horse hair", 2);
      b2.Description = "Get some Horse hair";
      b2.ItemName = "Horse hair";
      second.Steps.Add(b2);

      ReachCertainLocation c2 = new ReachCertainLocation("You should go to Here, which is located at {0}; {1}", new Coordinates(4, 45));
      c2.Description = "Go to the Here";
      second.Steps.Add(c2);

      quests.Add(second);
      logger.Log("Quests generated!");

    }

    public void StartQuest(string id)
    {
      Quest target = quests.Find(x => x.QuestName == id);

      if (target != null)
      {
        ActiveQuests.Add(target);
        logger.Log("Quest started: " + target.QuestName);
      }
      else
      {
        logger.Log("ERROR! Quest not found: "+id);
      }
    }

  }
}
