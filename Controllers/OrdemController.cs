using Microsoft.AspNetCore.Mvc;

public class OrdemController : Controller
{
    private IOrdemData ordemData;

    public OrdemController(IOrdemData ordemData)
    {
        this.ordemData = ordemData;
    }

    public ActionResult Index()
    {
        return View();
    }
}