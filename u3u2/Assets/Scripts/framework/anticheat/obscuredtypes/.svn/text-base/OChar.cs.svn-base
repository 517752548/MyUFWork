using System;
using System.Runtime.InteropServices;

namespace anticheat
{
    public struct OChar : IEquatable<OChar>
    {
        private static char cryptoKey;
        private char currentCryptoKey;
        private char hiddenValue;
        private char fakeValue;
        private bool inited;
        private OChar(char value)
        {
            this.currentCryptoKey = cryptoKey;
            this.hiddenValue = value;
            this.fakeValue = '\0';
            this.inited = true;
        }

        static OChar()
        {
            cryptoKey = '—';
        }

        public static void SetNewCryptoKey(char newKey)
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

        public static char EncryptDecrypt(char value)
        {
            return EncryptDecrypt(value, '\0');
        }

        public static char EncryptDecrypt(char value, char key)
        {
            if (key == null || key == '\0')
            {
                return (char)(value ^ cryptoKey);
            }
            return (char)(value ^ key);
        }

        public char GetEncrypted()
        {
            this.ApplyNewCryptoKey();
            return this.hiddenValue;
        }

        public void SetEncrypted(char encrypted)
        {
            this.hiddenValue = encrypted;
            if (OCheatDetector.isRunning)
            {
                this.fakeValue = this.InternalDecrypt();
            }
        }

        private char InternalDecrypt()
        {
            if (!this.inited)
            {
                this.currentCryptoKey = OChar.cryptoKey;
                this.hiddenValue = EncryptDecrypt('\0');
                this.fakeValue = '\0';
                this.inited = true;
            }
            char cryptoKey = OChar.cryptoKey;
            if (this.currentCryptoKey != OChar.cryptoKey)
            {
                cryptoKey = this.currentCryptoKey;
            }
            char ch2 = EncryptDecrypt(this.hiddenValue, cryptoKey);
            if ((OCheatDetector.isRunning && (this.fakeValue != null)) && (ch2 != this.fakeValue))
            {
                OCheatDetector.Instance.OnCheatingDetected();
            }
            return ch2;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is OChar))
            {
                return false;
            }
            OChar ch = (OChar)obj;
            return (this.hiddenValue == ch.hiddenValue);
        }

        public bool Equals(OChar obj)
        {
            return (this.hiddenValue == obj.hiddenValue);
        }

        public override string ToString()
        {
            return this.InternalDecrypt().ToString();
        }

        public string ToString(IFormatProvider provider)
        {
            return this.InternalDecrypt().ToString(provider);
        }

        public override int GetHashCode()
        {
            return this.InternalDecrypt().GetHashCode();
        }

        public static implicit operator OChar(char value)
        {
            OChar ch = new OChar(EncryptDecrypt(value));
            if (OCheatDetector.isRunning)
            {
                ch.fakeValue = value;
            }
            return ch;
        }

        public static implicit operator char(OChar value)
        {
            return value.InternalDecrypt();
        }

        public static OChar operator ++(OChar input)
        {
            char ch = (char)(input.InternalDecrypt() + '\x0001');
            input.hiddenValue = EncryptDecrypt(ch, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = ch;
            }
            return input;
        }

        public static OChar operator --(OChar input)
        {
            char ch = (char)(input.InternalDecrypt() - '\x0001');
            input.hiddenValue = EncryptDecrypt(ch, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = ch;
            }
            return input;
        }
    }
}

