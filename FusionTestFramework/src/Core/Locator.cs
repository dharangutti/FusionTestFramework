using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionTestFramework.src.Core
{
    public class Locator
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public string? PlaywrightOverride { get; set; } // Allow null values

        public Locator(string type, string value, string? playwrightOverride = null) // Allow null values
        {
            Type = type;
            Value = value;
            PlaywrightOverride = playwrightOverride;
        }
    }
}
