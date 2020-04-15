using PS3FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FFX2SaveEditor.Saves
{
    public class Ps3Save : Ffx2Save
    {
        public string Directory { get; set; }

        private readonly string[] ps3GameIDs = { "BLUS31211", "NPUB31247", "BLES01880", "NPEB01391", "BLJM61093", "BCAS20289", "NPJB00458" };
        private byte[] secureFileId = { 0x02, 0x06, 0x04, 0x03, 0x03, 0x08, 0x03, 0x02, 0x07, 0x09, 0x05, 0x00, 0x02, 0x08, 0x08, 0x04 };
        private const string dataName = "SAVES";

        private string pfdFile, sfoFile, datFile;
        private Ps3SaveManager manager;

        public Ps3Save(string directory) : base(0x16268, 0x7980, 0x7cc0, 0x7844, 0x784d, 0x222c)
        {
            Directory = directory;
            OpenPS3Save(directory);
        }

        public Ps3Save(string[] files) : base(0x16268, 0x7980, 0x7cc0, 0x7844, 0x784d, 0x222c)
        {
            for(var i = 0; i < 3; i++)
            {
                var extension = Path.GetExtension(files[i]).ToUpper();
                switch (extension)
                {
                    case ".PFD":
                        pfdFile = files[i];
                        break;
                    case ".SFO":
                        sfoFile = files[i];
                        break;
                    default:
                        datFile = files[i];
                        break;
                }
            }

            if(string.IsNullOrEmpty(pfdFile))
            {
                MessageBox.Show("No .PFD file in selected files. Please select all three files (.PFD, .SFO, SAVES)");
                return;
            }
            if(string.IsNullOrEmpty(sfoFile))
            {
                MessageBox.Show("No .SFO file in selected files. Please select all three files (.PFD, .SFO, SAVES)");
                return;
            }
            if(string.IsNullOrEmpty(datFile))// || !datFile.EndsWith("SAVES"))
            {
                MessageBox.Show("No SAVES file in selected files. Please select all three files (.PFD, .SFO, SAVES)");
                return;
            }
            OpenPS3Save(File.Open(pfdFile, FileMode.Open), File.Open(sfoFile, FileMode.Open), File.Open(datFile, FileMode.Open));
        }

        private void OpenPS3Save(string directory)
        {
            manager = new Ps3SaveManager(directory, secureFileId);
            Ps3File file = manager.Files.FirstOrDefault(t => t.PFDEntry.FileName == dataName);

            byte[] filedata = null;
            if (file != null)
                filedata = file.DecryptToBytes();
            if (filedata == null)
                return;

            ReadFile(new MemoryStream(filedata));
        }

        private void OpenPS3Save(Stream pfd, Stream sfo, Stream bin)
        {
            //declare ps3 manager using the directory path, and the secure file id
            manager = new Ps3SaveManager(pfd, sfo, bin, dataName, secureFileId);
            //get data file entry by name
            Ps3File file = manager.Files.FirstOrDefault(t => t.PFDEntry.FileName == dataName);

            byte[] filedata = null;
            //decrypt file to raw save bytes
            if (file != null)
                filedata = file.DecryptToBytes();
            if (filedata == null)
                return;

            ReadFile(new MemoryStream(filedata));
        }

        public override void SaveFile(string filename)
        {
            Ps3File file;
            // First write raw file and mod checksum
            try
            {
                file = manager.Files.FirstOrDefault(t => t.PFDEntry.FileName == dataName);
                if (file == null) { MessageBox.Show("Could not locate data file named " + dataName); return; }

                base.SaveFile(file.FilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to write to disk.\r\n" + ex.Message);
                return;
            }

            // Then encrypt with PS3 standard
            if (manager.ReBuildChanges(true))//(manager.Param_PFD.Encrypt(filename))
            {
                MessageBox.Show("Saved successfully.", "File Saved");
            }
            else
                MessageBox.Show("Error encrypting data to PS3 format.");
        }

        public void Convert(string filename)
        {
            base.SaveFile(filename);
        }
    }
}
