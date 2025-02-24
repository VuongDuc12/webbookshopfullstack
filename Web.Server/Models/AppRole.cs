using Microsoft.AspNetCore.Identity;

public class AppRole : IdentityRole
{
    public string Description { get; set; }

    // Một vai trò có nhiều người dùng
    public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; }
}
