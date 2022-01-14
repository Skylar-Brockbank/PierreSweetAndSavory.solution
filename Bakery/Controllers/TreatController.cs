using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
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