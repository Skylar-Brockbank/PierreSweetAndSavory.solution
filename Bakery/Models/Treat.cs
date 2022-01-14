namespace Bakery.Models
{
  using System.Collections.Generic;
  public class Treat
  {
    public Treat()
    {
      Flavors = new HashSet<FlavorTreat>();
    }
    public int TreatId {get;set;}
    public string Description {get;set;}
    public virtual ICollection<FlavorTreat> Flavors {get;}
  }
}