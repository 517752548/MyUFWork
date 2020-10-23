using System;
using System.Runtime.InteropServices;

namespace anticheat
{
    public struct ODecimal : IEquatable<ODecimal>
    {
        private static long cryptoKey;
        private long currentCryptoKey;
        private byte[] hiddenValue;
        private decimal fakeValue;
        private bool inited;
        private ODecimal(byte[] value)
        {
            this.currentCryptoKey = cryptoKey;
            this.hiddenValue = value;
            this.fakeValue = 0M;
            this.inited = true;
        }

        static ODecimal()
        {
            cryptoKey = 0x33138L;
        }

        public static void SetNewCryptoKey(long newKey)
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

        public static decimal Encrypt(decimal value)
        {
            return Encrypt(value, cryptoKey);
        }

        public static decimal Encrypt(decimal value, long key)
        {
            DecimalLongBytesUnion union;
            union = new DecimalLongBytesUnion {
                d = value,
                //l1 = union.l1 ^ key,
                //l2 = union.l2 ^ key
            };
            union.l1 = union.l1 ^ key;
            union.l2 = union.l2 ^ key;
            return union.d;
        }

        private static byte[] InternalEncrypt(decimal value)
        {
            return InternalEncrypt(value, 0L);
        }

        private static byte[] InternalEncrypt(decimal value, long key)
        {
            DecimalLongBytesUnion union;
            long cryptoKey = key;
            if (cryptoKey == 0)
            {
                cryptoKey = ODecimal.cryptoKey;
            }
            union = new DecimalLongBytesUnion {
                d = value,
                //l1 = union.l1 ^ key,
                //l2 = union.l2 ^ key
            };
            union.l1 = union.l1 ^ key;
            union.l2 = union.l2 ^ key;
            return new byte[] { union.b1, union.b2, union.b3, union.b4, union.b5, union.b6, union.b7, union.b8, union.b9, union.b10, union.b11, union.b12, union.b13, union.b14, union.b15, union.b16 };
        }

        public static decimal Decrypt(decimal value)
        {
            return Decrypt(value, cryptoKey);
        }

        public static decimal Decrypt(decimal value, long key)
        {
            DecimalLongBytesUnion union;
            union = new DecimalLongBytesUnion {
                d = value,
                //l1 = union.l1 ^ key,
                //l2 = union.l2 ^ key
            };
            union.l1 = union.l1 ^ key;
            union.l2 = union.l2 ^ key;
            return union.d;
        }

        public decimal GetEncrypted()
        {
            this.ApplyNewCryptoKey();
            DecimalLongBytesUnion union = new DecimalLongBytesUnion {
                b1 = this.hiddenValue[0],
                b2 = this.hiddenValue[1],
                b3 = this.hiddenValue[2],
                b4 = this.hiddenValue[3],
                b5 = this.hiddenValue[4],
                b6 = this.hiddenValue[5],
                b7 = this.hiddenValue[6],
                b8 = this.hiddenValue[7],
                b9 = this.hiddenValue[8],
                b10 = this.hiddenValue[9],
                b11 = this.hiddenValue[10],
                b12 = this.hiddenValue[11],
                b13 = this.hiddenValue[12],
                b14 = this.hiddenValue[13],
                b15 = this.hiddenValue[14],
                b16 = this.hiddenValue[15]
            };
            return union.d;
        }

        public void SetEncrypted(decimal encrypted)
        {
            DecimalLongBytesUnion union = new DecimalLongBytesUnion {
                d = encrypted
            };
            this.hiddenValue = new byte[] { union.b1, union.b2, union.b3, union.b4, union.b5, union.b6, union.b7, union.b8, union.b9, union.b10, union.b11, union.b12, union.b13, union.b14, union.b15, union.b16 };
            if (OCheatDetector.isRunning)
            {
                this.fakeValue = this.InternalDecrypt();
            }
        }

