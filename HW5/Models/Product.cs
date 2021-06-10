using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Models
{
    public class Product
    {
        public Guid Uid { get; set; } 
        public string Title { get; set; }
        public int GroupId { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Uid.Equals(product.Uid) &&
                   Title == product.Title &&
                   GroupId == product.GroupId &&
                   Price == product.Price &&
                   IsAvailable == product.IsAvailable;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Uid, Title, GroupId, Price, IsAvailable);
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
