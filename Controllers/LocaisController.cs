using Microsoft.AspNetCore.Mvc;

public class LocaisController : Controller
{
    private ILocaisData LocaisData;

    public LocaisController(ILocaisData locaisData){
        this.LocaisData = locaisData;
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