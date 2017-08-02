using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestManagement.Abstract
{
  public abstract class QuestStep
  {
    public string Description { get; set; }
    public bool Complete { get; set; }
    protected string targetDescription;

    public abstract void CheckProgress(QuestPerformerAbstract p);
    public abstract string GetTargetDescription();
  }
}
