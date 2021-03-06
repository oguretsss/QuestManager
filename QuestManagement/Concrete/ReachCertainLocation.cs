﻿using QuestManagement.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestManagement.Concrete
{
  public class ReachCertainLocation : QuestStep
  {

    private Coordinates targetLocation;

    public ReachCertainLocation(string targetDesc, Coordinates loc, QuestPerformerAbstract p)
    {
      targetDescription = targetDesc;
      targetLocation = loc;
      player = p;
    }

    public override void CheckProgress()
    {
      if (Complete) return;
      Coordinates perfLocation = player.GetCurrentLocation();
      Complete = perfLocation.X == targetLocation.X && perfLocation.Y == targetLocation.Y;
    }

    public override string GetTargetDescription()
    {
      return string.Format(targetDescription, targetLocation.X, targetLocation.Y);
    }
  }
}
