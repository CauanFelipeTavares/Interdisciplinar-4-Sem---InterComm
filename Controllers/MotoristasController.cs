using Microsoft.AspNetCore.Mvc;

public class MotoristasController : Controller
{
    private IMotoristasData MotoristasData;

    public MotoristasController (IMotoristasData MotoristasData)
    {
        this.MotoristasData = MotoristasData;
    }
}