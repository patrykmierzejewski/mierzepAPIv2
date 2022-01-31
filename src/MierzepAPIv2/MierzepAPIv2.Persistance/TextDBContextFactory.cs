using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Persistance
{
    public class TextDBContextFactory : DesignTimeDbContextFactoryBase<TextDBContext>
    {
        protected override TextDBContext CreateNewInstance(DbContextOptions<TextDBContext> options)
        {
            return new TextDBContext(options);
        }
    }
}
