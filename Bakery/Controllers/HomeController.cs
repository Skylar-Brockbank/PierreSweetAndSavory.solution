using Microsoft.AspNetCore.Mvc;

namespace Bakery.Controllers
{
  public class HomeController : Controller
  {
    private readonly Skylar_brockbankContext _db;
    public TreatController(skylar_brockbankContext db)
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