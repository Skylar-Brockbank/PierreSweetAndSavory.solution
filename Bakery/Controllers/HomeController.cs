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
      return View();
    }
    [HttpPost]
    public ActionResult Index(int CategoryOptions)
    {
      if(CategoryOptions==0)
      {
        List<Treat> listOut = _db.Treats.ToList();
      }else
      {
        Flavor target = _db.Flavors
          .Include(f =>f.Treats)
          .ThenInclude(f=>f.Treat)
          .FirstOrDefault(f=>f.FlavorId == CategoryOptions);
        List<Treat> listOut = target.Treats;
      }
      return View(listOut);
    }
  }
}