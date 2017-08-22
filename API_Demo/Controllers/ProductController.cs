using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_Demo.Models;

namespace API_Demo.Controllers
{
    public class ProductController : ApiController
    {
        [HttpPut()]
        public IHttpActionResult Put(Product product)
        {
            IHttpActionResult ret = null;
            if (Update(product))
            {
                ret = Ok(product);
            }
            else
            {
                ret = NotFound();
            }
            return ret;
        }

        private bool Update(Product product)
        {
            return true;
        }

        [HttpGet()]
        public IHttpActionResult Get()
        {
            IHttpActionResult ret = null;
            List<Product> list = new List<Product>();
            list = CreateMockData();
            var q = Request.GetQueryNameValuePairs().SingleOrDefault(n => n.Key == "viewWeek");
            if (q.Value == "1")
            {
                list[0].Sale = 100;
                list[1].Sale = 115;
                list[2].Sale = 150;
            }

            if (list.Count > 0)
            {
                ret = Ok(list);
            }
            else
            {
                ret = NotFound();
            }
            return ret;
        }

        [HttpGet()]
        public IHttpActionResult Get(int id)
        {
            IHttpActionResult ret;
            List<Product> list = new List<Product>();
            Product prod = new Product();

            list = CreateMockData();
            prod = list.Find(p => p.ProductId == id);
            if (prod == null)
            {
                ret = NotFound();
            }
            else {
                ret = Ok(prod);
            }

            return ret;
        }

        [HttpPost()]
        public IHttpActionResult Post(Product product)
        {
            IHttpActionResult ret = null;
            if (Add(product))
            {
                ret = Created<Product>(Request.RequestUri +
                     product.ProductId.ToString(), product);
            }
            else
            {
                ret = NotFound();
            }
            return ret;
        }

        private bool Add(Product product)
        {
            int newId = 0;
            List<Product> list = new List<Product>();
            list = CreateMockData();

            newId = list.Max(p => p.ProductId);
            newId++;
            product.ProductId = newId;
            list.Add(product);
            // TODO: Change to ‘ false ’ to test NotFound()
            return true;
        }

        private List<Product> CreateMockData()
        {
            List<Product> ret = new List<Product>();
            ret.Add(new Product()
            {
                ProductId = 1,
                ProductName = "Extending Bootstrap with CSS, JavaScript and jQuery",
                IntroductionDate = Convert.ToDateTime("6/11/2015"),
                Url = "http://bit.ly/1SNzc0i", 
                Sale = 5
            });

            ret.Add(new Product()
            {
                ProductId = 2,
                ProductName = "Build your own Bootstrap Business Application Template in MVC",
                IntroductionDate = Convert.ToDateTime("1/29/2015"),
                Url = "http://bit.ly/1I8ZqZg",
                Sale = 10
            });

            ret.Add(new Product()
            {
                ProductId = 3,
                ProductName = "Building Mobile Web Sites Using Web Forms, Bootstrap, and HTML5",
                IntroductionDate = Convert.ToDateTime("8/28/2014"),
                Url = "http://bit.ly/1J2dcrj",
                Sale = 15
            });

            return ret;
        }
    }
}
