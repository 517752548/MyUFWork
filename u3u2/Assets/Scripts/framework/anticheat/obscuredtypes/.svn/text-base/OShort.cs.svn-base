using System;
using System.Runtime.InteropServices;

namespace anticheat
{
    public struct OShort : IEquatable<OShort>
    {
        private static short cryptoKey;
        private short currentCryptoKey;
        private short hiddenValue;
        private short fakeValue;
        private bool inited;
        private OShort(short value)
        {
            this.currentCryptoKey = cryptoKey;
            this.hiddenValue = value;
            this.fakeValue = 0;
            this.inited = true;
        }

        static OShort()
        {
            cryptoKey = 0xd6;
        }

        public static void SetNewCryptoKey(short newKey)
        {
            cryptoKey = newKey;
        }

        public void ApplyNewCryptoKey()
        {
            if (this.currentCryptoKey != cryptoKey)
            {
                this.hiddenValue = EncryptDecrypt(this.InternalDecrypt(), cryptoKey);
                this.currentCryptoKey = cryptoKey;
            }
        }

        public static short EncryptDecrypt(short value)
        {
            return EncryptDecrypt(value, 0);
        }

        public static short EncryptDecrypt(short value, short key)
        {
            if (key == 0)
            {
                return (short) (value ^ cryptoKey);
            }
            return (short) (value ^ key);
        }

        public short GetEncrypted()
        {
            this.ApplyNewCryptoKey();
            return this.hiddenValue;
        }

        public void SetEncrypted(short encrypted)
        {
            this.hiddenValue = encrypted;
            if (OCheatDetector.isRunning)
            {
                this.fakeValue = this.InternalDecrypt();
            }
        }

        private short InternalDecrypt()
        {
            if (!this.inited)
            {
                this.currentCryptoKey = OShort.cryptoKey;
                this.hiddenValue = EncryptDecrypt(0);
                this.fakeValue = 0;
                this.inited = true;
            }
            short cryptoKey = OShort.cryptoKey;
            if (this.currentCryptoKey != OShort.cryptoKey)
            {
                cryptoKey = this.currentCryptoKey;
            }
            short num2 = EncryptDecrypt(this.hiddenValue, cryptoKey);
            if ((OCheatDetector.isRunning && (this.fakeValue != null)) && (num2 != this.fakeValue))
            {
                OCheatDetector.Instance.OnCheatingDetected();
            }
            return num2;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is OShort))
            {
                return false;
            }
            OShort @short = (OShort)obj;
            return (this.hiddenValue == @short.hiddenValue);
        }

        public bool Equals(OShort obj)
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

        public static implicit operator OShort(short value)
        {
            OShort @short = new OShort(EncryptDecrypt(value));
            if (OCheatDetector.isRunning)
            {
                @short.fakeValue = value;
            }
            return @short;
        }

        public static implicit operator short(OShort value)
        {
            return value.InternalDecrypt();
        }

        public static OShort operator ++(OShort input)
        {
            short num = (short)(input.InternalDecrypt() + 1);
            input.hiddenValue = EncryptDecrypt(num);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }

        public static OShort operator --(OShort input)
        {
            short num = (short)(input.InternalDecrypt() - 1);
            input.hiddenValue = EncryptDecrypt(num);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }
    }
}

