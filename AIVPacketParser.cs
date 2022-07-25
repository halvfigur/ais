using System;
using System.Globalization;
using System.Text;
using ais.Messages;

namespace ais
{
    [Serializable]
    public class InvalidAIVPacketException : Exception
    {
        public InvalidAIVPacketException() { }
        public InvalidAIVPacketException(string message) : base(message) { }
        public InvalidAIVPacketException(string message, Exception inner) : base(message, inner) { }
        protected InvalidAIVPacketException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }


    public class AIVPacketParser
    {
        private int fragmentCount;
        private int fragmentNumber;
        private int sequenceNumber;
        private char radioChannel;
        private StringBuilder sentenceBuilder;
        private int padLength;
        
        public AIVPacketParser()
        {
            Reset();
        }

        private void Reset()
        {
            fragmentCount = -1;
            fragmentNumber = -1;
            sequenceNumber = -1;
            sentenceBuilder = new StringBuilder();
        }

        public AISMessage AddFragment(string fragment)
        {
            // Extract the checksum from the packet, calculate the checksum
            // and compare the two.
            if (!VerifyChecksum(fragment))
            {
                return null;
            }

            string[] fields = fragment.Split(new char[] { ',' }, 7, StringSplitOptions.None);

            // The packet should have seven fields.
            if (fields.Length != 7)
            {
                return null;
            }

            int fragCount;

            if (!int.TryParse(fields[1], out fragCount))
            {
                return null;
            }

            // Sanity check, the fragment count cannot change.
            if (fragmentCount != -1 && fragCount != fragmentCount)
            {
                return null;
            }
            fragmentCount = fragCount;

            int fragNumber;

            if (!int.TryParse(fields[2], out fragNumber))
            {
                return null;
            }

            // Sanity check, the next fragment number should equal the last plus 1.
            if (fragmentNumber != -1 && fragNumber != fragmentNumber + 1)
            {
                return null;
            }

            fragmentNumber = fragNumber;

            if (fields[3] != string.Empty)
            {
                if (!int.TryParse(fields[3], out sequenceNumber))
                {
                    return null;
                }
            }
            else
            {
                // Packet contained no sequence number.
                sequenceNumber = -1;
            }

            radioChannel = fields[4][0];

            sentenceBuilder.Append(fields[5]);

            if (fragmentNumber == fragmentCount)
            {
                if (GetZeroPadding(fields[6], out padLength))
                {
                    AISMessage message = AISMessageFactory.CreateMessage(sentenceBuilder.ToString(), padLength);

                    if (message != null) {
                        Reset();
                    }

                    return message;
                }
            }

            return null;            
        }

        private bool VerifyChecksum(string input)
        {
            int delimPos = input.LastIndexOf('*');

            if (delimPos == -1 || delimPos == input.Length - 1)
            {
                // Could not find the '*' delimiter or the delimiter
                // was found at the very end of the input, leaving
                // no room for a checksum.
                return false;
            }

            string checksumStr = input.Substring(delimPos + 1);
            int refChecksum = int.Parse(checksumStr, NumberStyles.HexNumber);

            int checksum = 0;

            // The checksum is calculated by XOR-ing all characters between
            // the initial '!' and the checksum delimiter '*'.
            for (int i = 1; i < delimPos; i++)
            {
                checksum ^= (int)input[i];
            }

            return refChecksum == checksum;
        }
        
        private bool GetZeroPadding(string input, out int padLength)
        {
            string padLengthStr = input.Substring(0, 1);

            if (!int.TryParse(padLengthStr, out padLength)) {
                return false;
            }

            return padLength >= 0 && padLength <= 5;
        }
    }
}
