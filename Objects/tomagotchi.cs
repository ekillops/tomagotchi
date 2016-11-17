using System.Collections.Generic;
using System;

namespace TomagotchiProgram.Objects
{
  public class Tomagotchi
  {
    private string _name;
    private int _age;
    private int _hungerLevel;
    private int _tiredLevel;
    private int _id;
    private DateTime _birthday;
    private DateTime _lastFed;
    private DateTime _startedSleeping;
    private DateTime _lastSlept;
    private bool _isAlive;
    private bool _isSleeping;

    private static List<Tomagotchi> _tomagotchiList = new List<Tomagotchi> {};

    public Tomagotchi(string name)
    {
      _birthday = DateTime.Now;
      _isAlive = true;
      _lastFed = DateTime.Now;
      _lastSlept = DateTime.Now;
      _name = name;
      _age = 0;
      _hungerLevel = 0;
      _tiredLevel = 0;
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
      _age = Convert.ToInt32(Math.Floor(DateTime.Now.Subtract(_birthday).TotalMinutes));
      return _age;
    }

    public void Feed()
    {
      _hungerLevel = 0;
      _lastFed = DateTime.Now;
    }

    public int GetHungerLevel()
    {
      DateTime feedingTime = DateTime.Now;
      _hungerLevel = Convert.ToInt32(Math.Floor(feedingTime.Subtract(_lastFed).TotalSeconds / 30));
      return _hungerLevel;
    }

    public bool GetIsAlive()
    {
      return _isAlive;
    }

    public bool GetIsSleeping()
    {
      return _isSleeping;
    }

    public void SetIsSleeping(bool sleep)
    {
      _isSleeping = sleep;
      if (_isSleeping)
      {
        _startedSleeping = DateTime.Now;
      }
    }

    public bool GetDoneSleeping()
    {
      int sleepLength = Convert.ToInt32(DateTime.Now.Subtract(_startedSleeping).TotalMinutes);
      if (sleepLength >= 2)
      {
        _isSleeping = false;
        _tiredLevel = 0;
        _lastSlept = DateTime.Now;
      }
      return _isSleeping;
    }

    public int GetTiredLevel()
    {
      return _tiredLevel;
    }

    public void SetTiredLevel()
    {
      _tiredLevel = Convert.ToInt32(Math.Floor(DateTime.Now.Subtract(_lastSlept).TotalSeconds / 30));
    }

    public void Kill()
    {
      _isAlive = false;
    }

    public void Resurrect()
    {
      _hungerLevel = 0;
      _tiredLevel = 0;
      _lastSlept = DateTime.Now;
      _lastFed = DateTime.Now;
      _isAlive = true;
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
