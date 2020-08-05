using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BokingWarnet.Utility
{
    public static class StatusPC
    {
        public static List<string> GetStatus()
        {
            List<string> listStatusPC = new List<string>();

            listStatusPC.Add("Berfungsi");
            listStatusPC.Add("Diperbaiki");
            listStatusPC.Add("Rusak");

            return listStatusPC;
        }


    }
}
