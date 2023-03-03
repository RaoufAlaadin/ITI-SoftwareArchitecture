using CompanDBAPP.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CompanDBAPP.Configuration
{
    public class ClientEntityConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Client> EntityBuilder)
        {
            EntityBuilder.Ignore(C => C.TimeStamp).HasKey(C => C.CID);

            EntityBuilder.Property(C => C.FName).HasMaxLength(50);

        }
    }
}
