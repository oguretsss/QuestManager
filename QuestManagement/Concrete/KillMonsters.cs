using System;
using QuestManagement.Abstract;

namespace QuestManagement.Concrete
{
  public class KillMonsters : QuestStep
  {
    public string MonsterName { get; set; }
    public int MonsterAmount { get; set; }
    private int startAmount;

    public KillMonsters(string tDesc, string name, int amount, QuestPerformerAbstract p)
    {
      targetDescription = tDesc;
      MonsterName = name;
      MonsterAmount = amount;
      player = p;
      startAmount = p.GetKillCount(name);
      Console.WriteLine("Kill monster: {0}, initial amount (not included for tracking: {1}", name, startAmount);
    }

    public override void CheckProgress()
    {
      if (Complete) return;
      int amount = player.GetKillCount(MonsterName) - startAmount;
      Complete = amount >= MonsterAmount;
    }

    public override string GetTargetDescription()
    {
      return string.Format(targetDescription, MonsterAmount, MonsterName);
    }
  }
}
