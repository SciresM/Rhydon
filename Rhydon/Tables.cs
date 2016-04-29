using System;

namespace Rhydon
{
    public static class Tables
    {
        private const int TYPE_NORMAL = 0x00;
        private const int TYPE_FIGHTING = 0x01;
        private const int TYPE_FLYING = 0x02;
        private const int TYPE_POISON = 0x03;
        private const int TYPE_GROUND = 0x04;
        private const int TYPE_ROCK = 0x05;
        /* 0x06 unknown */
        private const int TYPE_BUG = 0x07;
        private const int TYPE_GHOST = 0x08;
        /* 0x08-0x13 unknown */
        private const int TYPE_FIRE = 0x14;
        private const int TYPE_WATER = 0x15;
        private const int TYPE_GRASS = 0x16;
        private const int TYPE_ELECTRIC = 0x17;
        private const int TYPE_PSYCHIC = 0x18;
        private const int TYPE_ICE = 0x19;
        private const int TYPE_DRAGON = 0x1A;

        public static readonly int[] ID_To_Dex =
        {
            0x00, 0x70, 0x73, 0x20, 0x23, 0x15, 0x64, 0x22, 0x50, 0x02, 0x67, 0x6C, 0x66,
            0x58, 0x5E, 0x1D, 0x1F, 0x68, 0x6F, 0x83, 0x3B, 0x97, 0x82, 0x5A, 0x48, 0x5C, 0x7B, 0x78, 0x09, 0x7F, 0x72,
            0x00, 0x00, 0x3A, 0x5F, 0x16, 0x10, 0x4F, 0x40, 0x4B, 0x71, 0x43, 0x7A, 0x6A, 0x6B, 0x18, 0x2F, 0x36, 0x60,
            0x4C, 0x00, 0x7E, 0x00, 0x7D, 0x52, 0x6D, 0x00, 0x38, 0x56, 0x32, 0x80, 0x00, 0x00, 0x00, 0x53, 0x30, 0x95,
            0x00, 0x00, 0x00, 0x54, 0x3C, 0x7C, 0x92, 0x90, 0x91, 0x84, 0x34, 0x62, 0x00, 0x00, 0x00, 0x25, 0x26, 0x19,
            0x1A, 0x00, 0x00, 0x93, 0x94, 0x8C, 0x8D, 0x74, 0x75, 0x00, 0x00, 0x1B, 0x1C, 0x8A, 0x8B, 0x27, 0x28, 0x85,
            0x88, 0x87, 0x86, 0x42, 0x29, 0x17, 0x2E, 0x3D, 0x3E, 0x0D, 0x0E, 0x0F, 0x00, 0x55, 0x39, 0x33, 0x31, 0x57,
            0x00, 0x00, 0x0A, 0x0B, 0x0C, 0x44, 0x00, 0x37, 0x61, 0x2A, 0x96, 0x8F, 0x81, 0x00, 0x00, 0x59, 0x00, 0x63,
            0x5B, 0x00, 0x65, 0x24, 0x6E, 0x35, 0x69, 0x00, 0x5D, 0x3F, 0x41, 0x11, 0x12, 0x79, 0x01, 0x03, 0x49, 0x00,
            0x76, 0x77, 0x00, 0x00, 0x00, 0x00, 0x4D, 0x4E, 0x13, 0x14, 0x21, 0x1E, 0x4A, 0x89, 0x8E, 0x00, 0x51, 0x00,
            0x00, 0x04, 0x07, 0x05, 0x08, 0x06, 0x00, 0x00, 0x00, 0x00, 0x2B, 0x2C, 0x2D, 0x45, 0x46, 0x47, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        };

        public static readonly int[] Dex_To_ID =
        {
            0x00, 0x99, 0x09, 0x9A, 0xB0, 0xB2, 0xB4, 0xB1, 0xB3, 0x1C, 0x7B, 0x7C, 0x7D,
            0x70, 0x71, 0x72, 0x24, 0x96, 0x97, 0xA5, 0xA6, 0x05, 0x23, 0x6C, 0x2D, 0x54, 0x55, 0x60, 0x61, 0x0F, 0xA8,
            0x10, 0x03, 0xA7, 0x07, 0x04, 0x8E, 0x52, 0x53, 0x64, 0x65, 0x6B, 0x82, 0xB9, 0xBA, 0xBB, 0x6D, 0x2E, 0x41,
            0x77, 0x3B, 0x76, 0x4D, 0x90, 0x2F, 0x80, 0x39, 0x75, 0x21, 0x14, 0x47, 0x6E, 0x6F, 0x94, 0x26, 0x95, 0x6A,
            0x29, 0x7E, 0xBC, 0xBD, 0xBE, 0x18, 0x9B, 0xA9, 0x27, 0x31, 0xA3, 0xA4, 0x25, 0x08, 0xAD, 0x36, 0x40, 0x46,
            0x74, 0x3A, 0x78, 0x0D, 0x88, 0x17, 0x8B, 0x19, 0x93, 0x0E, 0x22, 0x30, 0x81, 0x4E, 0x8A, 0x06, 0x8D, 0x0C,
            0x0A, 0x11, 0x91, 0x2B, 0x2C, 0x0B, 0x37, 0x8F, 0x12, 0x01, 0x28, 0x1E, 0x02, 0x5C, 0x5D, 0x9D, 0x9E, 0x1B,
            0x98, 0x2A, 0x1A, 0x48, 0x35, 0x33, 0x1D, 0x3C, 0x85, 0x16, 0x13, 0x4C, 0x66, 0x69, 0x68, 0x67, 0xAA, 0x62,
            0x63, 0x5A, 0x5B, 0xAB, 0x84, 0x4A, 0x4B, 0x49, 0x58, 0x59, 0x42, 0x83, 0x15, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        };

