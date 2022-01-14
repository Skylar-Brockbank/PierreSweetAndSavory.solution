using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
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
      return View();
    }
  }
}