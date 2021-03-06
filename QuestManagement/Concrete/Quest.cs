﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuestManagement.Abstract;
using System.Threading.Tasks;

namespace QuestManagement.Concrete
{
  public class Quest
  {
    private QuestPerformerAbstract performer;
    public string QuestName { get; set; }
    public string QuestDescription { get; set; }
    public List<QuestStep> Steps { get; set; }
    public string Reward { get; set; }
    public Coordinates ReceivedLocation { get; set; }
    public bool RewardGiven { get; set; } = false;
    public bool Complete { get; set; } = false;

    public Quest(QuestPerformerAbstract p)
    {
      performer = p;
      Steps = new List<QuestStep>();
    }

    public void CheckProgress()
    {
      //Steps.ForEach(x => x.CheckProgress(p));
      bool checkNext = true;
      foreach (QuestStep step in Steps)
      {
        if (checkNext)
        {
          step.CheckProgress();
          if (!step.Complete)
          {
            checkNext = false;
            break;
          }
        }
      }
      Complete = Steps.Count(x => !x.Complete) == 0;
      Console.WriteLine("Check Progress! "+ QuestName);
      if (Complete)
        Console.WriteLine(ToString());
    }

    public string GiveReward()
    {
      if (RewardGiven) return null;
      RewardGiven = true;
      return Reward;
    }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();

      sb.Append(string.Format("Quest: {0}\nDescription:\n{1}\n", QuestName, QuestDescription));
      sb.Append(string.Format("Reward:\n{0}\n", Reward));
      sb.Append(string.Format("Received at {0} : {1}\n", ReceivedLocation.X, ReceivedLocation.Y));
      sb.Append("Steps To Complete:\n");
      foreach (var step in Steps)
      {
        int index = Steps.FindIndex(x => x.Description == step.Description);
        sb.Append(string.Format("Step {0}. {1}. Complete: {2}\n", index, step.Description, step.Complete));
        sb.Append(string.Format("\tDescription: {0}\n", step.GetTargetDescription()));
      }
      sb.Append(string.Format("\nStatus: complete: {0}, reward received: {1}", Complete, RewardGiven));
      return sb.ToString();
    }
  }

  public struct Coordinates
  {
    public int X { get; set; }
    public int Y { get; set; }

    public Coordinates(int x, int y)
    {
      X = x;
      Y = y;
    }
  }
}
