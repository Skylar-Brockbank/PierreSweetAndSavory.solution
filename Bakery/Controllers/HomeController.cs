using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
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
      return View();
    }
  }
}