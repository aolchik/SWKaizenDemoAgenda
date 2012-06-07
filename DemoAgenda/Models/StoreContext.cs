using System.Data.Entity;
using DemoAgenda.Models;


public interface IStoreContext
{
    IDbSet<Evento> Eventos { get; }
    int SaveChanges();
}

public class StoreContext : DbContext, IStoreContext
{
    public IDbSet<Evento> Eventos { get; set; }
}