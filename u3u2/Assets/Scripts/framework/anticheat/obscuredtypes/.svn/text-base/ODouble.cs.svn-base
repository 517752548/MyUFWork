using System;
using System.Runtime.InteropServices;

namespace anticheat
{
    public struct ODouble : IEquatable<ODouble>
    {
        private static long cryptoKey;
        private long currentCryptoKey;
        private byte[] hiddenValue;
        private double fakeValue;
        private bool inited;
        private ODouble(byte[] value)
        {
            this.currentCryptoKey = cryptoKey;
            this.hiddenValue = value;
            this.fakeValue = 0.0;
            this.inited = true;
        }

        static ODouble()
        {
            cryptoKey = 0x3382bL;
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

        public static long Encrypt(double value)
        {
            return Encrypt(value, cryptoKey);
        }

        public static long Encrypt(double value, long key)
        {
            DoubleLongBytesUnion union;
            union = new DoubleLongBytesUnion {
                d = value,
                //l = union.l ^ key
            };
            union.l = union.l ^ cryptoKey;
            return union.l;
        }

        private static byte[] InternalEncrypt(double value)
        {
            return InternalEncrypt(value, 0L);
        }

        private static byte[] InternalEncrypt(double value, long key)
        {
            DoubleLongBytesUnion union;
            long cryptoKey = key;
            if (cryptoKey == 0L)
            {
                cryptoKey = ODouble.cryptoKey;
            }
            union = new DoubleLongBytesUnion {
                d = value,
                //l = union.l ^ cryptoKey
            };
            union.l = union.l ^ cryptoKey;
            return new byte[] { union.b1, union.b2, union.b3, union.b4, union.b5, union.b6, union.b7, union.b8 };
        }

        public static double Decrypt(long value)
        {
            return Decrypt(value, cryptoKey);
        }

        public static double Decrypt(long value, long key)
        {
            DoubleLongBytesUnion union = new DoubleLongBytesUnion {
                l = value ^ key
            };
            return union.d;
        }

        public long GetEncrypted()
        {
            this.ApplyNewCryptoKey();
            DoubleLongBytesUnion union = new DoubleLongBytesUnion {
                b1 = this.hiddenValue[0],
                b2 = this.hiddenValue[1],
                b3 = this.hiddenValue[2],
                b4 = this.hiddenValue[3],
                b5 = this.hiddenValue[4],
                b6 = this.hiddenValue[5],
                b7 = this.hiddenValue[6],
                b8 = this.hiddenValue[7]
            };
            return union.l;
        }

        public void SetEncrypted(long encrypted)
        {
            DoubleLongBytesUnion union = new DoubleLongBytesUnion {
                l = encrypted
            };
            this.hiddenValue = new byte[] { union.b1, union.b2, union.b3, union.b4, union.b5, union.b6, union.b7, union.b8 };
            if (OCheatDetector.isRunning)
            {
                this.fakeValue = this.InternalDecrypt();
            }
        }

        private double InternalDecrypt()
        {
            DoubleLongBytesUnion union;
            if (!this.inited)
            {
                this.currentCryptoKey = ODouble.cryptoKey;
                this.hiddenValue = InternalEncrypt(0.0);
                this.fakeValue = 0.0;
                this.inited = true;
            }
            long cryptoKey = ODouble.cryptoKey;
            if (this.currentCryptoKey != ODouble.cryptoKey)
            {
                cryptoKey = this.currentCryptoKey;
            }
            union = new DoubleLongBytesUnion {
                b1 = this.hiddenValue[0],
                b2 = this.hiddenValue[1],
                b3 = this.hiddenValue[2],
                b4 = this.hiddenValue[3],
                b5 = this.hiddenValue[4],
                b6 = this.hiddenValue[5],
                b7 = this.hiddenValue[6],
                b8 = this.hiddenValue[7],
                //l = union.l ^ cryptoKey
            };
            union.l = union.l ^ cryptoKey;

            double d = union.d;
            if ((OCheatDetector.isRunning && (this.fakeValue != 0.0)) && (Math.Abs(d - this.fakeValue) > 1E-06))
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
            if (!(obj is ODouble))
            {
                return false;
            }
            double num2 = ((ODouble)obj).InternalDecrypt();
            double num3 = this.InternalDecrypt();
            return ((num2 == num3) || (double.IsNaN(num2) && double.IsNaN(num3)));
        }

        public bool Equals(ODouble obj)
        {
            double num = obj.InternalDecrypt();
            double num2 = this.InternalDecrypt();
            return ((num == num2) || (double.IsNaN(num) && double.IsNaN(num2)));
        }

        public override int GetHashCode()
        {
            return this.InternalDecrypt().GetHashCode();
        }

        public static implicit operator ODouble(double value)
        {
            ODouble num = new ODouble(InternalEncrypt(value));
            if (OCheatDetector.isRunning)
            {
                num.fakeValue = value;
            }
            return num;
        }

        public static implicit operator double(ODouble value)
        {
            return value.InternalDecrypt();
        }

        public static ODouble operator ++(ODouble input)
        {
            double num = input.InternalDecrypt() + 1.0;
            input.hiddenValue = InternalEncrypt(num, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }

        public static ODouble operator --(ODouble input)
        {
            double num = input.InternalDecrypt() - 1.0;
            input.hiddenValue = InternalEncrypt(num, input.currentCryptoKey);
            if (OCheatDetector.isRunning)
            {
                input.fakeValue = num;
            }
            return input;
        }
        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleLongBytesUnion
        {
            [FieldOffset(0)]
            public byte b1;
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
            [FieldOffset(0)]
            public double d;
            [FieldOffset(0)]
            public long l;
        }
    }
}

