using Microsoft.AspNetCore.Mvc;

public class MotoristasController : Controller
{
    private IMotoristasData MotoristasData;

    public MotoristasController (IMotoristasData MotoristasData)
    {
        this.MotoristasData = MotoristasData;
    }

    /*
    ----- INDEX -----
    */
    public ActionResult Index()
    {
        List<Motoristas> lista = MotoristasData.Read();

        return View(lista);
    }
    //SEARCH
    public ActionResult Search(IFormCollection FormMotoristas)
    {
        string search = FormMotoristas["search"];

        List<Motoristas> motoristas = MotoristasData.Read(search);

        return View("Index", motoristas);
    }




    /*
    ----- CREATE -----
    */
    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Create(Motoristas motorista)
    {
        MotoristasData.Create(motorista);

        return RedirectToAction("Index");
    }



    /*
    ----- UPDATE -----
    */
    [HttpGet]
    public ActionResult Update(int IdMotorista)
    {
        Motoristas motorista = MotoristasData.Read(IdMotorista);

        return View(motorista);
    }
    [HttpPost]
    public ActionResult Update(Motoristas motorista)
    {
        MotoristasData.Update(motorista);

       return RedirectToAction("Index");
    }

    
}