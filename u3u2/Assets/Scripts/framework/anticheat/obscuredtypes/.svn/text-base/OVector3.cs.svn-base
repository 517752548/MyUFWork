using System;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;

namespace anticheat
{
    public struct OVector3
    {
        private static int cryptoKey;
        private static readonly Vector3 initialFakeValue;
        private int currentCryptoKey;
        private RawEncryptedVector3 hiddenValue;
        private Vector3 fakeValue;
        private bool inited;
        private OVector3(RawEncryptedVector3 encrypted)
        {
            this.currentCryptoKey = cryptoKey;
            this.hiddenValue = encrypted;
            this.fakeValue = initialFakeValue;
            this.inited = true;
        }

        static OVector3()
        {
            cryptoKey = 0x1d58f;
            initialFakeValue = Vector3.zero;
        }

        public float x
        {
            get
            {
                float num = this.InternalDecryptField(this.hiddenValue.x);
                if ((OCheatDetector.isRunning && !this.fakeValue.Equals(initialFakeValue)) && (Math.Abs(num - this.fakeValue.x) > OCheatDetector.Instance.vector3Epsilon))
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
                if ((OCheatDetector.isRunning && !this.fakeValue.Equals(initialFakeValue)) && (Math.Abs(num - this.fakeValue.y) > OCheatDetector.Instance.vector3Epsilon))
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
        public float z
        {
            get
            {
                float num = this.InternalDecryptField(this.hiddenValue.z);
                if ((OCheatDetector.isRunning && !this.fakeValue.Equals(initialFakeValue)) && (Math.Abs(num - this.fakeValue.z) > OCheatDetector.Instance.vector3Epsilon))
                {
                    OCheatDetector.Instance.OnCheatingDetected();
                }
                return num;
            }
            set
            {
                this.hiddenValue.z = this.InternalEncryptField(value);
                if (OCheatDetector.isRunning)
                {
                    this.fakeValue.z = value;
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

                    case 2:
                        return this.z;
                }
                throw new IndexOutOfRangeException("Invalid ObscuredVector3 index!");
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

                    case 2:
                        this.z = value;
                        break;

                    default:
                        throw new IndexOutOfRangeException("Invalid ObscuredVector3 index!");
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

        public static RawEncryptedVector3 Encrypt(Vector3 value)
        {
            return Encrypt(value, 0);
        }

        public static RawEncryptedVector3 Encrypt(Vector3 value, int key)
        {
            RawEncryptedVector3 vector;
            if (key == 0)
            {
                key = cryptoKey;
            }
            vector.x = OFloat.Encrypt(value.x, key);
            vector.y = OFloat.Encrypt(value.y, key);
            vector.z = OFloat.Encrypt(value.z, key);
            return vector;
        }

        public static Vector3 Decrypt(RawEncryptedVector3 value)
        {
            return Decrypt(value, 0);
        }

        public static Vector3 Decrypt(RawEncryptedVector3 value, int key)
        {
            Vector3 vector;
            if (key == 0)
            {
                key = cryptoKey;
            }
            vector.x = OFloat.Decrypt(value.x, key);
            vector.y = OFloat.Decrypt(value.y, key);
            vector.z = OFloat.Decrypt(value.z, key);
            return vector;
        }

        public RawEncryptedVector3 GetEncrypted()
        {
            this.ApplyNewCryptoKey();
            return this.hiddenValue;
        }

        public void SetEncrypted(RawEncryptedVector3 encrypted)
        {
            this.hiddenValue = encrypted;
            if (OCheatDetector.isRunning)
            {
                this.fakeValue = this.InternalDecrypt();
            }
        }

        private Vector3 InternalDecrypt()
        {
            Vector3 vector;
            if (!this.inited)
            {
                this.currentCryptoKey = OVector3.cryptoKey;
                this.hiddenValue = Encrypt(initialFakeValue, OVector3.cryptoKey);
                this.fakeValue = initialFakeValue;
                this.inited = true;
            }
            int cryptoKey = OVector3.cryptoKey;
            if (this.currentCryptoKey != OVector3.cryptoKey)
            {
                cryptoKey = this.currentCryptoKey;
            }
            vector.x = OFloat.Decrypt(this.hiddenValue.x, cryptoKey);
            vector.y = OFloat.Decrypt(this.hiddenValue.y, cryptoKey);
            vector.z = OFloat.Decrypt(this.hiddenValue.z, cryptoKey);
            if ((OCheatDetector.isRunning && !this.fakeValue.Equals(Vector3.zero)) && !this.CompareVectorsWithTolerance(vector, this.fakeValue))
            {
                OCheatDetector.Instance.OnCheatingDetected();
            }
            return vector;
        }

        private bool CompareVectorsWithTolerance(Vector3 vector1, Vector3 vector2)
        {
            float num = OCheatDetector.Instance.vector3Epsilon;
            return (((Math.Abs(vector1.x - vector2.x) < num) && (Math.Abs(vector1.y - vector2.y) < num)) && (Math.Abs(vector1.z - vector2.z) < num));
        }

        private float InternalDecryptField(int encrypted)
        {
            int cryptoKey = OVector3.cryptoKey;
            if (this.currentCryptoKey != OVector3.cryptoKey)
            {
                cryptoKey = this.currentCryptoKey;
            }
            return OFloat.Decrypt(encrypted, cryptoKey);
        }

        private int InternalEncryptField(float encrypted)
        {
            return OFloat.Encrypt(encrypted, cryptoKey);
        }

        public override bool Equals(object other)
        {
            return this.InternalDecrypt().Equals(other);
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
        public static Vector3 EncryptDeprecated(Vector3 value)
        {
            return EncryptDeprecated(value, 0);
        }

        [Obsolete("This method may lead to the cheating detection false positives. Please use Encrypt() instead.", false)]
        public static Vector3 EncryptDeprecated(Vector3 value, int key)
        {
            if (key == 0)
            {
                key = cryptoKey;
            }
            value.x = OFloat.Encrypt(value.x, key);
            value.y = OFloat.Encrypt(value.y, key);
            value.z = OFloat.Encrypt(value.z, key);
            return value;
        }

        [Obsolete("This method may lead to the cheating detection false positives. Please use Decrypt() instead.", false)]
        public static Vector3 DecryptDeprecated(Vector3 value)
        {
            return DecryptDeprecated(value, 0);
        }

        [Obsolete("This method may lead to the cheating detection false positives. Please use Decrypt() instead.", false)]
        public static Vector3 DecryptDeprecated(Vector3 value, int key)
        {
            if (key == 0)
            {
                key = cryptoKey;
            }
            value.x = OFloat.Decrypt((int) value.x, key);
            value.y = OFloat.Decrypt((int) value.y, key);
            value.z = OFloat.Decrypt((int) value.z, key);
            return value;
        }

        [Obsolete("This method may lead to the cheating detection false positives. Please use GetEncrypted() instead.", false)]
        public Vector3 GetEncryptedDeprecated()
        {
            this.ApplyNewCryptoKey();
            return (Vector3) this.hiddenValue;
        }

        [Obsolete("This method may lead to the cheating detection false positives. Please use SetEncrypted() instead.", false)]
        public void SetEncryptedDeprecated(Vector3 encrypted)
        {
            this.hiddenValue = (RawEncryptedVector3)encrypted;
            if (OCheatDetector.isRunning)
            {
                this.fakeValue = this.InternalDecrypt();
            }
        }

        public static implicit operator OVector3(Vector3 value)
        {
            OVector3 vector = new OVector3(Encrypt(value, cryptoKey));
            if (OCheatDetector.isRunning)
            {
                vector.fakeValue = value;
            }
            return vector;
        }

        public static implicit operator Vector3(OVector3 value)
        {
            return value.InternalDecrypt();
        }

        public static OVector3 operator +(OVector3 a, OVector3 b)
        {
            return (a.InternalDecrypt() + b.InternalDecrypt());
        }

        public static OVector3 operator +(Vector3 a, OVector3 b)
        {
            return (a + b.InternalDecrypt());
        }

        public static OVector3 operator +(OVector3 a, Vector3 b)
        {
            return (a.InternalDecrypt() + b);
        }

        public static OVector3 operator -(OVector3 a, OVector3 b)
        {
            return (a.InternalDecrypt() - b.InternalDecrypt());
        }

        public static OVector3 operator -(Vector3 a, OVector3 b)
        {
            return (a - b.InternalDecrypt());
        }

        public static OVector3 operator -(OVector3 a, Vector3 b)
        {
            return (a.InternalDecrypt() - b);
        }

        public static OVector3 operator -(OVector3 a)
        {
            return -a.InternalDecrypt();
        }

        public static OVector3 operator *(OVector3 a, float d)
        {
            return (a.InternalDecrypt() * d);
        }

        public static OVector3 operator *(float d, OVector3 a)
        {
            return (d * a.InternalDecrypt());
        }

        public static OVector3 operator /(OVector3 a, float d)
        {
            return (a.InternalDecrypt() / d);
        }

        public static bool operator ==(OVector3 lhs, OVector3 rhs)
        {
            return (lhs.InternalDecrypt() == rhs.InternalDecrypt());
        }

        public static bool operator ==(Vector3 lhs, OVector3 rhs)
        {
            return (lhs == rhs.InternalDecrypt());
        }

        public static bool operator ==(OVector3 lhs, Vector3 rhs)
        {
            return (lhs.InternalDecrypt() == rhs);
        }

        public static bool operator !=(OVector3 lhs, OVector3 rhs)
        {
            return (lhs.InternalDecrypt() != rhs.InternalDecrypt());
        }

        public static bool operator !=(Vector3 lhs, OVector3 rhs)
        {
            return (lhs != rhs.InternalDecrypt());
        }

        public static bool operator !=(OVector3 lhs, Vector3 rhs)
        {
            return (lhs.InternalDecrypt() != rhs);
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct RawEncryptedVector3
        {
            internal int x;
            internal int y;
            internal int z;
            private RawEncryptedVector3(float x, float y, float z)
            {
                this.x = (int)x;
                this.y = (int)y;
                this.z = (int)z;
            }

            public static explicit operator Vector3(OVector3.RawEncryptedVector3 value)
            {
                return new Vector3((float) value.x, (float) value.y, (float) value.z);
            }

            public static explicit operator OVector3.RawEncryptedVector3(Vector3 value)
            {
                return new OVector3.RawEncryptedVector3(value.x, value.y, value.z);
            }
        }
    }
}