        public static readonly int[] ID_To_Sprite =
        {
            0x00, 0x00, 0x00, 0x00, 0x03, 0x04, 0x01, 0x00, 0x00, 0x07, 0x07, 0x00, 0x07,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x09, 0x05, 0x09, 0x00, 0x08, 0x02, 0x05, 0x00, 0x06, 0x02, 0x05, 0x06, 0x07,
            0x00, 0x00, 0x09, 0x08, 0x04, 0x04, 0x09, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x08, 0x06, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x05, 0x00, 0x09, 0x00, 0x00, 0x00, 0x04, 0x06, 0x08,
            0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x04, 0x04, 0x04, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00, 0x09, 0x09, 0x03,
            0x03, 0x00, 0x00, 0x08, 0x08, 0x02, 0x02, 0x05, 0x05, 0x00, 0x00, 0x00, 0x00, 0x02, 0x02, 0x03, 0x03, 0x09,
            0x09, 0x09, 0x09, 0x00, 0x00, 0x08, 0x06, 0x00, 0x00, 0x06, 0x06, 0x06, 0x00, 0x04, 0x00, 0x00, 0x06, 0x05,
            0x00, 0x00, 0x06, 0x06, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00, 0x00, 0x05,
            0x02, 0x00, 0x01, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x04, 0x02, 0x07, 0x07, 0x05, 0x00,
            0x05, 0x05, 0x00, 0x00, 0x00, 0x00, 0x09, 0x09, 0x09, 0x09, 0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x01, 0x00,
            0x00, 0x00, 0x05, 0x00, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0x07, 0x07, 0x07, 0x07, 0x07, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        };

        public static readonly string[] ID_To_Name =
        {
            "Missingno", "Rhydon", "Kangaskhan", "Nidoran♂", "Clefairy", "Spearow",
            "Voltorb", "Nidoking", "Slowbro", "Ivysaur", "Exeggutor", "Lickitung", "Exeggcute", "Grimer", "Gengar",
            "Nidoran♀", "Nidoqueen", "Cubone", "Rhyhorn", "Lapras", "Arcanine", "Mew", "Gyarados", "Shellder",
            "Tentacool", "Gastly", "Scyther", "Staryu", "Blastoise", "Pinsir", "Tangela", "Missingno", "Missingno",
            "Growlithe", "Onix", "Fearow", "Pidgey", "Slowpoke", "Kadabra", "Graveler", "Chansey", "Machoke", "Mr. Mime",
            "Hitmonlee", "Hitmonchan", "Arbok", "Parasect", "Psyduck", "Drowzee", "Golem", "Missingno", "Magmar",
            "Missingno", "Electabuzz", "Magneton", "Koffing", "Missingno", "Mankey", "Seel", "Diglett", "Tauros",
            "Missingno", "Missingno", "Missingno", "Farfetchd", "Venonat", "Dragonite", "Missingno", "Missingno",
            "Missingno", "Doduo", "Poliwag", "Jynx", "Moltres", "Articuno", "Zapdos", "Ditto", "Meowth", "Krabby",
            "Missingno", "Missingno", "Missingno", "Vulpix", "Ninetales", "Pikachu", "Raichu", "Missingno", "Missingno",
            "Dratini", "Dragonair", "Kabuto", "Kabutops", "Horsea", "Seadra", "Missingno", "Missingno", "Sandshrew",
            "Sandslash", "Omanyte", "Omastar", "Jigglypuff", "Wigglytuff", "Eevee", "Flareon", "Jolteon", "Vaporeon",
            "Machop", "Zubat", "Ekans", "Paras", "Poliwhirl", "Poliwrath", "Weedle", "Kakuna", "Beedrill", "Missingno",
            "Dodrio", "Primeape", "Dugtrio", "Venomoth", "Dewgong", "Missingno", "Missingno", "Caterpie", "Metapod",
            "Butterfree", "Machamp", "Missingno", "Golduck", "Hypno", "Golbat", "Mewtwo", "Snorlax", "Magikarp",
            "Missingno", "Missingno", "Muk", "Missingno", "Kingler", "Cloyster", "Missingno", "Electrode", "Clefable",
            "Weezing", "Persian", "Marowak", "Missingno", "Haunter", "Abra", "Alakazam", "Pidgeotto", "Pidgeot",
            "Starmie", "Bulbasaur", "Venusaur", "Tentacruel", "Missingno", "Goldeen", "Seaking", "Missingno",
            "Missingno", "Missingno", "Missingno", "Ponyta", "Rapidash", "Rattata", "Raticate", "Nidorino", "Nidorina",
            "Geodude", "Porygon", "Aerodactyl", "Missingno", "Magnemite", "Missingno", "Missingno", "Charmander",
            "Squirtle", "Charmeleon", "Wartortle", "Charizard", "Missingno", "Missingno", "Missingno", "Missingno",
            "Oddish", "Gloom", "Vileplume", "Bellsprout", "Weepinbell", "Victreebel", "Missingno", "Missingno",
            "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno",
            "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno",
            "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno",
            "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno",
            "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno",
            "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno",
            "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno",
            "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno", "Missingno"
        };

        public static readonly string[] ID_To_MoveName =
        {
            "(None)", "Pound", "Karate Chop", "Doubleslap", "Comet Punch", "Mega Punch",
            "Pay Day", "Fire Punch", "Ice Punch", "Thunderpunch", "Scratch", "Vicegrip", "Guillotine", "Razor Wind",
            "Swords Dance", "Cut", "Gust", "Wing Attack", "Whirlwind", "Fly", "Bind", "Slam", "Vine Whip", "Stomp",
            "Double Kick", "Mega Kick", "Jump Kick", "Rolling Kick", "Sand Attack", "Headbutt", "Horn Attack",
            "Fury Attack", "Horn Drill", "Tackle", "Body Slam", "Wrap", "Take down", "Thrash", "Double Edge",
            "Tail Whip", "Poison Sting", "Twineedle", "Pin Missile", "Leer", "Bite", "Growl", "Roar", "Sing",
            "Supersonic", "Sonicboom", "Disable", "Acid", "Ember", "Flamethrower", "Mist", "Water Gun", "Hydro Pump",
            "Surf", "Ice Beam", "Blizzard", "Psybeam", "Bubblebeam", "Aurora Beam", "Hyper Beam", "Peck", "Drill Peck",
            "Submission", "Low Kick", "Counter", "Seismic Toss", "Strength", "Absorb", "Mega Drain", "Leech Seed",
            "Growth", "Razor Leaf", "Solarbeam", "Poisonpowder", "Stun Spore", "Sleep Powder", "Petal Dance",
            "String Shot", "Dragon Rage", "Fire Spin", "Thundershock", "Thunderbolt", "Thunder Wave", "Thunder",
            "Rock Throw", "Earthquake", "Fissure", "Dig", "Toxic", "Confusion", "Psychic", "Hypnosis", "Meditate",
            "Agility", "Quick Attack", "Rage", "Teleport", "Night Shade", "Mimic", "Screech", "Double Team", "Recover",
            "Harden", "Minimize", "Smokescreen", "Confuse Ray", "Withdraw", "Defense Curl", "Barrier", "Light Screen",
            "Haze", "Reflect", "Focus Energy", "Bide", "Metronome", "Mirror Move", "Selfdestruct", "Egg Bomb", "Lick",
            "Smog", "Sludge", "Bone Club", "Fire Blast", "Waterfall", "Clamp", "Swift", "Skull Bash", "Spike Cannon",
            "Constrict", "Amnesia", "Kinesis", "Softboiled", "Hi Jump Kick", "Glare", "Dream Eater", "Poison Gas",
            "Barrage", "Leech Life", "Lovely Kiss", "Sky Attack", "Transform", "Bubble", "Dizzy Punch", "Spore", "Flash",
            "Psywave", "Splash", "Acid Armor", "Crabhammer", "Explosion", "Fury Swipes", "Bonemerang", "Rest",
            "Rock Slide", "Hyper Fang", "Sharpen", "Conversion", "Tri Attack", "Super Fang", "Slash", "Substitute",
            "Struggle", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
            "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
            "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
            "", "", "", "", "", "", "", "", "", "", "", ""
        };

