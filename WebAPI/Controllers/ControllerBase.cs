using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using rebulanyum.CatalogApp.Business;
using rebulanyum.CatalogApp.Data;
using MvcControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;

namespace WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public abstract class ControllerBase : MvcControllerBase
    {
        
    }
}