using System;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;

namespace anticheat
{
    public struct OVector2
    {
        private static int cryptoKey;
        private static readonly Vector2 initialFakeValue;
        private int currentCryptoKey;
        private RawEncryptedVector2 hiddenValue;
        private Vector2 fakeValue;
        private bool inited;
        private OVector2(RawEncryptedVector2 value)
        {
            this.currentCryptoKey = cryptoKey;
            this.hiddenValue = value;
            this.fakeValue = initialFakeValue;
            this.inited = true;
        }

        static OVector2()
        {
            cryptoKey = 0x1d58e;
            initialFakeValue = Vector2.zero;
        }

        public float x
        {
            get
            {
                float num = this.InternalDecryptField(this.hiddenValue.x);
                if ((OCheatDetector.isRunning && !this.fakeValue.Equals(initialFakeValue)) && (Math.Abs(num - this.fakeValue.x) > OCheatDetector.Instance.vector2Epsilon))
                {
                    OCheatDetector.Instance.OnCheatingDetected();
                }
                return num;
            }
            set
            {
                this.hiddenValue.x = this.InternalEncryptField(value);
                if (OCheatDetector.isRunning)
                {
                    this.fakeValue.x = value;
                }
            }
        }
        public float y
        {
            get
            {
                float num = this.InternalDecryptField(this.hiddenValue.y);
                if ((OCheatDetector.isRunning && !this.fakeValue.Equals(initialFakeValue)) && (Math.Abs(num - this.fakeValue.y) > OCheatDetector.Instance.vector2Epsilon))
                {
                    OCheatDetector.Instance.OnCheatingDetected();
                }
                return num;
            }
            set
            {
                this.hiddenValue.y = this.InternalEncryptField(value);
                if (OCheatDetector.isRunning)
                {
                    this.fakeValue.y = value;
                }
            }
        }
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this.x;

