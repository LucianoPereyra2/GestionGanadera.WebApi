using GestionGanadera.Entities.MicrosoftIdentity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGanadera.DataAccess.MicrosoftIdentity
{
    public class UserClamConfiguration
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.ToTable(nameof(UserClaim));
        }

    }
}
