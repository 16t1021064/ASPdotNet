using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiteCommerce.BusinessLayers;
using LiteCommerce.DomainModels;

namespace LiteCommerce.Admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult List(int category = 0, int supplier = 0, string searchValue ="", int page =1)
        {
           
                int rowCount = 0;
                int pageSize = 10;
                var model = ProductService.List(page, pageSize, category, supplier, searchValue, out rowCount);
                ViewBag.RowCount = rowCount;
                ViewBag.Page = page;
                int pageCount = rowCount / pageSize;
                if (rowCount % pageSize > 0)
                    pageCount++;
                ViewBag.PageCount = pageCount;
                return View(model);
            
        }
    }
}