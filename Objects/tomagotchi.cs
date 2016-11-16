namespace Tomagotchi.Objects
{
  public class Tomagotchi
  {
    private string _name;
    private int _age;
    private int _hungerLevel;
    private int _id;

    private static List<Tomagotchi> _tomagotchiList = new List<Tomagotchi> {};

    public Tomagotchi(string name)
    {
      _name = name;
      _age = 0;
      _hungerLevel = 10;
      _tomagotchiList.Add(this);
      _id = _tomagotchiList.Count;
    }

    public void SetName(string name)
    {
      _name = name;
    }
    public string GetName()
    {
      return _name;
    }

    public void SetAge(int age)
    {
      _age = age;
    }
    public int GetAge()
    {
      return _age;
    }

    public void SetHungerLevel(int level)
    {
      _hungerLevel = level;
    }
    public int GetHungerLevel()
    {
      return _hungerLevel;
    }

    public int GetID()
    {
      return _id;
    }

    public static Tomagotchi FindByID(int idNumber)
    {
      return _tomagotchiList[idNumber -1];
    }

    public static List<Tomagotchi> GetAll()
    {
      return _tomagotchiList;
    }
    
    public static void ClearAll()
    {
      _tomagotchiList.Clear();
    }
  }
}
