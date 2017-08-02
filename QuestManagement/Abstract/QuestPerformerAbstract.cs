using QuestManagement.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestManagement.Abstract
{
  public abstract class QuestPerformerAbstract
  {
    public delegate void StateChangedHandler(QuestPerformerAbstract p);
    public event StateChangedHandler OnPlayerStateChanged;

    public abstract Coordinates GetCurrentLocation();
    public abstract int GetItemCount(string itemName);
    public abstract int GetKillCount(string monsterName);
    protected virtual void OnStateChanged(QuestPerformerAbstract p)
    {
      OnPlayerStateChanged?.Invoke(p);
    }
  }
}
