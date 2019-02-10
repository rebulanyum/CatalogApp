using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using rebulanyum.CatalogApp.Data;
using rebulanyum.CatalogApp.WebSite.Models;

namespace rebulanyum.CatalogApp.WebSite.Controllers
{
    public class ProductController : Controller
    {
        CatalogAppAPIConfig config;
        public ProductController(IOptions<CatalogAppAPIConfig> config)
        {
            this.config = config.Value;
        }
        public IActionResult Index()
        {
            ViewData["apiBase"] = config.APIBaseAddress;
            return View();
        }

        public IActionResult Create()
        {
            ViewData["apiBase"] = config.APIBaseAddress;
            return View();
        }

        public IActionResult View(int id)
        {
            ViewData["apiBase"] = config.APIBaseAddress;
            return View(new Product() { Id = id });
        }

        public IActionResult Edit(int id)
        {
            ViewData["apiBase"] = config.APIBaseAddress;
            return View(new Product() { Id = id });
        }

        public IActionResult Delete(int id)
        {
            ViewData["apiBase"] = config.APIBaseAddress;
            return View(new Product() { Id = id });
        }
    }
}
