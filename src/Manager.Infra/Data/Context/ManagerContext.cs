using Manager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Data.Context
{
    public class ManagerContext : DbContext
    {
        public ManagerContext()
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
