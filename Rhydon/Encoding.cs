using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rhydon
{
    public static class RBY_Encoding
    {
        private const byte CHAR_INVALID = 0xFF;
        private const byte CHAR_TRAINER = 0xFE;
        private const byte CHAR_PK_NUM = 0x7B;
        private const byte CHAR_MN_NUM = 0x7D;
        internal const byte CHAR_MAL_NUM = 0x7E;
        internal const byte CHAR_FEM_NUM = 0x60;

        public static string GetString(byte[] arr, bool JP)
        {
            if (JP)
                return GetJPString(arr);
            return GetAmericanString(arr);
        }

        public static string GetAmericanString(byte[] arr)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in arr)
            {
                byte ascii = RBY_To_ASCII[b];
                if (ascii == 0 || b == 0)
                    return sb.ToString();
                else if (ascii == CHAR_TRAINER)
                    sb.Append("[TRAINER]");
                else
                    sb.Append((char)ascii);
            }
            return sb.ToString();
        }

        public static string GetJPString(byte[] arr)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in arr)
            {
                char c = (JP_RBY_TO_CHAR.ContainsKey(b)) ? JP_RBY_TO_CHAR[b] : (char)RBY_To_ASCII[b];
                if (c == 0 || b == 0)
                    return sb.ToString();
                if (c == CHAR_TRAINER)
                    sb.Append("トレーナー");
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }

        public static byte[] GetBytes(string s, bool JP)
        {
            if (JP)
                return GetJPBytes(s);
            return GetAmericanBytes(s);
        }

        public static byte[] GetAmericanBytes(string s)
        {
            s = s.Replace('♀', (char)CHAR_FEM_NUM).Replace('♂', (char)CHAR_MAL_NUM);
            if (!Validate(s, false))
                s = FixString(s, false);
            if (s == "[TRAINER]")
                return new[] { ASCII_To_RBY[CHAR_TRAINER], (byte)0x50 };
            return s.Select(c => ASCII_To_RBY[c]).Concat(new[] { (byte)0x50 }).ToArray();
        }

        public static byte[] GetJPBytes(string s)
        {
            s = s.Replace('♀', (char)CHAR_FEM_NUM).Replace('♂', (char)CHAR_MAL_NUM);
            if (!Validate(s, true))
                s = FixString(s, true);
            if (s == "トレーナー")
                return new[] { ASCII_To_RBY[CHAR_TRAINER], (byte)0x50 };
            return s.Select(c => CHAR_TO_JP_RBY.ContainsKey(c) ? CHAR_TO_JP_RBY[c] : ASCII_To_RBY[(byte)c]).Concat(new[] { (byte)0x50 }).ToArray();
        }

        public static bool Validate(string s, bool JP)
        {
            if (JP)
                return s.All(c => CHAR_TO_JP_RBY.ContainsKey(c) || c == CHAR_FEM_NUM || c == CHAR_MAL_NUM);
            return !s.Any(c => c > 0xFF || ASCII_To_RBY[c] == 0);
        }

        public static string FixString(string s, bool JP)
        {
            if (JP)
                return FixJPString(s);
            return FixAmericanString(s);
        }

        public static string FixJPString(string s)
        {
            StringBuilder sb = new StringBuilder();
            s = s.Replace('♀', (char)CHAR_FEM_NUM).Replace('♂', (char)CHAR_MAL_NUM);
            foreach (char c in s)
            {
                if (CHAR_TO_JP_RBY.ContainsKey(c) || c == CHAR_FEM_NUM || c == CHAR_MAL_NUM)
                    sb.Append(c);
            }
            return sb.ToString();
        }

        public static string FixAmericanString(string s)
        {
            StringBuilder sb = new StringBuilder();
            s = s.Replace('♀', (char)CHAR_FEM_NUM).Replace('♂', (char)CHAR_MAL_NUM);
            foreach (char c in s)
            {
                if (c <= 0xFF && ASCII_To_RBY[c] != 0)
                    sb.Append(c);
            }
            return sb.ToString();
        }

        #region Character Tables
        internal static readonly byte[] ASCII_To_RBY = {
			0x50, /* 0x00 */
			0x00, /* 0x01 */
			0x00, /* 0x02 */
			0x00, /* 0x03 */
			0x00, /* 0x04 */
			0x00, /* 0x05 */
			0x00, /* 0x06 */
			0x00, /* 0x07 */
			0x00, /* 0x08 */
			0x00, /* 0x09 */
			0x00, /* 0x0A */
			0x00, /* 0x0B */
			0x00, /* 0x0C */
			0x00, /* 0x0D */
			0x00, /* 0x0E */
			0x00, /* 0x0F */
			0x00, /* 0x10 */
			0x00, /* 0x11 */
			0x00, /* 0x12 */
			0x00, /* 0x13 */
			0x00, /* 0x14 */
			0x00, /* 0x15 */
			0x00, /* 0x16 */
			0x00, /* 0x17 */
			0x00, /* 0x18 */
			0x00, /* 0x19 */
			0x00, /* 0x1A */
			0x00, /* 0x1B */
			0x00, /* 0x1C */
			0x00, /* 0x1D */
			0x00, /* 0x1E */
			0x00, /* 0x1F */
			0x7F, /* 0x20 */
			0xE7, /* 0x21 */
			0x00, /* 0x22 */
			0x00, /* 0x23 */
			0x00, /* 0x24 */
			0x00, /* 0x25 */
			0x00, /* 0x26 */
			0x00, /* 0x27 */
			0x9A, /* 0x28 */
			0x9B, /* 0x29 */
			0x00, /* 0x2A */
			0x00, /* 0x2B */
			0xF4, /* 0x2C */
			0xE3, /* 0x2D */
			0xF2, /* 0x2E */
			0xF3, /* 0x2F */
			0xF6, /* 0x30 */
			0xF7, /* 0x31 */
			0xF8, /* 0x32 */
			0xF9, /* 0x33 */
			0xFA, /* 0x34 */
			0xFB, /* 0x35 */
			0xFC, /* 0x36 */
			0xFD, /* 0x37 */
			0xFE, /* 0x38 */
			0xFF, /* 0x39 */
			0x9C, /* 0x3A */
			0x9D, /* 0x3B */
			0x00, /* 0x3C */
			0x00, /* 0x3D */
			0x00, /* 0x3E */
			0xE6, /* 0x3F */
			0x00, /* 0x40 */
			0x80, /* 0x41 */
			0x81, /* 0x42 */
			0x82, /* 0x43 */
			0x83, /* 0x44 */
			0x84, /* 0x45 */
			0x85, /* 0x46 */
			0x86, /* 0x47 */
			0x87, /* 0x48 */
			0x88, /* 0x49 */
			0x89, /* 0x4A */
			0x8A, /* 0x4B */
			0x8B, /* 0x4C */
			0x8C, /* 0x4D */
			0x8D, /* 0x4E */
			0x8E, /* 0x4F */
			0x8F, /* 0x50 */
			0x90, /* 0x51 */
			0x91, /* 0x52 */
			0x92, /* 0x53 */
			0x93, /* 0x54 */
			0x94, /* 0x55 */
			0x95, /* 0x56 */
			0x96, /* 0x57 */
			0x97, /* 0x58 */
			0x98, /* 0x59 */
			0x99, /* 0x5A */
			0x9E, /* 0x5B */
			0x00, /* 0x5C */
			0x9F, /* 0x5D */
			0x00, /* 0x5E */
			0x00, /* 0x5F */
			0xF5, /* 0x60 */
			0xA0, /* 0x61 */
			0xA1, /* 0x62 */
			0xA2, /* 0x63 */
			0xA3, /* 0x64 */
			0xA4, /* 0x65 */
			0xA5, /* 0x66 */
			0xA6, /* 0x67 */
			0xA7, /* 0x68 */
			0xA8, /* 0x69 */
			0xA9, /* 0x6A */
			0xAA, /* 0x6B */
			0xAB, /* 0x6C */
			0xAC, /* 0x6D */
			0xAD, /* 0x6E */
			0xAE, /* 0x6F */
			0xAF, /* 0x70 */
			0xB0, /* 0x71 */
			0xB1, /* 0x72 */
			0xB2, /* 0x73 */
			0xB3, /* 0x74 */
			0xB4, /* 0x75 */
			0xB5, /* 0x76 */
			0xB6, /* 0x77 */
			0xB7, /* 0x78 */
			0xB8, /* 0x79 */
			0xB9, /* 0x7A */
			0xE1, /* 0x7B */
			0x00, /* 0x7C */
			0xE2, /* 0x7D */
			0xEF, /* 0x7E */
			0x00, /* 0x7F */
			0x00, /* 0x80 */
			0x00, /* 0x81 */
			0x00, /* 0x82 */
			0x00, /* 0x83 */
			0x00, /* 0x84 */
			0x00, /* 0x85 */
			0x00, /* 0x86 */
			0x00, /* 0x87 */
			0x00, /* 0x88 */
			0x00, /* 0x89 */
			0x00, /* 0x8A */
			0x00, /* 0x8B */
			0x00, /* 0x8C */
			0x00, /* 0x8D */
			0x00, /* 0x8E */
			0x00, /* 0x8F */
			0x00, /* 0x90 */
			0x00, /* 0x91 */
			0x00, /* 0x92 */
			0x00, /* 0x93 */
			0x00, /* 0x94 */
			0x00, /* 0x95 */
			0x00, /* 0x96 */
			0x00, /* 0x97 */
			0x00, /* 0x98 */
			0x00, /* 0x99 */
			0x00, /* 0x9A */
			0x00, /* 0x9B */
			0x00, /* 0x9C */
			0x00, /* 0x9D */
			0x00, /* 0x9E */
			0x00, /* 0x9F */
			0x00, /* 0xA0 */
			0x00, /* 0xA1 */
			0x00, /* 0xA2 */
			0x00, /* 0xA3 */
			0x00, /* 0xA4 */
			0x00, /* 0xA5 */
			0x00, /* 0xA6 */
			0x00, /* 0xA7 */
			0x00, /* 0xA8 */
			0x00, /* 0xA9 */
			0x00, /* 0xAA */
			0x00, /* 0xAB */
			0x00, /* 0xAC */
			0x00, /* 0xAD */
			0x00, /* 0xAE */
			0x00, /* 0xAF */
			0x00, /* 0xB0 */
			0x00, /* 0xB1 */
			0x00, /* 0xB2 */
			0x00, /* 0xB3 */
			0x00, /* 0xB4 */
			0x00, /* 0xB5 */
			0x00, /* 0xB6 */
			0x00, /* 0xB7 */
			0x00, /* 0xB8 */
			0x00, /* 0xB9 */
			0x00, /* 0xBA */
			0x00, /* 0xBB */
			0x00, /* 0xBC */
			0x00, /* 0xBD */
			0x00, /* 0xBE */
			0x00, /* 0xBF */
			0x00, /* 0xC0 */
			0x00, /* 0xC1 */
			0x00, /* 0xC2 */
			0x00, /* 0xC3 */
			0x00, /* 0xC4 */
			0x00, /* 0xC5 */
			0x00, /* 0xC6 */
			0x00, /* 0xC7 */
			0x00, /* 0xC8 */
			0x00, /* 0xC9 */
			0x00, /* 0xCA */
			0x00, /* 0xCB */
			0x00, /* 0xCC */
			0x00, /* 0xCD */
			0x00, /* 0xCE */
			0x00, /* 0xCF */
			0x00, /* 0xD0 */
			0x00, /* 0xD1 */
			0x00, /* 0xD2 */
			0x00, /* 0xD3 */
			0x00, /* 0xD4 */
			0x00, /* 0xD5 */
			0x00, /* 0xD6 */
			0x00, /* 0xD7 */
			0x00, /* 0xD8 */
			0x00, /* 0xD9 */
			0x00, /* 0xDA */
			0x00, /* 0xDB */
			0x00, /* 0xDC */
			0x00, /* 0xDD */
			0x00, /* 0xDE */
			0x00, /* 0xDF */
			0x00, /* 0xE0 */
			0x00, /* 0xE1 */
			0x00, /* 0xE2 */
			0x00, /* 0xE3 */
			0x00, /* 0xE4 */
			0x00, /* 0xE5 */
			0x00, /* 0xE6 */
			0x00, /* 0xE7 */
			0x00, /* 0xE8 */
			0x00, /* 0xE9 */
			0x00, /* 0xEA */
			0x00, /* 0xEB */
			0x00, /* 0xEC */
			0x00, /* 0xED */
			0x00, /* 0xEE */
			0x00, /* 0xEF */
			0x00, /* 0xF0 */
			0x00, /* 0xF1 */
			0x00, /* 0xF2 */
			0x00, /* 0xF3 */
			0x00, /* 0xF4 */
			0x00, /* 0xF5 */
			0x00, /* 0xF6 */
			0x00, /* 0xF7 */
			0x00, /* 0xF8 */
			0x00, /* 0xF9 */
			0x00, /* 0xFA */
			0x00, /* 0xFB */
			0x00, /* 0xFC */
			0x00, /* 0xFD */
			0x5D, /* 0xFE */
			0x00 /* 0xFF */
		};

        internal static readonly byte[] RBY_To_ASCII = {
			CHAR_INVALID, /* 0x00 */
			CHAR_INVALID, /* 0x01 */
			CHAR_INVALID, /* 0x02 */
			CHAR_INVALID, /* 0x03 */
			CHAR_INVALID, /* 0x04 */
			CHAR_INVALID, /* 0x05 */
			CHAR_INVALID, /* 0x06 */
			CHAR_INVALID, /* 0x07 */
			CHAR_INVALID, /* 0x08 */
			CHAR_INVALID, /* 0x09 */
			CHAR_INVALID, /* 0x0A */
			CHAR_INVALID, /* 0x0B */
			CHAR_INVALID, /* 0x0C */
			CHAR_INVALID, /* 0x0D */
			CHAR_INVALID, /* 0x0E */
			CHAR_INVALID, /* 0x0F */
			CHAR_INVALID, /* 0x10 */
			CHAR_INVALID, /* 0x11 */
			CHAR_INVALID, /* 0x12 */
			CHAR_INVALID, /* 0x13 */
			CHAR_INVALID, /* 0x14 */
			CHAR_INVALID, /* 0x15 */
			CHAR_INVALID, /* 0x16 */
			CHAR_INVALID, /* 0x17 */
			CHAR_INVALID, /* 0x18 */
			CHAR_INVALID, /* 0x19 */
			CHAR_INVALID, /* 0x1A */
			CHAR_INVALID, /* 0x1B */
			CHAR_INVALID, /* 0x1C */
			CHAR_INVALID, /* 0x1D */
			CHAR_INVALID, /* 0x1E */
			CHAR_INVALID, /* 0x1F */
			CHAR_INVALID, /* 0x20 */
			CHAR_INVALID, /* 0x21 */
			CHAR_INVALID, /* 0x22 */
			CHAR_INVALID, /* 0x23 */
			CHAR_INVALID, /* 0x24 */
			CHAR_INVALID, /* 0x25 */
			CHAR_INVALID, /* 0x26 */
			CHAR_INVALID, /* 0x27 */
			CHAR_INVALID, /* 0x28 */
			CHAR_INVALID, /* 0x29 */
			CHAR_INVALID, /* 0x2A */
			CHAR_INVALID, /* 0x2B */
			CHAR_INVALID, /* 0x2C */
			CHAR_INVALID, /* 0x2D */
			CHAR_INVALID, /* 0x2E */
			CHAR_INVALID, /* 0x2F */
			CHAR_INVALID, /* 0x30 */
			CHAR_INVALID, /* 0x31 */
			CHAR_INVALID, /* 0x32 */
			CHAR_INVALID, /* 0x33 */
			CHAR_INVALID, /* 0x34 */
			CHAR_INVALID, /* 0x35 */
			CHAR_INVALID, /* 0x36 */
			CHAR_INVALID, /* 0x37 */
			CHAR_INVALID, /* 0x38 */
			CHAR_INVALID, /* 0x39 */
			CHAR_INVALID, /* 0x3A */
			CHAR_INVALID, /* 0x3B */
			CHAR_INVALID, /* 0x3C */
			CHAR_INVALID, /* 0x3D */
			CHAR_INVALID, /* 0x3E */
			CHAR_INVALID, /* 0x3F */
			CHAR_INVALID, /* 0x40 */
			CHAR_INVALID, /* 0x41 */
			CHAR_INVALID, /* 0x42 */
			CHAR_INVALID, /* 0x43 */
			CHAR_INVALID, /* 0x44 */
			CHAR_INVALID, /* 0x45 */
			CHAR_INVALID, /* 0x46 */
			CHAR_INVALID, /* 0x47 */
			CHAR_INVALID, /* 0x48 */
			CHAR_INVALID, /* 0x49 */
			CHAR_INVALID, /* 0x4A */
			CHAR_INVALID, /* 0x4B */
			CHAR_INVALID, /* 0x4C */
			CHAR_INVALID, /* 0x4D */
			CHAR_INVALID, /* 0x4E */
			CHAR_INVALID, /* 0x4F */
			(byte) '\0', /* 0x50 */
			CHAR_INVALID, /* 0x51 */
			CHAR_INVALID, /* 0x52 */
			CHAR_INVALID, /* 0x53 */
			CHAR_INVALID, /* 0x54 */
			CHAR_INVALID, /* 0x55 */
			CHAR_INVALID, /* 0x56 */
			CHAR_INVALID, /* 0x57 */
			CHAR_INVALID, /* 0x58 */
			CHAR_INVALID, /* 0x59 */
			CHAR_INVALID, /* 0x5A */
			CHAR_INVALID, /* 0x5B */
			CHAR_INVALID, /* 0x5C */
			CHAR_TRAINER, /* 0x5D */
			CHAR_INVALID, /* 0x5E */
			CHAR_INVALID, /* 0x5F */
			CHAR_INVALID, /* 0x60 */
			CHAR_INVALID, /* 0x61 */
			CHAR_INVALID, /* 0x62 */
			CHAR_INVALID, /* 0x63 */
			CHAR_INVALID, /* 0x64 */
			CHAR_INVALID, /* 0x65 */
			CHAR_INVALID, /* 0x66 */
			CHAR_INVALID, /* 0x67 */
			CHAR_INVALID, /* 0x68 */
			CHAR_INVALID, /* 0x69 */
			CHAR_INVALID, /* 0x6A */
			CHAR_INVALID, /* 0x6B */
			CHAR_INVALID, /* 0x6C */
			CHAR_INVALID, /* 0x6D */
			CHAR_INVALID, /* 0x6E */
			CHAR_INVALID, /* 0x6F */
			CHAR_INVALID, /* 0x70 */
			CHAR_INVALID, /* 0x71 */
			CHAR_INVALID, /* 0x72 */
			CHAR_INVALID, /* 0x73 */
			CHAR_INVALID, /* 0x74 */
			CHAR_INVALID, /* 0x75 */
			CHAR_INVALID, /* 0x76 */
			CHAR_INVALID, /* 0x77 */
			CHAR_INVALID, /* 0x78 */
			CHAR_INVALID, /* 0x79 */
			CHAR_INVALID, /* 0x7A */
			CHAR_INVALID, /* 0x7B */
			CHAR_INVALID, /* 0x7C */
			CHAR_INVALID, /* 0x7D */
			CHAR_INVALID, /* 0x7E */
			(byte) ' ', /* 0x7F */
			(byte) 'A', /* 0x80 */
			(byte) 'B', /* 0x81 */
			(byte) 'C', /* 0x82 */
			(byte) 'D', /* 0x83 */
			(byte) 'E', /* 0x84 */
			(byte) 'F', /* 0x85 */
			(byte) 'G', /* 0x86 */
			(byte) 'H', /* 0x87 */
			(byte) 'I', /* 0x88 */
			(byte) 'J', /* 0x89 */
			(byte) 'K', /* 0x8A */
			(byte) 'L', /* 0x8B */
			(byte) 'M', /* 0x8C */
			(byte) 'N', /* 0x8D */
			(byte) 'O', /* 0x8E */
			(byte) 'P', /* 0x8F */
			(byte) 'Q', /* 0x90 */
			(byte) 'R', /* 0x91 */
			(byte) 'S', /* 0x92 */
			(byte) 'T', /* 0x93 */
			(byte) 'U', /* 0x94 */
			(byte) 'V', /* 0x95 */
			(byte) 'W', /* 0x96 */
			(byte) 'X', /* 0x97 */
			(byte) 'Y', /* 0x98 */
			(byte) 'Z', /* 0x99 */
			(byte) '[', /* 0x9A */
			(byte) '\\',/* 0x9B */
			(byte) ']', /* 0x9C */
			(byte) '^', /* 0x9D */
			(byte) '_', /* 0x9E */
			(byte) '`', /* 0x9F */
			(byte) 'a', /* 0xA0 */
			(byte) 'b', /* 0xA1 */
			(byte) 'c', /* 0xA2 */
			(byte) 'd', /* 0xA3 */
			(byte) 'e', /* 0xA4 */
			(byte) 'f', /* 0xA5 */
			(byte) 'g', /* 0xA6 */
			(byte) 'h', /* 0xA7 */
			(byte) 'i', /* 0xA8 */
			(byte) 'j', /* 0xA9 */
			(byte) 'k', /* 0xAA */
			(byte) 'l', /* 0xAB */
			(byte) 'm', /* 0xAC */
			(byte) 'n', /* 0xAD */
			(byte) 'o', /* 0xAE */
			(byte) 'p', /* 0xAF */
			(byte) 'q', /* 0xB0 */
			(byte) 'r', /* 0xB1 */
			(byte) 's', /* 0xB2 */
			(byte) 't', /* 0xB3 */
			(byte) 'u', /* 0xB4 */
			(byte) 'v', /* 0xB5 */
			(byte) 'w', /* 0xB6 */
			(byte) 'x', /* 0xB7 */
			(byte) 'y', /* 0xB8 */
			(byte) 'z', /* 0xB9 */
			CHAR_INVALID, /* 0xBA */
			CHAR_INVALID, /* 0xBB */
			CHAR_INVALID, /* 0xBC */
			CHAR_INVALID, /* 0xBD */
			CHAR_INVALID, /* 0xBE */
			CHAR_INVALID, /* 0xBF */
			CHAR_INVALID, /* 0xC0 */
			CHAR_INVALID, /* 0xC1 */
			CHAR_INVALID, /* 0xC2 */
			CHAR_INVALID, /* 0xC3 */
			CHAR_INVALID, /* 0xC4 */
			CHAR_INVALID, /* 0xC5 */
			CHAR_INVALID, /* 0xC6 */
			CHAR_INVALID, /* 0xC7 */
			CHAR_INVALID, /* 0xC8 */
			CHAR_INVALID, /* 0xC9 */
			CHAR_INVALID, /* 0xCA */
			CHAR_INVALID, /* 0xCB */
			CHAR_INVALID, /* 0xCC */
			CHAR_INVALID, /* 0xCD */
			CHAR_INVALID, /* 0xCE */
			CHAR_INVALID, /* 0xCF */
			CHAR_INVALID, /* 0xD0 */
			CHAR_INVALID, /* 0xD1 */
			CHAR_INVALID, /* 0xD2 */
			CHAR_INVALID, /* 0xD3 */
			CHAR_INVALID, /* 0xD4 */
			CHAR_INVALID, /* 0xD5 */
			CHAR_INVALID, /* 0xD6 */
			CHAR_INVALID, /* 0xD7 */
			CHAR_INVALID, /* 0xD8 */
			CHAR_INVALID, /* 0xD9 */
			CHAR_INVALID, /* 0xDA */
			CHAR_INVALID, /* 0xDB */
			CHAR_INVALID, /* 0xDC */
			CHAR_INVALID, /* 0xDD */
			CHAR_INVALID, /* 0xDE */
			CHAR_INVALID, /* 0xDF */
			CHAR_INVALID, /* 0xE0 */
			CHAR_PK_NUM, /* 0xE1 */
			CHAR_MN_NUM, /* 0xE2 */
			(byte) '-', /* 0xE3 */
			CHAR_INVALID, /* 0xE4 */
			CHAR_INVALID, /* 0xE5 */
			(byte) '?', /* 0xE6 */
			(byte) '!', /* 0xE7 */
			(byte) '.', /* 0xE8 */
			CHAR_INVALID, /* 0xE9 */
			CHAR_INVALID, /* 0xEA */
			CHAR_INVALID, /* 0xEB */
			CHAR_INVALID, /* 0xEC */
			CHAR_INVALID, /* 0xED */
			CHAR_INVALID, /* 0xEE */
			CHAR_MAL_NUM, /* 0xEF */
			CHAR_INVALID, /* 0xF0 */
			CHAR_INVALID, /* 0xF1 */
			(byte) '.', /* 0xF2 */
			(byte) '/', /* 0xF3 */
			(byte) ',', /* 0xF4 */
			CHAR_FEM_NUM, /* 0xF5 */
			(byte) '0', /* 0xF6 */
			(byte) '1', /* 0xF7 */
			(byte) '2', /* 0xF8 */
			(byte) '3', /* 0xF9 */
			(byte) '4', /* 0xFA */
			(byte) '5', /* 0xFB */
			(byte) '6', /* 0xFC */
			(byte) '7', /* 0xFD */
			(byte) '8', /* 0xFE */
			(byte) '9'  /* 0xFF */
		};
        #endregion

        #region JP Character Dictionaries
        static Dictionary<char, byte> CHAR_TO_JP_RBY = new Dictionary<char, byte>(){
            {'ガ', 0x05},
            {'ギ', 0x06},
            {'グ', 0x07},
            {'ゲ', 0x08},
            {'ゴ', 0x09},
            {'ザ', 0x0A},
            {'ジ', 0x0B},
            {'ズ', 0x0C},
            {'ゼ', 0x0D},
            {'ゾ', 0x0E},
            {'ダ', 0x0F},
            {'ヂ', 0x10},
            {'ヅ', 0x11},
            {'デ', 0x12},
            {'ド', 0x13},
            {'バ', 0x19},
            {'ビ', 0x1A},
            {'ブ', 0x1B},
            {'ボ', 0x1C},
            {'が', 0x26},
            {'ぎ', 0x27},
            {'ぐ', 0x28},
            {'げ', 0x29},
            {'ご', 0x2A},
            {'ざ', 0x2B},
            {'じ', 0x2C},
            {'ず', 0x2D},
            {'ぜ', 0x2E},
            {'ぞ', 0x2F},
            {'だ', 0x30},
            {'ぢ', 0x31},
            {'づ', 0x32},
            {'で', 0x33},
            {'ど', 0x34},
            {'ば', 0x3A},
            {'び', 0x3B},
            {'ぶ', 0x3C},
            {'べ', 0x3D},
            {'ぼ', 0x3E},
            {'パ', 0x40},
            {'ピ', 0x41},
            {'プ', 0x42},
            {'ポ', 0x43},
            {'ぱ', 0x44},
            {'ぴ', 0x45},
            {'ぷ', 0x46},
            {'ぺ', 0x47},
            {'ぽ', 0x48},
            {'ア', 0x80},
            {'イ', 0x81},
            {'ウ', 0x82},
            {'エ', 0x83},
            {'ォ', 0x84},
            {'カ', 0x85},
            {'キ', 0x86},
            {'ク', 0x87},
            {'ケ', 0x88},
            {'コ', 0x89},
            {'サ', 0x8A},
            {'シ', 0x8B},
            {'ス', 0x8C},
            {'セ', 0x8D},
            {'ソ', 0x8E},
            {'タ', 0x8F},
            {'チ', 0x90},
            {'ツ', 0x91},
            {'テ', 0x92},
            {'ト', 0x93},
            {'ナ', 0x94},
            {'ニ', 0x95},
            {'ヌ', 0x96},
            {'ネ', 0x97},
            {'ノ', 0x98},
            {'ハ', 0x99},
            {'ヒ', 0x9A},
            {'フ', 0x9B},
            {'ホ', 0x9C},
            {'マ', 0x9D},
            {'ミ', 0x9E},
            {'ム', 0x9F},
            {'メ', 0xA0},
            {'モ', 0xA1},
            {'ヤ', 0xA2},
            {'ユ', 0xA3},
            {'ヨ', 0xA4},
            {'ラ', 0xA5},
            {'ル', 0xA6},
            {'レ', 0xA7},
            {'ロ', 0xA8},
            {'ワ', 0xA9},
            {'ヲ', 0xAA},
            {'ン', 0xAB},
            {'ッ', 0xAC},
            {'ャ', 0xAD},
            {'ュ', 0xAE},
            {'ョ', 0xAF},
            {'ィ', 0xB0},
            {'あ', 0xB1},
            {'い', 0xB2},
            {'う', 0xB3},
            {'え', 0xB4},
            {'お', 0xB5},
            {'か', 0xB6},
            {'き', 0xB7},
            {'く', 0xB8},
            {'け', 0xB9},
            {'こ', 0xBA},
            {'さ', 0xBB},
            {'し', 0xBC},
            {'す', 0xBD},
            {'せ', 0xBE},
            {'そ', 0xBF},
            {'た', 0xC0},
            {'ち', 0xC1},
            {'つ', 0xC2},
            {'て', 0xC3},
            {'と', 0xC4},
            {'な', 0xC5},
            {'に', 0xC6},
            {'ぬ', 0xC7},
            {'ね', 0xC8},
            {'の', 0xC9},
            {'は', 0xCA},
            {'ひ', 0xCB},
            {'ふ', 0xCC},
            {'へ', 0xCD},
            {'ほ', 0xCE},
            {'ま', 0xCF},
            {'み', 0xD0},
            {'む', 0xD1},
            {'め', 0xD2},
            {'も', 0xD3},
            {'や', 0xD4},
            {'ゆ', 0xD5},
            {'よ', 0xD6},
            {'ら', 0xD7},
            {'り', 0xD8},
            {'る', 0xD9},
            {'れ', 0xDA},
            {'ろ', 0xDB},
            {'わ', 0xDC},
            {'を', 0xDD},
            {'ん', 0xDE},
            {'っ', 0xDF},
            {'ゃ', 0xE0},
            {'ゅ', 0xE1},
            {'ょ', 0xE2},
            {'ー', 0xE3},
            {'ァ', 0xE9},
        };

        static Dictionary<byte, char> JP_RBY_TO_CHAR = new Dictionary<byte, char>(){
            {0x05, 'ガ'},
            {0x06, 'ギ'},
            {0x07, 'グ'},
            {0x08, 'ゲ'},
            {0x09, 'ゴ'},
            {0x0A, 'ザ'},
            {0x0B, 'ジ'},
            {0x0C, 'ズ'},
            {0x0D, 'ゼ'},
            {0x0E, 'ゾ'},
            {0x0F, 'ダ'},
            {0x10, 'ヂ'},
            {0x11, 'ヅ'},
            {0x12, 'デ'},
            {0x13, 'ド'},
            {0x19, 'バ'},
            {0x1A, 'ビ'},
            {0x1B, 'ブ'},
            {0x1C, 'ボ'},
            {0x26, 'が'},
            {0x27, 'ぎ'},
            {0x28, 'ぐ'},
            {0x29, 'げ'},
            {0x2A, 'ご'},
            {0x2B, 'ざ'},
            {0x2C, 'じ'},
            {0x2D, 'ず'},
            {0x2E, 'ぜ'},
            {0x2F, 'ぞ'},
            {0x30, 'だ'},
            {0x31, 'ぢ'},
            {0x32, 'づ'},
            {0x33, 'で'},
            {0x34, 'ど'},
            {0x3A, 'ば'},
            {0x3B, 'び'},
            {0x3C, 'ぶ'},
            {0x3D, 'べ'},
            {0x3E, 'ぼ'},
            {0x40, 'パ'},
            {0x41, 'ピ'},
            {0x42, 'プ'},
            {0x43, 'ポ'},
            {0x44, 'ぱ'},
            {0x45, 'ぴ'},
            {0x46, 'ぷ'},
            {0x47, 'ぺ'},
            {0x48, 'ぽ'},
            {0x50, '\0'},
            {0x80, 'ア'},
            {0x81, 'イ'},
            {0x82, 'ウ'},
            {0x83, 'エ'},
            {0x84, 'ォ'},
            {0x85, 'カ'},
            {0x86, 'キ'},
            {0x87, 'ク'},
            {0x88, 'ケ'},
            {0x89, 'コ'},
            {0x8A, 'サ'},
            {0x8B, 'シ'},
            {0x8C, 'ス'},
            {0x8D, 'セ'},
            {0x8E, 'ソ'},
            {0x8F, 'タ'},
            {0x90, 'チ'},
            {0x91, 'ツ'},
            {0x92, 'テ'},
            {0x93, 'ト'},
            {0x94, 'ナ'},
            {0x95, 'ニ'},
            {0x96, 'ヌ'},
            {0x97, 'ネ'},
            {0x98, 'ノ'},
            {0x99, 'ハ'},
            {0x9A, 'ヒ'},
            {0x9B, 'フ'},
            {0x9C, 'ホ'},
            {0x9D, 'マ'},
            {0x9E, 'ミ'},
            {0x9F, 'ム'},
            {0xA0, 'メ'},
            {0xA1, 'モ'},
            {0xA2, 'ヤ'},
            {0xA3, 'ユ'},
            {0xA4, 'ヨ'},
            {0xA5, 'ラ'},
            {0xA6, 'ル'},
            {0xA7, 'レ'},
            {0xA8, 'ロ'},
            {0xA9, 'ワ'},
            {0xAA, 'ヲ'},
            {0xAB, 'ン'},
            {0xAC, 'ッ'},
            {0xAD, 'ャ'},
            {0xAE, 'ュ'},
            {0xAF, 'ョ'},
            {0xB0, 'ィ'},
            {0xB1, 'あ'},
            {0xB2, 'い'},
            {0xB3, 'う'},
            {0xB4, 'え'},
            {0xB5, 'お'},
            {0xB6, 'か'},
            {0xB7, 'き'},
            {0xB8, 'く'},
            {0xB9, 'け'},
            {0xBA, 'こ'},
            {0xBB, 'さ'},
            {0xBC, 'し'},
            {0xBD, 'す'},
            {0xBE, 'せ'},
            {0xBF, 'そ'},
            {0xC0, 'た'},
            {0xC1, 'ち'},
            {0xC2, 'つ'},
            {0xC3, 'て'},
            {0xC4, 'と'},
            {0xC5, 'な'},
            {0xC6, 'に'},
            {0xC7, 'ぬ'},
            {0xC8, 'ね'},
            {0xC9, 'の'},
            {0xCA, 'は'},
            {0xCB, 'ひ'},
            {0xCC, 'ふ'},
            {0xCD, 'へ'},
            {0xCE, 'ほ'},
            {0xCF, 'ま'},
            {0xD0, 'み'},
            {0xD1, 'む'},
            {0xD2, 'め'},
            {0xD3, 'も'},
            {0xD4, 'や'},
            {0xD5, 'ゆ'},
            {0xD6, 'よ'},
            {0xD7, 'ら'},
            {0xD8, 'り'},
            {0xD9, 'る'},
            {0xDA, 'れ'},
            {0xDB, 'ろ'},
            {0xDC, 'わ'},
            {0xDD, 'を'},
            {0xDE, 'ん'},
            {0xDF, 'っ'},
            {0xE0, 'ゃ'},
            {0xE1, 'ゅ'},
            {0xE2, 'ょ'},
            {0xE3, 'ー'},
            {0xE9, 'ァ'},
};
        #endregion
    }


}
