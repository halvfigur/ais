namespace ais.Messages
{
    public sealed class AISMessage8 : AISMessage
    {
        // === Type 8: Binary Broadcast Message ===
        //|==============================================================================
        //|Field   |Len |Description          |Member    |T|Units
        //|0-5     |  6 |Message Type         |type      |u|Constant: 8
        //|6-7     |  2 |Repeat Indicator     |repeat    |u|As in Common Navigation Block
        //|8-37    | 30 |Source MMSI          |mmsi      |u|9 decimal digits
        //|38-39   |  2 |Spare                |          |x|Not used
        //|40-49   | 10 |Designated Area Code |dac       |u|Unsigned integer
        //|50-55   |  6 |Functional ID        |fid       |u|Unsigned integer
        //|56      |952 |Data                 |data      |d|Binary data,
        //                                                  May be shorter than 952 bits.
        //|==============================================================================
        public int    RepeatIndicator     { get; private set; }
        public int    SourceMMSI          { get; private set; }
        public int    Spare               { get; private set; }
        public int    DesignatedAreaCode  { get; private set; }
        public int    FunctionalID        { get; private set; }
        public byte[] Data                { get; private set; }

        public AISMessage8(AISSentenceParser SentenceParser) :
            base("Binary Broadcast Message", SentenceParser, AISMessageType.Message8)
        {
            RepeatIndicator    = (int)SentenceParser.GetBits(2);
            SourceMMSI         = (int)SentenceParser.GetBits(30);
            Spare              = (int)SentenceParser.GetBits(2);
            DesignatedAreaCode = (int)SentenceParser.GetBits(10);
            FunctionalID       = (int)SentenceParser.GetBits(6);
            Data               = GetDataPayload();
        }
    }
}
