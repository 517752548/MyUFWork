using System;
using System.Text;
using UnityEngine;

namespace anticheat
{
    public sealed class OString
    {
        private static string cryptoKey = "4441";
        private string currentCryptoKey = cryptoKey;
        private string fakeValue;
        private byte[] hiddenValue;
        private bool inited;

        private OString(byte[] value)
        {
            this.hiddenValue = value;
            this.fakeValue = null;
            this.inited = true;
        }

        public void ApplyNewCryptoKey()
        {
            if (this.currentCryptoKey != cryptoKey)
            {
                this.hiddenValue = InternalEncrypt(this.InternalDecrypt());
                this.currentCryptoKey = cryptoKey;
            }
        }

        private static bool ArraysEquals(byte[] a1, byte[] a2)
        {
            if (a1 != a2)
            {
                if ((a1 == null) || (a2 == null))
                {
                    return false;
                }
                if (a1.Length != a2.Length)
                {
                    return false;
                }
                for (int i = 0; i < a1.Length; i++)
                {
                    if (a1[i] != a2[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static string EncryptDecrypt(string value)
        {
            return EncryptDecrypt(value, string.Empty);
        }

        public static string EncryptDecrypt(string value, string key)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(key))
            {
                key = cryptoKey;
            }
            StringBuilder builder = new StringBuilder();
            int num = key.Length;
            int num2 = value.Length;
            char[] valueArr = value.ToCharArray();
            char[] keyArr = key.ToCharArray();
            for (int i = 0; i < num2; i++)
            {
                builder.Append((char)(valueArr[i] ^ keyArr[i % num]));
            }
            return builder.ToString();
        }

        public bool Equals(OString value)
        {
            byte[] hiddenValue = null;
            if (value != null)
            {
                hiddenValue = value.hiddenValue;
            }
            return ArraysEquals(this.hiddenValue, hiddenValue);
        }

        public override bool Equals(object obj)
        {
            OString str = obj as OString;
            string str2 = null;
            if (str != null)
            {
                str2 = GetString(str.hiddenValue);
            }
            return object.Equals(this.hiddenValue, str2);
        }

        public bool Equals(OString value, StringComparison comparisonType)
        {
            string str = null;
            if (value != null)
            {
                str = value.InternalDecrypt();
            }
            return string.Equals(this.InternalDecrypt(), str, comparisonType);
        }

        private static byte[] GetBytes(string str)
        {
            byte[] buffer = new byte[str.Length * 2];
            Buffer.BlockCopy(str.ToCharArray(), 0, buffer, 0, buffer.Length);
            return buffer;
        }

        public string GetEncrypted()
        {
            this.ApplyNewCryptoKey();
            return GetString(this.hiddenValue);
        }

        public override int GetHashCode()
        {
            return this.InternalDecrypt().GetHashCode();
        }

        private static string GetString(byte[] bytes)
        {
            char[] chArray = new char[bytes.Length / 2];
            Buffer.BlockCopy(bytes, 0, chArray, 0, bytes.Length);
            return new string(chArray);
        }

        private string InternalDecrypt()
        {
            if (!this.inited)
            {
                this.currentCryptoKey = OString.cryptoKey;
                this.hiddenValue = InternalEncrypt(string.Empty);
                this.fakeValue = string.Empty;
                this.inited = true;
            }
            string cryptoKey = OString.cryptoKey;
            if (this.currentCryptoKey != OString.cryptoKey)
            {
                cryptoKey = this.currentCryptoKey;
            }
            if (string.IsNullOrEmpty(cryptoKey))
            {
                cryptoKey = OString.cryptoKey;
            }
            string str2 = EncryptDecrypt(GetString(this.hiddenValue), cryptoKey);
            if ((OCheatDetector.isRunning && !string.IsNullOrEmpty(this.fakeValue)) && (str2 != this.fakeValue))
            {
                OCheatDetector.Instance.OnCheatingDetected();
            }
            return str2;
        }

        private static byte[] InternalEncrypt(string value)
        {
            return GetBytes(EncryptDecrypt(value, cryptoKey));
        }

        public static bool operator ==(OString a, OString b)
        {
            try
            {
                return (object.ReferenceEquals(a, b) || ArraysEquals(a.hiddenValue, b.hiddenValue));
            }
            catch (NullReferenceException e)
            {
                
            }
            return false;
        }

        public static implicit operator string(OString value)
        {
            if (value == null)
            {
                return null;
            }
            return value.InternalDecrypt();
        }

        public static implicit operator OString(string value)
        {
            if (value == null)
            {
                return null;
            }
            OString str = new OString(InternalEncrypt(value));
            if (OCheatDetector.isRunning)
            {
                str.fakeValue = value;
            }
            return str;
        }

        public static bool operator !=(OString a, OString b)
        {
            return !(a == b);
        }

        public void SetEncrypted(string encrypted)
        {
            this.hiddenValue = GetBytes(encrypted);
            if (OCheatDetector.isRunning)
            {
                this.fakeValue = this.InternalDecrypt();
            }
        }

        public static void SetNewCryptoKey(string newKey)
        {
            cryptoKey = newKey;
        }

        public override string ToString()
        {
            return this.InternalDecrypt();
        }
    }
}

