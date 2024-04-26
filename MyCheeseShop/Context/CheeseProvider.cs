using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Context;
using MyCheeseShop.Model;

public class CheeseProvider
{
    private readonly DatabaseContext _context;

    public CheeseProvider(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<Cheese>> GetAllCheesesAsync()
    {
       var cheeses =  await _context.Cheeses.OrderBy(cheese  => cheese.Name).ToListAsync();
        return cheeses;
    }

    public Cheese? GetCheese(int id)
    {
        return _context.Cheeses.Find(id);
    }

}
