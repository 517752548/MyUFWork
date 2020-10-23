using System;
using System.Runtime.InteropServices;

namespace anticheat
{
    public struct OSByte : IEquatable<OSByte>
    {
        private static sbyte cryptoKey;
        private sbyte currentCryptoKey;
        private sbyte hiddenValue;
        private sbyte fakeValue;
        private bool inited;
        private OSByte(sbyte value)
        {
            this.currentCryptoKey = cryptoKey;
            this.hiddenValue = value;
            this.fakeValue = 0;
            this.inited = true;
        }

        static OSByte()
        {
            cryptoKey = 0x70;
        }

        public static void SetNewCryptoKey(sbyte newKey)
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

        public static sbyte EncryptDecrypt(sbyte value)
        {
            return EncryptDecrypt(value, 0);
        }

        public static sbyte EncryptDecrypt(sbyte value, sbyte key)
        {
            if (key == 0)
            {
                return (sbyte) (value ^ cryptoKey);
            }
            return (sbyte) (value ^ key);
        }

        public sbyte GetEncrypted()
        {
            this.ApplyNewCryptoKey();
            return this.hiddenValue;
        }

        public void SetEncrypted(sbyte encrypted)
        {
            this.hiddenValue = encrypted;
            if (OCheatDetector.isRunning)
            {
                this.fakeValue = this.InternalDecrypt();
            }
        }

        private sbyte InternalDecrypt()
        {
            if (!this.inited)
            {
                this.currentCryptoKey = OSByte.cryptoKey;
                this.hiddenValue = EncryptDecrypt(0);
                this.fakeValue = 0;
                this.inited = true;
            }
            sbyte cryptoKey = OSByte.cryptoKey;
            if (this.currentCryptoKey != OSByte.cryptoKey)
            {
                cryptoKey = this.currentCryptoKey;
            }
            sbyte num2 = EncryptDecrypt(this.hiddenValue, cryptoKey);
            if ((OCheatDetector.isRunning && (this.fakeValue != 0)) && (num2 != this.fakeValue))
            {
                OCheatDetector.Instance.OnCheatingDetected();
            }
            return num2;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is OSByte))
            {
                return false;
            }
            OSByte num = (OSByte)obj;
            return (this.hiddenValue == num.hiddenValue);
        }

        public bool Equals(OSByte obj)
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

        public static implicit operator OSByte(sbyte value)
        {
            OSByte num = new OSByte(EncryptDecrypt(value));
            if (OCheatDetector.isRunning)
            {
                num.fakeValue = value;
            }
            return num;
        }

        public static implicit operator sbyte(OSByte value)
        {
            return value.InternalDecrypt();
        }

        public static OSByte operator ++(OSByte input)
        {
            sbyte num = (sbyte)(input.InternalDecrypt() + 1);
            input.hiddenValue = EncryptDecrypt(num, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }

        public static OSByte operator --(OSByte input)
        {
            sbyte num = (sbyte)(input.InternalDecrypt() - 1);
            input.hiddenValue = EncryptDecrypt(num, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }
    }
}

