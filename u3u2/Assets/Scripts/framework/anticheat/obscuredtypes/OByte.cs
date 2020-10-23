using System;
using System.Runtime.InteropServices;

namespace anticheat
{
    public struct OByte : IEquatable<OByte>
    {
        private static byte cryptoKey;
        private byte currentCryptoKey;
        private byte hiddenValue;
        private byte fakeValue;
        private bool inited;
        private OByte(byte value)
        {
            this.currentCryptoKey = cryptoKey;
            this.hiddenValue = value;
            this.fakeValue = 0;
            this.inited = true;
        }

        static OByte()
        {
            cryptoKey = 0xf4;
        }

        public static void SetNewCryptoKey(byte newKey)
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

        public static byte EncryptDecrypt(byte value)
        {
            return EncryptDecrypt(value, 0);
        }

        public static byte EncryptDecrypt(byte value, byte key)
        {
            if (key == 0)
            {
                return (byte) (value ^ cryptoKey);
            }
            return (byte) (value ^ key);
        }

        public byte GetEncrypted()
        {
            this.ApplyNewCryptoKey();
            return this.hiddenValue;
        }

        public void SetEncrypted(byte encrypted)
        {
            this.hiddenValue = encrypted;
            if (OCheatDetector.isRunning)
            {
                this.fakeValue = this.InternalDecrypt();
            }
        }

        private byte InternalDecrypt()
        {
            if (!this.inited)
            {
                this.currentCryptoKey = OByte.cryptoKey;
                this.hiddenValue = EncryptDecrypt(0);
                this.fakeValue = 0;
                this.inited = true;
            }
            byte cryptoKey = OByte.cryptoKey;
            if (this.currentCryptoKey != OByte.cryptoKey)
            {
                cryptoKey = this.currentCryptoKey;
            }
            byte num2 = EncryptDecrypt(this.hiddenValue, cryptoKey);
            if ((OCheatDetector.isRunning && (this.fakeValue != 0)) && (num2 != this.fakeValue))
            {
                OCheatDetector.Instance.OnCheatingDetected();
            }
            return num2;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is OByte))
            {
                return false;
            }
            OByte num = (OByte)obj;
            return (this.hiddenValue == num.hiddenValue);
        }

        public bool Equals(OByte obj)
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

        public static implicit operator OByte(byte value)
        {
            OByte num = new OByte(EncryptDecrypt(value));
            if (OCheatDetector.isRunning)
            {
                num.fakeValue = value;
            }
            return num;
        }

        public static implicit operator byte(OByte value)
        {
            return value.InternalDecrypt();
        }

        public static OByte operator ++(OByte input)
        {
            byte num = (byte)(input.InternalDecrypt() + 1);
            input.hiddenValue = EncryptDecrypt(num, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }

        public static OByte operator --(OByte input)
        {
            byte num = (byte)(input.InternalDecrypt() - 1);
            input.hiddenValue = EncryptDecrypt(num, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }
    }
}

