using PizzaMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMAUI.Services
{
    public class PizzaService
    {
        private readonly static IEnumerable<Pizza> _pizzas = new
            List<Pizza> 
        {
            new Pizza
            {
                Name = "pizza 1",
                Image = "pizza1.png",
                Price = 100,
            },
            new Pizza
            {
                Name = "pizza 2",
                Image = "pizza1.png",
                Price = 55,
            },
            new Pizza
            {
                Name = "pizza 3",
                Image = "pizza1.png",
                Price = 75,
            },
            new Pizza
            {
                Name = "pizza 4",
                Image = "pizza1.png",
                Price = 180,
            },
            new Pizza
            {
                Name = "pizza 5",
                Image = "pizza1.png",
                Price = 108,
            },
            new Pizza
            {
                Name = "pizza 6",
                Image = "pizza1.png",
                Price = 118,
            },
            new Pizza
            {
                Name = "pizza 7",
                Image = "pizza1.png",
                Price = 95,
            },
            new Pizza
            {
                Name = "pizza 8",
                Image = "pizza1.png",
                Price = 80,
            },
            new Pizza
            {
                Name = "pizza 9",
                Image = "pizza1.png",
                Price = 130,
            },
            new Pizza
            {
                Name = "pizza 10",
                Image = "pizza1.png",
                Price = 108,
            }
        };

        public IEnumerable<Pizza> GetAllPizzas() => _pizzas;
        public IEnumerable<Pizza> GetPopularPizzas(int count = 6) => 
            _pizzas.OrderBy(p => Guid.NewGuid()).Take(count);

        public IEnumerable<Pizza> SearchPizzas(string searchTerm) =>
            string.IsNullOrEmpty(searchTerm) ? _pizzas
            : _pizzas.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }
}
