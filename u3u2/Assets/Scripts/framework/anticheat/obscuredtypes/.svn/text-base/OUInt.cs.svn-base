using System;
using System.Runtime.InteropServices;

namespace anticheat
{
    public struct OUInt : IEquatable<OUInt>
    {
        private static uint cryptoKey;
        private uint currentCryptoKey;
        private uint hiddenValue;
        private uint fakeValue;
        private bool inited;
        private OUInt(uint value)
        {
            this.currentCryptoKey = cryptoKey;
            this.hiddenValue = value;
            this.fakeValue = 0;
            this.inited = true;
        }

        static OUInt()
        {
            cryptoKey = 0x3ab81;
        }

        public static void SetNewCryptoKey(uint newKey)
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

        public static uint Encrypt(uint value)
        {
            return Encrypt(value, 0);
        }

        public static uint Decrypt(uint value)
        {
            return Decrypt(value, 0);
        }

        public static uint Encrypt(uint value, uint key)
        {
            if (key == 0)
            {
                return (value ^ cryptoKey);
            }
            return (value ^ key);
        }

        public static uint Decrypt(uint value, uint key)
        {
            if (key == 0)
            {
                return (value ^ cryptoKey);
            }
            return (value ^ key);
        }

        public uint GetEncrypted()
        {
            this.ApplyNewCryptoKey();
            return this.hiddenValue;
        }

        public void SetEncrypted(uint encrypted)
        {
            this.hiddenValue = encrypted;
            if (OCheatDetector.isRunning)
            {
                this.fakeValue = this.InternalDecrypt();
            }
        }

        private uint InternalDecrypt()
        {
            if (!this.inited)
            {
                this.currentCryptoKey = OUInt.cryptoKey;
                this.hiddenValue = Encrypt(0);
                this.fakeValue = 0;
                this.inited = true;
            }
            uint cryptoKey = OUInt.cryptoKey;
            if (this.currentCryptoKey != OUInt.cryptoKey)
            {
                cryptoKey = this.currentCryptoKey;
            }
            uint num2 = Decrypt(this.hiddenValue, cryptoKey);
            if ((OCheatDetector.isRunning && (this.fakeValue != null)) && (num2 != this.fakeValue))
            {
                OCheatDetector.Instance.OnCheatingDetected();
            }
            return num2;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is OUInt))
            {
                return false;
            }
            OUInt num = (OUInt)obj;
            return (this.hiddenValue == num.hiddenValue);
        }

        public bool Equals(OUInt obj)
        {
            return (this.hiddenValue == obj.hiddenValue);
        }

        public override string ToString()
        {
            return this.InternalDecrypt().ToString();
        }

        public string ToString(string format)
        {
            return this.InternalDecrypt().ToString(format);
        }

        public override int GetHashCode()
        {
            return this.InternalDecrypt().GetHashCode();
        }

        public string ToString(IFormatProvider provider)
        {
            return this.InternalDecrypt().ToString(provider);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            return this.InternalDecrypt().ToString(format, provider);
        }

        public static implicit operator OUInt(uint value)
        {
            OUInt num = new OUInt(Encrypt(value));
            if (OCheatDetector.isRunning)
            {
                num.fakeValue = value;
            }
            return num;
        }

        public static implicit operator uint(OUInt value)
        {
            return value.InternalDecrypt();
        }

        public static OUInt operator ++(OUInt input)
        {
            uint num = input.InternalDecrypt() + 1;
            input.hiddenValue = Encrypt(num, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }

        public static OUInt operator --(OUInt input)
        {
            uint num = input.InternalDecrypt() - 1;
            input.hiddenValue = Encrypt(num, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }
    }
}

