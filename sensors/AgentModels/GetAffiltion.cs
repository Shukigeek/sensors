using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensors.AgentModels
{
    internal static class GetAffiltion
    {
        static Random random = new Random();
        static List<string> terrorOrganizations = new List<string>
        {
            "Al-Qaeda",
            "ISIS",
            "Hezbollah",
            "Hamas",
            "Boko Haram",
            "Taliban",
            "Palestinian Islamic Jihad"
        };
        public static string Affiletion()
        {
            return terrorOrganizations[random.Next(terrorOrganizations.Count)];
            
        }

    }
}