        private decimal InternalDecrypt()
        {
            DecimalLongBytesUnion union;
            if (!this.inited)
            {
                this.currentCryptoKey = ODecimal.cryptoKey;
                this.hiddenValue = InternalEncrypt(0M);
                this.fakeValue = 0M;
                this.inited = true;
            }
            long cryptoKey = ODecimal.cryptoKey;
            if (this.currentCryptoKey != ODecimal.cryptoKey)
            {
                cryptoKey = this.currentCryptoKey;
            }
            union = new DecimalLongBytesUnion {
                b1 = this.hiddenValue[0],
                b2 = this.hiddenValue[1],
                b3 = this.hiddenValue[2],
                b4 = this.hiddenValue[3],
                b5 = this.hiddenValue[4],
                b6 = this.hiddenValue[5],
                b7 = this.hiddenValue[6],
                b8 = this.hiddenValue[7],
                b9 = this.hiddenValue[8],
                b10 = this.hiddenValue[9],
                b11 = this.hiddenValue[10],
                b12 = this.hiddenValue[11],
                b13 = this.hiddenValue[12],
                b14 = this.hiddenValue[13],
                b15 = this.hiddenValue[14],
                b16 = this.hiddenValue[15],
                //l1 = union.l1 ^ cryptoKey,
                //l2 = union.l2 ^ cryptoKey
            };
            union.l1 = union.l1 ^ cryptoKey;
            union.l2 = union.l2 ^ cryptoKey;
            decimal d = union.d;
            if ((OCheatDetector.isRunning && (this.fakeValue != 0M)) && (d != this.fakeValue))
            {
                OCheatDetector.Instance.OnCheatingDetected();
            }
            return d;
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

        public override bool Equals(object obj)
        {
            if (!(obj is ODecimal))
            {
                return false;
            }
            ODecimal num = (ODecimal)obj;
            return num.InternalDecrypt().Equals(this.InternalDecrypt());
        }

        public bool Equals(ODecimal obj)
        {
            return obj.InternalDecrypt().Equals(this.InternalDecrypt());
        }

        public override int GetHashCode()
        {
            return this.InternalDecrypt().GetHashCode();
        }

        public static implicit operator ODecimal(decimal value)
        {
            ODecimal num = new ODecimal(InternalEncrypt(value));
            if (OCheatDetector.isRunning)
            {
                num.fakeValue = value;
            }
            return num;
        }

        public static implicit operator decimal(ODecimal value)
        {
            return value.InternalDecrypt();
        }

        public static ODecimal operator ++(ODecimal input)
        {
            decimal num = input.InternalDecrypt() + 1M;
            input.hiddenValue = InternalEncrypt(num, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }

        public static ODecimal operator --(ODecimal input)
        {
            decimal num = input.InternalDecrypt() - 1M;
            input.hiddenValue = InternalEncrypt(num, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }
        [StructLayout(LayoutKind.Explicit)]
        private struct DecimalLongBytesUnion
        {
            [FieldOffset(0)]
            public byte b1;
            [FieldOffset(9)]
            public byte b10;
            [FieldOffset(10)]
            public byte b11;
            [FieldOffset(11)]
            public byte b12;
            [FieldOffset(12)]
            public byte b13;
            [FieldOffset(13)]
            public byte b14;
            [FieldOffset(14)]
            public byte b15;
            [FieldOffset(15)]
            public byte b16;
            [FieldOffset(1)]
            public byte b2;
            [FieldOffset(2)]
            public byte b3;
            [FieldOffset(3)]
            public byte b4;
            [FieldOffset(4)]
            public byte b5;
            [FieldOffset(5)]
            public byte b6;
            [FieldOffset(6)]
            public byte b7;
            [FieldOffset(7)]
            public byte b8;
            [FieldOffset(8)]
            public byte b9;
            [FieldOffset(0)]
            public decimal d;
            [FieldOffset(0)]
            public long l1;
            [FieldOffset(8)]
            public long l2;
        }
    }
}

