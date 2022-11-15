using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeBlu.Data
{
    public class CodeBluingDbContext : IdentityDbContext
    {
        public CodeBluingDbContext(DbContextOptions<CodeBluingDbContext> options)
            : base(options)
        {
        }
    }
}