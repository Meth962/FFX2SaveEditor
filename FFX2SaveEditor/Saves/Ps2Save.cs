using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFX2SaveEditor.Saves
{
    // Raw file format of the Ps2 version
    public class Ps2Save : Ffx2Save
    {
        public Ps2Save(string filename) : base(0xd424, 0x7980, 0x7cc0, 0x7844, 0x784d, 0x222c)
        {

        }
    }
}
