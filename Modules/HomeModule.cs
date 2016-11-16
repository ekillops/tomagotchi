using TomagotchiProgram.Objects;
using System.Collections.Generic;
using System;
using Nancy;

namespace TomagotchiProgram
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>
      {
        List<Tomagotchi> allPets = Tomagotchi.GetAll();
        return View["index.cshtml", allPets];
      };
      Get["/tomagotchi"] = _ =>
      {
        List<Tomagotchi> allPets = Tomagotchi.GetAll();
        return View["index.cshtml", allPets];
      };
      Get["/tomagotchi/new"] = _ =>
      {
        return View["new_pet.cshtml"];
      };
      Get["/tomagotchi/{id}"] = parameters =>
      {
        Tomagotchi currentPet = Tomagotchi.FindByID(parameters.id);
        if (currentPet.GetHungerLevel() >= 20)
        {
          currentPet.Kill();
        }
        return View["pet.cshtml", currentPet];
      };
      Get["/tomagotchi/clear"] = _ =>
      {
        Tomagotchi.ClearAll();
        return View["/tomagotchi"];
      };
      Get["/tomagotchi/{id}/feed"] = parameters =>
      {
        Tomagotchi currentPet = Tomagotchi.FindByID(parameters.id);
        currentPet.Feed();
        return View["pet.cshtml", currentPet];
      };
      Post["/tomagotchi"] = _ =>
      {
        Tomagotchi newPet = new Tomagotchi(Request.Form["name"]);
        List<Tomagotchi> allPets = Tomagotchi.GetAll();
        return View["index.cshtml", allPets];
      };
      Get["/tomagotchi/necronomicon"] = _ =>
      {
        List<Tomagotchi> allPets = Tomagotchi.GetAll();
        foreach (Tomagotchi pet in allPets)
        {
          pet.Resurrect();
        }
        return View["index.cshtml", allPets];
      };
    }
  }
}
