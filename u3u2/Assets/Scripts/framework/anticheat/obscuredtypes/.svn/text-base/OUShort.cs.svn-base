using System;
using System.Runtime.InteropServices;

namespace anticheat
{
    public struct OUShort : IEquatable<OUShort>
    {
        private static ushort cryptoKey;
        private ushort currentCryptoKey;
        private ushort hiddenValue;
        private ushort fakeValue;
        private bool inited;
        private OUShort(ushort value)
        {
            this.currentCryptoKey = cryptoKey;
            this.hiddenValue = value;
            this.fakeValue = 0;
            this.inited = true;
        }

        static OUShort()
        {
            cryptoKey = 0xe0;
        }

        public static void SetNewCryptoKey(ushort newKey)
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

        public static ushort EncryptDecrypt(ushort value)
        {
            return EncryptDecrypt(value, 0);
        }

        public static ushort EncryptDecrypt(ushort value, ushort key)
        {
            if (key == 0)
            {
                return (ushort) (value ^ cryptoKey);
            }
            return (ushort) (value ^ key);
        }

        public ushort GetEncrypted()
        {
            this.ApplyNewCryptoKey();
            return this.hiddenValue;
        }

        public void SetEncrypted(ushort encrypted)
        {
            this.hiddenValue = encrypted;
            if (OCheatDetector.isRunning)
            {
                this.fakeValue = this.InternalDecrypt();
            }
        }

        private ushort InternalDecrypt()
        {
            if (!this.inited)
            {
                this.currentCryptoKey = OUShort.cryptoKey;
                this.hiddenValue = EncryptDecrypt(0);
                this.fakeValue = 0;
                this.inited = true;
            }
            ushort cryptoKey = OUShort.cryptoKey;
            if (this.currentCryptoKey != OUShort.cryptoKey)
            {
                cryptoKey = this.currentCryptoKey;
            }
            ushort num2 = EncryptDecrypt(this.hiddenValue, cryptoKey);
            if ((OCheatDetector.isRunning && (this.fakeValue != null)) && (num2 != this.fakeValue))
            {
                OCheatDetector.Instance.OnCheatingDetected();
            }
            return num2;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is OUShort))
            {
                return false;
            }
            OUShort @short = (OUShort)obj;
            return (this.hiddenValue == @short.hiddenValue);
        }

        public bool Equals(OUShort obj)
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

        public static implicit operator OUShort(ushort value)
        {
            OUShort @short = new OUShort(EncryptDecrypt(value));
            if (OCheatDetector.isRunning)
            {
                @short.fakeValue = value;
            }
            return @short;
        }

        public static implicit operator ushort(OUShort value)
        {
            return value.InternalDecrypt();
        }

        public static OUShort operator ++(OUShort input)
        {
            ushort num = (ushort)(input.InternalDecrypt() + 1);
            input.hiddenValue = EncryptDecrypt(num, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }

        public static OUShort operator --(OUShort input)
        {
            ushort num = (ushort)(input.InternalDecrypt() - 1);
            input.hiddenValue = EncryptDecrypt(num, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }
    }
}

