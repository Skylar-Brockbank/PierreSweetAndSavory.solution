using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
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
      return View();
    }
  }
}