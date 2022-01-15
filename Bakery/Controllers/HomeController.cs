using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System;
namespace Bakery.Controllers
{
  public class HomeController : Controller
  {
    private readonly skylar_brockbankContext _db;
    public HomeController(skylar_brockbankContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      ViewBag.CategoryOptions = _db.Flavors.ToList();
      List<Treat> listOut = _db.Treats.ToList();
      return View(listOut);
    }
    [HttpPost]
    public ActionResult Index(int category)
    {
      Console.WriteLine(category);
      List<Treat> listOut = new List<Treat>();
      ViewBag.CategoryOptions = _db.Flavors.ToList();
      if(category==0)
      {
        listOut = _db.Treats.ToList();
      }else
      {
        Flavor target = _db.Flavors
          .Include(f =>f.Treats)
          .ThenInclude(f=>f.Treat)
          .FirstOrDefault(f=>f.FlavorId == category);
        foreach (FlavorTreat t in target.Treats)
        {
          listOut.Add(t.Treat);
        }
      }
      return View(listOut);
    }
  }
}