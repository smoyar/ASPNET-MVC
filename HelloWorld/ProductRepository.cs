using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching; //Use this for catching

namespace HelloWorld
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }

    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> Products
        {
            get
            {
                // Check if the MyProducts is NOT cached
                if (HttpContext.Current.Cache["MyProducts"] == null)//if (there is no catch) {}
                {
                    var items = new[]
                    {
                    new Product{ Name = "Baseball"},
                    new Product{ Name="Football"},
                    new Product{ Name="Tennis ball"} ,
                    new Product{ Name="Golf ball"},
                };
                    //No sliding means absolute catching: 30 seconds after loading, the data is catched is not catched anymore
                    HttpContext.Current.Cache.Insert("MyProducts",
                                             items,
                                             null,
                                             DateTime.Now.AddSeconds(30),
                                             Cache.NoSlidingExpiration);
                    
                    // Sliding catching: catches data every five seconds after the page is refreshed
                    HttpContext.Current.Cache.Insert("MyProducts",
                                             items,
                                             null,                                                                                                                                                                                 
                                             Cache.NoAbsoluteExpiration,
                                             new TimeSpan(0,0,5));
                }

                return (IEnumerable<Product>)HttpContext.Current.Cache["MyProducts"];
            }
        }
    }
}