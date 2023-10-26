using Microsoft.AspNetCore.Mvc;

public class ContratosController : Controller
{
    private IContratosData ContratosData;

    public ContratosController (IContratosData ContratosData)
    {
        this.ContratosData = ContratosData;
    }

    public ActionResult Index()
    {
        List<Contratos> lista = ContratosData.Read();
        return View(lista);
    }
}