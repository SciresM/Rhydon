using System;
using System.Linq;

namespace Rhydon
{
    public class PK1
    {
        internal const int SIZE_PARTY = 0x2C;
        internal const int SIZE_STORED = 0x21;

        public PK1(byte[] d = null, string i = "")
        {
            Data = (byte[])(d ?? new byte[SIZE_PARTY]).Clone();
            Identifier = i;
            if (Data.Length != SIZE_PARTY)
            {
                Array.Resize(ref Data, SIZE_PARTY);
            }
        }

        public PK1 Clone()
        {
            PK1 new_pk1 = new PK1();
            Array.Copy(Data, 0, new_pk1.Data, 0, Data.Length);
            Array.Copy(otname, 0, new_pk1.otname, 0, otname.Length);
            Array.Copy(nick, 0, new_pk1.nick, 0, nick.Length);
            return new_pk1;
        }

        // Internal Attributes set on creation
        public byte[] Data; // Raw Storage
        public string Identifier; // User or Form Custom Attribute

        private byte[] otname = Enumerable.Repeat((byte)0x50, 0xB).ToArray();
        private byte[] nick = Enumerable.Repeat((byte)0x50, 0xB).ToArray();

        public byte[] OT_Name { get { return otname; } set { if (value == null) return; value.CopyTo(otname, 0); } }
        public byte[] Nickname { get { return nick; } set { if (value == null) return; value.CopyTo(nick, 0); } }

        // Structure
        public byte Species
        {
            get { return Data[0]; }
            set
            {
                if (value < byte.MinValue || value > byte.MaxValue)
                    return;
                Data[0] = value;
                Type_A = (byte)Tables.ID_To_Base_Stats[value][5];
                Type_B = (byte)Tables.ID_To_Base_Stats[value][6];
                Catch_Rate = (byte)Tables.ID_To_Base_Stats[value][7];
            }
        }
        public ushort HP_Current
        {
            get { return Util.ToUInt16(Data, 1); }
            set { Util.GetBytes(value).CopyTo(Data, 1); }
        }

        public byte Level
        {
            get { return Data[3]; }
            set { Data[3] = value; }
        }

        public byte Status_Condition
        {
            get { return Data[4]; }
            set { Data[4] = value; }
        }

        public byte Type_A
        {
            get { return Data[5]; }
            set { Data[5] = value; }
        }

        public byte Type_B
        {
            get { return Data[6]; }
            set { Data[6] = value; }
        }

        public byte Catch_Rate
        {
            get { return Data[7]; }
            set { Data[7] = value; }
        }

        public byte Move_1
        {
            get { return Data[8]; }
            set { Data[8] = value; }
        }

        public byte Move_2
        {
            get { return Data[9]; }
            set { Data[9] = value; }
        }

        public byte Move_3
        {
            get { return Data[0xA]; }
            set { Data[0xA] = value; }
        }

        public byte Move_4
        {
            get { return Data[0xB]; }
            set { Data[0xB] = value; }
        }

        public ushort TID
        {
            get { return Util.ToUInt16(Data, 0xC); }
            set { Util.GetBytes(value).CopyTo(Data, 0xC); }
        }

        public uint EXP
        {
            get
            { return (Util.ToUInt32(Data, 0xE) >> 8) & 0x00FFFFFF; }
            set { Array.Copy(Util.GetBytes((value << 8) & 0xFFFFFF00), 0, Data, 0xE, 3); }
        }

        public ushort STATEXP_HP
        {
            get { return Util.ToUInt16(Data, 0x11); }
            set { Util.GetBytes(value).CopyTo(Data, 0x11); }
        }

        public ushort STATEXP_ATK
        {
            get { return Util.ToUInt16(Data, 0x13); }
            set { Util.GetBytes(value).CopyTo(Data, 0x13); }
        }

        public ushort STATEXP_DEF
        {
            get { return Util.ToUInt16(Data, 0x15); }
            set { Util.GetBytes(value).CopyTo(Data, 0x15); }
        }

        public ushort STATEXP_SPD
        {
            get { return Util.ToUInt16(Data, 0x17); }
            set { Util.GetBytes(value).CopyTo(Data, 0x17); }
        }

        public ushort STATEXP_SPC
        {
            get { return Util.ToUInt16(Data, 0x19); }
            set { Util.GetBytes(value).CopyTo(Data, 0x19); }
        }

        private ushort DV16
        {
            get { return Util.ToUInt16(Data, 0x1B); }
            set { Util.GetBytes(value).CopyTo(Data, 0x1B); }
        }

