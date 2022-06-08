using eRestoran.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestoran.WebAPI
{
    public class SetupService
    {
        public static void Init(eRestoranContext context)
        {
            //context.Database.Migrate();
        }
    }
}
