using System;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace anticheat
{
    public static class OPrefs
    {
        private static string deviceHash;
        public static bool emergencyMode;
        private static string encryptionKey = "e806f6";
        private static bool foreignSavesReported;
        public static DeviceLockLevel lockToDevice;
        public static UnityAction onAlterationDetected;
        public static UnityAction onPossibleForeignSavesDetected;
        public static bool preservePlayerPrefs;
        public static bool readForeignSaves;
        private static bool savesAlterationReported;

        private static string CalculateChecksum(string input)
        {
            int num = 0;
            byte[] bytes = Encoding.UTF8.GetBytes(input + encryptionKey);
            int length = bytes.Length;
            int num3 = encryptionKey.Length ^ 0x40;
            for (int i = 0; i < length; i++)
            {
                byte num5 = bytes[i];
                num += num5 + ((num5 * (i + num3)) % 3);
            }
            return num.ToString("X2");
        }

        private static string DecryptKey(string key)
        {
            byte[] buffer = Convert.FromBase64String(key);
            key = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            key = OString.EncryptDecrypt(key, encryptionKey);
            return key;
        }

        private static string DecryptValue(string value)
        {
            byte[] buffer;
            char[] chArray1 = new char[] { ':' };
            string[] strArray = value.Split(chArray1);
            if (strArray.Length < 2)
            {
                SavesTampered();
                return string.Empty;
            }
            string input = strArray[0];
            string str2 = strArray[1];
            try
            {
                buffer = Convert.FromBase64String(input);
            }
            catch
            {
                SavesTampered();
                return string.Empty;
            }
            string str4 = OString.EncryptDecrypt(Encoding.UTF8.GetString(buffer, 0, buffer.Length), encryptionKey);
            if (strArray.Length == 3)
            {
                if (str2 != CalculateChecksum(input + DeviceHash))
                {
                    SavesTampered();
                }
            }
            else if (strArray.Length == 2)
            {
                if (str2 != CalculateChecksum(input))
                {
                    SavesTampered();
                }
            }
            else
            {
                SavesTampered();
            }
            if ((lockToDevice != DeviceLockLevel.None) && !emergencyMode)
            {
                if (strArray.Length >= 3)
                {
                    string str5 = strArray[2];
                    if (str5 != DeviceHash)
                    {
                        if (!readForeignSaves)
                        {
                            str4 = string.Empty;
                        }
                        PossibleForeignSavesDetected();
                    }
                    return str4;
                }
                if (lockToDevice == DeviceLockLevel.Strict)
                {
                    if (!readForeignSaves)
                    {
                        str4 = string.Empty;
                    }
                    PossibleForeignSavesDetected();
                    return str4;
                }
                if (str2 == CalculateChecksum(input))
                {
                    return str4;
                }
                if (!readForeignSaves)
                {
                    str4 = string.Empty;
                }
                PossibleForeignSavesDetected();
            }
            return str4;
        }

        private static string DecryptValueDeprecated(string value)
        {
            byte[] buffer = Convert.FromBase64String(value);
            value = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            if (lockToDevice != DeviceLockLevel.None)
            {
                value = OString.EncryptDecrypt(value, GetDeviceIDDeprecated());
            }
            value = OString.EncryptDecrypt(value, encryptionKey);
            return value;
        }

        public static void DeleteAll()
        {
            PlayerPrefs.DeleteAll();
        }

        public static void DeleteKey(string key)
        {
            PlayerPrefs.DeleteKey(EncryptKey(key));
            PlayerPrefs.DeleteKey(key);
        }

        private static string EncryptKey(string key)
        {
            key = OString.EncryptDecrypt(key, encryptionKey);
            key = Convert.ToBase64String(Encoding.UTF8.GetBytes(key));
            return key;
        }

        private static string EncryptKeyDeprecated(string key)
        {
            key = OString.EncryptDecrypt(key);
            if (lockToDevice != DeviceLockLevel.None)
            {
                key = OString.EncryptDecrypt(key, GetDeviceIDDeprecated());
            }
            key = Convert.ToBase64String(Encoding.UTF8.GetBytes(key));
            return key;
        }

        private static string EncryptValue(string value)
        {
            string input = OString.EncryptDecrypt(value, encryptionKey);
            input = Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
            if (lockToDevice != DeviceLockLevel.None)
            {
                string str2 = input;
                object[] objArray1 = new object[] { str2, ':', CalculateChecksum(input + DeviceHash), ":", DeviceHash };
                return string.Concat(objArray1);
            }
            return (input + ':' + CalculateChecksum(input));
        }

        public static void ForceDeviceID(string newDeviceID)
        {
            deviceHash = newDeviceID;
        }

        public static void ForceLockToDeviceInit()
        {
            if (string.IsNullOrEmpty(deviceHash))
            {
                deviceHash = GetDeviceID();
            }
            else
            {
                ClientLog.LogWarning("[ACT] ObscuredPrefs.ForceLockToDeviceInit() is called, but device ID is already obtained!");
            }
        }

        public static bool GetBool(string key)
        {
            return GetBool(key, false);
        }

        public static bool GetBool(string key, bool defaultValue)
        {
            int num2;
            int num = !defaultValue ? 0 : 1;
            int.TryParse(GetData(EncryptKey(key), num.ToString()), out num2);
            return (num2 == 1);
        }

        public static byte[] GetByteArray(string key)
        {
            return GetByteArray(key, 0, 0);
        }

        public static byte[] GetByteArray(string key, byte defaultValue, int defaultLength)
        {
            string data = GetData(EncryptKey(key), "{not_found}");
            if (data == "{not_found}")
            {
                byte[] buffer = new byte[defaultLength];
                for (int i = 0; i < defaultLength; i++)
                {
                    buffer[i] = defaultValue;
                }
                return buffer;
            }
            return Encoding.UTF8.GetBytes(data);
        }

        private static string GetData(string key, string defaultValueRaw)
        {
            string str = PlayerPrefs.GetString(key, defaultValueRaw);
            if (str != defaultValueRaw)
            {
                str = DecryptValue(str);
                if (str == string.Empty)
                {
                    str = defaultValueRaw;
                }
                return str;
            }
            string str2 = DecryptKey(key);
            string str3 = EncryptKeyDeprecated(str2);
            str = PlayerPrefs.GetString(str3, defaultValueRaw);
            if (str != defaultValueRaw)
            {
                str = DecryptValueDeprecated(str);
                PlayerPrefs.DeleteKey(str3);
                SetStringValue(str2, str);
                return str;
            }
            if (PlayerPrefs.HasKey(str2))
            {
                ClientLog.LogWarning("[ACT] Are you trying to read data saved with regular PlayerPrefs using ObscuredPrefs (key = " + str2 + ")?");
            }
            return str;
        }

        private static string GetDeviceID()
        {
            string input = string.Empty;
            if (string.IsNullOrEmpty(input))
            {
                input = SystemInfo.deviceUniqueIdentifier;
            }
            return CalculateChecksum(input);
        }

        private static string GetDeviceIDDeprecated()
        {
            return SystemInfo.deviceUniqueIdentifier;
        }

        public static double GetDouble(string key)
        {
            return GetDouble(key, 0.0);
        }

        public static double GetDouble(string key, double defaultValue)
        {
            double num;
            double.TryParse(GetData(EncryptKey(key), defaultValue.ToString()), out num);
            return num;
        }

        public static float GetFloat(string key)
        {
            return GetFloat(key, 0f);
        }

        public static float GetFloat(string key, float defaultValue)
        {
            float num2;
            string str = EncryptKey(key);
            if (!PlayerPrefs.HasKey(str) && PlayerPrefs.HasKey(key))
            {
                float @float = PlayerPrefs.GetFloat(key, defaultValue);
                if (!preservePlayerPrefs)
                {
                    SetFloat(key, @float);
                    PlayerPrefs.DeleteKey(key);
                }
                return @float;
            }
            float.TryParse(GetData(str, defaultValue.ToString()), out num2);
            return num2;
        }

        public static int GetInt(string key)
        {
            return GetInt(key, 0);
        }

        public static int GetInt(string key, int defaultValue)
        {
            int num2;
            string str = EncryptKey(key);
            if (!PlayerPrefs.HasKey(str) && PlayerPrefs.HasKey(key))
            {
                int @int = PlayerPrefs.GetInt(key, defaultValue);
                if (!preservePlayerPrefs)
                {
                    SetInt(key, @int);
                    PlayerPrefs.DeleteKey(key);
                }
                return @int;
            }
            int.TryParse(GetData(str, defaultValue.ToString()), out num2);
            return num2;
        }

        public static long GetLong(string key)
        {
            return GetLong(key, 0L);
        }

        public static long GetLong(string key, long defaultValue)
        {
            long num;
            long.TryParse(GetData(EncryptKey(key), defaultValue.ToString()), out num);
            return num;
        }

        public static string GetString(string key)
        {
            return GetString(key, string.Empty);
        }

        public static string GetString(string key, string defaultValue)
        {
            string str = EncryptKey(key);
            if (PlayerPrefs.HasKey(str) || !PlayerPrefs.HasKey(key))
            {
                return GetData(str, defaultValue);
            }
            string str2 = PlayerPrefs.GetString(key, defaultValue);
            if (!preservePlayerPrefs)
            {
                SetString(key, str2);
                PlayerPrefs.DeleteKey(key);
            }
            return str2;
        }

        public static Vector3 GetVector3(string key)
        {
            return GetVector3(key, Vector3.zero);
        }

        public static Vector3 GetVector3(string key, Vector3 defaultValue)
        {
            float num;
            float num2;
            float num3;
            string data = GetData(EncryptKey(key), "{not_found}");
            if (data == "{not_found}")
            {
                return defaultValue;
            }
            char[] chArray1 = new char[] { '|' };
            string[] strArray = data.Split(chArray1);
            float.TryParse(strArray[0], out num);
            float.TryParse(strArray[1], out num2);
            float.TryParse(strArray[2], out num3);
            return new Vector3(num, num2, num3);
        }

        public static bool HasKey(string key)
        {
            return (PlayerPrefs.HasKey(key) || PlayerPrefs.HasKey(EncryptKey(key)));
        }

        private static void PossibleForeignSavesDetected()
        {
            if ((onPossibleForeignSavesDetected != null) && !foreignSavesReported)
            {
                foreignSavesReported = true;
                onPossibleForeignSavesDetected.Invoke();
            }
        }

        public static void Save()
        {
            PlayerPrefs.Save();
        }

        private static void SavesTampered()
        {
            if ((onAlterationDetected != null) && !savesAlterationReported)
            {
                savesAlterationReported = true;
                onAlterationDetected.Invoke();
            }
        }

        public static void SetBool(string key, bool value)
        {
            SetInt(key, !value ? 0 : 1);
        }

        public static void SetByteArray(string key, byte[] value)
        {
            SetStringValue(key, Encoding.UTF8.GetString(value, 0, value.Length));
        }

        public static void SetDouble(string key, double value)
        {
            SetStringValue(key, value.ToString());
        }

        public static void SetFloat(string key, float value)
        {
            SetStringValue(key, value.ToString());
        }

        public static void SetInt(string key, int value)
        {
            SetStringValue(key, value.ToString());
        }

        public static void SetLong(string key, long value)
        {
            SetStringValue(key, value.ToString());
        }

        public static void SetNewCryptoKey(string newKey)
        {
            encryptionKey = newKey;
        }

        public static void SetString(string key, string value)
        {
            SetStringValue(key, value);
        }

        private static void SetStringValue(string key, string value)
        {
            PlayerPrefs.SetString(EncryptKey(key), EncryptValue(value));
        }

        public static void SetVector3(string key, Vector3 value)
        {
            object[] objArray1 = new object[] { value.x, "|", value.y, "|", value.z };
            string str = string.Concat(objArray1);
            SetStringValue(key, str);
        }

        private static string DeviceHash
        {
            get
            {
                if (string.IsNullOrEmpty(deviceHash))
                {
                    deviceHash = GetDeviceID();
                }
                return deviceHash;
            }
        }

        public enum DeviceLockLevel : byte
        {
            None = 0,
            Soft = 1,
            Strict = 2
        }
    }
}