        public static readonly string[] ID_To_ItemName = { "(None)", "Master Ball", "Ultra Ball", "Great Ball", "Poké Ball", "Town Map", "Bicycle", "????? (7)", "Safari Ball", "Pokédex", "Moon Stone", "Antidote", "Burn Heal", "Ice Heal", "Awakening", "Parlyz Heal", "Full Restore", "Max Potion", "Hyper Potion", "Super Potion", "Potion", "BoulderBadge", "CascadeBadge", "ThunderBadge", "RainbowBadge", "SoulBadge", "MarshBadge", "VolcanoBadge", "EarthBadge", "Escape Rope", "Repel", "Old Amber", "Fire Stone", "Thunder Stone", "Water Stone", "HP Up", "Protein", "Iron", "Carbos", "Calcium", "Rare Candy", "Dome Fossil", "Helix Fossil", "Secret Key", "????? (44)", "Bike Voucher", "X Accuracy", "Leaf Stone", "Card Key", "Nugget", "PP Up", "Poké Doll", "Full Heal", "Revive", "Max Revive", "Guard Spec.", "Super Repel", "Max Repel", "Dire Hit", "Coin", "Fresh Water", "Soda Pop", "Lemonade", "S.S. Ticket", "Gold Teeth", "X Attack", "X Defend", "X Speed", "X Special", "Coin Case", "Oak's Parcel", "Itemfinder", "Silph Scope", "Poké Flute", "Lift Key", "Exp. All", "Old Rod", "Good Rod", "Super Rod", "PP Up", "Ether", "Max Ether", "Elixer", "Max Elixer", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "HM01", "HM02", "HM03", "HM04", "HM05", "TM01", "TM02", "TM03", "TM04", "TM05", "TM06", "TM07", "TM08", "TM09", "TM10", "TM11", "TM12", "TM13", "TM14", "TM15", "TM16", "TM17", "TM18", "TM19", "TM20", "TM21", "TM22", "TM23", "TM24", "TM25", "TM26", "TM27", "TM28", "TM29", "TM30", "TM31", "TM32", "TM33", "TM34", "TM35", "TM36", "TM37", "TM38", "TM39", "TM40", "TM41", "TM42", "TM43", "TM44", "TM45", "TM46", "TM47", "TM48", "TM49", "TM50", "TM51", "TM52", "TM53", "TM54", "TM55" };

        public static int getItemIndex(string name)
        {
            return Array.IndexOf(ID_To_ItemName, name);
        }

        public static string getItemName(int id)
        {
            if (id < 0 || id > ID_To_ItemName.Length)
                throw new IndexOutOfRangeException("Invalid Item Name Access");
            return !string.IsNullOrEmpty(ID_To_ItemName[id]) 
                ? ID_To_ItemName[id] 
                : $"[Item 0x{id.ToString("X2")}]";
        }

        public enum Stats
        {
            HP = 0,
            ATK = 1,
            DEF = 2,
            SPD = 3,
            SPC = 4
        }

