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
        public bool IsRequisite { get; set; }

        public StoryFlag(ushort address, byte value, string description, byte chapter, string location, bool requisite = false)
        {
            Address = address;
            Value = value;
            Description = description;
            Chapter = chapter;
            Location = location;
            Faction = 0;
            IsRequisite = requisite;
        }

        public StoryFlag(ushort address, byte value, string description, byte chapter, string location, byte faction, bool requisite = false)
        {
            Address = address;
            Value = value;
            Description = description;
            Chapter = chapter;
            Location = location;
            Faction = faction;
            IsRequisite = requisite;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
