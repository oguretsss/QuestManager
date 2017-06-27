using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestManager.Abstract
{
  public abstract class QuestStep
  {
    public string Description { get; set; }
    public bool Complete { get; set; }
    protected string targetDescription;

    public abstract void CheckProgress(IQuestPerformer p);
    public abstract string GetTargetDescription();
  }
}
