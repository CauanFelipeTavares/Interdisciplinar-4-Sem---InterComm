using Microsoft.AspNetCore.Mvc;

public class ContratosController : Controller
{
    private IContratosData ContratosData;

    public ContratosController (IContratosData ContratosData)
    {
        this.ContratosData = ContratosData;
    }
}