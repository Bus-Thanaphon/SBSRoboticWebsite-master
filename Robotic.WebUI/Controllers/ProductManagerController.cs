using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Robotic.Core.Contracts;
using Robotic.Core.Models;
using Robotic.DataAccess.InMemory;


namespace Robotic.WecUI.Controllers
{
    public class ProductManagerController : Controller
    {
        IRepository<Product> context;

        public ProductManagerController(IRepository<Product> prodectContext)
        {
            context = prodectContext;
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }


        public ActionResult Create( int no = 0)
        {
            Product product = new Product();
            var lastNo = context.Collection().OrderByDescending(c => c.No).FirstOrDefault();
            if (no != 0)
            {
                product = context.Collection().Where(x => x.No == no).FirstOrDefault<Product>();
            }
            else if (lastNo == null)
            {
                product.No = 1;
            }
            else
            {
                product.No = lastNo.No + 1;
                //product.UNo = "ID" + (lastNo.No + 1).ToString();
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.Commit();

                return RedirectToAction("index");
            }
        }

        public ActionResult Details(string Id)
        {
            Product productToView = context.Find(Id);
            if (productToView == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToView);
            }

        }

        public ActionResult AddQuantity(string Id)
        {
            Product productAdd = context.Find(Id);
            if (productAdd == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productAdd);
            }

        }

        [HttpPost]
        public ActionResult AddQuantity(Product product, string Id)
        {
            Product productAdd = context.Find(Id);
            if (productAdd == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                productAdd.Quantity = productAdd.Quantity + product.Quantity;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult UseProduct(string Id)
        {
            Product productuse = context.Find(Id);
            if (productuse == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productuse);
            }

        }

        [HttpPost]
        public ActionResult UseProduct(Product product, string Id)
        {
            Product productuse = context.Find(Id);
            if (productuse == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                productuse.Quantity = productuse.Quantity - 1;

                if (productuse.Quantity < 0)
                {
                    ModelState.AddModelError("Quantity","ไม่สามารถใช้เพิ่มได้");
                    return View(product);
                }
                else
                {
                    context.Commit();

                    return Redirect(Request.UrlReferrer.ToString());
                }
            }
        }

        public ActionResult Edit(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product, string Id)
        {
            Product productToEdit = context.Find(Id);
            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                productToEdit.No = product.No;
                productToEdit.PurchaseID = product.PurchaseID;
                productToEdit.Name = product.Name;
                productToEdit.Category = product.Category;
                productToEdit.Color_Principle = product.Color_Principle;
                productToEdit.Grain = product.Grain;
                productToEdit.Thickness = product.Thickness;
                productToEdit.Quantity = product.Quantity;
                productToEdit.Description = product.Description;
                productToEdit.Dimention_Weight = product.Dimention_Weight;
                productToEdit.Dimention_Height = product.Dimention_Height;
                productToEdit.Note = product.Note;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(Product product, string Id)
        {
            Product productToDelete = context.Find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Product productToDelete = context.Find(Id);

            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}