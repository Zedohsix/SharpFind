/* INIFile.cs
** This file is part #Find.
** 
** Copyright 2017 by Babiker M Babiker <bestivitiness@gmail.com>
** Licensed under MIT
** <https://github.com/Zedohsix/SharpFind>
*/

using System.Windows.Forms;
using System;

using static SharpFind.Classes.NativeMethods;

namespace SharpFind.Classes
{
    public class INIFile
    {
        /// <summary>
        /// Path to the settings file.
        /// </summary>
        public static string SettingsPath()
        {
            return Application.StartupPath + "\\settings.ini";
        }

        #region Reading

        /// <summary>
        /// Reads <c>string</c> type keys.
        /// </summary>
        public static string ReadINI(string path, string section, string key)
        {
            return ReadData(path, section, key, string.Empty);
        }

        /// <summary>
        /// Reads <c>integer</c> type keys
        /// </summary>
        public static int ReadINI(string path, string section, string key, int defaultValue)
        {
            return int.Parse(ReadData(path, section, key, string.Empty));
        }

        /// <summary>
        /// Reads <c>boolean</c> type keys.
        /// </summary>
        public static bool ReadINI(string path, string section, string key, bool defaultValue)
        {
            return bool.Parse(ReadData(path, section, key, defaultValue.ToString()));
        }

        public static string ReadData(string path, string section, string key, string defaultValue)
        {
            var sData = new string(' ', 1024);
            var i = Convert.ToInt32(GetPrivateProfileString(section, key, defaultValue, sData, sData.Length, path));
            var value = i > 0 ? sData.Substring(0, i) : string.Empty;

            return value;
        }

        #endregion
        #region Writing

        /// <summary>
        /// Writes <c>string</c> type keys.
        /// </summary>
        public static void WriteINI(string path, string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, path);
        }

        /// <summary>
        /// Writes <c>integer</c> type keys.
        /// </summary>
        public static void WriteINI(string path, string section, string key, int value)
        {
            WritePrivateProfileString(section, key, value.ToString(), path);
        }

        /// <summary>
        /// Writes <c>boolean</c> type keys.
        /// </summary>
        public static void WriteINI(string path, string section, string key, bool value)
        {
            WritePrivateProfileString(section, key, value.ToString().ToLower(), path);
        }

        #endregion
    }
}