        public int DV_ATK
        {
            get { return (DV16 >> 12) & 0xF; }
            set { DV16 = (ushort)((DV16 & ~(0xF << 12)) | (ushort)((value > 0xF ? 0xF : value) << 12)); }
        }

        public int DV_DEF
        {
            get { return (DV16 >> 8) & 0xF; }
            set { DV16 = (ushort)((DV16 & ~(0xF << 8)) | (ushort)((value > 0xF ? 0xF : value) << 8)); }
        }

        public int DV_SPD
        {
            get { return (DV16 >> 4) & 0xF; }
            set { DV16 = (ushort)((DV16 & ~(0xF << 4)) | (ushort)((value > 0xF ? 0xF : value) << 4)); }
        }

        public int DV_SPC
        {
            get { return (DV16 >> 0) & 0xF; }
            set { DV16 = (ushort)((DV16 & ~(0xF << 0)) | (ushort)((value > 0xF ? 0xF : value) << 0)); }
        }


        public int DV_HP
        {
            get { return ((DV_ATK & 1) << 3) | ((DV_DEF & 1) << 2) | ((DV_SPD & 1) << 1) | ((DV_SPC & 1) << 0); }
        }

        public byte PP_1
        {
            get { return (byte)(Data[0x1D] & 0x3F); }
            set { Data[0x1D] = (byte)((Data[0x1D] & 0xC0) | (value & 0x3F)); }
        }

        public byte PPUP_1
        {
            get { return (byte)((Data[0x1D] & 0xC0) >> 6); }
            set { Data[0x1D] = (byte)((Data[0x1D] & 0x3F) | ((value & 0x3) << 6)); }
        }

        public byte PP_2
        {
            get { return (byte)(Data[0x1E] & 0x3F); }
            set { Data[0x1E] = (byte)((Data[0x1E] & 0xC0) | (value & 0x3F)); }
        }

        public byte PPUP_2
        {
            get { return (byte)((Data[0x1E] & 0xC0) >> 6); }
            set { Data[0x1E] = (byte)((Data[0x1E] & 0x3F) | ((value & 0x3) << 6)); }
        }

        public byte PP_3
        {
            get { return (byte)(Data[0x1F] & 0x3F); }
            set { Data[0x1F] = (byte)((Data[0x1F] & 0xC0) | (value & 0x3F)); }
        }

        public byte PPUP_3
        {
            get { return (byte)((Data[0x1F] & 0xC0) >> 6); }
            set { Data[0x1F] = (byte)((Data[0x1F] & 0x3F) | ((value & 0x3) << 6)); }
        }

        public byte PP_4
        {
            get { return (byte)(Data[0x20] & 0x3F); }
            set { Data[0x20] = (byte)((Data[0x20] & 0xC0) | (value & 0x3F)); }
        }

        public byte PPUP_4
        {
            get { return (byte)((Data[0x20] & 0xC0) >> 6); }
            set { Data[0x20] = (byte)((Data[0x20] & 0x3F) | ((value & 0x3) << 6)); }
        }

        // Party Only
        public byte Current_Level
        {
            get { return Data[0x21]; }
            set { Data[0x21] = value; }
        }
        public ushort HP_Max
        {
            get { return Util.ToUInt16(Data, 0x22); }
            set { Util.GetBytes(value).CopyTo(Data, 0x22); }
        }

        public ushort ATK
        {
            get { return Util.ToUInt16(Data, 0x24); }
            set { Util.GetBytes(value).CopyTo(Data, 0x24); }
        }

        public ushort DEF
        {
            get { return Util.ToUInt16(Data, 0x26); }
            set { Util.GetBytes(value).CopyTo(Data, 0x26); }
        }

        public ushort SPD
        {
            get { return Util.ToUInt16(Data, 0x28); }
            set { Util.GetBytes(value).CopyTo(Data, 0x28); }
        }

        public ushort SPC
        {
            get { return Util.ToUInt16(Data, 0x2A); }
            set { Util.GetBytes(value).CopyTo(Data, 0x2A); }
        }

        public int[] DVs
        {
            get { return new[] { DV_HP, DV_ATK, DV_DEF, DV_SPD, DV_SPC }; }
            set
            {
                if (value == null || value.Length != 4) return;
                DV_ATK = value[0];
                DV_DEF = value[1];
                DV_SPD = value[2];
                DV_SPC = value[3];
            }
        }

