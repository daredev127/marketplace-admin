namespace Marketplace.Admin.Application.Dtos.ThirdParty
{
    public class OrderDto
    {
        public string Seller_Name { get; set; }
        public DateTime Created_At { get; set; }
        public IEnumerable<OrderItemDto> Order_Lines { get; set; }
        public ShippingAddressDto Shipping_Address { get; set; }
    }
}
