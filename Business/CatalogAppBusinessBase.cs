using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using rebulanyum.CatalogApp.Data;

namespace rebulanyum.CatalogApp.Business
{
    public abstract class CatalogAppBusinessBase 
    {
        public CatalogAppContext Context { get; private set; }
        public CatalogAppBusinessBase(CatalogAppContext context)
        {
            Context = context;
        }
    }
}
