using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class UserSettings
    {
    }
}

public class Dnd
{
    public int dndstart { get; set; }
    public int dndstop { get; set; }
}

public class JokeCategory
{
    public int programming { get; set; }
    public int miscellaneous { get; set; }
    public int dark { get; set; }
    public int pun { get; set; }
    public int spooky { get; set; }
    public int christmas { get; set; }
}

public class Root
{
    public int time { get; set; }
    public int jokeInterval { get; set; }
    public string jokeSelection { get; set; }
    public string jokeSelection1 { get; set; }
    public int pic { get; set; }
    public List<Dnd> dnd { get; set; }
    public object name { get; set; }
    public JokeCategory jokeCategory { get; set; }
    public List<object> blacklist { get; set; }
}
