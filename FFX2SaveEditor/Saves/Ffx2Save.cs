using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FFX2SaveEditor
{
    public abstract class Ffx2Save
    {
        private MemoryStream ms;
        private BinaryReader br;
        private BinaryWriter bw;

        private readonly int storyOffset = 0x222c;
        private readonly int crcOffset = 0xd424;
        private readonly int itemOffset = 0x7980;
        private readonly int accOffset = 0x7cc0;
        private readonly int garmOffset = 0x7844;
        private readonly int dressOffset = 0x784d;
        private readonly int[] abilityOffsets = { 0x8da0, 0x9440, 0x9ae0 };

        public TimeSpan GameTime { get; set; }
        public int Gil { get; set; }
        public Character[] Characters { get; set; }
        public uint OpenAirCredits { get; set; }
        public uint ArgentCredits { get; set; }
        public byte TowerFlag { get; set; }
        public byte TowerFlag2 { get; set; }
        public byte[] TowerCalibrations { get; set; }
        public byte[] TowerAttempts { get; set; }
        public byte Faction { get; set; }
        public uint SuccessfulDigs { get; set; }
        public uint FailedDigs { get; set; }
        public uint GunnerPoints { get; set; }
        public uint SlCredits5 { get; set; }
        public uint HoverRides { get; set; }
        public byte[] ChocoboSuccesses { get; set; }
        public uint PahsanaGreens { get; set; }
        public uint MimettGreens { get; set; }
        public uint SylkisGreens { get; set; }
        public uint GysahlGreens { get; set; }
        public uint KimahriSelfEsteemCh2 { get; set; }
        public uint KimahriSelfEsteem { get; set; }
        public ushort[,] AssemblyParts { get; set; }
        public uint OpenAirPoints { get; set; }
        public uint ArgentPoints { get; set; }
        public uint MarraigePoints { get; set; }
        public uint SlCredits { get; set; }
        public byte Chapter { get; set; }
        public float OakaDept { get; set; }
        public byte AlBhedPrimerCount { get; set; }
        public byte AlBhedMaster { get; set; }

        public uint Encounters { get; set; }
        public bool[] GarmentGrids { get; set; }
        public byte[] Dresspheres { get; set; }

        public byte[,] Items { get; set; }
        public byte[,] Accessories { get; set; }
        public byte[] AlBhedPrimers { get; set; }

        public short StoryFlagCount { get; set; }
        public byte[] StoryFlagBytes { get; set; }
        public List<StoryFlag> MissingFlags = new List<StoryFlag>();
        public List<StoryFlag> Requisites = new List<StoryFlag>();

        public Ffx2Save(int crcOffset, int itemOffset, int accOffset, int garmOffset, int dressOffset, int storyOffset) : this()
        {
            this.crcOffset = crcOffset;
            this.itemOffset = itemOffset;
            this.accOffset = accOffset;
            this.garmOffset = garmOffset;
            this.dressOffset = dressOffset;
            this.storyOffset = storyOffset;
        }

        public Ffx2Save()
        {
            Characters = new Character[3] { new Character(PartyMember.Yuna), new Character(PartyMember.Rikku), new Character(PartyMember.Paine) };
            TowerCalibrations = new byte[10];
            TowerAttempts = new byte[10];
            ChocoboSuccesses = new byte[5];
            AssemblyParts = new ushort[3, 3];
            GarmentGrids = new bool[64];
            Dresspheres = new byte[29];
            Items = new byte[256, 2];
            StoryFlagBytes = new byte[0x4000];

            for (int i = 0; i <= Items.GetUpperBound(0); i++)
            {
                Items[i, 0] = 255;
            }
            Accessories = new byte[256, 2];
            for (int i = 0; i <= Accessories.GetUpperBound(0); i++)
            {
                Accessories[i, 0] = 255;
            }
            AlBhedPrimers = new byte[4];
        }

        public virtual byte[] GetBytes()
        {
            return ms.ToArray();
        }

        public virtual void ReadFile(MemoryStream stream)
        {
            ms = stream;
            br = new BinaryReader(ms);
            bw = new BinaryWriter(ms);
            byte[] work = br.ReadBytes(0x222c);

            // New up save object?

            br.BaseStream.Seek(0x10, SeekOrigin.Begin);
            GameTime = TimeSpan.FromSeconds(br.ReadUInt32());
            Gil = br.ReadInt32(); // not real value

            br.BaseStream.Seek(0x2ec, SeekOrigin.Begin);
            OpenAirCredits = br.ReadUInt32();
            ArgentCredits = br.ReadUInt32();

            br.BaseStream.Seek(0x301, SeekOrigin.Begin);
            TowerCalibrations = br.ReadBytes(10);
            TowerAttempts = br.ReadBytes(10);

            br.BaseStream.Seek(0x340, SeekOrigin.Begin);
            SuccessfulDigs = br.ReadUInt32();
            FailedDigs = br.ReadUInt32();

            br.BaseStream.Seek(0x3b0, SeekOrigin.Begin);
            GunnerPoints = br.ReadUInt32();

            br.BaseStream.Seek(0x4b4, SeekOrigin.Begin);
            SlCredits5 = br.ReadUInt32();

            br.BaseStream.Seek(0x4c1, SeekOrigin.Begin);
            HoverRides = br.ReadUInt32();

            br.BaseStream.Seek(0x4c7, SeekOrigin.Begin);
            ChocoboSuccesses = br.ReadBytes(5);

            br.BaseStream.Seek(0xc55, SeekOrigin.Begin);
            Faction = br.ReadByte();

            br.BaseStream.Seek(0xd0c, SeekOrigin.Begin);
            PahsanaGreens = br.ReadUInt32();
            MimettGreens = br.ReadUInt32();
            SylkisGreens = br.ReadUInt32();
            GysahlGreens = br.ReadUInt32();

            br.BaseStream.Seek(0xdb8, SeekOrigin.Begin);
            KimahriSelfEsteemCh2 = br.ReadUInt32();
            KimahriSelfEsteem = br.ReadUInt32();

            br.BaseStream.Seek(0xdc4, SeekOrigin.Begin);
            // Two bytes each, A/S/Z -> A/D/S
            for (int i = 0; i < 3; i++)
            {
                for (int n = 0; n < 3; n++)
                {
                    AssemblyParts[i, n] = br.ReadUInt16();
                }
            }

            br.BaseStream.Seek(0xde4, SeekOrigin.Begin);
            OpenAirPoints = br.ReadUInt32();
            ArgentPoints = br.ReadUInt32();
            MarraigePoints = br.ReadUInt32();
            SlCredits = br.ReadUInt32();

            br.BaseStream.Seek(0x118c, SeekOrigin.Begin);
            Chapter = br.ReadByte();

            br.BaseStream.Seek(0x1194, SeekOrigin.Begin);
            OakaDept = br.ReadSingle();

            br.BaseStream.Seek(0x11a6, SeekOrigin.Begin);
            AlBhedPrimerCount = br.ReadByte();
            AlBhedMaster = br.ReadByte();

            br.BaseStream.Seek(storyOffset, SeekOrigin.Begin);
            StoryFlagBytes = br.ReadBytes(StoryFlagBytes.Length);

            // Requirements
            foreach (StoryFlag f in GameInfo.Requisites)
            {
                byte b = work[f.Address];
                if ((b & f.Value) != f.Value)
                {
                    Requisites.Add(f);
                }
            }

            // Completion flags
            for (int i = 0; i < 0x4000; i++)
            {
                byte b = StoryFlagBytes[i];
                for (int n = 0; n < 8; n++)
                {
                    if ((b & 1) == 1)
                    {
                        StoryFlagCount++;
                        StoryFlag flag = GameInfo.Flags.FirstOrDefault(f => f.Address == i && f.Value == Math.Pow(2, n));
                        if (flag != null)
                        {
                            MissingFlags.Add(flag);
                        }
                        else
                        {
                            MissingFlags.Add(new StoryFlag((ushort)i, (byte)Math.Pow(2, n), i.ToString("X2"), 0, "???"));
                        }
                    }
                    b >>= 1;
                }
            }

            br.BaseStream.Seek(0x7818, SeekOrigin.Begin);
            Gil = br.ReadInt32();

            br.BaseStream.Seek(0x7824, SeekOrigin.Begin);
            Encounters = br.ReadUInt32();

            br.BaseStream.Seek(garmOffset, SeekOrigin.Begin);
            work = br.ReadBytes(8);
            for (byte b = 0; b < 8; b++)
            {
                for (byte bit = 0; bit < 8; bit++)
                {
                    GarmentGrids[b * 8 + bit] = (work[b] & (byte)Math.Pow(2, bit)) > 0;
                }
            }

            br.ReadByte();//space
            for (int i = 0; i < Dresspheres.Length; i++)
            {
                Dresspheres[i] = br.ReadByte();
            }

            br.BaseStream.Seek(itemOffset, SeekOrigin.Begin);
            byte[] table = br.ReadBytes(0x200);
            for (int i = 0; i < table.Length / 2; i++)
            {
                if (table[i * 2 + 1] == 0x20)
                {
                    Items[i, 0] = table[i * 2] > 67 ? (byte)255 : table[i * 2];
                }
            }
            table = br.ReadBytes(0x100);
            for (int i = 0; i < table.Length; i++)
            {
                Items[i, 1] = table[i];
            }

            br.BaseStream.Seek(accOffset, SeekOrigin.Begin);
            table = br.ReadBytes(0x100);
            for (int i = 0; i < table.Length / 2; i++)
            {
                if (table[i * 2 + 1] == 0x90)
                {
                    Accessories[i, 0] = table[i * 2] > 0x7f ? (byte)0 : table[i * 2];
                }
            }
            table = br.ReadBytes(0x80);
            for (int i = 0; i < table.Length; i++)
            {
                Accessories[i, 1] = table[i];
            }

            #region AlBhed Primers
            /*
            8161 = al bhed primers
            01 =
            02 =
            04 = I   A
            08 = II  B
            10 = III C
            20 = IV  D
            40 = V   E
            80 = VI  F
            8162
            01 = VII   G
            02 = VIII  H
            04 = VIV   I
            08 = X     J
            10 = XI    K
            20 = XII   L
            40 = XIII  M
            80 = XIV   N
            8163
            01 = XV    O
            02 = XVI   P
            04 = XVII  Q
            08 = XVIII R
            10 = XVIV  S
            20 = XX   T
            40 = XXI  U
            80 = XXII V
            8164
            01 = XXIII W
            02 = XXIV  Y
            08 = XXVI  Z
            */
            #endregion
            br.BaseStream.Seek(0x8161, SeekOrigin.Begin);
            AlBhedPrimers = br.ReadBytes(4);

            br.BaseStream.Seek(0x8204, SeekOrigin.Begin);
            for (int c = 0; c < 3; c++)
            {
                Characters[c].Experience = br.ReadUInt32();
                Characters[c].NextLevel = br.ReadUInt32();
                Characters[c].HP = br.ReadUInt32();
                Characters[c].MP = br.ReadUInt32();
                Characters[c].MaxHP = br.ReadUInt32();
                Characters[c].MaxMP = br.ReadUInt32();
                br.ReadByte();
                Characters[c].Strength = br.ReadByte();
                Characters[c].Defense = br.ReadByte();
                Characters[c].Magic = br.ReadByte();
                Characters[c].MagicDefense = br.ReadByte();
                Characters[c].Agility = br.ReadByte();
                Characters[c].Accuracy = br.ReadByte();
                Characters[c].Evasion = br.ReadByte();
                Characters[c].Luck = br.ReadByte();
                Characters[c].Level = br.ReadByte();
                Characters[c].Dressphere = br.ReadByte();
                //+0x20 has same dressphere byte
                br.ReadBytes(0x5d);
            }

            for (int c = 0; c < 3; c++)
            {
                foreach (Ability ability in Characters[c].Abilities)
                {
                    br.BaseStream.Seek(abilityOffsets[c] + ability.Offset, SeekOrigin.Begin);
                    ability.Ap = br.ReadUInt16();
                }
            }
        }

        public virtual void WriteCharLevel(byte index)
        {
            bw.BaseStream.Seek(0x8204, SeekOrigin.Begin);
            bw.Write(Characters[index].Level);
        }

        public virtual void WriteItems()
        {
            bw.BaseStream.Seek(itemOffset, SeekOrigin.Begin);
            for (int i = 0; i < 256; i++)
            {
                bw.Write(Items[i, 0]);
                bw.Write(Items[i, 0] == 0xff ? (byte)0 : (byte)0x20);
            }

            for (int i = 0; i < 256; i++)
            {
                bw.Write(Items[i, 1]);
            }
        }

        public virtual void WriteGil()
        {
            // Save game info (unused)
            bw.BaseStream.Seek(0x14, SeekOrigin.Begin);
            bw.Write(Gil);
            // Actual gil value
            bw.BaseStream.Seek(0x7818, SeekOrigin.Begin);
            bw.Write(Gil);
        }

        public virtual void WriteItem(byte index)
        {
            bw.BaseStream.Seek(itemOffset + index * 2, SeekOrigin.Begin);
            bw.Write(Items[index, 0]);
            bw.Write(Items[index, 0] == 0xff ? (byte)0 : (byte)0x20);

            bw.BaseStream.Seek(itemOffset + 0x200 + index, SeekOrigin.Begin);
            bw.Write(Items[index, 1]);
        }

        public virtual void WriteAccessories()
        {
            bw.BaseStream.Seek(accOffset, SeekOrigin.Begin);
            for (int i = 0; i < 128; i++)
            {
                bw.Write(Accessories[i, 0]);
                bw.Write(Accessories[i, 0] == 0xff ? (byte)0 : (byte)0x90);
            }

            for (int i = 0; i < 128; i++)
            {
                bw.Write(Accessories[i, 1]);
            }
        }

        public virtual void WriteAccessory(byte index)
        {
            bw.BaseStream.Seek(accOffset + index * 2, SeekOrigin.Begin);
            bw.Write(Accessories[index, 0]);
            bw.Write(Accessories[index, 0] == 0xff ? (byte)0 : (byte)0x90);

            bw.BaseStream.Seek(accOffset + 0x100 + index, SeekOrigin.Begin);
            bw.Write(Accessories[index, 1]);
        }

        public virtual void WriteGarmentGrids()
        {
            bw.BaseStream.Seek(garmOffset, SeekOrigin.Begin);
            byte[] bytes = new byte[8];
            for (byte b = 0; b < 8; b++)
            {
                for (byte bit = 0; bit < 8; bit++)
                {
                    if (GarmentGrids[b * 8 + bit])
                    {
                        bytes[b] |= (byte)Math.Pow(2, bit);
                    }
                }
            }
            bw.Write(bytes);
        }

        public virtual void WriteDressphere(byte index)
        {
            bw.BaseStream.Seek(dressOffset + index, SeekOrigin.Begin);
            bw.Write(Dresspheres[index]);
        }

        public virtual void WriteDresspheres()
        {
            bw.BaseStream.Seek(dressOffset, SeekOrigin.Begin);
            bw.Write(Dresspheres);
        }

        public virtual void WriteAbility(byte character, Ability ability)
        {
            bw.BaseStream.Seek(abilityOffsets[character] + ability.Offset, SeekOrigin.Begin);
            bw.Write(ability.Ap);
        }

        public virtual void WriteStoryFlag(int offset, byte value)
        {
            bw.BaseStream.Seek(storyOffset + offset, SeekOrigin.Begin);
            bw.Write(value);
        }

        public virtual void CompleteWriteStoryFlags()
        {
            StoryFlagBytes = new byte[0x4000];
            bw.BaseStream.Seek(storyOffset, SeekOrigin.Begin);
            bw.Write(StoryFlagBytes);
        }

        public virtual void SaveFile(string filename)
        {
            CalculateChecksum();
            CalculateGameComplete();

            using (BinaryWriter fw = new BinaryWriter(File.Open(filename, FileMode.Create)))
            {
                fw.Write(ms.ToArray());
            }
        }

        private void CalculateChecksum()
        {
            bw.Write(crcOffset, 0);
            Crc16_CCITT hasher = new Crc16_CCITT();
            {
                br.BaseStream.Seek(0x40, SeekOrigin.Begin);
                hasher.ComputeHash(br.ReadBytes(crcOffset + 4 - 0x40));
                bw.Write(0x1a, (short)hasher.Value);
                bw.Write(crcOffset, (short)hasher.Value);
            }
        }

        private void CalculateGameComplete()
        {
            int incomplete = StoryFlagBytes.Sum(b => Convert.ToString(b, 2).ToCharArray().Count(c => c == '1'));
            bw.BaseStream.Seek(0x0C, SeekOrigin.Begin);
            bw.Write((byte)((525 - incomplete) / 5));
        }
    }

    public class Character
    {
        public byte Level { get; set; }
        public uint Experience { get; set; }
        public uint NextLevel { get; set; }
        public uint HP { get; set; }
        public uint MP { get; set; }
        public uint MaxHP { get; set; }
        public uint MaxMP { get; set; }
        public byte Strength { get; set; }
        public byte Defense { get; set; }
        public byte Magic { get; set; }
        public byte MagicDefense { get; set; }
        public byte Agility { get; set; }
        public byte Accuracy { get; set; }
        public byte Evasion { get; set; }
        public byte Luck { get; set; }
        public byte Dressphere { get; set; }
        public List<Ability> Abilities { get; set; } = new List<Ability>();

        public Character(PartyMember member)
        {
            foreach (Ability ability in Globals.Abilities.Where(a => a.Character == (byte)PartyMember.All))
            {
                Abilities.Add(ability);
            }

            foreach (Ability ability in Globals.Abilities.Where(a => a.Character == (byte)member))
            {
                Abilities.Add(ability);
            }
        }
    }

    public class Item
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public byte Quantity { get; set; }
    }

    public class Ability
    {
        public byte Character { get; set; }
        public byte Dressphere { get; set; }
        public byte Type { get; set; }
        public ushort MaxAp { get; set; }
        public short Offset { get; set; }
        public string Name { get; set; }
        public ushort Ap { get; set; }

        public bool Mastered => Ap >= MaxAp;

        public Ability(byte character, byte dressphere, byte type, ushort ap, short offset, string name)
        {
            Character = character;
            Dressphere = dressphere;
            MaxAp = ap;
            Offset = offset;
            Name = name;
            Ap = 0;
            Type = type;
        }
    }
}
