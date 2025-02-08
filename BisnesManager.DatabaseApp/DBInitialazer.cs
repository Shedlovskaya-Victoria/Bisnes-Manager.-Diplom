using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisnesManager.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace BisnesManager.Database
{
    public static class DBInitialazer
    {
        private static BissnesExpertSystemDiplomaContext context;
        public static void Initialize()
        {
            if (context == null)
                context = new();
            
                context.Database.Migrate();
                context.SaveChanges();
            
        }

        public static BissnesExpertSystemDiplomaContext GetContext()
        {
            if (context == null)
                throw new Exception("База данных еще не инициализированна!");
            else
                return context;
        }
    }
}
