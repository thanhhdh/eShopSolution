using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Data.Entities
{
    public class Order
    {
        public int Id { set; get; }
        public DateTime OrderDate { set; get; }
        public Guid UserId { set; get; }
        public string? ShipName { set; get; }
        public string? ShipAddress { get; set; }
        public string? ShipEmail { get; set; }
        public string? ShipPhoneNumber { set; get; }
        public OrderDetail? Status { set; get; }
        public List<OrderDetail>? OrderDetails { get; set; }
        public AppUser? AppUser { set; get; }
    }
}
