using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace universal.entropic.compression.Domain.Service
{
    public class BinaryBitWriter : BinaryWriter
    {
        public byte BitPosition { get; private set; } = 0;
        private bool[] curByte = new bool[8];
        private System.Collections.BitArray ba;

        public BinaryBitWriter(Stream s) : base(s) { }

        public override void Flush()
        {
            flushBitBuffer();
            base.Flush();
        }

        public override void Write(byte[] buffer, int index, int count)
        {
            for (int i = index; i < index + count; i++)
                Write((byte)buffer[i]);
        }
        public override void Write(byte value)
        {
            ba = new BitArray(new byte[] { value });
            for (byte i = 0; i < 8; i++)
                Write(ba[i]);
        }
        public override void Write(bool value)
        {
            curByte[BitPosition] = value;
            BitPosition++;

            if (BitPosition == 8)
                flushBitBuffer();
        }
        public override void Write(char[] chars, int index, int count)
        {
            for (int i = index; i < index + count; i++)
                Write(chars[i]);
        }
        public override void Write(string value)
        {
            // write strings as normal for now, so flush the bits first
            flushBitBuffer();
            base.Write(value);
        }
        public override void Write(decimal value)
        {
            var ints = decimal.GetBits(value);
            for (int i = 0; i < ints.Length; i++)
                Write(ints[i]);
        }
        public override void Write(float value) => Write(BitConverter.GetBytes(value));
        public override void Write(ulong value) => Write(BitConverter.GetBytes(value));
        public override void Write(long value) => Write(BitConverter.GetBytes(value));
        public override void Write(uint value) => Write(BitConverter.GetBytes(value));
        public override void Write(int value) => Write(BitConverter.GetBytes(value));
        public override void Write(ushort value) => Write(BitConverter.GetBytes(value));
        public override void Write(short value) => Write(BitConverter.GetBytes(value));
        public override void Write(double value) => Write(BitConverter.GetBytes(value));
        public override void Write(char[] value) => Write(value, 0, value.Length);
        public override void Write(char value)
        {
            // write strings as normal for now, so flush the bits first
            flushBitBuffer();
            base.Write(value);
            //var b = BitConverter.GetBytes(value);
            //Write(b);
        }
        public override void Write(byte[] buffer) => Write(buffer, 0, buffer.Length);
        public override void Write(sbyte value) => Write((byte)value);

        void flushBitBuffer()
        {
            if (BitPosition == 0) // Nothing to flush
                return;

            base.Write(ConvertToByte(curByte));
            BitPosition = 0;
            curByte = new bool[8];
        }

        private static byte ConvertToByte(bool[] bools)
        {
            byte b = 0;

            byte bitIndex = 0;
            for (int i = 0; i < 8; i++)
            {
                if (bools[i])
                    b |= (byte)(((byte)1) << bitIndex);
                bitIndex++;
            }

            return b;
        }
    }
}
