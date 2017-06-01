using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nop.Plugin.Pickup.Test.Data
{
    public class TestMap : NopEntityTypeConfiguration<Domain.TestRecord>
    {
        public TestMap()
        {
            ToTable("Test");
            HasKey(hw => hw.Id);
            Property(hw => hw.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(hw => hw.Message);
            //HasMany(hw => hw.ColorsList);

        }

    }
}