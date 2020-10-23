using System;

namespace anticheat
{
    public struct OInt : IEquatable<OInt>
    {
        private static int cryptoKey;
        private int currentCryptoKey;
        private int hiddenValue;
        private int fakeValue;
        private bool inited;
        private OInt(int value)
        {
            this.currentCryptoKey = cryptoKey;
            this.hiddenValue = value;
            this.fakeValue = 0;
            this.inited = true;
        }

        static OInt()
        {
            cryptoKey = 0x6c81c;
        }

        public static void SetNewCryptoKey(int newKey)
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

        public static int Encrypt(int value)
        {
            return Encrypt(value, 0);
        }

        public static int Encrypt(int value, int key)
        {
            if (key == 0)
            {
                return (value ^ cryptoKey);
            }
            return (value ^ key);
        }

        public static int Decrypt(int value)
        {
            return Decrypt(value, 0);
        }

        public static int Decrypt(int value, int key)
        {
            if (key == 0)
            {
                return (value ^ cryptoKey);
            }
            return (value ^ key);
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
            }
        }

        private int InternalDecrypt()
        {
            if (!this.inited)
            {
                this.currentCryptoKey = OInt.cryptoKey;
                this.hiddenValue = Encrypt(0);
                this.fakeValue = 0;
                this.inited = true;
            }
            int cryptoKey = OInt.cryptoKey;
            if (this.currentCryptoKey != OInt.cryptoKey)
            {
                cryptoKey = this.currentCryptoKey;
            }
            int num2 = Decrypt(this.hiddenValue, cryptoKey);
            if ((OCheatDetector.isRunning && (this.fakeValue != 0)) && (num2 != this.fakeValue))
            {
                ClientLog.LogWarning("decrypted = " + num2 + ";fakeValue = " + this.fakeValue);
                OCheatDetector.Instance.OnCheatingDetected();
            }
            return num2;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is OInt))
            {
                return false;
            }
            OInt num = (OInt)obj;
            return (this.hiddenValue == num.hiddenValue);
        }

        public bool Equals(OInt obj)
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

        public static implicit operator OInt(int value)
        {
            OInt num = new OInt(Encrypt(value));
            if (OCheatDetector.isRunning)
            {
                num.fakeValue = value;
            }
            return num;
        }

        public static implicit operator int(OInt value)
        {
            return value.InternalDecrypt();
        }

        public static OInt operator ++(OInt input)
        {
            int num = input.InternalDecrypt() + 1;
            input.hiddenValue = Encrypt(num, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }

        public static OInt operator --(OInt input)
        {
            int num = input.InternalDecrypt() - 1;
            input.hiddenValue = Encrypt(num, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }
    }
}

