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
        public ActionResult List(int categoryId = 0, int supplierId = 0, string searchValue ="", int page =1)
        {

            int rowCount = 0;
            int pageSize = 10;
            var listOfProducts = ProductService.List(page, pageSize, categoryId, supplierId, searchValue, out rowCount);
            Models.ProductPaginationQueryResult model = new Models.ProductPaginationQueryResult()
            {
                Page = page,
                PageSize = pageSize,
                CategoryID = categoryId,
                SupplierID = supplierId,
                SearchValue = searchValue,
                RowCount = rowCount,
                Data = listOfProducts,
            };
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var model = ProductService.GetEx(id);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);

        }
        public ActionResult DeleteAttributes(int id, long[] attributeIds )
        {
            if (attributeIds == null)
            {
                return RedirectToAction("Edit", new { id = id });
            }
            ProductService.DeleteAttributes(attributeIds);
            return RedirectToAction("Edit", new { id = id });
        }
        public ActionResult DeleteGalleries(int id, long[] galleryIds)
        {
            if (galleryIds == null)
            {
                return RedirectToAction("Edit", new { id = id });
            }
            ProductService.DeleteGallery(galleryIds);
            return RedirectToAction("Edit", new { id = id });
        }
    }
}