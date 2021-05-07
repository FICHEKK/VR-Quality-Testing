using UnityEngine;

namespace VRQualityTesting.Scripts.Utility
{
    public static class Settings
    {
        public static string GetString(string key, string defaultValue = "") => PlayerPrefs.GetString(key, defaultValue);
        public static int GetInt(string key, int defaultValue = 0) => PlayerPrefs.GetInt(key, defaultValue);
        public static float GetFloat(string key, float defaultValue = 0) => PlayerPrefs.GetFloat(key, defaultValue);
        public static bool GetBool(string key, bool defaultValue = false) => PlayerPrefs.HasKey(key) ? PlayerPrefs.GetInt(key) == 1 : defaultValue;

        public static void SetString(string key, string value) => PlayerPrefs.SetString(key, value);
        public static void SetInt(string key, int value) => PlayerPrefs.SetInt(key, value);
        public static void SetFloat(string key, float value) => PlayerPrefs.SetFloat(key, value);
        public static void SetBool(string key, bool value) => PlayerPrefs.SetInt(key, value ? 1 : 0);
    }
}
