using System;
using System.Runtime.InteropServices;

namespace anticheat
{
    public struct OULong : IEquatable<OULong>
    {
        private static ulong cryptoKey;
        private ulong currentCryptoKey;
        private ulong hiddenValue;
        private ulong fakeValue;
        private bool inited;
        private OULong(ulong value)
        {
            this.currentCryptoKey = cryptoKey;
            this.hiddenValue = value;
            this.fakeValue = 0L;
            this.inited = true;
        }

        static OULong()
        {
            cryptoKey = 0x6c81bL;
        }

        public static void SetNewCryptoKey(ulong newKey)
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

        public static ulong Encrypt(ulong value)
        {
            return Encrypt(value, 0L);
        }

        public static ulong Decrypt(ulong value)
        {
            return Decrypt(value, 0L);
        }

        public static ulong Encrypt(ulong value, ulong key)
        {
            if (key == 0)
            {
                return (value ^ cryptoKey);
            }
            return (value ^ key);
        }

        public static ulong Decrypt(ulong value, ulong key)
        {
            if (key == 0)
            {
                return (value ^ cryptoKey);
            }
            return (value ^ key);
        }

        public ulong GetEncrypted()
        {
            this.ApplyNewCryptoKey();
            return this.hiddenValue;
        }

        public void SetEncrypted(ulong encrypted)
        {
            this.hiddenValue = encrypted;
            if (OCheatDetector.isRunning)
            {
                this.fakeValue = this.InternalDecrypt();
            }
        }

        private ulong InternalDecrypt()
        {
            if (!this.inited)
            {
                this.currentCryptoKey = OULong.cryptoKey;
                this.hiddenValue = Encrypt(0L);
                this.fakeValue = 0L;
                this.inited = true;
            }
            ulong cryptoKey = OULong.cryptoKey;
            if (this.currentCryptoKey != OULong.cryptoKey)
            {
                cryptoKey = this.currentCryptoKey;
            }
            ulong num2 = Decrypt(this.hiddenValue, cryptoKey);
            if ((OCheatDetector.isRunning && (this.fakeValue != null)) && (num2 != this.fakeValue))
            {
                OCheatDetector.Instance.OnCheatingDetected();
            }
            return num2;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is OULong))
            {
                return false;
            }
            OULong @long = (OULong)obj;
            return (this.hiddenValue == @long.hiddenValue);
        }

        public bool Equals(OULong obj)
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

        public string ToString(string format)
        {
            return this.InternalDecrypt().ToString(format);
        }

        public string ToString(IFormatProvider provider)
        {
            return this.InternalDecrypt().ToString(provider);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            return this.InternalDecrypt().ToString(format, provider);
        }

        public static implicit operator OULong(ulong value)
        {
            OULong @long = new OULong(Encrypt(value));
            if (OCheatDetector.isRunning)
            {
                @long.fakeValue = value;
            }
            return @long;
        }

        public static implicit operator ulong(OULong value)
        {
            return value.InternalDecrypt();
        }

        public static OULong operator ++(OULong input)
        {
            ulong num = input.InternalDecrypt() + 1L;
            input.hiddenValue = Encrypt(num, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }

        public static OULong operator --(OULong input)
        {
            ulong num = input.InternalDecrypt() - 1L;
            input.hiddenValue = Encrypt(num, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }
    }
}

