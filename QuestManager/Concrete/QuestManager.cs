using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestManager.Abstract;

namespace QuestManager.Concrete
{
  public class QuestManager
  {

    private List<Quest> quests;

    public QuestManager()
    {
      quests = new List<Quest>();
    }

    void CheckProgress()
    {
      quests.ForEach(x => x.CheckProgress());
    }


  }
}
