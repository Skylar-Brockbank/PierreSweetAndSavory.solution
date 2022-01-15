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
    [Authorize]
    public ActionResult Edit(int id)
    {
      Flavor target = _db.Flavors
        .Include(f=>f.Treats)
        .ThenInclude(ft=>ft.Treat)
        .FirstOrDefault(f=>f.FlavorId == id);
      ViewBag.SelectJoins = new SelectList(_db.Treats, "TreatId", "Description");
      return View(target);
    }
    [Authorize]
    [HttpPost]
    public ActionResult Edit(Flavor f, int SelectJoins)
    {
      _db.Entry(f).State = EntityState.Modified;
      _db.SaveChanges();
      _db.Joins.Add(new FlavorTreat(){TreatId = SelectJoins, FlavorId=f.FlavorId});
      _db.SaveChanges();
      
      return RedirectToAction("Edit", new{id = f.FlavorId});
    }
    
    public ActionResult Delete(int id)
    {
      Flavor target = _db.Flavors.FirstOrDefault(f => f.FlavorId == id);
      _db.Flavors.Remove(target);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult DeleteLink(int id)
    {
      FlavorTreat x = _db.Joins.FirstOrDefault(join => join.FlavorTreatId == id);
      _db.Joins.Remove(x);
      _db.SaveChanges();
      return RedirectToAction("Edit","Flavor", new{id = x.FlavorId});
    }
  }
}