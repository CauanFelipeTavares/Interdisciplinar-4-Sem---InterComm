using Microsoft.AspNetCore.Mvc;

public class ContratosController : Controller
{
    private IContratosData ContratosData;
    private ILocaisData LocaisData;

    public ContratosController (IContratosData ContratosData, ILocaisData LocaisData)
    {
        this.ContratosData = ContratosData;
        this.LocaisData = LocaisData;
    }

    public ActionResult Index()
    {
        List<Contratos> lista = ContratosData.Read();
        return View(lista);
    }

    public ActionResult Search(IFormCollection form)
    {
        string search = form["search"];

        List<Contratos> lista = ContratosData.Read(search);

        return View("Index", lista);
    }

    [HttpGet]
    public ActionResult Create() 
    {
        List<Locais> locais = LocaisData.Read();
        return View(locais);
    }

    [HttpPost]
    public ActionResult Create(Contratos contratos)
    {
        ContratosData.Create(contratos);
        return RedirectToAction("Index");
    }

}