        public ushort[] STATEXPs
        {
            get { return new[] { STATEXP_HP, STATEXP_ATK, STATEXP_DEF, STATEXP_SPD, STATEXP_SPC }; }
            set
            {
                if (value == null || value.Length != 5) return;
                STATEXP_HP = value[0];
                STATEXP_ATK = value[1];
                STATEXP_DEF = value[2];
                STATEXP_SPD = value[3];
                STATEXP_SPC = value[4];
            }
        }

        public byte[] Moves
        {
            get { return new[] { Move_1, Move_2, Move_3, Move_4 }; }
            set
            {
                if (value == null || value.Length != 4) return;
                Move_1 = value[0];
                Move_2 = value[1];
                Move_3 = value[2];
                Move_4 = value[3];
            }
        }

        public void setPP(int index, byte PP)
        {
            switch (index)
            {
                case 0:
                    PP_1 = PP;
                    break;
                case 1:
                    PP_2 = PP;
                    break;
                case 2:
                    PP_3 = PP;
                    break;
                case 3:
                    PP_4 = PP;
                    break;
            }
        }

        public byte[] PPUPs
        {
            get { return new[] { PPUP_1, PPUP_2, PPUP_3, PPUP_4 }; }
            set
            {
                if (value == null || value.Length != 4) return;
                PPUP_1 = Math.Min(value[0], (byte)3);
                PPUP_2 = Math.Min(value[1], (byte)3);
                PPUP_3 = Math.Min(value[2], (byte)3);
                PPUP_4 = Math.Min(value[3], (byte)3);
            }
        }

        public ushort[] getStats()
        {
            ushort[] Stats = new[] { HP_Max, ATK, DEF, SPD, SPC };
            for (int i = 0; i < Stats.Length; i++)
            {
                ushort L = Current_Level;
                ushort B = (ushort)Tables.ID_To_Base_Stats[Species][i];
                ushort I = (ushort)DVs[i];
                ushort E = // Fixed formula via http://www.smogon.com/ingame/guides/rby_gsc_stats
                    (ushort) Math.Floor(Math.Min(255, Math.Floor(Math.Sqrt(Math.Max(0, STATEXPs[i] - 1)) + 1))/4.0);
                Stats[i] = (ushort)Math.Floor((2 * (B + I) + E) * L / 100.0 + 5);
            }
            Stats[0] += (ushort)(5 + Level); // HP

            return Stats;
        }

        public void CalculateStats()
        {
            ushort[] Stats = getStats();
            HP_Max = HP_Current = Stats[(int)Tables.Stats.HP];
            ATK = Stats[(int)Tables.Stats.ATK];
            DEF = Stats[(int)Tables.Stats.DEF];
            SPD = Stats[(int)Tables.Stats.SPD];
            SPC = Stats[(int)Tables.Stats.SPC];
        }

