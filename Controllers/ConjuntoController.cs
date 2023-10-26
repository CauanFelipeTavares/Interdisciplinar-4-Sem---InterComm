using Microsoft.AspNetCore.Mvc;

public class ConjuntoController : Controller
{
    private IConjuntoData ConjuntoData;

    public ConjuntoController (IConjuntoData ConjuntoData)
    {
        this.ConjuntoData = ConjuntoData;
    }
}