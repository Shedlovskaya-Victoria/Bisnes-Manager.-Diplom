using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisnesManager.DatabasePersistens.Context;

namespace BisnesManager.DatabasePersistens
{
    public class DBInitialazer
    {
        public static void Initialize(BissnesExpertSystemDiplomaContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
