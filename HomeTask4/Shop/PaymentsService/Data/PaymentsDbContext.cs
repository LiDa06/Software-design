using Microsoft.EntityFrameworkCore;

namespace PaymentsService.Data;

public class PaymentsDbContext(DbContextOptions<PaymentsDbContext> options) : DbContext(options)
{
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<InboxMessage> Inbox => Set<InboxMessage>();
}
