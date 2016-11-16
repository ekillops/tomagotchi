using Tomagotchi.Objects;
using System.Collections.Generic;
using Nancy;

namespace TomagotchiProgram
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>
      {
        List<Tomagotchi> allPets = new List<Tomagotchi> {};
        return View["index.cshtml", allPets];
      };
      Get["/tomagotchi"] = _ =>
      {
        List<Tomagotchi> allPets = new List<Tomagotchi> {};
        return View["index.cshtml", allPets];
      };
      Get["/tomagotchi/new"] = _ =>
      {
        return View["new_pet.cshtml"];
      };
      Get["/tomagotchi/clear"] = _ =>
      {
        Tomagotchi.ClearAll();
        return View["/tomagotchi"];
      };
      Post["/tomagotchi"] = _ =>
      {
        Tomagotchi newPet = new Tomagotchi(Request.Form["name"]);
        List<Tomagotchi> allPets = new List<Tomagotchi> {};
        return View["index.cshtml", allPets];
      };
    }
  }
}
