using Microsoft.AspNetCore.Identity;

public class AppUser : IdentityUser
{
    public string FullName { get; set; }
    public string Address { get; set; }

    // Một user có nhiều đơn hàng
    public virtual ICollection<Order> Orders { get; set; }
}
