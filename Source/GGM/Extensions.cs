﻿using System;
using GGM.Caching;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace GGM
{
    public static class Extensions
    {
        /// <summary>
        /// Converts Bytes to Megabytes.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static float BytesToMegabytes(this long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        /// <summary>
        /// Counts words in string.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="s1"></param>
        /// <returns></returns>
        public static int CountWords(this string s, string s1)
        {
            return (s.Length - s.Replace(s1, "").Length) / s1.Length;
        }

        /// <summary>
        /// Disables GameObject using cache.
        /// </summary>
        /// <param name="str"></param>
        public static void DisableObject(string str)
        {
            if (GameObjectCache.Find(str))
            {
                GameObjectCache.Find(str).SetActive(false);
            }
        }

        /// <summary>
        /// Enables GameObject using cache.
        /// </summary>
        /// <param name="str"></param>
        public static void EnableObject(string str)
        {
            if (GameObjectCache.Find(str))
            {
                GameObjectCache.Find(str).SetActive(true);
            }
        }

        /// <summary>
        /// Sends RPC to all GGM users on server.
        /// </summary>
        /// <param name="pv"></param>
        /// <param name="RPCName"></param>
        /// <param name="data"></param>
        public static void SendToGGMUser(this PhotonView pv, string RPCName, params object[] data)
        {
            var targets = PhotonPlayer.GetGGMUsers();
            if (targets.Length == 0)
            {
                return;
            }

            foreach (var player in targets)
            {
                pv.RPC(RPCName, player, data);
            }
        }

        /// <summary>
        /// Adds HTML color tag to string.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string SetColor(this string str, string color)
        {
            return $"<color=#{color}>{str}</color>";
        }

        /// <summary>
        /// Adds HTML size tag to string.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string SetSize(this string str, int size)
        {
            return $"<size={size}>{str}</size>";
        }

        /// <summary>
        /// Removes HEX tag colors from string.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string StripHEX(this string text)
        {
            var list = new[] { 'A', 'B', 'C', 'D', 'E', 'F', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }.ToList();
            for (var i = 0; i < text.Length; i++)
            {
                if (text[i] == '[')
                {
                    var num = i;
                    var num2 = 1;
                    var flag = false;
                    while (num + num2 < text.Length)
                    {
                        num2++;
                        if (num2 > 8)
                        {
                            break;
                        }

                        var num3 = num + num2 - 1;
                        if (text[num3] == ']')
                        {
                            if (num2 >= 3 && (num2 != 3 || text[num3 - 1] == '-'))
                            {
                                flag = true;
                            }

                            break;
                        }

                        if (!list.Contains(Char.ToUpper(text[num3])) && (num3 + 1 >= text.Length || text[num3 + 1] != ']'))
                        {
                            break;
                        }
                    }

                    if (flag)
                    {
                        text = text.Remove(num, num2);
                        i = 0;
                    }
                }
            }

            return String.Concat(text);
        }

        /// <summary>
        /// Removes HTML tags from string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string StripHTML(this string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        /// <summary>
        /// Converts HEX string to Color.
        /// </summary>
        /// <param name="hex"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Color ToColor(this string hex, byte a = 255)
        {
            if (hex.Length != 6) return ColorCache.White;
            var r = Byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
            var g = Byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
            var b = Byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
            return new Color32(r, g, b, a);
        }

        /// <summary>
        /// Converts string array to float array.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static float[] ToFloatArray(this string[] str)
        {
            var output = new float[str.Length];

            for (var i = 0; i < str.Length; i++)
            {
                output[i] = Single.Parse(str[i]);
            }

            return output;
        }

        /// <summary>
        /// Converts Color variable to HEX-format string.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string ToHEX(this Color color)
        {
            return color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
        }

        /// <summary>
        /// Converts HEX color tag to HTML color tag.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToHTML(this string str)
        {
            if (Regex.IsMatch(str, @"\[([0-9a-zA-Z]{6})\]"))
            {
                str = str.Contains("[-]") ? Regex.Replace(str, @"\[([0-9a-fA-F]{6})\]", "<color=#$1>").Replace("[-]", "</color>") : Regex.Replace(str, @"\[([0-9a-fA-F]{6})\]", "<color=#$1>");
                var c = (short)(str.CountWords("<color=") - str.CountWords("</color>"));
                for (short i = 0; i < c; i++)
                {
                    str += "</color>";
                }
            }

            return str;
        }

        /// <summary>
        /// Makes first letter of string upper case.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToUpperCase(this string str)
        {
            return Char.ToUpper(str[0]) + str.Substring(1);
        }

        public static string CheckProps(this PhotonPlayer player)
        {
            var result = String.Empty;
            foreach (string str in player.customProperties.Keys)
            {
                if (PhotonPlayer.AllProps.Contains(str))
                {
                    if ((string)str == String.Empty)
                    {
                        result += "string.Empty ";
                    }
                    else
                    {
                        result += str + ": " + player.customProperties[str] + '\n';
                    }
                }
            }

            return result == String.Empty ? "No unusual properties" : result;
        }

        public static string CheckMod(this PhotonPlayer player)
        {
            var mod = String.Empty;
            var key = String.Empty;
            var rank = String.Empty;
            string[] rankarray = { "bronze", "silver", "gold", "platin", "diamond", "master", "grandmaster", "top5", "legendary" };
            switch (key)
            {
                case "Arch":
                    return mod = "Arch Mod";

                case "ZM":
                    return mod = "ZM Mod";

                case "KM":
                    return mod = "Kirito's Mod";

                case "CearPriv":
                    return mod = "Cear's Mod";

                case "GHOST":
                    return mod = "Ghost's Mod";

                case "CyanModNew":
                case "CyanMod":
                    return mod = "Cyan Mod";

                case "NRC":
                    return mod = "NRC Mod";

                case "RPR":
                    return mod = "RP Mod";

                case "USaitama":
                    return mod = "Saitama Mod";

                case "SRC":
                    return mod = "SRC Mod";

                case "Rage":
                case "RAGE":
                    return mod = "Tactical Rage's Mod / Valkyre Mod";

                case "EXE":
                    return mod = "EXE Mod";

                case "SoSteam":
                    return mod = "Ori's Mod";

                case "Nathan":
                    return mod = "Aurora & Nathan Mod";

                case "Angry_Guest":
                    return mod = "Angry_Guest Mod";

                case "not null":
                    return mod = "EC Mod";

                case "kies":
                case "Red":
                case "Death":
                    return mod = "Death Mod / Red Skies Mod";

                case "raohsopmod":
                    return mod = "Raoh Mod";

                case "Robbie'sMod":
                    return mod = "Robbie's Mod";

                case "KageNoKishi":
                    return mod = "Kage no kishi Mod";

                case "Universe":
                case "coins":
                case "UPublica":
                case "UPublica2":
                case "[a100ff]|[ac00ff]U[b800ff]n[c300ff]e[cf00ff]~[da00ff]]|fefcff| ":
                case "string.Empty":
                    return mod = "Universe Mod";

                case "INS":
                case "INSANE":
                    return mod = "Insane Mod";

                case "BRM":
                    return mod = "BRM Mod";

                case "AlphaX":
                    return mod = "AlphaX Mod";

                case "BSM":
                    return mod = "Blossom Mod";

                case "pedoModUser":
                    return mod = "Pedo Mod";
            }

            if (player.customProperties.ContainsKey(rankarray[0]) || player.customProperties.ContainsKey(rankarray[1]) || player.customProperties.ContainsKey(rankarray[2]) || player.customProperties.ContainsKey(rankarray[3]) || player.customProperties.ContainsKey(rankarray[4]) || player.customProperties.ContainsKey(rankarray[5]) || player.customProperties.ContainsKey(rankarray[6]) || player.customProperties.ContainsKey(rankarray[7]))
            {
                if (player.customProperties.ContainsKey(rankarray[0]))
                {
                    rank = "Bronze";
                }

                if (player.customProperties.ContainsKey(rankarray[1]))
                {
                    rank = "Silver";
                }

                if (player.customProperties.ContainsKey(rankarray[2]))
                {
                    rank = "Gold";
                }

                if (player.customProperties.ContainsKey(rankarray[3]))
                {
                    rank = "Platinum";
                }

                if (player.customProperties.ContainsKey(rankarray[4]))
                {
                    rank = "Diamond";
                }

                if (player.customProperties.ContainsKey(rankarray[5]))
                {
                    rank = "Master";
                }

                if (player.customProperties.ContainsKey(rankarray[6]))
                {
                    rank = "Grandmaster";
                }

                if (player.customProperties.ContainsKey(rankarray[7]))
                {
                    rank = "Top 5";
                }

                if (player.customProperties.ContainsKey(rankarray[8]))
                {
                    rank = "Legendary";
                }

                mod = rank;
                return "RRC Mod \nRank: " + rank;
            }

            if (player.customProperties.ContainsKey(key))
            {
                return mod;
            }

            if (player.isLocal)
            {
                return "GucciGangMod";
            }

            if (player.CelestialDeath)
            {
                return "CelestialDeath";
            }

            if (player.CyanMod)
            {
                return "CyanMod v0.3.0.2";
            }

            if (player.DI)
            {
                return "DI";
            }

            if (player.DeadInside)
            {
                return "DeadInside";
            }

            if (player.DeadInsideVer)
            {
                return "DeadInsideVer";
            }

            if (player.DeathMod)
            {
                return "DeathMod";
            }

            if (player.GucciLab)
            {
                return "GucciGangMod v1";
            }

            if (player.GucciGangMod)
            {
                return "GucciGangMod";
            }

            if (player.RC83)
            {
                return "RC83";
            }

            if (player.RS)
            {
                return "Red Skies";
            }

            if (player.SukaMod)
            {
                return "SukaRC";
            }

            if (player.SukaModOld)
            {
                return "OldSukaRC";
            }

            if (player.Universe)
            {
                return "Universe";
            }

            if (player.VENICE)
            {
                return "Venice's Mod";
            }

            if (player.customProperties.ContainsKey("RCteam") && mod == String.Empty)
            {
                return "RC Mod";
            }

            return "Unknown";
        }
    }
}