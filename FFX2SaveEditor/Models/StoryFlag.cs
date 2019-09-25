using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFX2SaveEditor
{
    public class StoryFlag
    {
        public ushort Address { get; set; }
        public byte Value { get; set; }
        public string Description { get; set; }
        public byte Chapter { get; set; }
        public string Location { get; set; }
        public byte Faction { get; set; }

        public StoryFlag(ushort address, byte value, string description, byte chapter, string location)
        {
            Address = address;
            Value = value;
            Description = description;
            Chapter = chapter;
            Location = location;
            Faction = 0;
        }

        public StoryFlag(ushort address, byte value, string description, byte chapter, string location, byte faction)
        {
            Address = address;
            Value = value;
            Description = description;
            Chapter = chapter;
            Location = location;
            Faction = faction;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
