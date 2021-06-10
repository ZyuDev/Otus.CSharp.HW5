using HW5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Helpers
{
    public class ProductGenerator
    {
        public static Product Product1()
        {
            var entity = new Product()
            {
                Uid = Guid.Parse("{D56833A1-7E7F-4D52-9660-04336B4BFB05}"),
                Title = "Product 1",
                GroupId = 1,
                Price = 123.45M,
                IsAvailable = true

            };

            return entity;
        }

        public static Product Product2()
        {
            var entity = new Product()
            {
                Uid = Guid.Parse("{35BF8C50-3A55-4242-9719-1DFC0BE48599}"),
                Title = "Product 2",
                GroupId = 2,
                Price = 678.91M

            };

            return entity;
        }
    }
}
