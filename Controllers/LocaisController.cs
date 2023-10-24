using Microsoft.AspNetCore.Mvc;

public class LocaisController : Controller
{
    private ILocaisData LocaisData;
    private IEnderecosData EnderecosData;

    public LocaisController(ILocaisData locaisData, IEnderecosData enderecosData){
        this.LocaisData = locaisData;
        this.EnderecosData = enderecosData;
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