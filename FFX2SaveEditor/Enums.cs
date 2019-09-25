using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFX2SaveEditor
{
    public enum MenuScreen
    {
        Main,
        Items,
        StoryCompletion,
        Equip,
        GarmentGrids,
        AbilitiesPartySelect,
        Accessories,
        Dresspheres,
        MiniGames,
        Sidequests,
        Config,
        AbilitiesDressSelect,
        Abilities,
        MiniGameSelect
    }

    public enum PartyMember
    {
        Yuna,
        Rikku,
        Paine,
        All
    }

    public enum ItemType
    {
        Potion,
        Magic,
        Misc
    }

    public enum Dressphere
    {
        None,
        Gunner,
        GunMage,
        Alchemist,
        Warrior,
        Samurai,
        DarkKnight,
        Berserker,
        Songstress,
        BlackMage,
        WhiteMage,
        Thief,
        Trainer,
        LadyLuck,
        Mascot,
        FloralFallal,
        RightPistil,
        LeftPistil,
        MachinaMaw,
        SmasherR,
        CrusherL,
        FullThrottle,
        DextralWing,
        SinistralWing,
        TrainerRikku,
        TrainerPaine,
        MascotRikku,
        MascotPaine,
        Psychic,
        Festivalist,
        FestivalistRikku,
        FestivalistPaine,
        Freelancer,
        LeblancGoon,
        WarriorDupe
    }
}
