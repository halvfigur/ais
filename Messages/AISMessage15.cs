namespace ais.Messages
{
    public sealed class AISMessage15 : AISMessage
    {
        // === Type 15: Interrogation
        //|==============================================================================
        //|Field   |Len |Description         |Member    |T|Units
        //|0-5     |  6 |Message Type        |type      |u|Constant: 15
        //|6-7     |  2 |Repeat Indicator    |repeat    |u|As in Common Navigation Block
        //|8-37    | 30 |Source MMSI         |mmsi      |u|9 decimal digits
        //|38-39   |  2 |Spare               |          |x|Not used
        //|40-69   | 30 |Interrogated MMSI   |mmsi1     |u|9 decimal digits
        //|70-75   |  6 |First message type  |type1_1   |u|Unsigned integer
        //|76-87   | 12 |First slot offset   |offset1_1 |u|Unsigned integer
        //|88-89   |  2 |Spare               |          |x|Not used
        //|90-95   |  6 |Second message type |type1_2   |u|Unsigned integer
        //|96-107  | 12 |Second slot offset  |offset1_2 |u|Unsigned integer
        //|108-109 |  2 |Spare               |          |x|Not used
        //|110-139 | 30 |Interrogated MMSI   |mmsi2     |u|9 decimal digits
        //|140-145 |  6 |First message type  |type2_1   |u|Unsigned integer
        //|146-157 | 12 |First slot offset   |offset2_1 |u|Unsigned integer
        //|158-159 |  2 |Spare               |          |x|Not used
        //|==============================================================================

        public int RepeatIndicator   { get; private set; }
        public int SourceMMSI        { get; private set; }
        public int Spare1            { get; private set; }
        public int InterrogatedMMSI1 { get; private set; }
        public int FirstMessageType1 { get; private set; }
        public int FirstSlotOffset1  { get; private set; }
        public int Spare2            { get; private set; }
        public int SecondMessageType { get; private set; }
        public int SecondSlotOffset  { get; private set; }
        public int Spare3            { get; private set; }
        public int InterrogatedMMSI2 { get; private set; }
        public int FirstMessageType2 { get; private set; }
        public int FirstSlotOffset2  { get; private set; }
        public int Spare4            { get; private set; }

        public AISMessage15(AISSentenceParser SentenceParser) :
            base("Interrogation", SentenceParser, AISMessageType.Message15)
        {
            RepeatIndicator   = (int)SentenceParser.GetBits(2);
            SourceMMSI        = (int)SentenceParser.GetBits(30);
            Spare1            = (int)SentenceParser.GetBits(2);
            InterrogatedMMSI1 = (int)SentenceParser.GetBits(30);
            FirstMessageType1 = (int)SentenceParser.GetBits(6);
            FirstSlotOffset1  = (int)SentenceParser.GetBits(12);
            Spare2            = (int)SentenceParser.GetBits(2);
            SecondMessageType = (int)SentenceParser.GetBits(6);
            SecondSlotOffset  = (int)SentenceParser.GetBits(12);
            Spare3            = (int)SentenceParser.GetBits(2);
            InterrogatedMMSI2 = (int)SentenceParser.GetBits(30);
            FirstMessageType2 = (int)SentenceParser.GetBits(6);
            FirstSlotOffset2  = (int)SentenceParser.GetBits(12);
            Spare4            = (int)SentenceParser.GetBits(2);
        }
    }
}
