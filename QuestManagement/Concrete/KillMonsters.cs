using System;
using QuestManagement.Abstract;

namespace QuestManagement.Concrete
{
  public class KillMonsters : QuestStep
  {
    public string MonsterName { get; set; }
    public int MonsterAmount { get; set; }

    public KillMonsters(string tDesc, string name, int amount)
    {
      targetDescription = tDesc;
      MonsterName = name;
      MonsterAmount = amount;
    }

    public override void CheckProgress(QuestPerformerAbstract p)
    {
      if (Complete) return;
      Complete = p.GetKillCount(MonsterName) >= MonsterAmount;
    }

    public override string GetTargetDescription()
    {
      return string.Format(targetDescription, MonsterAmount, MonsterName);
    }
  }
}
