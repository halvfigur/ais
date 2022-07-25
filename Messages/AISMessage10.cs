namespace ais.Messages
{
    public sealed class AISMessage10 : AISMessage
    {
        // === Type 10: UTC/Date Inquiry
        //|==============================================================================
        //|Field   |Len |Description        |Member     |T|Encoding
        //|0-5     | 6  |Message Type       |type       |u|Constant: 10
        //|6-7     | 2  |Repeat Indicator   |repeat     |u|As in Common Navigation Block
        //|8-37    |30  |Source MMSI        |mmsi       |u|9 decimal digits
        //|38-39   | 2  |Spare              |           |x|Not used
        //|40-69   |30  |Destination MMSI   |dest_mmsi  |u|9 decimal digits
        //|70-71   | 2  |Spare              |           |x|Not used
        //|==============================================================================

        public int RepeatIndicator { get; private set; }
        public int SourceMMSI      { get; private set; }
        public int Spare1          { get; private set; }
        public int DestinationMMSI { get; private set; }
        public int Spare2          { get; private set; }

        public AISMessage10(AISSentenceParser SentenceParser) :
            base("UTC and Date Inquiry", SentenceParser, AISMessageType.Message10)
        {
            RepeatIndicator = (int)SentenceParser.GetBits(2);
            SourceMMSI      = (int)SentenceParser.GetBits(30);
            Spare1          = (int)SentenceParser.GetBits(2);
            DestinationMMSI = (int)SentenceParser.GetBits(30);
            Spare2          = (int)SentenceParser.GetBits(2);
        }
    }
}
