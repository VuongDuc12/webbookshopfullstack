using System;
using System.Collections.Generic;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }

    // Khóa ngoại đến User
    public string UserId { get; set; }
    public virtual AppUser User { get; set; }

    // Một đơn hàng có nhiều chi tiết
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}
