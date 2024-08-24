using BookStore.Enums;
using Microsoft.AspNetCore.Authorization;

namespace BookStore.Authentication
{
    public class HasPermissionAttribute(Permissions permission)
        : AuthorizeAttribute(policy: permission.ToString())
    {
    }
}
