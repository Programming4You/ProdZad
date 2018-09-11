using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ProductApp.Core;
using ProductApp.Infrastructure;


namespace ProductApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepository _db = new ProductRepository();
        private readonly CategoryRepository _catDb = new CategoryRepository();

        // GET: Products
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.ProductNameSortParm = String.IsNullOrEmpty(sortOrder) ? "product_name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.CategoryNameSortParm = String.IsNullOrEmpty(sortOrder) ? "category_name_desc" : "";
            ViewBag.CreatedSortParm = sortOrder == "Created" ? "created_desc" : "Created";
            ViewBag.ModifiededSortParm = sortOrder == "Modified" ? "modified_desc" : "Modifieded";

            var products = from p in _db.GetProducts()
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString));
            }
            

            switch (sortOrder)
            {
                case "product_name_desc":
                    products = products.OrderByDescending(p => p.Name);
                    break;
                case "Price":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                case "category_name_desc":
                    products = products.OrderByDescending(p => p.Category.Name);
                    break;
                case "Created":
                    products = products.OrderBy(p => p.Created);
                    break;
                case "created_desc":
                    products = products.OrderByDescending(p => p.Created);
                    break;
                case "Modified":
                    products = products.OrderBy(p => p.Modified);
                    break;
                case "modified_desc":
                    products = products.OrderByDescending(p => p.Modified);
                    break;
                default:
                    products = products.OrderBy(p => p.Name);
                    break;
            }

            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.FindById(Convert.ToInt32(id));
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.category = _catDb.GetCategories();
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,CategoryId,IsActive,Created,Modified")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.Created = DateTime.Now;
                _db.Add(product);

                TempData["Success"] = "Added Successfully";
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.FindById(Convert.ToInt32(id));
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.category = _catDb.GetCategories();
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,CategoryId,IsActive,Created,Modified")] Product product)
        {
            
            if (ModelState.IsValid)
            {
                product.Modified = DateTime.Now;
                _db.Edit(product);

                TempData["Success"] = "Updated Successfully";
                return RedirectToAction("Index");
            }
          
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.FindById(Convert.ToInt32(id));
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _db.Remove(id);

            TempData["Success"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