        // HP, ATK, DEF, SPE, SPC, TYPE_1, TYPE_2, CATCH_RATE, BASE_EXP_YIELD.
        // From onesav: https://projectpokemon.org/forums/showthread.php?42680-onesav-a-gen-1-save-file-viewer-and-editor
        public static readonly int[][] ID_To_Base_Stats =
        {
            new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x1F) */
            new []{ 105, 130, 120,  40,  45,   TYPE_GROUND,     TYPE_ROCK,  60, 204 }, /* RHYDON       (0x01) */
        	new []{ 105,  95,  80,  90,  40,   TYPE_NORMAL,   TYPE_NORMAL,  45, 175 }, /* KANGASKHAN   (0x02) */
        	new []{  46,  57,  40,  50,  40,   TYPE_POISON,   TYPE_POISON, 235,  60 }, /* NIDORAN_M    (0x03) */
        	new []{  70,  45,  48,  35,  60,   TYPE_NORMAL,   TYPE_NORMAL, 150,  68 }, /* CLEFAIRY     (0x04) */
        	new []{  40,  60,  30,  70,  31,   TYPE_NORMAL,   TYPE_FLYING, 255,  58 }, /* SPEAROW      (0x05) */
        	new []{  40,  30,  50, 100,  55, TYPE_ELECTRIC, TYPE_ELECTRIC, 190, 103 }, /* VOLTORB      (0x06) */
        	new []{  81,  92,  77,  85,  75,   TYPE_POISON,   TYPE_GROUND,  45, 195 }, /* NIDOKING     (0x07) */
        	new []{  95,  75, 110,  30,  80,    TYPE_WATER,  TYPE_PSYCHIC,  75, 164 }, /* SLOWBRO      (0x08) */
        	new []{  60,  62,  63,  60,  80,    TYPE_GRASS,   TYPE_POISON,  45, 141 }, /* IVYSAUR      (0x09) */
        	new []{  95,  95,  85,  55, 125,    TYPE_GRASS,  TYPE_PSYCHIC,  45, 212 }, /* EXEGGUTOR    (0x0A) */
        	new []{  90,  55,  75,  30,  60,   TYPE_NORMAL,   TYPE_NORMAL,  45, 127 }, /* LICKITUNG    (0x0B) */
        	new []{  60,  40,  80,  40,  60,    TYPE_GRASS,  TYPE_PSYCHIC,  90,  98 }, /* EXEGGCUTE    (0x0C) */
        	new []{  80,  80,  50,  25,  40,   TYPE_POISON,   TYPE_POISON, 190,  90 }, /* GRIMER       (0x0D) */
        	new []{  60,  65,  60, 110, 130,    TYPE_GHOST,   TYPE_POISON,  45, 190 }, /* GENGAR       (0x0E) */
        	new []{  55,  47,  52,  41,  40,   TYPE_POISON,   TYPE_POISON, 235,  59 }, /* NIDORAN_F    (0x0F) */
        	new []{  90,  82,  87,  76,  75,   TYPE_POISON,   TYPE_GROUND,  45, 194 }, /* NIDOQUEEN    (0x10) */
        	new []{  50,  50,  95,  35,  40,   TYPE_GROUND,   TYPE_GROUND, 190,  87 }, /* CUBONE       (0x11) */
        	new []{  80,  85,  95,  25,  30,   TYPE_GROUND,     TYPE_ROCK, 120, 135 }, /* RHYHORN      (0x12) */
        	new []{ 130,  85,  80,  60,  95,    TYPE_WATER,      TYPE_ICE,  45, 219 }, /* LAPRAS       (0x13) */
        	new []{  90, 110,  80,  95,  80,     TYPE_FIRE,     TYPE_FIRE,  75, 213 }, /* ARCANINE     (0x14) */
        	new []{ 100, 100, 100, 100, 100,  TYPE_PSYCHIC,  TYPE_PSYCHIC,  45,  64 }, /* MEW          (0x15) */
        	new []{  95, 125,  79,  81, 100,    TYPE_WATER,   TYPE_FLYING,  45, 214 }, /* GYARADOS     (0x16) */
        	new []{  30,  65, 100,  40,  45,    TYPE_WATER,    TYPE_WATER, 190,  97 }, /* SHELLDER     (0x17) */
        	new []{  40,  40,  35,  70, 100,    TYPE_WATER,   TYPE_POISON, 190, 105 }, /* TENTACOOL    (0x18) */
        	new []{  30,  35,  30,  80, 100,    TYPE_GHOST,   TYPE_POISON, 190,  95 }, /* GASTLY       (0x19) */
        	new []{  70, 110,  80, 105,  55,      TYPE_BUG,   TYPE_FLYING,  45, 187 }, /* SCYTHER      (0x1A) */
        	new []{  30,  45,  55,  85,  70,    TYPE_WATER,    TYPE_WATER, 225, 106 }, /* STARYU       (0x1B) */
        	new []{  79,  83, 100,  78,  85,    TYPE_WATER,    TYPE_WATER,  45, 210 }, /* BLASTOISE    (0x1C) */
        	new []{  65, 125, 100,  85,  55,      TYPE_BUG,      TYPE_BUG,  45, 200 }, /* PINSIR       (0x1D) */
        	new []{  65,  55, 115,  60, 100,    TYPE_GRASS,    TYPE_GRASS,  45, 166 }, /* TANGELA      (0x1E) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x1F) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x20) */
        	new []{  55,  70,  45,  60,  50,     TYPE_FIRE,     TYPE_FIRE, 190,  91 }, /* GROWLITHE    (0x21) */
        	new []{  35,  45, 160,  70,  30,     TYPE_ROCK,   TYPE_GROUND,  45, 108 }, /* ONIX         (0x22) */
        	new []{  65,  90,  65, 100,  61,   TYPE_NORMAL,   TYPE_FLYING,  90, 162 }, /* FEAROW       (0x23) */
        	new []{  40,  45,  40,  56,  35,   TYPE_NORMAL,   TYPE_FLYING, 255,  55 }, /* PIDGEY       (0x24) */
        	new []{  90,  65,  65,  15,  40,    TYPE_WATER,  TYPE_PSYCHIC, 190,  99 }, /* SLOWPOKE     (0x25) */
        	new []{  40,  35,  30, 105, 120,  TYPE_PSYCHIC,  TYPE_PSYCHIC, 100, 145 }, /* KADABRA      (0x26) */
        	new []{  55,  95, 115,  35,  45,     TYPE_ROCK,   TYPE_GROUND, 120, 134 }, /* GRAVELER     (0x27) */
        	new []{ 250,   5,   5,  50, 105,   TYPE_NORMAL,   TYPE_NORMAL,  30, 255 }, /* CHANSEY      (0x28) */
        	new []{  80, 100,  70,  45,  50, TYPE_FIGHTING, TYPE_FIGHTING,  90, 146 }, /* MACHOKE      (0x29) */
        	new []{  40,  45,  65,  90, 100,  TYPE_PSYCHIC,  TYPE_PSYCHIC,  45, 136 }, /* MR_MIME      (0x2A) */
        	new []{  50, 120,  53,  87,  35, TYPE_FIGHTING, TYPE_FIGHTING,  45, 139 }, /* HITMONLEE    (0x2B) */
        	new []{  50, 105,  79,  76,  35, TYPE_FIGHTING, TYPE_FIGHTING,  45, 140 }, /* HITMONCHAN   (0x2C) */
        	new []{  60,  85,  69,  80,  65,   TYPE_POISON,   TYPE_POISON,  90, 147 }, /* ARBOK        (0x2D) */
        	new []{  60,  95,  80,  30,  80,      TYPE_BUG,    TYPE_GRASS,  75, 128 }, /* PARASECT     (0x2E) */
        	new []{  50,  52,  48,  55,  50,    TYPE_WATER,    TYPE_WATER, 190,  80 }, /* PSYDUCK      (0x2F) */
        	new []{  60,  48,  45,  42,  90,  TYPE_PSYCHIC,  TYPE_PSYCHIC, 190, 102 }, /* DROWZEE      (0x30) */
        	new []{  80, 110, 130,  45,  55,     TYPE_ROCK,   TYPE_GROUND,  45, 177 }, /* GOLEM        (0x31) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x32) */
        	new []{  65,  95,  57,  93,  85,     TYPE_FIRE,     TYPE_FIRE,  45, 167 }, /* MAGMAR       (0x33) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x34) */
        	new []{  65,  83,  57, 105,  85, TYPE_ELECTRIC, TYPE_ELECTRIC,  45, 156 }, /* ELECTABUZZ   (0x35) */
        	new []{  50,  60,  95,  70, 120, TYPE_ELECTRIC, TYPE_ELECTRIC,  60, 161 }, /* MAGNETON     (0x36) */
        	new []{  40,  65,  95,  35,  60,   TYPE_POISON,   TYPE_POISON, 190, 114 }, /* KOFFING      (0x37) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x38) */
        	new []{  40,  80,  35,  70,  35, TYPE_FIGHTING, TYPE_FIGHTING, 190,  74 }, /* MANKEY       (0x39) */
        	new []{  65,  45,  55,  45,  70,    TYPE_WATER,    TYPE_WATER, 190, 100 }, /* SEEL         (0x3A) */
        	new []{  10,  55,  25,  95,  45,   TYPE_GROUND,   TYPE_GROUND, 255,  81 }, /* DIGLETT      (0x3B) */
        	new []{  75, 100,  95, 110,  70,   TYPE_NORMAL,   TYPE_NORMAL,  45, 211 }, /* TAUROS       (0x3C) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x3D) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x3E) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x3F) */
        	new []{  52,  65,  55,  60,  58,   TYPE_NORMAL,   TYPE_FLYING,  45,  94 }, /* FARFETCH_D   (0x40) */
        	new []{  60,  55,  50,  45,  40,      TYPE_BUG,   TYPE_POISON, 190,  75 }, /* VENONAT      (0x41) */
        	new []{  91, 134,  95,  80, 100,   TYPE_DRAGON,   TYPE_FLYING,  45, 218 }, /* DRAGONITE    (0x42) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x43) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x44) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x45) */
        	new []{  35,  85,  45,  75,  35,   TYPE_NORMAL,   TYPE_FLYING, 190,  96 }, /* DODUO        (0x46) */
        	new []{  40,  50,  40,  90,  40,    TYPE_WATER,    TYPE_WATER, 255,  77 }, /* POLIWAG      (0x47) */
        	new []{  65,  50,  35,  95,  95,      TYPE_ICE,  TYPE_PSYCHIC,  45, 137 }, /* JYNX         (0x48) */
        	new []{  90, 100,  90,  90, 125,     TYPE_FIRE,   TYPE_FLYING,   3, 217 }, /* MOLTRES      (0x49) */
        	new []{  90,  85, 100,  85, 125,      TYPE_ICE,   TYPE_FLYING,   3, 215 }, /* ARTICUNO     (0x4A) */
        	new []{  90,  90,  85, 100, 125, TYPE_ELECTRIC,   TYPE_FLYING,   3, 216 }, /* ZAPDOS       (0x4B) */
        	new []{  48,  48,  48,  48,  48,   TYPE_NORMAL,   TYPE_NORMAL,  35,  61 }, /* DITTO        (0x4C) */
        	new []{  40,  45,  35,  90,  40,   TYPE_NORMAL,   TYPE_NORMAL, 255,  69 }, /* MEOWTH       (0x4D) */
        	new []{  30, 105,  90,  50,  25,    TYPE_WATER,    TYPE_WATER, 225, 115 }, /* KRABBY       (0x4E) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x4F) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x50) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x51) */
        	new []{  38,  41,  40,  65,  65,     TYPE_FIRE,     TYPE_FIRE, 190,  63 }, /* VULPIX       (0x52) */
        	new []{  73,  76,  75, 100, 100,     TYPE_FIRE,     TYPE_FIRE,  75, 178 }, /* NINETALES    (0x53) */
        	new []{  35,  55,  30,  90,  50, TYPE_ELECTRIC, TYPE_ELECTRIC, 190,  82 }, /* PIKACHU      (0x54) */
        	new []{  60,  90,  55, 100,  90, TYPE_ELECTRIC, TYPE_ELECTRIC,  75, 122 }, /* RAICHU       (0x55) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x56) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x57) */
        	new []{  41,  64,  45,  50,  50,   TYPE_DRAGON,   TYPE_DRAGON,  45,  67 }, /* DRATINI      (0x58) */
        	new []{  61,  84,  65,  70,  70,   TYPE_DRAGON,   TYPE_DRAGON,  45, 144 }, /* DRAGONAIR    (0x59) */
        	new []{  30,  80,  90,  55,  45,     TYPE_ROCK,    TYPE_WATER,  45, 119 }, /* KABUTO       (0x5A) */
        	new []{  60, 115, 105,  80,  70,     TYPE_ROCK,    TYPE_WATER,  45, 201 }, /* KABUTOPS     (0x5B) */
        	new []{  30,  40,  70,  60,  70,    TYPE_WATER,    TYPE_WATER, 225,  83 }, /* HORSEA       (0x5C) */
        	new []{  55,  65,  95,  85,  95,    TYPE_WATER,    TYPE_WATER,  75, 155 }, /* SEADRA       (0x5D) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x5E) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x5F) */
        	new []{  50,  75,  85,  40,  30,   TYPE_GROUND,   TYPE_GROUND, 255,  93 }, /* SANDSHREW    (0x60) */
        	new []{  75, 100, 110,  65,  55,   TYPE_GROUND,   TYPE_GROUND,  90, 163 }, /* SANDSLASH    (0x61) */
        	new []{  35,  40, 100,  35,  90,     TYPE_ROCK,    TYPE_WATER,  45, 120 }, /* OMANYTE      (0x62) */
        	new []{  70,  60, 125,  55, 115,     TYPE_ROCK,    TYPE_WATER,  45, 199 }, /* OMASTAR      (0x63) */
        	new []{ 115,  45,  20,  20,  25,   TYPE_NORMAL,   TYPE_NORMAL, 170,  76 }, /* JIGGLYPUFF   (0x64) */
        	new []{ 140,  70,  45,  45,  50,   TYPE_NORMAL,   TYPE_NORMAL,  50, 109 }, /* WIGGLYTUFF   (0x65) */
        	new []{  55,  55,  50,  55,  65,   TYPE_NORMAL,   TYPE_NORMAL,  45,  92 }, /* EEVEE        (0x66) */
        	new []{  65, 130,  60,  65, 110,     TYPE_FIRE,     TYPE_FIRE,  45, 198 }, /* FLAREON      (0x67) */
        	new []{  65,  65,  60, 130, 110, TYPE_ELECTRIC, TYPE_ELECTRIC,  45, 197 }, /* JOLTEON      (0x68) */
        	new []{ 130,  65,  60,  65, 110,    TYPE_WATER,    TYPE_WATER,  45, 196 }, /* VAPOREON     (0x69) */
        	new []{  70,  80,  50,  35,  35, TYPE_FIGHTING, TYPE_FIGHTING, 180,  88 }, /* MACHOP       (0x6A) */
        	new []{  40,  45,  35,  55,  40,   TYPE_POISON,   TYPE_FLYING, 255,  54 }, /* ZUBAT        (0x6B) */
        	new []{  35,  60,  44,  55,  40,   TYPE_POISON,   TYPE_POISON, 255,  62 }, /* EKANS        (0x6C) */
        	new []{  35,  70,  55,  25,  55,      TYPE_BUG,    TYPE_GRASS, 190,  70 }, /* PARAS        (0x6D) */
        	new []{  65,  65,  65,  90,  50,    TYPE_WATER,    TYPE_WATER, 120, 131 }, /* POLIWHIRL    (0x6E) */
        	new []{  90,  85,  95,  70,  70,    TYPE_WATER, TYPE_FIGHTING,  45, 185 }, /* POLIWRATH    (0x6F) */
        	new []{  40,  35,  30,  50,  20,      TYPE_BUG,   TYPE_POISON, 255,  52 }, /* WEEDLE       (0x70) */
        	new []{  45,  25,  50,  35,  25,      TYPE_BUG,   TYPE_POISON, 120,  71 }, /* KAKUNA       (0x71) */
        	new []{  65,  80,  40,  75,  45,      TYPE_BUG,   TYPE_POISON,  45, 159 }, /* BEEDRILL     (0x72) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x73) */
        	new []{  60, 110,  70, 100,  60,   TYPE_NORMAL,   TYPE_FLYING,  45, 158 }, /* DODRIO       (0x74) */
        	new []{  65, 105,  60,  95,  60, TYPE_FIGHTING, TYPE_FIGHTING,  75, 149 }, /* PRIMEAPE     (0x75) */
        	new []{  35,  80,  50, 120,  70,   TYPE_GROUND,   TYPE_GROUND,  50, 153 }, /* DUGTRIO      (0x76) */
        	new []{  70,  65,  60,  90,  90,      TYPE_BUG,   TYPE_POISON,  75, 138 }, /* VENOMOTH     (0x77) */
        	new []{  90,  70,  80,  70,  95,    TYPE_WATER,      TYPE_ICE,  75, 176 }, /* DEWGONG      (0x78) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x79) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x7A) */
        	new []{  45,  30,  35,  45,  20,      TYPE_BUG,      TYPE_BUG, 255,  53 }, /* CATERPIE     (0x7B) */
        	new []{  50,  20,  55,  30,  25,      TYPE_BUG,      TYPE_BUG, 120,  72 }, /* METAPOD      (0x7C) */
        	new []{  60,  45,  50,  70,  80,      TYPE_BUG,   TYPE_FLYING,  45, 160 }, /* BUTTERFREE   (0x7D) */
        	new []{  90, 130,  80,  55,  65, TYPE_FIGHTING, TYPE_FIGHTING,  45, 193 }, /* MACHAMP      (0x7E) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x7F) */
        	new []{  80,  82,  78,  85,  80,    TYPE_WATER,    TYPE_WATER,  75, 174 }, /* GOLDUCK      (0x80) */
        	new []{  85,  73,  70,  67, 115,  TYPE_PSYCHIC,  TYPE_PSYCHIC,  75, 165 }, /* HYPNO        (0x81) */
        	new []{  75,  80,  70,  90,  75,   TYPE_POISON,   TYPE_FLYING,  90, 171 }, /* GOLBAT       (0x82) */
        	new []{ 106, 110,  90, 130, 154,  TYPE_PSYCHIC,  TYPE_PSYCHIC,   3, 220 }, /* MEWTWO       (0x83) */
        	new []{ 160, 110,  65,  30,  65,   TYPE_NORMAL,   TYPE_NORMAL,  25, 154 }, /* SNORLAX      (0x84) */
        	new []{  20,  10,  55,  80,  20,    TYPE_WATER,    TYPE_WATER, 255,  20 }, /* MAGIKARP     (0x85) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x86) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x87) */
        	new []{ 105, 105,  75,  50,  65,   TYPE_POISON,   TYPE_POISON,  75, 157 }, /* MUK          (0x88) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x89) */
        	new []{  55, 130, 115,  75,  50,    TYPE_WATER,    TYPE_WATER,  60, 206 }, /* KINGLER      (0x8A) */
        	new []{  50,  95, 180,  70,  85,    TYPE_WATER,      TYPE_ICE,  60, 203 }, /* CLOYSTER     (0x8B) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x8C) */
        	new []{  60,  50,  70, 140,  80, TYPE_ELECTRIC, TYPE_ELECTRIC,  60, 150 }, /* ELECTRODE    (0x8D) */
        	new []{  95,  70,  73,  60,  85,   TYPE_NORMAL,   TYPE_NORMAL,  25, 129 }, /* CLEFABLE     (0x8E) */
        	new []{  65,  90, 120,  60,  85,   TYPE_POISON,   TYPE_POISON,  60, 173 }, /* WEEZING      (0x8F) */
        	new []{  65,  70,  60, 115,  65,   TYPE_NORMAL,   TYPE_NORMAL,  90, 148 }, /* PERSIAN      (0x90) */
        	new []{  60,  80, 110,  45,  50,   TYPE_GROUND,   TYPE_GROUND,  75, 124 }, /* MAROWAK      (0x91) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x92) */
        	new []{  45,  50,  45,  95, 115,    TYPE_GHOST,   TYPE_POISON,  90, 126 }, /* HAUNTER      (0x93) */
        	new []{  25,  20,  15,  90, 105,  TYPE_PSYCHIC,  TYPE_PSYCHIC, 200,  73 }, /* ABRA         (0x94) */
        	new []{  55,  50,  45, 120, 135,  TYPE_PSYCHIC,  TYPE_PSYCHIC,  50, 186 }, /* ALAKAZAM     (0x95) */
        	new []{  63,  60,  55,  71,  50,   TYPE_NORMAL,   TYPE_FLYING, 120, 113 }, /* PIDGEOTTO    (0x96) */
        	new []{  83,  80,  75,  91,  70,   TYPE_NORMAL,   TYPE_FLYING,  45, 172 }, /* PIDGEOT      (0x97) */
        	new []{  60,  75,  85, 115, 100,    TYPE_WATER,  TYPE_PSYCHIC,  60, 207 }, /* STARMIE      (0x98) */
        	new []{  45,  49,  49,  45,  65,    TYPE_GRASS,   TYPE_POISON,  45,  64 }, /* BULBASAUR    (0x99) */
        	new []{  80,  82,  83,  80, 100,    TYPE_GRASS,   TYPE_POISON,  45, 208 }, /* VENUSAUR     (0x9A) */
        	new []{  80,  70,  65, 100, 120,    TYPE_WATER,   TYPE_POISON,  60, 205 }, /* TENTACRUEL   (0x9B) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x9C) */
        	new []{  45,  67,  60,  63,  50,    TYPE_WATER,    TYPE_WATER, 225, 111 }, /* GOLDEEN      (0x9D) */
        	new []{  80,  92,  65,  68,  80,    TYPE_WATER,    TYPE_WATER,  60, 170 }, /* SEAKING      (0x9E) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0x9F) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0xA0) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0xA1) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0xA2) */
        	new []{  50,  85,  55,  90,  65,     TYPE_FIRE,     TYPE_FIRE, 190, 152 }, /* PONYTA       (0xA3) */
        	new []{  65, 100,  70, 105,  80,     TYPE_FIRE,     TYPE_FIRE,  60, 192 }, /* RAPIDASH     (0xA4) */
        	new []{  30,  56,  35,  72,  25,   TYPE_NORMAL,   TYPE_NORMAL, 255,  57 }, /* RATTATA      (0xA5) */
        	new []{  55,  81,  60,  97,  50,   TYPE_NORMAL,   TYPE_NORMAL,  90, 116 }, /* RATICATE     (0xA6) */
        	new []{  61,  72,  57,  65,  55,   TYPE_POISON,   TYPE_POISON, 120, 118 }, /* NIDORINO     (0xA7) */
        	new []{  70,  62,  67,  56,  55,   TYPE_POISON,   TYPE_POISON, 120, 117 }, /* NIDORINA     (0xA8) */
        	new []{  40,  80, 100,  20,  30,     TYPE_ROCK,   TYPE_GROUND, 255,  86 }, /* GEODUDE      (0xA9) */
        	new []{  65,  60,  70,  40,  75,   TYPE_NORMAL,   TYPE_NORMAL,  45, 130 }, /* PORYGON      (0xAA) */
        	new []{  80, 105,  65, 130,  60,     TYPE_ROCK,   TYPE_FLYING,  45, 202 }, /* AERODACTYL   (0xAB) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0xAC) */
        	new []{  25,  35,  70,  45,  95, TYPE_ELECTRIC, TYPE_ELECTRIC, 190,  89 }, /* MAGNEMITE    (0xAD) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0xAE) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0xAF) */
        	new []{  39,  52,  43,  65,  50,     TYPE_FIRE,     TYPE_FIRE,  45,  65 }, /* CHARMANDER   (0xB0) */
        	new []{  44,  48,  65,  43,  50,    TYPE_WATER,    TYPE_WATER,  45,  66 }, /* SQUIRTLE     (0xB1) */
        	new []{  58,  64,  58,  80,  65,     TYPE_FIRE,     TYPE_FIRE,  45, 142 }, /* CHARMELEON   (0xB2) */
        	new []{  59,  63,  80,  58,  65,    TYPE_WATER,    TYPE_WATER,  45, 143 }, /* WARTORTLE    (0xB3) */
        	new []{  78,  84,  78, 100,  85,     TYPE_FIRE,   TYPE_FLYING,  45, 209 }, /* CHARIZARD    (0xB4) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0xB5) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0xB6) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0xB7) */
        	new []{   0,   0,   0,   0,   0,   TYPE_NORMAL,   TYPE_NORMAL,   0,   0 }, /* MISSINGNO    (0xB8) */
        	new []{  45,  50,  55,  30,  75,    TYPE_GRASS,   TYPE_POISON, 255,  78 }, /* ODDISH       (0xB9) */
        	new []{  60,  65,  70,  40,  85,    TYPE_GRASS,   TYPE_POISON, 120, 132 }, /* GLOOM        (0xBA) */
        	new []{  75,  80,  85,  50, 100,    TYPE_GRASS,   TYPE_POISON,  45, 184 }, /* VILEPLUME    (0xBB) */
        	new []{  50,  75,  35,  40,  70,    TYPE_GRASS,   TYPE_POISON, 255,  84 }, /* BELLSPROUT   (0xBC) */
        	new []{  65,  90,  50,  55,  85,    TYPE_GRASS,   TYPE_POISON, 120, 151 }, /* WEEPINBELL   (0xBD) */
        	new []{  80, 105,  65,  70, 100,    TYPE_GRASS,   TYPE_POISON,  45, 191 }, /* VICTREEBEL   (0xBE) */
    };