        public enum SpeciesType
        {
            Rhydon = 0x01,
            Kangaskhan = 0x02,
            Nidoran_M = 0x03,
            Clefairy = 0x04,
            Spearow = 0x05,
            Voltorb = 0x06,
            Nidoking = 0x07,
            Slowbro = 0x08,
            Ivysaur = 0x09,
            Exeggutor = 0x0a,
            Lickitung = 0x0b,
            Exeggcute = 0x0c,
            Grimer = 0x0d,
            Gengar = 0x0e,
            Nidoran_F = 0x0f,
            Nidoqueen = 0x10,
            Cubone = 0x11,
            Rhyhorn = 0x12,
            Lapras = 0x13,
            Arcanine = 0x14,
            Mew = 0x15,
            Gyarados = 0x16,
            Shellder = 0x17,
            Tentacool = 0x18,
            Gastly = 0x19,
            Scyther = 0x1a,
            Staryu = 0x1b,
            Blastoise = 0x1c,
            Pinsir = 0x1d,
            Tangela = 0x1e,
            Growlithe = 0x21,
            Onix = 0x22,
            Fearow = 0x23,
            Pidgey = 0x24,
            Slowpoke = 0x25,
            Kadabra = 0x26,
            Graveler = 0x27,
            Chansey = 0x28,
            Machoke = 0x29,
            Mr_Mime = 0x2a,
            Hitmonlee = 0x2b,
            Hitmonchan = 0x2c,
            Arbok = 0x2d,
            Parasect = 0x2e,
            Psyduck = 0x2f,
            Drowzee = 0x30,
            Golem = 0x31,
            Magmar = 0x33,
            Electabuzz = 0x35,
            Magneton = 0x36,
            Koffing = 0x37,
            Mankey = 0x39,
            Seel = 0x3a,
            Diglett = 0x3b,
            Tauros = 0x3c,
            Farfetchd = 0x40,
            Venonat = 0x41,
            Dragonite = 0x42,
            Doduo = 0x46,
            Poliwag = 0x47,
            Jynx = 0x48,
            Moltres = 0x49,
            Articuno = 0x4a,
            Zapdos = 0x4b,
            Ditto = 0x4c,
            Meowth = 0x4d,
            Krabby = 0x4e,
            Vulpix = 0x52,
            Ninetales = 0x53,
            Pikachu = 0x54,
            Raichu = 0x55,
            Dratini = 0x58,
            Dragonair = 0x59,
            Kabuto = 0x5a,
            Kabutops = 0x5b,
            Horsea = 0x5c,
            Seadra = 0x5d,
            Sandshrew = 0x60,
            Sandslash = 0x61,
            Omanyte = 0x62,
            Omastar = 0x63,
            Jigglypuff = 0x64,
            Wigglytuff = 0x65,
            Eevee = 0x66,
            Flareon = 0x67,
            Jolteon = 0x68,
            Vaporeon = 0x69,
            Machop = 0x6a,
            Zubat = 0x6b,
            Ekans = 0x6c,
            Paras = 0x6d,
            Poliwhirl = 0x6e,
            Poliwrath = 0x6f,
            Weedle = 0x70,
            Kakuna = 0x71,
            Beedrill = 0x72,
            Dodrio = 0x74,
            Primeape = 0x75,
            Dugtrio = 0x76,
            Venomoth = 0x77,
            Dewgong = 0x78,
            Caterpie = 0x7b,
            Metapod = 0x7c,
            Butterfree = 0x7d,
            Machamp = 0x7e,
            Golduck = 0x80,
            Hypno = 0x81,
            Golbat = 0x82,
            Mewtwo = 0x83,
            Snorlax = 0x84,
            Magikarp = 0x85,
            Muk = 0x88,
            Kingler = 0x8a,
            Cloyster = 0x8b,
            Electrode = 0x8d,
            Clefable = 0x8e,
            Weezing = 0x8f,
            Persian = 0x90,
            Marowak = 0x91,
            Haunter = 0x93,
            Abra = 0x94,
            Alakazam = 0x95,
            Pidgeotto = 0x96,
            Pidgeot = 0x97,
            Starmie = 0x98,
            Bulbasaur = 0x99,
            Venusaur = 0x9a,
            Tentacruel = 0x9b,
            Goldeen = 0x9d,
            Seaking = 0x9e,
            Ponyta = 0xa3,
            Rapidash = 0xa4,
            Rattata = 0xa5,
            Raticate = 0xa6,
            Nidorino = 0xa7,
            Nidorina = 0xa8,
            Geodude = 0xa9,
            Porygon = 0xaa,
            Aerodactyl = 0xab,
            Magnemite = 0xad,
            Charmander = 0xb0,
            Squirtle = 0xb1,
            Charmeleon = 0xb2,
            Wartortle = 0xb3,
            Charizard = 0xb4,
            Oddish = 0xb9,
            Gloom = 0xba,
            Vileplume = 0xbb,
            Bellsprout = 0xbc,
            Weepinbell = 0xbd,
            Victreebel = 0xbe,
            Missingno = 0xff
        }

