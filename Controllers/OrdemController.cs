using Microsoft.AspNetCore.Mvc;

public class OrdemController : Controller
{
    private IOrdemData OrdemData;

    public OrdemController (IOrdemData OrdemData)
    {
        this.OrdemData = OrdemData;
    }
}