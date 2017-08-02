using QuestManagement.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGen.Infrastructure
{
  public class GameLog : IGameLog
  {
    private static GameLog Instance = null;
    public static GameLog instance
    {
      get
      {
        return Instance;
      }
    }

    public GameLog()
    {
      if (Instance != null && Instance != this)
        Instance = this;
      else if (Instance == null)
        Instance = this;
      else
        Console.WriteLine("What the fuck mazafuck?!");
    }

    public void Log(string msg)
    {
      Console.WriteLine(msg);
    }
  }
}
