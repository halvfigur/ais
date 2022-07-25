using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ais.Messages
{
    public enum AISMessageType
    {
        Message1,
        Message2,
        Message3,
        Message4,
        Message5,
        Message6,
        Message7,
        Message8,
        Message9,
        Message10,
        Message11,
        Message12,
        Message13,
        Message14,
        Message15,
        Message16,
        Message17,
        Message18,
        Message19,
        Message20,
        Message21,
        Message22,
        Message23,
        Message24,
        Message25,
        Message26,
        Message27
    }

    public abstract class AISMessage
    {        
        public AISMessageType Type        { get; private set; }
        public string         Description { get; private set; }

        protected AISSentenceParser SentenceParser;

        protected AISMessage(string Description,
            AISSentenceParser SentenceParser, AISMessageType Type) {
            this.Description = Description;
            this.SentenceParser = SentenceParser;
            this.Type = Type;
        }

        protected double ConvertLongitude(int longitude)
        {
            return longitude / 600000.0;
        }

        protected double ConvertLatitude(int latitude)
        {
            return latitude / 600000.0;
        }

        protected string GetString(int bits)
        {
            StringBuilder builder = new StringBuilder();

            // Nibbles 0-31 map to the characters "@" (ASCII 64) 
            // through "\_" (ASCII 95) respectively; nibbles 32-63 map to
            // characters " " (ASCII 32) though "?"  (ASCII 63)
            for (int i = 0; i < bits && i < SentenceParser.BitsLeft; i += 6)
            {
                byte nibble = (byte)SentenceParser.GetBits(6);

                if (nibble < 0x20)
                {
                    builder.Append((char)('@' + nibble));
                }
                else
                {
                    builder.Append((char)nibble);
                }
            }

            // Strip of everything following and including '@'
            string str = builder.ToString();
            int end = str.IndexOf('@');

            if (end > 0)
            {
                str = str.Substring(0, end);
            }

            // Strip trailing whitespace
            return str.Trim();
        }

        protected byte[] GetDataPayload()
        {
            uint bitsLeft = SentenceParser.BitsLeft;
            byte[] data = new byte[bitsLeft / 8 + (bitsLeft % 8 > 0 ? 1 : 0)];

            int i;
            for (i = 0; i < SentenceParser.BitsLeft; i += 8)
            {
                data[i] = (byte)SentenceParser.GetBits(8);
            }

            if (SentenceParser.BitsLeft > 0)
            {
                data[i] = (byte)SentenceParser.GetBits((int)SentenceParser.BitsLeft);
            }

            return data;
        }
    }
}
