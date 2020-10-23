using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace anticheat
{
    public struct OQuaternion
    {
        private static int cryptoKey;
        private static readonly Quaternion initialFakeValue;
        private int currentCryptoKey;
        private RawEncryptedQuaternion hiddenValue;
        public Quaternion fakeValue;
        private bool inited;
        private OQuaternion(RawEncryptedQuaternion value)
        {
            this.currentCryptoKey = cryptoKey;
            this.hiddenValue = value;
            this.fakeValue = initialFakeValue;
            this.inited = true;
        }

        static OQuaternion()
        {
            cryptoKey = 0x1d58d;
            initialFakeValue = Quaternion.identity;
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

        public static RawEncryptedQuaternion Encrypt(Quaternion value)
        {
            return Encrypt(value, 0);
        }

        public static RawEncryptedQuaternion Encrypt(Quaternion value, int key)
        {
            RawEncryptedQuaternion quaternion;
            if (key == 0)
            {
                key = cryptoKey;
            }
            quaternion.x = OFloat.Encrypt(value.x, key);
            quaternion.y = OFloat.Encrypt(value.y, key);
            quaternion.z = OFloat.Encrypt(value.z, key);
            quaternion.w = OFloat.Encrypt(value.w, key);
            return quaternion;
        }

        public static Quaternion Decrypt(RawEncryptedQuaternion value)
        {
            return Decrypt(value, 0);
        }

        public static Quaternion Decrypt(RawEncryptedQuaternion value, int key)
        {
            Quaternion quaternion;
            if (key == 0)
            {
                key = cryptoKey;
            }
            quaternion.x = OFloat.Decrypt(value.x, key);
            quaternion.y = OFloat.Decrypt(value.y, key);
            quaternion.z = OFloat.Decrypt(value.z, key);
            quaternion.w = OFloat.Decrypt(value.w, key);
            return quaternion;
        }

        public RawEncryptedQuaternion GetEncrypted()
        {
            this.ApplyNewCryptoKey();
            return this.hiddenValue;
        }

        public void SetEncrypted(RawEncryptedQuaternion encrypted)
        {
            this.hiddenValue = encrypted;
            if (OCheatDetector.isRunning)
            {
                this.fakeValue = this.InternalDecrypt();
            }
        }

        private Quaternion InternalDecrypt()
        {
            Quaternion quaternion;
            if (!this.inited)
            {
                this.currentCryptoKey = OQuaternion.cryptoKey;
                this.hiddenValue = Encrypt(initialFakeValue);
                this.fakeValue = initialFakeValue;
                this.inited = true;
            }
            int cryptoKey = OQuaternion.cryptoKey;
            if (this.currentCryptoKey != OQuaternion.cryptoKey)
            {
                cryptoKey = this.currentCryptoKey;
            }
            quaternion.x = OFloat.Decrypt(this.hiddenValue.x, cryptoKey);
            quaternion.y = OFloat.Decrypt(this.hiddenValue.y, cryptoKey);
            quaternion.z = OFloat.Decrypt(this.hiddenValue.z, cryptoKey);
            quaternion.w = OFloat.Decrypt(this.hiddenValue.w, cryptoKey);
            if ((OCheatDetector.isRunning && !this.fakeValue.Equals(initialFakeValue)) && !this.CompareQuaternionsWithTolerance(quaternion, this.fakeValue))
            {
                OCheatDetector.Instance.OnCheatingDetected();
            }
            return quaternion;
        }

        private bool CompareQuaternionsWithTolerance(Quaternion q1, Quaternion q2)
        {
            float quaternionEpsilon = OCheatDetector.Instance.quaternionEpsilon;
            return ((((Math.Abs(q1.x - q2.x) < quaternionEpsilon) && (Math.Abs(q1.y - q2.y) < quaternionEpsilon)) && (Math.Abs(q1.z - q2.z) < quaternionEpsilon)) && (Math.Abs(q1.w - q2.w) < quaternionEpsilon));
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
        public static Quaternion EncryptDeprecated(Quaternion value)
        {
            return EncryptDeprecated(value, 0);
        }

        [Obsolete("This method may lead to the cheating detection false positives. Please use Encrypt() instead.", false)]
        public static Quaternion EncryptDeprecated(Quaternion value, int key)
        {
            if (key == 0)
            {
                key = cryptoKey;
            }
            value.x = OFloat.Encrypt(value.x, key);
            value.y = OFloat.Encrypt(value.y, key);
            value.z = OFloat.Encrypt(value.z, key);
            value.w = OFloat.Encrypt(value.w, key);
            return value;
        }

        [Obsolete("This method may lead to the cheating detection false positives. Please use Decrypt() instead.", false)]
        public static Quaternion DecryptDeprecated(Quaternion value)
        {
            return DecryptDeprecated(value, 0);
        }

        [Obsolete("This method may lead to the cheating detection false positives. Please use Decrypt() instead.", false)]
        public static Quaternion DecryptDeprecated(Quaternion value, int key)
        {
            if (key == 0)
            {
                key = cryptoKey;
            }
            value.x = OFloat.Decrypt((int) value.x, key);
            value.y = OFloat.Decrypt((int) value.y, key);
            value.z = OFloat.Decrypt((int) value.z, key);
            value.w = OFloat.Decrypt((int) value.w, key);
            return value;
        }

        [Obsolete("This method may lead to the cheating detection false positives. Please use GetEncrypted() instead.", false)]
        public Quaternion GetEncryptedDeprecated()
        {
            this.ApplyNewCryptoKey();
            return (Quaternion) this.hiddenValue;
        }

        [Obsolete("This method may lead to the cheating detection false positives. Please use SetEncrypted() instead.", false)]
        public void SetEncryptedDeprecated(Quaternion encrypted)
        {
            this.hiddenValue = (RawEncryptedQuaternion)encrypted;
            if (OCheatDetector.isRunning)
            {
                this.fakeValue = this.InternalDecrypt();
            }
        }

        public static implicit operator OQuaternion(Quaternion value)
        {
            OQuaternion quaternion = new OQuaternion(Encrypt(value));
            if (OCheatDetector.isRunning)
            {
                quaternion.fakeValue = value;
            }
            return quaternion;
        }

        public static implicit operator Quaternion(OQuaternion value)
        {
            return value.InternalDecrypt();
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct RawEncryptedQuaternion
        {
            internal int x;
            internal int y;
            internal int z;
            internal int w;
            private RawEncryptedQuaternion(float x, float y, float z, float w)
            {
                this.x = (int)x;
                this.y = (int)y;
                this.z = (int)z;
                this.w = (int)w;
            }

            public static explicit operator Quaternion(OQuaternion.RawEncryptedQuaternion value)
            {
                return new Quaternion((float) value.x, (float) value.y, (float) value.z, (float) value.w);
            }

            public static explicit operator OQuaternion.RawEncryptedQuaternion(Quaternion value)
            {
                return new OQuaternion.RawEncryptedQuaternion(value.x, value.y, value.z, value.w);
            }
        }
    }
}

