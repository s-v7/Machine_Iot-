using Microsoft.EntityFrameworkCore;

namespace MachineWebApi.Models;

public class MachineIotContext : DbContext
{
    public MachineIotContext(DbContextOptions<MachineIotContext> options) : base(options)
    {
    }

    public DbSet<MachineIot> machineIots { get; set; }
}