using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace anticheat
{
    public struct OFloat : IEquatable<OFloat>
    {
        private static int cryptoKey;
        private int currentCryptoKey;
        private byte[] hiddenValue;
        private float fakeValue;
        private bool inited;
        private OFloat(byte[] value)
        {
            this.currentCryptoKey = cryptoKey;
            this.hiddenValue = value;
            this.fakeValue = 0f;
            this.inited = true;
        }

        static OFloat()
        {
            cryptoKey = 0x385e7;
        }

        public static void SetNewCryptoKey(int newKey)
        {
            cryptoKey = newKey;
        }

        public void ApplyNewCryptoKey()
        {
            if (this.currentCryptoKey != cryptoKey)
            {
                this.hiddenValue = InternalEncrypt(this.InternalDecrypt(), cryptoKey);
                this.currentCryptoKey = cryptoKey;
            }
        }

        public static int Encrypt(float value)
        {
            return Encrypt(value, cryptoKey);
        }

        public static int Encrypt(float value, int key)
        {
            FloatIntBytesUnion union;
            union = new FloatIntBytesUnion {
                f = value
            };
            union.i = union.i ^ key;
            return union.i;
        }

        private static byte[] InternalEncrypt(float value)
        {
            return InternalEncrypt(value, 0);
        }

        private static byte[] InternalEncrypt(float value, int key)
        {
            FloatIntBytesUnion union;
            int cryptoKey = key;
            if (cryptoKey == 0)
            {
                cryptoKey = OFloat.cryptoKey;
            }
            union = new FloatIntBytesUnion {
                f = value
                //i = union.i ^ cryptoKey
            };
            union.i = union.i ^ cryptoKey;
            return new byte[] { union.b1, union.b2, union.b3, union.b4 };
        }

        public static float Decrypt(int value)
        {
            return Decrypt(value, cryptoKey);
        }

        public static float Decrypt(int value, int key)
        {
            FloatIntBytesUnion union = new FloatIntBytesUnion {
                i = value ^ key
            };
            return union.f;
        }

        public int GetEncrypted()
        {
            this.ApplyNewCryptoKey();
            FloatIntBytesUnion union = new FloatIntBytesUnion {
                b1 = this.hiddenValue[0],
                b2 = this.hiddenValue[1],
                b3 = this.hiddenValue[2],
                b4 = this.hiddenValue[3]
            };
            return union.i;
        }

        public void SetEncrypted(int encrypted)
        {
            FloatIntBytesUnion union = new FloatIntBytesUnion {
                i = encrypted
            };
            this.hiddenValue = new byte[] { union.b1, union.b2, union.b3, union.b4 };
            if (OCheatDetector.isRunning)
            {
                this.fakeValue = this.InternalDecrypt();
            }
        }

        private float InternalDecrypt()
        {
            FloatIntBytesUnion union;
            if (!this.inited)
            {
                this.currentCryptoKey = OFloat.cryptoKey;
                this.hiddenValue = InternalEncrypt(0f);
                this.fakeValue = 0f;
                this.inited = true;
            }
            int cryptoKey = OFloat.cryptoKey;
            if (this.currentCryptoKey != OFloat.cryptoKey)
            {
                cryptoKey = this.currentCryptoKey;
            }
            union = new FloatIntBytesUnion {
                b1 = this.hiddenValue[0],
                b2 = this.hiddenValue[1],
                b3 = this.hiddenValue[2],
                b4 = this.hiddenValue[3],
                //i = union.i ^ cryptoKey
            };
            union.i = union.i ^ cryptoKey;

            float f = union.f;
            if ((OCheatDetector.isRunning && (this.fakeValue != 0f)) && (Math.Abs(f - this.fakeValue) > OCheatDetector.Instance.floatEpsilon))
            {
                OCheatDetector.Instance.OnCheatingDetected();
            }
            return f;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is OFloat))
            {
                return false;
            }
            float num2 = ((OFloat)obj).InternalDecrypt();
            float num3 = this.InternalDecrypt();
            return ((num2 == num3) || (float.IsNaN(num2) && float.IsNaN(num3)));
        }

        public bool Equals(OFloat obj)
        {
            float num = obj.InternalDecrypt();
            float num2 = this.InternalDecrypt();
            return ((num == num2) || (float.IsNaN(num) && float.IsNaN(num2)));
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

        public static implicit operator OFloat(float value)
        {
            OFloat num = new OFloat(InternalEncrypt(value));
            if (OCheatDetector.isRunning)
            {
                num.fakeValue = value;
            }
            return num;
        }

        public static implicit operator float(OFloat value)
        {
            return value.InternalDecrypt();
        }

        public static OFloat operator ++(OFloat input)
        {
            float num = input.InternalDecrypt() + 1f;
            input.hiddenValue = InternalEncrypt(num, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }

        public static OFloat operator --(OFloat input)
        {
            float num = input.InternalDecrypt() - 1f;
            input.hiddenValue = InternalEncrypt(num, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }
        [StructLayout(LayoutKind.Explicit)]
        private struct FloatIntBytesUnion
        {
            [FieldOffset(0)]
            public byte b1;
            [FieldOffset(1)]
            public byte b2;
            [FieldOffset(2)]
            public byte b3;
            [FieldOffset(3)]
            public byte b4;
            [FieldOffset(0)]
            public float f;
            [FieldOffset(0)]
            public int i;
        }
    }
}

