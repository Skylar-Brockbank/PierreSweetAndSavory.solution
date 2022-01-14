using Microsoft.AspNetCore.Mvc;

namespace Bakery.Controllers
{
  public class FlavorController : Controller
  {
    private readonly Skylar_brockbankContext _db;
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