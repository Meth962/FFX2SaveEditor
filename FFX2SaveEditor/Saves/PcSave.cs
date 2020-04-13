using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFX2SaveEditor.Saves
{
    /// <summary>
    /// The raw file format of the PC version.
    /// </summary>
    public class PcSave : Ffx2Save
    {
        public string OriginalName;

        public PcSave(string filename) : base(0x16268, 0x7980, 0x7cc0, 0x7844, 0x784d, 0x222c)
        {
            OriginalName = Path.GetFileName(filename);
            ReadFile(new MemoryStream(File.ReadAllBytes(filename)));
        }
    }
}
