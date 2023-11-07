using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

public class LocaisController : Controller
{
    private ILocaisData LocaisData;

    public LocaisController (ILocaisData LocaisData)
    {
        this.LocaisData = LocaisData;
    }

    public ActionResult Index ()
    {
        List<Locais> lista = LocaisData.Read();
        return View(lista);
    }

    public ActionResult Search (IFormCollection form)
    {
        string search = form["search"];

        List<Locais> lista = LocaisData.Read(search);
        return View("Index", lista);
    }

    [HttpGet]
    public ActionResult Create() 
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Locais locais)
    {
        LocaisData.Create(locais);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult Update(int id)
    {
        Locais locais = LocaisData.Read(id);

        if(locais == null)
            return RedirectToAction("Index");

        return View(locais);
    }

    [HttpPost]
    public ActionResult Update(Locais local)
    {
        LocaisData.Update(local);
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id) 
    {
        LocaisData.Delete(id);
        return RedirectToAction("Index");
    }

    public JsonResult Responsaveis(int CodLocal)
    {
        List<Responsaveis> responsaveis = LocaisData.ReadResponaveis(CodLocal);

        return Json(responsaveis);
    }

    public JsonResult CreateResponsavel(Responsaveis responsaveis)
    {
        Responsaveis newResponsavel = LocaisData.CreateResponsaveis(responsaveis);

        return Json(newResponsavel);
    }

    public void DeleteResponsavel(int id)
    {
        
    }
}