        internal static readonly int[] ID_To_Growth_Rate = { 0, 5, 0, 3, 4, 0, 0, 3, 0, 3, 5, 0, 5, 0, 3, 3, 3, 0, 5, 5, 5, 3, 5, 5, 5, 3, 0, 5, 3, 5, 0, 0, 0, 5, 0, 0, 3, 0, 3, 3, 4, 3, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 3, 0, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 3, 0, 0, 0, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 5, 0, 0, 4, 0, 0, 0, 0, 3, 3, 3, 3, 3, 5, 3, 3, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 0, 5, 0, 0, 0, 0, 3, 3, 3, 3, 3, 0, 0, 0, 0, 3, 3, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        // From PKHeX: https://github.com/kwsch/PKHeX
        internal static int getLevel(int species, uint exp)
        {
            if (exp == 0) return 1;

            int growth = ID_To_Growth_Rate[species];

            // Iterate upwards to find the level above our current level
            int tl = 0; // Initial Level, immediately incremented before loop.
            while (ExpTable[++tl, growth] <= exp)
            {
                if (tl != 100) continue;
                return 100;
                // After we find the level above ours, we're done.
            }
            return --tl;
        }

        // From PKHeX
        internal static uint getEXP(int level, int species)
        {
            // Fetch Growth
            if (level <= 1) return 0;
            if (level > 100) level = 100;
            return ExpTable[level, ID_To_Growth_Rate[species]];
        }

        // From PKHeX, though only four columns get used.
        internal static readonly uint[,] ExpTable =
        {
            {0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0},
            {8, 15, 4, 9, 6, 10},
            {27, 52, 13, 57, 21, 33},
            {64, 122, 32, 96, 51, 80},
            {125, 237, 65, 135, 100, 156},
            {216, 406, 112, 179, 172, 270},
            {343, 637, 178, 236, 274, 428},
            {512, 942, 276, 314, 409, 640},
            {729, 1326, 393, 419, 583, 911},
            {1000, 1800, 540, 560, 800, 1250},
            {1331, 2369, 745, 742, 1064, 1663},
            {1728, 3041, 967, 973, 1382, 2160},
            {2197, 3822, 1230, 1261, 1757, 2746},
            {2744, 4719, 1591, 1612, 2195, 3430},
            {3375, 5737, 1957, 2035, 2700, 4218},
            {4096, 6881, 2457, 2535, 3276, 5120},
            {4913, 8155, 3046, 3120, 3930, 6141},
            {5832, 9564, 3732, 3798, 4665, 7290},
            {6859, 11111, 4526, 4575, 5487, 8573},
            {8000, 12800, 5440, 5460, 6400, 10000},
            {9261, 14632, 6482, 6458, 7408, 11576},
            {10648, 16610, 7666, 7577, 8518, 13310},
            {12167, 18737, 9003, 8825, 9733, 15208},
            {13824, 21012, 10506, 10208, 11059, 17280},
            {15625, 23437, 12187, 11735, 12500, 19531},
            {17576, 26012, 14060, 13411, 14060, 21970},
            {19683, 28737, 16140, 15244, 15746, 24603},
            {21952, 31610, 18439, 17242, 17561, 27440},
            {24389, 34632, 20974, 19411, 19511, 30486},
            {27000, 37800, 23760, 21760, 21600, 33750},
            {29791, 41111, 26811, 24294, 23832, 37238},
            {32768, 44564, 30146, 27021, 26214, 40960},
            {35937, 48155, 33780, 29949, 28749, 44921},
            {39304, 51881, 37731, 33084, 31443, 49130},
            {42875, 55737, 42017, 36435, 34300, 53593},
            {46656, 59719, 46656, 40007, 37324, 58320},
            {50653, 63822, 50653, 43808, 40522, 63316},
            {54872, 68041, 55969, 47846, 43897, 68590},
            {59319, 72369, 60505, 52127, 47455, 74148},
            {64000, 76800, 66560, 56660, 51200, 80000},
            {68921, 81326, 71677, 61450, 55136, 86151},
            {74088, 85942, 78533, 66505, 59270, 92610},
            {79507, 90637, 84277, 71833, 63605, 99383},
            {85184, 95406, 91998, 77440, 68147, 106480},
            {91125, 100237, 98415, 83335, 72900, 113906},
            {97336, 105122, 107069, 89523, 77868, 121670},
            {103823, 110052, 114205, 96012, 83058, 129778},
            {110592, 115015, 123863, 102810, 88473, 138240},
            {117649, 120001, 131766, 109923, 94119, 147061},
            {125000, 125000, 142500, 117360, 100000, 156250},
            {132651, 131324, 151222, 125126, 106120, 165813},
            {140608, 137795, 163105, 133229, 112486, 175760},
            {148877, 144410, 172697, 141677, 119101, 186096},
            {157464, 151165, 185807, 150476, 125971, 196830},
            {166375, 158056, 196322, 159635, 133100, 207968},
            {175616, 165079, 210739, 169159, 140492, 219520},
            {185193, 172229, 222231, 179056, 148154, 231491},
            {195112, 179503, 238036, 189334, 156089, 243890},
            {205379, 186894, 250562, 199999, 164303, 256723},
            {216000, 194400, 267840, 211060, 172800, 270000},
            {226981, 202013, 281456, 222522, 181584, 283726},
            {238328, 209728, 300293, 234393, 190662, 297910},
            {250047, 217540, 315059, 246681, 200037, 312558},
            {262144, 225443, 335544, 259392, 209715, 327680},
            {274625, 233431, 351520, 272535, 219700, 343281},
            {287496, 241496, 373744, 286115, 229996, 359370},
            {300763, 249633, 390991, 300140, 240610, 375953},
            {314432, 257834, 415050, 314618, 251545, 393040},
            {328509, 267406, 433631, 329555, 262807, 410636},
            {343000, 276458, 459620, 344960, 274400, 428750},
            {357911, 286328, 479600, 360838, 286328, 447388},
            {373248, 296358, 507617, 377197, 298598, 466560},
            {389017, 305767, 529063, 394045, 311213, 486271},
            {405224, 316074, 559209, 411388, 324179, 506530},
            {421875, 326531, 582187, 429235, 337500, 527343},
            {438976, 336255, 614566, 447591, 351180, 548720},
            {456533, 346965, 639146, 466464, 365226, 570666},
            {474552, 357812, 673863, 485862, 379641, 593190},
            {493039, 367807, 700115, 505791, 394431, 616298},
            {512000, 378880, 737280, 526260, 409600, 640000},
            {531441, 390077, 765275, 547274, 425152, 664301},
            {551368, 400293, 804997, 568841, 441094, 689210},
            {571787, 411686, 834809, 590969, 457429, 714733},
            {592704, 423190, 877201, 613664, 474163, 740880},
            {614125, 433572, 908905, 636935, 491300, 767656},
            {636056, 445239, 954084, 660787, 508844, 795070},
            {658503, 457001, 987754, 685228, 526802, 823128},
            {681472, 467489, 1035837, 710266, 545177, 851840},
            {704969, 479378, 1071552, 735907, 563975, 881211},
            {729000, 491346, 1122660, 762160, 583200, 911250},
            {753571, 501878, 1160499, 789030, 602856, 941963},
            {778688, 513934, 1214753, 816525, 622950, 973360},
            {804357, 526049, 1254796, 844653, 643485, 1005446},
            {830584, 536557, 1312322, 873420, 664467, 1038230},
            {857375, 548720, 1354652, 902835, 685900, 1071718},
            {884736, 560922, 1415577, 932903, 707788, 1105920},
            {912673, 571333, 1460276, 963632, 730138, 1140841},
            {941192, 583539, 1524731, 995030, 752953, 1176490},
            {970299, 591882, 1571884, 1027103, 776239, 1212873},
            {1000000, 600000, 1640000, 1059860, 800000, 1250000},
        };

        public static readonly int[] movePPs = { 35, 25, 10, 15, 20, 20, 15, 15, 15, 35, 30, 5, 10, 30, 30, 35, 35, 20, 15, 20, 20, 10, 20, 30, 5, 25, 15, 15, 15, 25, 20, 5, 35, 15, 20, 20, 20, 15, 30, 35, 20, 20, 30, 25, 40, 20, 15, 20, 20, 20, 30, 25, 15, 30, 25, 5, 15, 10, 5, 20, 20, 20, 5, 35, 20, 25, 20, 20, 20, 15, 20, 10, 10, 40, 25, 10, 35, 30, 15, 20, 40, 10, 15, 30, 15, 20, 10, 15, 10, 5, 10, 10, 25, 10, 20, 40, 30, 30, 20, 20, 15, 10, 40, 15, 20, 30, 20, 20, 10, 40, 40, 30, 30, 30, 20, 30, 10, 10, 20, 5, 10, 30, 20, 20, 20, 5, 15, 10, 20, 15, 15, 35, 20, 15, 10, 20, 30, 15, 40, 20, 15, 10, 5, 10, 30, 10, 15, 20, 15, 40, 40, 10, 5, 15, 10, 10, 10, 15, 30, 30, 10, 10, 20, 10, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public static int getMovePP(int move, int ppup)
        {
            return movePPs[move] * (5 + ppup) / 5;
        }
    }

}
