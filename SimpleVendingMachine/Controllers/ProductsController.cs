using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleVendingMachine.Models;

namespace SimpleVendingMachine.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static Product[] products = new Product[3];

        private static readonly string[] Names = new[]
        {
            "Soda", "Candy Bar", "Chips"
        };
        private static readonly double[] Costs = new[]
        {
            0.95, 0.60, 0.99
        };
        private static int[] Quantities = new[]
        {
            new Random().Next(5, 11),
            new Random().Next(5, 11),
            new Random().Next(5, 11)
        };

        private static void PopulateProducts()
        {
            products = new Product[3];
            for (int i = 0; i < 3; i++)
            {
                Product product = new Product();
                product.Id = i;
                product.Name = Names[i];
                product.Cost = Costs[i];
                product.Quantity = Quantities[i];
                products[i] = product;
            }
        }


        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }


        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            //return await _context.Products.ToListAsync();

            if (products[0] == null)
            {
                PopulateProducts();
            }

            return products;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            if (products[id].Id == -1)
            {
                PopulateProducts();
            }
            var product = new Product();

            if (id > -1 && id < 3)
            {
                product = products[id];
            } else
            {
                return NotFound();
            }

            return product;
        }


        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            Product p = new Product();
            p.Id = product.Id;
            p.Name = product.Name;
            p.Cost = product.Cost;
            p.Quantity = product.Quantity;
            products[p.Id] = p;

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id < 0 || id > 2)
            {
                return BadRequest();
            }

            products[id].Quantity = product.Quantity;

            return NoContent();
        }
    }
}
