using CrudAsp.net.Dbcontext;
using CrudAsp.net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudAsp.net.Controllers
{
    public class ProductController : Controller
    {
        private readonly CRUDDbcontext context;
        private readonly IWebHostEnvironment env;

        public ProductController(CRUDDbcontext context,IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var product = await context.products.ToListAsync();
            return View(product);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(ProductDetail productdetai)
        {

            if(productdetai.Image != null)
            {
                string folder = "images/";
                folder += Guid.NewGuid().ToString()+"_"+productdetai.Image?.FileName;
                string serverFolder =Path.Combine( env.WebRootPath,folder);

                await productdetai.Image.CopyToAsync(new FileStream(serverFolder,FileMode.Create));
                var product = new Product()
                {

                    Title = productdetai.Title,
                    Description = productdetai.Description,
                    Price = productdetai.Price,
                    CreatedDate = DateTime.Now,
                    Image = "/"+folder,
                };
                await context.products.AddAsync(product);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) {
            var product= await context.products.FindAsync(id);
            if(product == null)
            {
                return RedirectToAction("Index");
            }
            var productdetail = new ProductDetail()
            {
                Title = product.Title,
                Description=product.Description,
                Price=product.Price,
            };
            ViewData["id"] = product.Id;
            return  View(productdetail);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,ProductDetail pd)
        {
            var product = await context.products.FindAsync(id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            product.Title = pd.Title; 
            product.Description=pd.Description;
            product.Price = pd.Price;
            if(pd.Image != null)
            {
                string folder = "images/";
                folder += Guid.NewGuid().ToString() + "_" + pd.Image?.FileName;
                string serverFolder = Path.Combine(env.WebRootPath, folder);

                await pd.Image.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                string oldImage= Path.Combine(env.WebRootPath, folder);
                //if (System.IO.File.Exists(oldImage))
                //{
                //    System.IO.File.Delete(oldImage);
                //}


                product.Image = "/"+folder ;
            }

            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product=await context.products.FindAsync(id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            context.products.Remove(product);
            context.SaveChanges(true);
            return RedirectToAction("Index");
        }
    }

 
}
