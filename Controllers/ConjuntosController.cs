using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ConjuntosController : Controller
{
    private IConjuntosData ConjuntosData;
    private IMotoristasData MotoristasData;

    public ConjuntosController (IConjuntosData ConjuntosData, IMotoristasData MotoristasData)
    {
        this.ConjuntosData = ConjuntosData;
        this.MotoristasData = MotoristasData;
    }



    /*
    ----- INDEX -----
    */
    public ActionResult Index()
    {
        List<Conjuntos> conjuntos = ConjuntosData.Read();

        return View(conjuntos);
    }

    public ActionResult Search(IFormCollection FormConjuntos)
    {
        string search = FormConjuntos["search"];

        List<Conjuntos> conjuntos = ConjuntosData.Read(search);

        return View("index", conjuntos);
    }


    /*
    ----- CREATE -----
    */
    [HttpGet]
    public ActionResult Create()
    {
        ViewBag.Motoristas = MotoristasData.Read().Select(c => new SelectListItem()
            {
                Text = c.NomeMotorista,
                Value = c.IdMotorista.ToString()
            }).ToList();

        return View();
    }
    [HttpPost]
    public ActionResult Create(Conjuntos conjuntos)
    {
        ConjuntosData.Create(conjuntos);

        return RedirectToAction("Index");
    }
}