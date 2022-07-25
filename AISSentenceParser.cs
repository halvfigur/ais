using System;
using System.Text;

namespace ais
{
    [Serializable]
    public class BitStreamExhaustedException : Exception
    {
        public BitStreamExhaustedException() { }
        public BitStreamExhaustedException(string message) : base(message) { }
        public BitStreamExhaustedException(string message, Exception inner) : base(message, inner) { }
        protected BitStreamExhaustedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public class ToManyBitsException : Exception
    {
        public ToManyBitsException() { }
        public ToManyBitsException(string message) : base(message) { }
        public ToManyBitsException(string message, Exception inner) : base(message, inner) { }
        protected ToManyBitsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public class IllegalCharacterException : Exception
    {
        public IllegalCharacterException() { }
        public IllegalCharacterException(string message) : base(message) { }
        public IllegalCharacterException(string message, Exception inner) : base(message, inner) { }
        protected IllegalCharacterException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    sealed public class AISSentenceParser
    {
        public uint TotalNumberOfBits { get; private set; }
        public uint BitsRead { get; private set; }
        public uint BitsLeft
        {
            get
            {
                return TotalNumberOfBits - BitsRead;
            }

            private set {}
        }

        private byte[] bytes;
        private int padLength;

        private int offset = 0;  //<! How far into the bytes array are we        
        private int remain = 6; //<! How many bits remain in the current byte

        private static readonly byte[] bitMask = { 0x00, 0x01, 0x03, 0x07, 0x0f, 0x1f, 0x3f };

        public AISSentenceParser(string input, int padLength)
        {
            bytes = StringToByteArray(input, padLength);
            this.padLength = padLength;

            TotalNumberOfBits = (uint)(bytes.Length * 6 - padLength);
            BitsRead = 0;
        }

        internal byte[] StringToByteArray(string input, int padLength)
        {
            // Convert the input string to a byte array.
            byte[] array = Encoding.ASCII.GetBytes(input);

            for (int i = 0; i < array.Length; i++)
            {
                // Undo AIVDM/AIVDO payload armoring.
                array[i] = ConvertFromPayloadArmoring(array[i]);
            }

            int lastIndex = array.Length - 1;

            // Apply zero padding.
            array[lastIndex] &= (byte)(~bitMask[padLength]);

            return array;
        }

        public byte ConvertFromPayloadArmoring(byte bits)
        {
            // Check for illegal characters
            if (bits < 0x30 || bits > 0x77 || (bits > 0x58 && bits < 0x60))
            {
                throw new IllegalCharacterException(
                    string.Format("Illegal character: 0x{0:x} in input data", bits));
            }

            // To recover the six bits, subtract 48 from the ASCII character.
            bits -= 0x30;

            // If the result is greater than 40 subtract 8.
            if (bits > 0x28)
            {
                bits -= 0x8;
            }

            return (byte)bits;
        }

        public ulong GetBits(int bits)
        {
            if (bits > sizeof(ulong) * 8)
            {
                throw new ToManyBitsException(
                    string.Format("At most {0} bits can be fetched at a time",
                    sizeof(ulong) * 8));
            }

            BitsRead += (uint)bits;

            ulong result = 0;

            while (bits > 0 && offset < bytes.Length)
            {
                // Check that the end of the stream has not been reached.
                if (bits > 0 && offset == bytes.Length - 1 && remain == 0)
                {
                    throw new BitStreamExhaustedException(
                        "The end of the bit stream ha been reached");
                }

                // Are there enough bits left in the current byte to satisfy the request?
                if (bits < remain)
                {
                    // Shift up the result by the required amount.
                    result = result << bits;

                    // Calculate the mask of remaining bits.
                    ulong mask = (ulong)(bytes[offset] >> (remain - bits));

                    // Mask in the remaining bits.
                    result |= mask;
                    
                    // Update the number of remaining bits.
                    remain -= bits;

                    // Mask out the bits that remain.
                    bytes[offset] &= bitMask[remain];

                    // The request has been processed, no more bits left.
                    bits = 0;
                }
                // More bits are required than remain in the current byte.
                else
                {
                    // Mask in the next byte
                    result = result << remain | bytes[offset];

                    // Update the bit count.
                    bits -= remain;

                    // Increase the offset since a whole byte has been expended.
                    offset += 1;

                    // Reset the remainder.
                    remain = 6;                   
                }
            }

            return result;
        }
    }
}
