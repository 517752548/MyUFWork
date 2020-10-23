using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace anticheat
{
    public struct OBool : IEquatable<OBool>
    {
        private static byte cryptoKey;
        private byte currentCryptoKey;
        private int hiddenValue;
        private bool fakeValue;
        private bool fakeValueChanged;
        private bool inited;
        private OBool(int value)
        {
            this.currentCryptoKey = cryptoKey;
            this.hiddenValue = value;
            this.fakeValue = false;
            this.fakeValueChanged = false;
            this.inited = true;
        }

        static OBool()
        {
            cryptoKey = 0xd7;
        }

        public static void SetNewCryptoKey(byte newKey)
        {
            cryptoKey = newKey;
        }

        public void ApplyNewCryptoKey()
        {
            if (this.currentCryptoKey != cryptoKey)
            {
                this.hiddenValue = Encrypt(this.InternalDecrypt(), cryptoKey);
                this.currentCryptoKey = cryptoKey;
            }
        }

        public static int Encrypt(bool value)
        {
            return Encrypt(value, 0);
        }

        public static int Encrypt(bool value, byte key)
        {
            if (key == 0)
            {
                key = cryptoKey;
            }
            int num = !value ? 0xb5 : 0xd5;
            return (num ^ key);
        }

        public static bool Decrypt(int value)
        {
            return Decrypt(value, 0);
        }

        public static bool Decrypt(int value, byte key)
        {
            if (key == 0)
            {
                key = cryptoKey;
            }
            value ^= key;
            return (value != 0xb5);
        }

        public int GetEncrypted()
        {
            this.ApplyNewCryptoKey();
            return this.hiddenValue;
        }

        public void SetEncrypted(int encrypted)
        {
            this.hiddenValue = encrypted;
            if (OCheatDetector.isRunning)
            {
                this.fakeValue = this.InternalDecrypt();
                this.fakeValueChanged = true;
            }
        }

        private bool InternalDecrypt()
        {
            if (!this.inited)
            {
                this.currentCryptoKey = OBool.cryptoKey;
                this.hiddenValue = Encrypt(false);
                this.fakeValue = false;
                this.fakeValueChanged = true;
                this.inited = true;
            }
            byte cryptoKey = OBool.cryptoKey;
            if (this.currentCryptoKey != OBool.cryptoKey)
            {
                cryptoKey = this.currentCryptoKey;
            }
            int num2 = this.hiddenValue ^ cryptoKey;
            bool flag = num2 != 0xb5;
            if ((OCheatDetector.isRunning && this.fakeValueChanged) && (flag != this.fakeValue))
            {
                OCheatDetector.Instance.OnCheatingDetected();
            }
            return flag;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is OBool))
            {
                return false;
            }
            OBool @bool = (OBool)obj;
            return (this.hiddenValue == @bool.hiddenValue);
        }

        public bool Equals(OBool obj)
        {
            return (this.hiddenValue == obj.hiddenValue);
        }

        public override int GetHashCode()
        {
            return this.InternalDecrypt().GetHashCode();
        }

        public override string ToString()
        {
            return this.InternalDecrypt().ToString();
        }

        public static implicit operator OBool(bool value)
        {
            OBool @bool = new OBool(Encrypt(value));
            if (OCheatDetector.isRunning)
            {
                @bool.fakeValue = value;
                @bool.fakeValueChanged = true;
            }
            return @bool;
        }

        public static implicit operator bool(OBool value)
        {
            return value.InternalDecrypt();
        }
    }
}