        public enum MoveType
        {
            None = 0x00,
            Pound = 0x01,
            Karate_Chop = 0x02,
            Doubleslap = 0x03,
            Comet_Punch = 0x04,
            Mega_Punch = 0x05,
            Pay_Day = 0x06,
            Fire_Punch = 0x07,
            Ice_Punch = 0x08,
            Thunderpunch = 0x09,
            Scratch = 0x0a,
            Vicegrip = 0x0b,
            Guillotine = 0x0c,
            Razor_Wind = 0x0d,
            Swords_Dance = 0x0e,
            Cut = 0x0f,
            Gust = 0x10,
            Wing_Attack = 0x11,
            Whirlwind = 0x12,
            Fly = 0x13,
            Bind = 0x14,
            Slam = 0x15,
            Vine_Whip = 0x16,
            Stomp = 0x17,
            Double_Kick = 0x18,
            Mega_Kick = 0x19,
            Jump_Kick = 0x1a,
            Rolling_Kick = 0x1b,
            Sand_Attack = 0x1c,
            Headbutt = 0x1d,
            Horn_Attack = 0x1e,
            Fury_Attack = 0x1f,
            Horn_Drill = 0x20,
            Tackle = 0x21,
            Body_Slam = 0x22,
            Wrap = 0x23,
            Take_down = 0x24,
            Thrash = 0x25,
            Double_Edge = 0x26,
            Tail_Whip = 0x27,
            Poison_Sting = 0x28,
            Twineedle = 0x29,
            Pin_Missile = 0x2a,
            Leer = 0x2b,
            Bite = 0x2c,
            Growl = 0x2d,
            Roar = 0x2e,
            Sing = 0x2f,
            Supersonic = 0x30,
            Sonicboom = 0x31,
            Disable = 0x32,
            Acid = 0x33,
            Ember = 0x34,
            Flamethrower = 0x35,
            Mist = 0x36,
            Water_Gun = 0x37,
            Hydro_Pump = 0x38,
            Surf = 0x39,
            Ice_Beam = 0x3a,
            Blizzard = 0x3b,
            Psybeam = 0x3c,
            Bubblebeam = 0x3d,
            Aurora_Beam = 0x3e,
            Hyper_Beam = 0x3f,
            Peck = 0x40,
            Drill_Peck = 0x41,
            Submission = 0x42,
            Low_Kick = 0x43,
            Counter = 0x44,
            Seismic_Toss = 0x45,
            Strength = 0x46,
            Absorb = 0x47,
            Mega_Drain = 0x48,
            Leech_Seed = 0x49,
            Growth = 0x4a,
            Razor_Leaf = 0x4b,
            Solarbeam = 0x4c,
            Poisonpowder = 0x4d,
            Stun_Spore = 0x4e,
            Sleep_Powder = 0x4f,
            Petal_Dance = 0x50,
            String_Shot = 0x51,
            Dragon_Rage = 0x52,
            Fire_Spin = 0x53,
            Thundershock = 0x54,
            Thunderbolt = 0x55,
            Thunder_Wave = 0x56,
            Thunder = 0x57,
            Rock_Throw = 0x58,
            Earthquake = 0x59,
            Fissure = 0x5a,
            Dig = 0x5b,
            Toxic = 0x5c,
            Confusion = 0x5d,
            Psychic_M = 0x5e,
            Hypnosis = 0x5f,
            Meditate = 0x60,
            Agility = 0x61,
            Quick_Attack = 0x62,
            Rage = 0x63,
            Teleport = 0x64,
            Night_Shade = 0x65,
            Mimic = 0x66,
            Screech = 0x67,
            Double_Team = 0x68,
            Recover = 0x69,
            Harden = 0x6a,
            Minimize = 0x6b,
            Smokescreen = 0x6c,
            Confuse_Ray = 0x6d,
            Withdraw = 0x6e,
            Defense_Curl = 0x6f,
            Barrier = 0x70,
            Light_Screen = 0x71,
            Haze = 0x72,
            Reflect = 0x73,
            Focus_Energy = 0x74,
            Bide = 0x75,
            Metronome = 0x76,
            Mirror_Move = 0x77,
            Selfdestruct = 0x78,
            Egg_Bomb = 0x79,
            Lick = 0x7a,
            Smog = 0x7b,
            Sludge = 0x7c,
            Bone_Club = 0x7d,
            Fire_Blast = 0x7e,
            Waterfall = 0x7f,
            Clamp = 0x80,
            Swift = 0x81,
            Skull_Bash = 0x82,
            Spike_Cannon = 0x83,
            Constrict = 0x84,
            Amnesia = 0x85,
            Kinesis = 0x86,
            Softboiled = 0x87,
            Hi_Jump_Kick = 0x88,
            Glare = 0x89,
            Dream_Eater = 0x8a,
            Poison_Gas = 0x8b,
            Barrage = 0x8c,
            Leech_Life = 0x8d,
            Lovely_Kiss = 0x8e,
            Sky_Attack = 0x8f,
            Transform = 0x90,
            Bubble = 0x91,
            Dizzy_Punch = 0x92,
            Spore = 0x93,
            Flash = 0x94,
            Psywave = 0x95,
            Splash = 0x96,
            Acid_Armor = 0x97,
            Crabhammer = 0x98,
            Explosion = 0x99,
            Fury_Swipes = 0x9a,
            Bonemerang = 0x9b,
            Rest = 0x9c,
            Rock_Slide = 0x9d,
            Hyper_Fang = 0x9e,
            Sharpen = 0x9f,
            Conversion = 0xa0,
            Tri_Attack = 0xa1,
            Super_Fang = 0xa2,
            Slash = 0xa3,
            Substitute = 0xa4,
            Struggle = 0xa5
        }
    }
  }
