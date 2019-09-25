using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FFX2SaveEditor
{
    public static class Globals
    {
        public static readonly SolidColorBrush GrayBrush = new SolidColorBrush(Color.FromRgb(55, 55, 55));
        public static readonly SolidColorBrush WhiteBrush = new SolidColorBrush(Color.FromRgb(225, 225, 225));

        public static readonly List<byte> ItemTypes = new List<byte>()
        {
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
            2,2,2,2,2,2,1,1,1,1,2,2,2,2,2,2,2,0,0,0,0
        };

        public static readonly Dictionary<byte, string> Items = new Dictionary<byte, string>()
        {
            {0,"Potion"},
            {1,"Hi-Potion"},
            {2,"X-Potion"},
            {3,"Mega-Potion"},
            {4,"Ether"},
            {5,"Turbo Ether"},
            {6,"Phoenix Down"},
            {7,"Mega Phoenix"},
            {8,"Elixir"},
            {9,"Megalixir"},
            {10,"Antidote" },
            {11,"Soft"},
            {12,"Eye Drops"},
            {13,"Echo Screen"},
            {14,"Holy Water"},
            {15,"Remedy"},
            {16,"Budget Grenade"},
            {17,"Grenade" },
            {18,"L-Bomb" },
            {19,"M-Bomb" },
            {20,"S-Bomb" },
            {21,"Sleep Grenade" },
            {22,"Silence Grenade" },
            {23,"Dark Grenade" },
            {24,"Petrify Grenade" },
            {25,"Bomb Fragment" },
            {26,"Bomb Core" },
            {27,"Fire Gem" },
            {28,"Antartctic Wind" },
            {29,"Arctic Wind" },
            {30,"Ice Gem" },
            {31,"Electro Marble" },
            {32,"Lightning Marble" },
            {33,"Lightning Gem" },
            {34,"Fish Scale" },
            {35,"Dragon Scale" },
            {36,"Water Gem" },
            {37,"Shadow Gem" },
            {38,"Shining Gem" },
            {39,"Blessed Gem" },
            {40,"Supreme Gem" },
            {41,"Poison Fang" },
            {42,"Silver Hourglass" },
            {43,"Gold Hourglass" },
            {44,"Candle of Life" },
            {45,"Farplane Shadow" },
            {46,"Dark Matter" },
            {47,"Chocobo Feather" },
            {48,"Chocobo Wing" },
            {49,"Lunar Curtain" },
            {50,"Light Curtain" },
            {51,"Star Curtain" },
            {52,"Healing Spring" },
            {53,"Mana Spring" },
            {54,"Stamina Spring" },
            {55,"Soul Spring" },
            {56,"Dispel Tonic" },
            {57,"Stamina Tablet" },
            {58,"Mana Tablet" },
            {59,"Staminc Tonic" },
            {60,"Mana Tonic" },
            {61,"Twin Stars" },
            {62,"Three Stars" },
            {63,"Hero Drink" },
            {64,"Gysahl Greens" },
            {65,"Sylkis Greens" },
            {66,"Mimett Greens" },
            {67,"Pahsana Greens" },
            {(byte)255,"Nothing" }
        };

        public static readonly string[] GarmentGrids = new string[] {
            "First Steps",
            "Vanguard",
            "Bum Rush",
            "Undying Storm",
            "Flash of Steel",
            "Protection Halo",
            "Hour of Need",
            "Unwavering Guard",
            "Valiant Lustre",
            "Highroad Winds",
            "Mounted Assault",
            "Heart of Flame",
            "Ice Queen",
            "Thunder Spawn",
            "Menace of the Deep",
            "Downtrodder",
            "Sacred Beast",
            "Tetra Master",
            "Restless Sleep",
            "Still of Night",
            "Mortal Coil",
            "Raging Giant",
            "Bitter Farewell",
            "Selene Guard",
            "Helios Guard",
            "Shining Mirror",
            "Covetous",
            "Disaster in Bloom",
            "Scourgebane",
            "Healing Wind",
            "Heart Reborn",
            "Healing Light",
            "Immortal Soul",
            "Wishbringer",
            "Strength of One",
            "Seething Cauldron",
            "Stonehewn",
            "Enigma Plate",
            "Howling Wind",
            "Ray of Hope",
            "Pride of the Sword",
            "Samurai's Honour",
            "Blood of the Beast",
            "Chaos Maelstrom",
            "White Signet",
            "Black Tabard",
            "Mercurial Strike",
            "Tricks of the Trade",
            "Horn of Plenty",
            "Treasure Hunt",
            "Tempered Will",
            "Covenant of Growth",
            "Salvation Promised",
            "Conflagration",
            "Supreme Light",
            "Megiddo",
            "Unerring Path",
            "Font of Power",
            "Higher Power",
            "The End",
            "Circle",
            "Triangle",
            "Maximum",
            "Infinity",
        };

        public static readonly string[] Dresspheres = new string[] {
            "Gunner",
            "Gun Mage",
            "Alchemist",
            "Warrior",
            "Samurai",
            "Dark Knight",
            "Berserker",
            "Songstress",
            "Black Mage",
            "White Mage",
            "Thief",
            "Trainer",
            "Lady Luck",
            "Mascot",
            "Floral Fallal",
            "  Right Pistil",
            "  Left Pistil",
            "Machina Maw",
            "  Smasher-R",
            "  Crusher-L",
            "Full Throttle",
            "  Dextral Wing",
            "  Sinistral Wing",
            "Trainer",//Rikku
            "Trainer",//Paine
            "Mascot",//Rikku's mascot
            "Mascot",//Paine's mascot
            "Psychic",
            "Festivalist",
            "Festivalist",
            "Festivalist",
            "Freelancer",
            "Leblanc Goon",
            "Warrior"
        };

        public static Uri[] DressIcons =
        {
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/gunner.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/gunmage.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/alchemist.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/warrior.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/samurai.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/darkknight.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/berserker.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/songstress.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/blackmage.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/whitemage.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/thief.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/trainer.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/ladyluck.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/mascot.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/floralfallal.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/floralfallal.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/floralfallal.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/machinamaw.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/machinamaw.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/machinamaw.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/fullthrottle.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/fullthrottle.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/fullthrottle.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/trainer.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/trainer.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/mascot.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/mascot.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/psychic.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/festivalist.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/festivalist.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/festivalist.png"),
            null,
            null,
            null
        };

        public static Uri GarmentIcon = new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/GarmentGrid.png");

        public static byte[] AccessoryType =
        {
            0,0,0,1,0,0,1,0,0,0,0,1,0,0,1,0,0,0,0,1,0,0,1,0,0,0,1,0,0,0,1,2,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,2,
            1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,1,1,1,1,1,1,2,
            1,1,1,1,1,1,1,1,1,1,1,1,
            1,2,0,0,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2
        };

        public static readonly Dictionary<byte, string> Accessories = new Dictionary<byte, string>()
        {
            {0,"Iron Bangle"},
            {1,"Titanium Bangle"},
            {2,"Mythril Bangle"},
            {3,"Crystal Bangle"},
            {4,"Silver Bracer"},
            {5,"Gold Bracer"},
            {6,"Rune Bracer"},
            {7,"Wristband"},
            {8,"Power Wrist"},
            {9,"Hyper Wrist"},
            {10,"Power Gloves"},
            {11,"Kaiser Knuckles"},
            {12,"Mythril Gloves"},
            {13,"Diamond Gloves"},
            {14,"Crystal Gloves"},
            {15,"Amulet"},
            {16,"Tarot Card"},
            {17,"Talisman"},
            {18,"Pixie Dust"},
            {19,"Crystal Ball"},
            {20,"Defence Veil"},
            {21,"Mystery Veil"},
            {22,"Oath Veil"},
            {23,"Gauntlets"},
            {24,"Muscle Belt"},
            {25,"Black Belt"},
            {26,"Champion Belt"},
            {27,"Tiara"},
            {28,"Circlet"},
            {29,"Hypno Crown"},
            {30,"Regal Crown"},
            {31,"Rabite's Foot"},
            {32,"Fiery Gleam"},
            {33,"Red Ring"},
            {34,"Nulblaze Ring"},
            {35,"Crimson Ring"},
            {36,"Icy Gleam"},
            {37,"White Ring"},
            {38,"NulFrost Ring"},
            {39,"Snow Ring"},
            {40,"Lightning Gleam"},
            {41,"Yellow Ring"},
            {42,"NulShock Ring"},
            {43,"Ochre Ring"},
            {44,"Watery Gleam"},
            {45,"Blue Ring"},
            {46,"NulTide Ring"},
            {47,"Cerulean Ring"},
            {48,"Bloodlust"},
            {49,"Wring"},
            {50,"Black Ring"},
            {51,"Freezerburn"},
            {52,"Sublimator"},
            {53,"Electrocutioner"},
            {54,"Short Circuit"},
            {55,"Tetra Gloves"},
            {56,"Tetra Bracelet"},
            {57,"Tetra Band"},
            {58,"Tetra Guard"},
            {59,"Mortal Shock"},
            {60,"Stone Shock"},
            {61,"Dream Shock"},
            {62,"Mute Shock"},
            {63,"Blind Shock"},
            {64,"Venom Shock"},
            {65,"Chaos Shock"},
            {66,"Fury Shock"},
            {67,"Lag Shock"},
            {68,"System Shock"},
            {69,"Angel Earrings"},
            {70,"Gold Anklet"},
            {71,"Twist Headband"},
            {72,"White Cape"},
            {73,"Silver Glasses"},
            {74,"Star Pendant"},
            {75,"Black Choker"},
            {76,"Potpourri"},
            {77,"Gris-Gris Bag"},
            {78,"Pearl Necklace"},
            {79,"Pretty Orb"},
            {80,"Dragonfly Orb"},
            {81,"Beaded Brooch"},
            {82,"Glass Buckle"},
            {83,"Faerie Earrings"},
            {84,"Kinesis Badge"},
            {85,"Safety Bit"},
            {86,"Ribbon"},
            {87,"Wall Ring"},
            {88,"Favourite Outfit"},
            {89,"Lure Bracer"},
            {90,"Regen Bangle"},
            {91,"Haste Bangle"},
            {92,"Moon Bracer"},
            {93,"Shining Bracer"},
            {94,"Star Bracer"},
            {95,"Defence Bracer"},
            {96,"Recovery Bracer"},
            {97,"Speed Bracer"},
            {98,"Sword Lore"},
            {99,"Bushido Lore"},
            {100,"Arcane Lore"},
            {101,"Nature's Lore"},
            {102,"Black Lore"},
            {103,"White Lore"},
            {104,"Sword Tome"},
            {105,"Bushido Tome"},
            {106,"Nature's Tome"},
            {107,"Arcane Tome"},
            {108,"White Tome"},
            {109,"Black Tome"},
            {110,"Sprint Shoes"},
            {111,"AP Egg"},
            {112,"Cat's Bell"},
            {113,"Wizard Bracelet"},
            {114,"Charm Bangle"},
            {115,"Gold Hairpin"},
            {116,"Soul of Thamasa"},
            {117,"Heady Perfume"},
            {118,"Shmooth Shailing"},
            {119,"Key to Success"},
            {120,"Minerva's Plate"},
            {121,"Adamantite"},
            {122,"Force of Nature"},
            {123,"Cat Nip"},
            {124,"Iron Duke"},
            {125,"Ragnarok"},
            {126,"Enterprise"},
            {127,"Invincible"},
            {255,"Nothing" }
        };

        public static List<Ability> Abilities = new List<Ability>
        {
            new Ability((byte)PartyMember.All,(byte)Dressphere.Gunner,0,  0, 0x0000, "Attack"),//auto
            new Ability((byte)PartyMember.All,(byte)Dressphere.Gunner,0,  0, 0x0000, "Trigger Happy"),//auto
            new Ability((byte)PartyMember.All,(byte)Dressphere.Gunner,0, 20, 0x0036, "Potshot"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Gunner,0, 30, 0x0038, "Cheap Shot"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Gunner,0, 30, 0x003A, "Enchanted Ammo"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Gunner,0, 30, 0x003C, "Target MP"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Gunner,0, 40, 0x003E, "Quarter Pounder"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Gunner,0, 40, 0x0040, "On the Level"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Gunner,0, 60, 0x0042, "Burst Shot"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Gunner,0, 60, 0x0044, "Table-turner"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Gunner,0, 80, 0x0046, "Scattershot"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Gunner,0,120, 0x0048, "Scatterburst"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Gunner,2, 30, 0x0514, "Darkproof"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Gunner,2, 30, 0x050C, "Sleepproof"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Gunner,2, 80, 0x04A0, "Trigger Happy Lv.2"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Gunner,2,150, 0x04A2, "Trigger Happy Lv.3"),

            new Ability((byte)PartyMember.All,(byte)Dressphere.GunMage,0,   0, 0x0000, "Attack"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.GunMage,9,   0, 0x0000, "Blue Bullet"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.GunMage,11,  0, 0x0000, "Scan"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.GunMage,10, 20, 0x004C, "Shell Cracker"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.GunMage,10, 20, 0x004E, "Anti-Aircraft"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.GunMage,10, 20, 0x0050, "Silver Bullet"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.GunMage,10, 20, 0x0052, "Flan Eater"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.GunMage,10, 20, 0x0054, "Elementillery"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.GunMage,10, 20, 0x0056, "Killasaurus"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.GunMage,10, 20, 0x0058, "Drake Slayer"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.GunMage,10, 20, 0x005A, "Dismantler"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.GunMage,10, 20, 0x005C, "Mech Destroyer"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.GunMage,2,  20, 0x005E, "Demon Muzzle"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.GunMage,2,  30, 0x04AC, "Fiend Hunter Lv.2"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.GunMage,2,  20, 0x04A4, "Scan Lv.2"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.GunMage,2, 100, 0x04A6, "Scan Lv.3"),
            //Blue bullet
			//new Ability((byte)PartyMember.All,(byte)PartyMember.All,(byte)Dressphere.GunMage, 1, 0x0060, "Fire Breath"),
			//new Ability((byte)PartyMember.All,(byte)PartyMember.All,(byte)Dressphere.GunMage, 1, 0x0062, "Seed Cannon"),
			//new Ability((byte)PartyMember.All,(byte)PartyMember.All,(byte)Dressphere.GunMage, 1, 0x0064, "Stone Breath"),
			//new Ability((byte)PartyMember.All,(byte)PartyMember.All,(byte)Dressphere.GunMage, 1, 0x0066, "Absorb"),
			//new Ability((byte)PartyMember.All,(byte)PartyMember.All,(byte)Dressphere.GunMage, 1, 0x0068, "White Wind"),
			//new Ability((byte)PartyMember.All,(byte)PartyMember.All,(byte)Dressphere.GunMage, 1, 0x006A, "Bad Breath"),
			//new Ability((byte)PartyMember.All,(byte)PartyMember.All,(byte)Dressphere.GunMage, 1, 0x006C, "Mighty Guard"),
			//new Ability((byte)PartyMember.All,(byte)PartyMember.All,(byte)Dressphere.GunMage, 1, 0x006E, "Supernova"),
			//new Ability((byte)PartyMember.All,(byte)PartyMember.All,(byte)Dressphere.GunMage, 1, 0x0070, "Cry in the Night"),
			//new Ability((byte)PartyMember.All,(byte)PartyMember.All,(byte)Dressphere.GunMage, 1, 0x0072, "Drill Shot"),
			//new Ability((byte)PartyMember.All,(byte)PartyMember.All,(byte)Dressphere.GunMage, 1, 0x0074, "Mortar"),
			//new Ability((byte)PartyMember.All,(byte)PartyMember.All,(byte)Dressphere.GunMage, 1, 0x0076, "Annihilator"),
			//new Ability((byte)PartyMember.All,(byte)PartyMember.All,(byte)Dressphere.GunMage, 1, 0x0078, "Heaven's Cataract"),
			//new Ability((byte)PartyMember.All,(byte)PartyMember.All,(byte)Dressphere.GunMage, 1, 0x007A, "1000 Needles"),
			//new Ability((byte)PartyMember.All,(byte)PartyMember.All,(byte)Dressphere.GunMage, 1, 0x007C, "Storm Cannon"),
			//new Ability((byte)PartyMember.All,(byte)PartyMember.All,(byte)Dressphere.GunMage, 1, 0x007E, "Blaster"),

			new Ability((byte)PartyMember.All,(byte)Dressphere.Alchemist,0,   0, 0x0000, "Attack"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.Alchemist,9,   0, 0x0000, "Mix"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.Alchemist,12, 10, 0x0082, "Potion"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Alchemist,12, 50, 0x0084, "Hi-Potion"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Alchemist,12,120, 0x0086, "Mega-Potion"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Alchemist,12,160, 0x0088, "X-Potion"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Alchemist,12, 20, 0x008A, "Remedy"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Alchemist,12, 20, 0x008C, "Dispel Tonic"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Alchemist,12, 30, 0x008E, "Phoenix Down"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Alchemist,12,200, 0x0090, "Mega Phoenix"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Alchemist,12,400, 0x0092, "Ether"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Alchemist,12,999, 0x0094, "Elixir"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Alchemist,2,  30, 0x04AE, "Items Lv.2"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Alchemist,2,  40, 0x047C, "Chemist"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Alchemist,2,  80, 0x047E, "Elementalist"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Alchemist,2, 100, 0x0480, "Physicist"),

            new Ability((byte)PartyMember.All,(byte)Dressphere.Warrior,1,   0, 0x0000, "Attack"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.Warrior,10, 20, 0x0098, "Sentinel"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Warrior,8,  20, 0x00A2, "Flametongue"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Warrior,8,  20, 0x00A4, "Ice Brand"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Warrior,8,  20, 0x00A6, "Thunder Blade"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Warrior,8,  20, 0x00A8, "Liquid Steel"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Warrior,8,  60, 0x00AA, "Demi Sword"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Warrior,8, 120, 0x00AC, "Excalibur"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Warrior,8,   0, 0x0000, "Power Break"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.Warrior,8,  30, 0x009C, "Armour Break"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Warrior,8,  30, 0x009E, "Magic Break"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Warrior,8,  30, 0x00A0, "Mental Break"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Warrior,8, 100, 0x00AE, "Delay Attack"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Warrior,8, 120, 0x00B0, "Delay Buster"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Warrior,10,100, 0x0096, "Assault"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Warrior,2,  20, 0x055A, "SOS Protect"),

            new Ability((byte)PartyMember.All,(byte)Dressphere.Samurai,1,   0, 0x0000, "Attack"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.Samurai,6,  20, 0x00CA, "Spare Change"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Samurai,8,   0, 0x0000, "Mirror of Equity"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.Samurai,8,  30, 0x00B4, "Magicide"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Samurai,8,  30, 0x00B6, "Dismissal"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Samurai,8,  40, 0x00B8, "Fingersnap"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Samurai,6,  40, 0x00BA, "Sparkler"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Samurai,6,  60, 0x00BC, "Fireworks"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Samurai,8,  60, 0x00BE, "Momentum"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Samurai,6, 100, 0x00C0, "Shin-Zantetsu"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Samurai,10, 20, 0x00C2, "Nonpareil"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Samurai,10, 30, 0x00C4, "No Fear"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Samurai,10, 40, 0x00C6, "Clean Slate"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Samurai,10, 60, 0x00C8, "Hayate"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Samurai,6, 140, 0x00CC, "Zantetsu"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Samurai,2,  80, 0x0566, "SOS Critical"),

            new Ability((byte)PartyMember.All,(byte)Dressphere.DarkKnight,1,  0, 0x0000, "Attack"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.DarkKnight,6,  0, 0x0000, "Darkness"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.DarkKnight,7, 20, 0x00D2, "Drain"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.DarkKnight,7, 20, 0x00D4, "Demi"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.DarkKnight,7, 30, 0x00D6, "Confuse"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.DarkKnight,7, 40, 0x00D8, "Break"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.DarkKnight,7, 30, 0x00DA, "Bio"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.DarkKnight,7, 20, 0x00DC, "Doom"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.DarkKnight,7, 50, 0x00DE, "Death"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.DarkKnight,7,100, 0x00E0, "Black Sky"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.DarkKnight,8, 20, 0x00D0, "Charon"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.DarkKnight,2, 30, 0x0518, "Poisonproof"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.DarkKnight,2, 30, 0x0508, "Stoneproof"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.DarkKnight,2, 30, 0x051C, "Confuseproof"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.DarkKnight,2, 30, 0x0526, "Curseproof"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.DarkKnight,2, 40, 0x0504, "Deathproof"),

            new Ability((byte)PartyMember.All,(byte)Dressphere.Berserker,1,   0, 0x0000, "Attack"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.Berserker,10,  0, 0x0000, "Berserk"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.Berserker,8,  20, 0x00E6, "Cripple"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Berserker,8,  30, 0x00E8, "Mad Rush"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Berserker,8,  30, 0x00EA, "Crackdown"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Berserker,8,  40, 0x00EC, "Eject"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Berserker,8,  40, 0x00EE, "Unhinge"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Berserker,8,  50, 0x00F0, "Intimidate"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Berserker,8,  30, 0x00F2, "Envenom"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Berserker,8,  60, 0x00F4, "Hurt"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Berserker,10, 80, 0x00E4, "Howl"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Berserker,2,  20, 0x052A, "Itchproof"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Berserker,2, 180, 0x0474, "Counterattack"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Berserker,2, 300, 0x0478, "Magic Counter"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Berserker,2, 400, 0x0476, "Evade & Counter"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Berserker,2,  80, 0x054C, "Auto-Regen"),

            new Ability((byte)PartyMember.All,(byte)Dressphere.Songstress,3,   0, 0x0000, "Darkness Dance"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.Songstress,3,  20, 0x00F8, "Samba of Silence"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Songstress,3,  20, 0x00FA, "MP Mambo"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Songstress,3,  20, 0x00FC, "Magical Masque"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Songstress,3,  80, 0x00FE, "Sleepy Shuffle"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Songstress,3,  80, 0x0100, "Carnival Cancan"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Songstress,3,  60, 0x0102, "Slow Dance"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Songstress,3, 120, 0x0104, "Brake-dance"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Songstress,3, 120, 0x0106, "Jitterbug"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Songstress,3, 160, 0x0108, "Dirty Dancing"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Songstress,10, 10, 0x010A, "Battle Cry"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Songstress,10, 10, 0x010C, "Cantus Firmus"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Songstress,10, 10, 0x010E, "Esoteric Melody"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Songstress,10, 10, 0x0110, "Disenchant"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Songstress,10, 10, 0x0112, "Perfect Pitch"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Songstress,10, 10, 0x0114, "Matador's Song"),

            new Ability((byte)PartyMember.All,(byte)Dressphere.BlackMage,7,   0, 0x0000, "Fire"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.BlackMage,7,   0, 0x0000, "Blizzard"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.BlackMage,7,   0, 0x0000, "Thunder"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.BlackMage,7,   0, 0x0000, "Water"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.BlackMage,7,  40, 0x0122, "Fira"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.BlackMage,7,  40, 0x0124, "Blizzara"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.BlackMage,7,  40, 0x0126, "Thundara"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.BlackMage,7,  40, 0x0128, "Watera"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.BlackMage,7, 100, 0x012A, "Firaga"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.BlackMage,7, 100, 0x012C, "Blizzaga"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.BlackMage,7, 100, 0x012E, "Thundaga"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.BlackMage,7, 100, 0x0130, "Waterga"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.BlackMage,10, 10, 0x0116, "Focus"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.BlackMage,7,  10, 0x0118, "MP Absorb"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.BlackMage,2,  40, 0x04B0, "Black Magic Lv.2"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.BlackMage,2,  60, 0x04B2, "Black Magic Lv.3"),

            new Ability((byte)PartyMember.All,(byte)Dressphere.WhiteMage,4,   0, 0x0000, "Pray"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.WhiteMage,4,  20, 0x0134, "Vigour"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.WhiteMage,5,   0, 0x0000, "Cure"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.WhiteMage,5,  40, 0x0138, "Cura"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.WhiteMage,5,  80, 0x013A, "Curaga"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.WhiteMage,5,  80, 0x013C, "Regen"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.WhiteMage,5,  20, 0x013E, "Esuna"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.WhiteMage,7,  30, 0x0140, "Dispel"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.WhiteMage,5,  30, 0x0142, "Life"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.WhiteMage,5, 160, 0x0144, "Full-Life"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.WhiteMage,10, 30, 0x0146, "Shell"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.WhiteMage,10, 30, 0x0148, "Protect"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.WhiteMage,10, 30, 0x014A, "Reflect"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.WhiteMage,5,  80, 0x014C, "Full-Cure"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.WhiteMage,2,  40, 0x04B4, "White Magic Lv.2"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.WhiteMage,2,  60, 0x04B6, "White Magic Lv.3"),

            new Ability((byte)PartyMember.All,(byte)Dressphere.Thief,1,    0, 0x0000, "Attack"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.Thief,11,   0, 0x0000, "Steal"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.Thief,11,  30, 0x0150, "Pilfer Gil"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Thief,11, 100, 0x0152, "Borrowed Time"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Thief,11,  60, 0x0154, "Pilfer HP"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Thief,11,  60, 0x0156, "Pilfer MP"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Thief,11, 120, 0x0158, "Sticky Fingers"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Thief,11, 140, 0x015A, "Master Thief"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Thief,11, 160, 0x015C, "Soul Swipe"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Thief,11, 160, 0x015E, "Steal Will"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Thief,11,  10, 0x0160, "Flee"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Thief,2,   60, 0x0494, "Item Hunter"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Thief,2,   40, 0x0470, "First Strike"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Thief,2,   60, 0x0472, "Initiative"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Thief,2,   20, 0x052E, "Slowproof"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Thief,2,   40, 0x0532, "Stopproof"),

            new Ability((byte)PartyMember.All,(byte)Dressphere.Trainer,1,   0, 0x0000, "Attack"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.Trainer,8,   0, 0x0000, "Holy Kogoro"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.Trainer,8,   0, 0x0000, "Kogoro Blaze"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.Trainer,8,  40, 0x0164, "Kogoro Freeze"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Trainer,8,  40, 0x0166, "Kogoro Shock"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Trainer,8,  40, 0x0168, "Kogoro Deluge"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Trainer,8,  80, 0x016A, "Kogoro Strike"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Trainer,8,  80, 0x016C, "Doom Kogoro"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Trainer,5,  40, 0x016E, "Kogoro Cure"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Trainer,5,  40, 0x0170, "Kogoro Remedy"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Trainer,8, 100, 0x0174, "Pound!"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Trainer,2, 200, 0x04A8, "Half MP Cost"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Trainer,2,  20, 0x0498, "HP Stroll"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Trainer,2,  20, 0x049A, "MP Stroll"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Trainer,2,  80, 0x04B8, "Kogoro Lv.2"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.Trainer,2, 100, 0x04BA, "Kogoro Lv.3"),

            new Ability((byte)PartyMember.All,(byte)Dressphere.LadyLuck,0,    0, 0x0000, "Attack"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.LadyLuck,7,   40, 0x01B0, "Bribe"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.LadyLuck,8,   20, 0x01A6, "Two Dice"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.LadyLuck,8,  100, 0x01A8, "Four Dice"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.LadyLuck,11,   0, 0x0000, "Attack Reels"),//auto
			new Ability((byte)PartyMember.All,(byte)Dressphere.LadyLuck,11,  70, 0x01A0, "Magic Reels"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.LadyLuck,11,  80, 0x01A2, "Item Reels"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.LadyLuck,11, 120, 0x01A4, "Random Reels"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.LadyLuck,10,  30, 0x01AA, "Luck"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.LadyLuck,10,  40, 0x01AC, "Felicity"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.LadyLuck,7,   60, 0x01AE, "Tantalise"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.LadyLuck,2,  160, 0x0550, "Critical"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.LadyLuck,2,   80, 0x0492, "Double EXP"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.LadyLuck,2,   30, 0x0562, "SOS Spellspring"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.LadyLuck,2,  100, 0x048E, "Gillionaire"),
            new Ability((byte)PartyMember.All,(byte)Dressphere.LadyLuck,2,  100, 0x0490, "Double Items"),

            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Mascot,1,   0, 0x0000, "Attack"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Mascot,5,  40, 0x01C2, "Moogle Jolt"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Mascot,5,   0, 0x0000, "Moogle Cure"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Mascot,5,   0, 0x0000, "Moogle Regen"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Mascot,10,  0, 0x00B6, "Moogle Wall"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Mascot,5,   0, 0x0000, "Moogle Life"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Mascot,5,  40, 0x01BA, "Moogle Cureja"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Mascot,5,  40, 0x01BC, "Moogle Regenja"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Mascot,10, 40, 0x01BE, "Moogle Wallja"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Mascot,5,  40, 0x01C0, "Moogle Lifeja"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Mascot,7,  80, 0x01C4, "Moogle Beam"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Mascot,2, 999, 0x053E, "Ribbon"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Mascot,2,  80, 0x0544, "Auto-Shell"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Mascot,2,  80, 0x0546, "Auto-Protect"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Mascot,9,  80, 0x000E, "Swordplay"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Mascot,9,  80, 0x0012, "Arcana"),

            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Mascot,1,   0, 0x0000, "Attack"),//auto
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Mascot,7,   0, 0x0000, "Cait Fire"),//auto
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Mascot,7,   0, 0x0000, "Cait Thunder"),//auto
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Mascot,7,   0, 0x0000, "Cait Blizzard"),//auto
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Mascot,7,   0, 0x0000, "Cait Water"),//auto
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Mascot,7,  40, 0x01CE, "Power Eraser"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Mascot,7,  40, 0x01D0, "Armour Eraser"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Mascot,7,  40, 0x01D2, "Magic Eraser"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Mascot,7,  40, 0x01D4, "Mental Eraser"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Mascot,7,  40, 0x01D6, "Speed Eraser"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Mascot,11, 80, 0x01D8, "PuPu Platter"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Mascot,2, 999, 0x053E, "Ribbon"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Mascot,2,  80, 0x0544, "Auto-Shell"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Mascot,2,  80, 0x0544, "Auto-Protect"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Mascot,9,  80, 0x0014, "Instinct"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Mascot,9,  80, 0x0018, "White Magic"),

            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Mascot,1,   0, 0x0000, "Attack"),//auto
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Mascot,8,   0, 0x0000, "Dark Knife"),//auto
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Mascot,8,   0, 0x0000, "Silence Knife"),//auto
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Mascot,8,   0, 0x0000, "Sleep Knife"),//auto
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Mascot,8,   0, 0x0000, "Berserk Knife"),//auto
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Mascot,8,   0, 0x0000, "Poison Knife"),//auto
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Mascot,8,   0, 0x0000, "Stone Knife"),//auto
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Mascot,8,   0, 0x0000, "Stop Knife"),//auto
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Mascot,8,   0, 0x0000, "Quartet Knife"),//auto
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Mascot,8,   0, 0x0000, "Arsenic Knife"),//auto
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Mascot,6,  80, 0x01EC, "Cactling Gun"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Mascot,2, 999, 0x053E, "Ribbon"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Mascot,2,  80, 0x0544, "Auto-Shell"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Mascot,2,  80, 0x0546, "Auto-Protect"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Mascot,9,  80, 0x0010, "Bushido"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Mascot,9,  80, 0x0016, "Black Magic"),

            //0x3D0 = 30 -> unlock flare sandals
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Festivalist,1,   0, 0x0000, "Attack"),//auto
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Festivalist,5,  30, 0x03C4, "Twinkler"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Festivalist,6,  30, 0x03B8, "Spinner"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Festivalist,6,  30, 0x03BE, "Popper"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Festivalist,6,  40, 0x03CA, "Fountain"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Festivalist,6,   0, 0x0000, "Fire Sandals"),//auto
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Festivalist,6,  30, 0x03D2, "Ice Sandals"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Festivalist,6,  30, 0x03D4, "Ltgn. Sandals"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Festivalist,6,  30, 0x03D6, "Water Sandals"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Festivalist,6,  60, 0x03D8, "Flare Sandals"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Festivalist,6, 100, 0x03DA, "Ultima Sandals"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Festivalist,2,  30, 0x0496, "Piercing Magic"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Festivalist,2,  30, 0x0510, "Silenceproof"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Festivalist,2,  30, 0x0528, "Pointlessproof"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Festivalist,2,  30, 0x055E, "SOS Regen"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Festivalist,2, 100, 0x05A6, "SOS Wall"),

            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Festivalist,1,   0, 0x0000, "Attack"),//auto
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Festivalist,5,  30, 0x01A2, "Twinkler"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Festivalist,6,  30, 0x0196, "Spinner"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Festivalist,6,  30, 0x019C, "Popper"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Festivalist,6,  40, 0x01A8, "Fountain"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Festivalist,6,   0, 0x0000, "Fire Fish"),//auto
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Festivalist,6,  30, 0x01BA, "Ice Fish"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Festivalist,6,  30, 0x01BC, "Ltgn. Fish"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Festivalist,6,  30, 0x01BE, "Water Fish"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Festivalist,6,  60, 0x01C0, "Gravity Fish"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Festivalist,6, 100, 0x01C2, "Holy Fish"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Festivalist,2,  30, 0x030A, "Slowproof"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Festivalist,2,  40, 0x030E, "Stopproof"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Festivalist,2,  20, 0x0304, "Pointlessproof"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Festivalist,2,  30, 0x033A, "SOS Regen"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Festivalist,2, 100, 0x0382, "SOS Wall"),

            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Festivalist,1,   0, 0x0000, "Attack"),//auto
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Festivalist,5,  30, 0x01A4, "Twinkler"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Festivalist,6,  30, 0x0198, "Spinner"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Festivalist,6,  30, 0x019E, "Popper"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Festivalist,6,  40, 0x01AA, "Fountain"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Festivalist,6,   0, 0x0000, "Blind Mask"),//auto
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Festivalist,6,  30, 0x01C4, "Silence Mask"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Festivalist,6,  30, 0x01CA, "Sleep Mask"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Festivalist,6,  30, 0x01C8, "Poison Mask"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Festivalist,6,  60, 0x01CC, "Stop Mask"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Festivalist,6,  80, 0x01CE, "Petro Mask"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Festivalist,2,  30, 0x030A, "Slowproof"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Festivalist,2,  40, 0x030E, "Stopproof"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Festivalist,2,  50, 0x033C, "SOS Haste"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Festivalist,2,  30, 0x033A, "SOS Regen"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Festivalist,2, 100, 0x0382, "SOS Wall"),

            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Psychic, 0,    0, 0x0000, "Attack"),//auto
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Psychic, 6,    0, 0x0000, "Psychic Bomb"),//auto
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Psychic, 6,   30, 0x03A0, "MaserEye"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Psychic, 6,   30, 0x039E, "Telekenesis"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Psychic, 6,   30, 0x03A2, "Brainstorm"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Psychic, 10,  40, 0x03A6, "Express"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Psychic, 10,  30, 0x03AC, "Teleport"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Psychic, 6,  100, 0x03A4, "Time Trip"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Psychic, 10,  80, 0x03A8, "Magic Guard"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Psychic, 10,  80, 0x03AA, "Physics Guard"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Psychic, 10, 120, 0x03AE, "Excellence"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Psychic, 2,   40, 0x04CA, "Fire Eater"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Psychic, 2,   40, 0x04D2, "Ice Eater"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Psychic, 2,   40, 0x04DA, "Lightning Eater"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Psychic, 2,   40, 0x04E2, "Water Eater"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.Psychic, 2,   60, 0x04EA, "Gravity Eater"),

            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Psychic, 0,    0, 0x0000, "Attack"),//auto
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Psychic, 6,    0, 0x0000, "Psychic Bomb"),//auto
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Psychic, 6,   30, 0x017C, "MaserEye"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Psychic, 6,   30, 0x017A, "Telekenesis"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Psychic, 6,   30, 0x017E, "Brainstorm"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Psychic, 10,  40, 0x0182, "Express"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Psychic, 10,  30, 0x0188, "Teleport"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Psychic, 6,  100, 0x0180, "Time Trip"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Psychic, 10,  80, 0x0184, "Magic Guard"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Psychic, 10,  80, 0x0186, "Physics Guard"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Psychic, 10, 120, 0x018A, "Excellence"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Psychic, 2,   40, 0x02A6, "Fire Eater"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Psychic, 2,   40, 0x02AE, "Ice Eater"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Psychic, 2,   40, 0x02B6, "Lightning Eater"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Psychic, 2,   40, 0x02BE, "Water Eater"),
            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.Psychic, 2,   60, 0x02C6, "Gravity Eater"),

            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Psychic, 0,    0, 0x0000, "Attack"),//auto
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Psychic, 6,    0, 0x0000, "Psychic Bomb"),//auto
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Psychic, 6,   30, 0x017C, "MaserEye"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Psychic, 6,   30, 0x017A, "Telekenesis"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Psychic, 6,   30, 0x017E, "Brainstorm"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Psychic, 10,  40, 0x0182, "Express"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Psychic, 10,  30, 0x0188, "Teleport"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Psychic, 6,  100, 0x0180, "Time Trip"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Psychic, 10,  80, 0x0184, "Magic Guard"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Psychic, 10,  80, 0x0186, "Physics Guard"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Psychic, 10, 120, 0x018A, "Excellence"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Psychic, 2,   40, 0x02A6, "Fire Eater"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Psychic, 2,   40, 0x02AE, "Ice Eater"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Psychic, 2,   40, 0x02B6, "Lightning Eater"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Psychic, 2,   40, 0x02BE, "Water Eater"),
            new Ability((byte)PartyMember.Paine,(byte)Dressphere.Psychic, 2,   60, 0x02C6, "Gravity Eater"),

            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.FloralFallal,1,   0, 0x0000, "Attack"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.FloralFallal,11,  4, 0x01FA, "Libra"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.FloralFallal,7,   0, 0x0000, "Heat Whirl"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.FloralFallal,7,   0, 0x0000, "Ice Whirl"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.FloralFallal,7,   0, 0x0000, "Electric Whirl"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.FloralFallal,7,   0, 0x0000, "Aqua Whirl"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.FloralFallal,10, 20, 0x01F8, "Barrier"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.FloralFallal,10, 20, 0x01F6, "Shield"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.FloralFallal,7,  24, 0x01FC, "Flare Whirl"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.FloralFallal,7,  30, 0x0200, "Great Whirl"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.FloralFallal,5,   8, 0x01FE, "All-Life"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.FloralFallal,2,   0, 0x0000, "Ribbon"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.FloralFallal,2,  20, 0x0554, "Double HP"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.FloralFallal,2,  30, 0x0556, "Triple HP"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.FloralFallal,2,  20, 0x0486, "Break HP Limit"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.FloralFallal,2,  20, 0x048A, "Break Dmg. Limit"),

            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.RightPistil,5,   0, 0x0000, "White Pollen"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.RightPistil,5,  10, 0x15E4, "White Honey"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.RightPistil,10,  0, 0x0000, "Hard Leaves"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.RightPistil,10,  0, 0x0000, "Tough Nuts"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.RightPistil,10,  0, 0x0000, "Mirror Petals"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.RightPistil,10, 20, 0x15EC, "Floral Rush"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.RightPistil,6,   0, 0x0000, "Floral Bomb"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.RightPistil,6,  10, 0x15F0, "Fallal Bomb"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.RightPistil,6,  10, 0x15F2, "Floral Magisol"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.RightPistil,6,  10, 0x15F4, "Fallal Magisol"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.RightPistil,6,  20, 0x15F6, "Right Stigma"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.RightPistil,2,   0, 0x0000, "Ribbon"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.RightPistil,2,  20, 0x1934, "Double HP"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.RightPistil,2,  30, 0x1936, "Triple HP"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.RightPistil,2,  20, 0x1866, "Break HP Limit"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.RightPistil,2,  20, 0x186A, "Break Dmg. Limit"),

            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.LeftPistil,7,   0, 0x0000, "Dream Pollen"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.LeftPistil,7,   0, 0x0000, "Mad Seeds"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.LeftPistil,7,   0, 0x0000, "Sticky Honey"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.LeftPistil,7,   0, 0x0000, "Halfdeath Petals"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.LeftPistil,7,  10, 0x1CA0, "Poison Leaves"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.LeftPistil,7,  10, 0x1CA2, "Death Petals"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.LeftPistil,6,   0, 0x0000, "Silent White"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.LeftPistil,6,  20, 0x1CA8, "Congealed Honey"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.LeftPistil,6,  10, 0x1CA6, "Panic Floralysis"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.LeftPistil,6,  10, 0x1CA4, "Ash Floralysis"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.LeftPistil,6,  20, 0x1CAC, "Left Stigma"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.LeftPistil,2,   0, 0x0000, "Ribbon"),//auto
			new Ability((byte)PartyMember.Yuna,(byte)Dressphere.LeftPistil,2,  20, 0x1FD4, "Double HP"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.LeftPistil,2,  30, 0x1FD6, "Triple HP"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.LeftPistil,2,  20, 0x1F06, "Break HP Limit"),
            new Ability((byte)PartyMember.Yuna,(byte)Dressphere.LeftPistil,2,  20, 0x1F0A, "Break Dmg. Limit"),

            new Ability((byte)PartyMember.Rikku,(byte)Dressphere.MachinaMaw,1,   0, 0x0000, "Attack"),//auto
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.MachinaMaw,5,  10, 0x0240, "Revival"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.MachinaMaw,6,   0, 0x0000, "Death Missile"),//auto
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.MachinaMaw,6,   0, 0x0000, "Bio Misile"),//auto
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.MachinaMaw,6,   0, 0x0000, "Break Missile"),//auto
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.MachinaMaw,6,  10, 0x0236, "Berserk Missile"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.MachinaMaw,6,  10, 0x0238, "Stop Missile"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.MachinaMaw,6,  10, 0x023A, "Confuse Missile"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.MachinaMaw,6,  20, 0x023C, "Shockwave"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.MachinaMaw,6,  20, 0x023E, "Shockstorm"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.MachinaMaw,6,  30, 0x0242, "Vajra"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.MachinaMaw,2,   0, 0x0000, "Ribbon"),//auto
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.MachinaMaw,2,  20, 0x0554, "Double HP"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.MachinaMaw,2,  30, 0x0556, "Triple HP"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.MachinaMaw,2,  20, 0x0486, "Break HP Limit"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.MachinaMaw,2,  20, 0x048A, "Break Dmg. Limit"),

			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.SmasherR,6,   0, 0x0000, "Howitzer"),//auto
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.SmasherR,6,  10, 0x1CCC, "Sleep Shell"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.SmasherR,6,  10, 0x1CCE, "Slow Shell"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.SmasherR,6,  10, 0x1CD0, "Anti-Power Shell"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.SmasherR,6,  10, 0x1CD2, "Anti-Armour Shell"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.SmasherR,11, 10, 0x1CD4, "Scan"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.SmasherR,10, 20, 0x1CD6, "Shellter"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.SmasherR,10, 20, 0x1CD8, "Protector"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.SmasherR,5,   0, 0x0000, "HP Repair"),//auto
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.SmasherR,5,   0, 0x0000, "MP Repair"),//auto
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.SmasherR,6,   0, 0x0000, "Homing Ray"),//auto
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.SmasherR,2,   0, 0x0000, "Ribbon"),//auto
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.SmasherR,2,  20, 0x1FD4, "Double HP"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.SmasherR,2,  30, 0x1FD6, "Triple HP"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.SmasherR,2,  20, 0x1F06, "Break HP Limit"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.SmasherR,2,  20, 0x1F0A, "Break Dmg. Limit"),

			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.CrusherL,6,   0, 0x0000, "Howitzer"),//auto
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.CrusherL,6,  10, 0x2382, "Blind Shell"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.CrusherL,6,  10, 0x2384, "Silence Shell"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.CrusherL,6,  10, 0x2386, "Anti-Magic Shell"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.CrusherL,6,  10, 0x2388, "Anti-Mental Shell"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.CrusherL,10, 20, 0x238A, "Booster"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.CrusherL,10, 20, 0x238C, "Offence"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.CrusherL,10, 20, 0x238E, "Defence"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.CrusherL,5,   0, 0x0000, "HP Repair"),//auto
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.CrusherL,5,   0, 0x0000, "MP Repair"),//auto
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.CrusherL,6,   0, 0x0000, "Homing Ray"),//auto
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.CrusherL,2,   0, 0x0000, "Ribbon"),//auto
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.CrusherL,2,  20, 0x2674, "Double HP"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.CrusherL,2,  30, 0x2676, "Triple HP"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.CrusherL,2,  20, 0x25A6, "Break HP Limit"),
			new Ability((byte)PartyMember.Rikku,(byte)Dressphere.CrusherL,2,  20, 0x25AA, "Break Dmg. Limit"),

			new Ability((byte)PartyMember.Paine,(byte)Dressphere.FullThrottle,1,   0, 0x0000, "Attack"),//auto
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.FullThrottle,8,  20, 0x0280, "Fright"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.FullThrottle,1,   0, 0x0000, "Aestus"),//auto
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.FullThrottle,1,   0, 0x0000, "Winterkill"),//auto
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.FullThrottle,1,   0, 0x0000, "Whelmen"),//auto
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.FullThrottle,1,   0, 0x0000, "Levin"),//auto
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.FullThrottle,1,  10, 0x0278, "Wisenen"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.FullThrottle,1,  20, 0x027A, "Fiers"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.FullThrottle,1,  20, 0x027C, "Deeth"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.FullThrottle,1,  20, 0x027E, "Assoil"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.FullThrottle,8,  30, 0x0282, "Sword Dance"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.FullThrottle,2,   0, 0x0000, "Ribbon"),//auto
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.FullThrottle,2,  20, 0x0554, "Double HP"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.FullThrottle,2,  30, 0x0556, "Triple HP"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.FullThrottle,2,  20, 0x0486, "Break HP Limit"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.FullThrottle,2,  20, 0x048A, "Break Dmg. Limit"),

			new Ability((byte)PartyMember.Paine,(byte)Dressphere.DextralWing,7,   0, 0x0000, "Venom Wing"),//auto
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.DextralWing,7,   0, 0x0000, "Blind Wing"),//auto
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.DextralWing,7,   0, 0x0000, "Mute Wing"),//auto
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.DextralWing,7,  10, 0x23AA, "Rock Wing"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.DextralWing,7,   0, 0x0000, "Lazy Wing"),//auto
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.DextralWing,7,  10, 0x23AE, "Violent Wing"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.DextralWing,7,  10, 0x23B0, "Still Wing"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.DextralWing,7,  10, 0x23B2, "Crazy Wing"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.DextralWing,5,   0, 0x0000, "Stamina"),//auto
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.DextralWing,5,   0, 0x0000, "Mettle"),//auto
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.DextralWing,5,  10, 0x23B8, "Reboot"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.DextralWing,2,   0, 0x0000, "Ribbon"),//auto
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.DextralWing,2,  20, 0x2674, "Double HP"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.DextralWing,2,  30, 0x2676, "Triple HP"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.DextralWing,2,  20, 0x25A6, "Break HP Limit"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.DextralWing,2,  20, 0x25AA, "Break Dmg. Limit"),

			new Ability((byte)PartyMember.Paine,(byte)Dressphere.SinistralWing,10,  0, 0x0000, "Steel Feather"),//auto
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.SinistralWing,10,  0, 0x0000, "Diamond Feather"),//auto
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.SinistralWing,7,   0, 0x0000, "White Feather"),//auto
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.SinistralWing,7,   0, 0x0000, "Buckle Feather"),//auto
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.SinistralWing,7,  10, 0x2A66, "Cloudy Feather"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.SinistralWing,7,  10, 0x2A68, "Pointed Feather"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.SinistralWing,10, 10, 0x2A5E, "Pumice Feather"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.SinistralWing,11, 10, 0x2A60, "Ma'at's Feather"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.SinistralWing,5,   0, 0x0000, "Stamina"),//auto
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.SinistralWing,5,   0, 0x0000, "Mettle"),//auto
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.SinistralWing,5,  10, 0x2A6E, "Reboot"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.SinistralWing,2,   0, 0x0000, "Ribbon"),//auto
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.SinistralWing,2,  20, 0x2D14, "Double HP"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.SinistralWing,2,  30, 0x2D16, "Triple HP"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.SinistralWing,2,  20, 0x2C46, "Break HP Limit"),
			new Ability((byte)PartyMember.Paine,(byte)Dressphere.SinistralWing,2,  20, 0x2C4A, "Break Dmg. Limit"),
        };

        public static Uri[] AbilityIcons =
        {
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/SkillAttack.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/SkillAttackW.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/SkillAuto.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/SkillDance.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/SkillHealFree.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/SkillHealMagic.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/SkillMagic.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/SkillMagicD.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/SkillMagicW.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/SkillMenu.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/SkillMenuW.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/SkillSpecial.png"),
            new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/Potion.png")
        };

        public static ImageBrush MasteredBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/FFX2SaveEditor;component/Resources/Master.png")));
    }
}
