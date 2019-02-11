using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using rebulanyum.CatalogApp.Data;

namespace rebulanyum.CatalogApp.Business.V2
{
    /// <summary>
    /// Base class for Business classes.
    /// </summary>
    public abstract class CatalogAppBusinessBase 
    {
        /// <summary>
        /// The reference to the store.
        /// </summary>
        public CatalogAppContext Context { get; private set; }
        public CatalogAppBusinessBase(CatalogAppContext context)
        {
            Context = context;
        }
    }
}
