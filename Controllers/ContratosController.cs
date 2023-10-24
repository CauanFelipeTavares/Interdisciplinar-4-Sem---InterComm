using Microsoft.AspNetCore.Mvc;

public class ContratosController : Controller
{
    private IContratosData ContratosData;

    public ContratosController(IContratosData contratosData)
    {
        ContratosData = contratosData;
    }

    public ActionResult Index()
    {
        return View();
    }

    public ActionResult Adicionar()
    {
        return View();
    }
}