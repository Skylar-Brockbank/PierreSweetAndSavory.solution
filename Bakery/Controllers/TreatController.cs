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
  
  public class TreatController : Controller
  {
    private readonly skylar_brockbankContext _db;
    public TreatController(skylar_brockbankContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Treat> TreatIndexList = _db.Treats.ToList();
      return View(TreatIndexList);
    }
    [Authorize]
    public ActionResult Create()
    {
      return View();
    }
    [Authorize]
    [HttpPost]
    public ActionResult Create(Treat t)
    {
      _db.Treats.Add(t);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Detail(int id)
    {
      Treat target = _db.Treats
        .Include(t=>t.Flavors)
        .ThenInclude(ft=>ft.Flavor)
        .FirstOrDefault(t=>t.TreatId == id);
      return View(target);
    }
    [Authorize]
    public ActionResult Edit(int id)
    {
      Treat target = _db.Treats
        .Include(t=>t.Flavors)
        .ThenInclude(ft=>ft.Flavor)
        .FirstOrDefault(t=>t.TreatId == id);
      ViewBag.SelectJoins = new SelectList(_db.Flavors, "FlavorId", "Description");
      return View(target);
    }
    [Authorize]
    [HttpPost]
    public ActionResult Edit(Treat t, int SelectJoins)
    {
      _db.Entry(t).State = EntityState.Modified;
      _db.SaveChanges();
      _db.Joins.Add(new FlavorTreat(){TreatId = t.TreatId, FlavorId=SelectJoins});
      _db.SaveChanges();
      
      return RedirectToAction("Edit", new{id = t.TreatId});
    }
    
    public ActionResult Delete(int id)
    {
      Treat target = _db.Treats.FirstOrDefault(t => t.TreatId == id);
      _db.Treats.Remove(target);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult DeleteLink(int id)
    {
      FlavorTreat x = _db.Joins.FirstOrDefault(join => join.FlavorTreatId == id);
      _db.Joins.Remove(x);
      _db.SaveChanges();
      return RedirectToAction("Edit","Treat", new{id = x.TreatId});
    }

  }
}