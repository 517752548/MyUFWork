using System;
using System.Runtime.InteropServices;

namespace anticheat
{
    public struct OLong : IEquatable<OLong>
    {
        private static long cryptoKey;
        private long currentCryptoKey;
        private long hiddenValue;
        private long fakeValue;
        private bool inited;
        private OLong(long value)
        {
            this.currentCryptoKey = cryptoKey;
            this.hiddenValue = value;
            this.fakeValue = 0L;
            this.inited = true;
        }

        static OLong()
        {
            cryptoKey = 0x6c81aL;
        }

        public static void SetNewCryptoKey(long newKey)
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

        public static long Encrypt(long value)
        {
            return Encrypt(value, 0L);
        }

        public static long Decrypt(long value)
        {
            return Decrypt(value, 0L);
        }

        public static long Encrypt(long value, long key)
        {
            if (key == 0)
            {
                return (value ^ cryptoKey);
            }
            return (value ^ key);
        }

        public static long Decrypt(long value, long key)
        {
            if (key == 0)
            {
                return (value ^ cryptoKey);
            }
            return (value ^ key);
        }

        public long GetEncrypted()
        {
            this.ApplyNewCryptoKey();
            return this.hiddenValue;
        }

        public void SetEncrypted(long encrypted)
        {
            this.hiddenValue = encrypted;
            if (OCheatDetector.isRunning)
            {
                this.fakeValue = this.InternalDecrypt();
            }
        }

        private long InternalDecrypt()
        {
            if (!this.inited)
            {
                this.currentCryptoKey = OLong.cryptoKey;
                this.hiddenValue = Encrypt(0L);
                this.fakeValue = 0L;
                this.inited = true;
            }
            long cryptoKey = OLong.cryptoKey;
            if (this.currentCryptoKey != OLong.cryptoKey)
            {
                cryptoKey = this.currentCryptoKey;
            }
            long num2 = Decrypt(this.hiddenValue, cryptoKey);
            if ((OCheatDetector.isRunning && (this.fakeValue != null)) && (num2 != this.fakeValue))
            {
                OCheatDetector.Instance.OnCheatingDetected();
            }
            return num2;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is OLong))
            {
                return false;
            }
            OLong @long = (OLong)obj;
            return (this.hiddenValue == @long.hiddenValue);
        }

        public bool Equals(OLong obj)
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

        public static implicit operator OLong(long value)
        {
            OLong @long = new OLong(Encrypt(value));
            if (OCheatDetector.isRunning)
            {
                @long.fakeValue = value;
            }
            return @long;
        }

        public static implicit operator long(OLong value)
        {
            return value.InternalDecrypt();
        }

        public static OLong operator ++(OLong input)
        {
            long num = input.InternalDecrypt() + 1L;
            input.hiddenValue = Encrypt(num, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }

        public static OLong operator --(OLong input)
        {
            long num = input.InternalDecrypt() - 1L;
            input.hiddenValue = Encrypt(num, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }
    }
}