                    case 1:
                        return this.y;
                }
                throw new IndexOutOfRangeException("Invalid ObscuredVector2 index!");
            }
            set
            {
                switch (index)
                {
                    case 0:
                        this.x = value;
                        break;

                    case 1:
                        this.y = value;
                        break;

                    default:
                        throw new IndexOutOfRangeException("Invalid ObscuredVector2 index!");
                }
            }
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

        public static RawEncryptedVector2 Encrypt(Vector2 value)
        {
            return Encrypt(value, 0);
        }

        public static RawEncryptedVector2 Encrypt(Vector2 value, int key)
        {
            RawEncryptedVector2 vector;
            if (key == 0)
            {
                key = cryptoKey;
            }
            vector.x = OFloat.Encrypt(value.x, key);
            vector.y = OFloat.Encrypt(value.y, key);
            return vector;
        }

        public static Vector2 Decrypt(RawEncryptedVector2 value)
        {
            return Decrypt(value, 0);
        }

        public static Vector2 Decrypt(RawEncryptedVector2 value, int key)
        {
            Vector2 vector;
            if (key == 0)
            {
                key = cryptoKey;
            }
            vector.x = OFloat.Decrypt(value.x, key);
            vector.y = OFloat.Decrypt(value.y, key);
            return vector;
        }

        public RawEncryptedVector2 GetEncrypted()
        {
            this.ApplyNewCryptoKey();
            return this.hiddenValue;
        }

        public void SetEncrypted(RawEncryptedVector2 encrypted)
        {
            this.hiddenValue = encrypted;
            if (OCheatDetector.isRunning)
            {
                this.fakeValue = this.InternalDecrypt();
            }
        }

        private Vector2 InternalDecrypt()
        {
            Vector2 vector;
            if (!this.inited)
            {
                this.currentCryptoKey = OVector2.cryptoKey;
                this.hiddenValue = Encrypt(initialFakeValue);
                this.fakeValue = initialFakeValue;
                this.inited = true;
            }
            int cryptoKey = OVector2.cryptoKey;
            if (this.currentCryptoKey != OVector2.cryptoKey)
            {
                cryptoKey = this.currentCryptoKey;
            }
            vector.x = OFloat.Decrypt(this.hiddenValue.x, cryptoKey);
            vector.y = OFloat.Decrypt(this.hiddenValue.y, cryptoKey);
            if ((OCheatDetector.isRunning && !this.fakeValue.Equals(initialFakeValue)) && !this.CompareVectorsWithTolerance(vector, this.fakeValue))
            {
                OCheatDetector.Instance.OnCheatingDetected();
            }
            return vector;
        }

        private bool CompareVectorsWithTolerance(Vector2 vector1, Vector2 vector2)
        {
            float num = OCheatDetector.Instance.vector2Epsilon;
            return ((Math.Abs(vector1.x - vector2.x) < num) && (Math.Abs(vector1.y - vector2.y) < num));
        }

        private float InternalDecryptField(int encrypted)
        {
            int cryptoKey = OVector2.cryptoKey;
            if (this.currentCryptoKey != OVector2.cryptoKey)
            {
                cryptoKey = this.currentCryptoKey;
            }
            return OFloat.Decrypt(encrypted, cryptoKey);
        }

        private int InternalEncryptField(float encrypted)
        {
            return OFloat.Encrypt(encrypted, cryptoKey);
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

        [Obsolete("This method may lead to the cheating detection false positives. Please use Encrypt() instead.", false)]
        public static Vector2 EncryptDeprecated(Vector2 value)
        {
            return EncryptDeprecated(value, 0);
        }

        [Obsolete("This method may lead to the cheating detection false positives. Please use Encrypt() instead.", false)]
        public static Vector2 EncryptDeprecated(Vector2 value, int key)
        {
            if (key == 0)
            {
                key = cryptoKey;
            }
            value.x = OFloat.Encrypt(value.x, key);
            value.y = OFloat.Encrypt(value.y, key);
            return value;
        }

        [Obsolete("This method may lead to the cheating detection false positives. Please use Decrypt() instead.", false)]
        public static Vector2 DecryptDeprecated(Vector2 value)
        {
            return DecryptDeprecated(value, 0);
        }

        [Obsolete("This method may lead to the cheating detection false positives. Please use Decrypt() instead.", false)]
        public static Vector2 DecryptDeprecated(Vector2 value, int key)
        {
            if (key == 0)
            {
                key = cryptoKey;
            }
            value.x = OFloat.Decrypt((int) value.x, key);
            return value;
        }

        [Obsolete("This method may lead to the cheating detection false positives. Please use GetEncrypted() instead.", false)]
        public Vector2 GetEncryptedDeprecated()
        {
            this.ApplyNewCryptoKey();
            return (Vector2) this.hiddenValue;
        }

        [Obsolete("This method may lead to the cheating detection false positives. Please use SetEncrypted() instead.", false)]
        public void SetEncryptedDeprecated(Vector2 encrypted)
        {
            this.hiddenValue = (RawEncryptedVector2)encrypted;
            if (OCheatDetector.isRunning)
            {
                this.fakeValue = this.InternalDecrypt();
            }
        }

        public static implicit operator OVector2(Vector2 value)
        {
            OVector2 vector = new OVector2(Encrypt(value));
            if (OCheatDetector.isRunning)
            {
                vector.fakeValue = value;
            }
            return vector;
        }

        public static implicit operator Vector2(OVector2 value)
        {
            return value.InternalDecrypt();
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct RawEncryptedVector2
        {
            internal int x;
            internal int y;
            private RawEncryptedVector2(float x, float y)
            {
                this.x = (int)x;
                this.y = (int)y;
            }

            public static explicit operator Vector2(OVector2.RawEncryptedVector2 value)
            {
                return new Vector2((float) value.x, (float) value.y);
            }

            public static explicit operator OVector2.RawEncryptedVector2(Vector2 value)
            {
                return new OVector2.RawEncryptedVector2(value.x, value.y);
            }
        }
    }
}

