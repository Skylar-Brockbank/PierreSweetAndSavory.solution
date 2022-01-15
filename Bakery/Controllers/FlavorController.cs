using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;
using System;

namespace Bakery.Controllers
{
  
  public class FlavorController : Controller
  {
    private readonly skylar_brockbankContext _db;
    public FlavorController(skylar_brockbankContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Flavor> FlavorIndexList = _db.Flavors.ToList();
      return View(FlavorIndexList);
    }
    [Authorize]
    public ActionResult Create()
    {
      return View();
    }
    [Authorize]
    [HttpPost]
    public ActionResult Create(Flavor f)
    {
      _db.Flavors.Add(f);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Detail(int id)
    {
      Flavor target = _db.Flavors
        .Include(f => f.Treats)
        .ThenInclude(ft => ft.Treat)
        .FirstOrDefault(f => f.FlavorId == id);
      return View(target);
    }
  }
}