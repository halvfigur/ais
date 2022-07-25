namespace ais.Messages
{
    public sealed class AISMessage12 : AISMessage
    {
        // === Type 12: Addressed Safety-Related Message
        //|==============================================================================
        //|Field   |Len |Description        |Member      |T|Units
        //|0-5     |  6 |Message Type       |type        |u|Constant: 12
        //|6-7     |  2 |Repeat Indicator   |repeat      |u|As in Common Navigation Block
        //|8-37    | 30 |Source MMSI        |mmsi        |u|9 decimal digits
        //|38-39   |  2 |Sequence Number    |seqno       |u|Unsigned integer 0-3
        //|40-69   | 30 |Destination MMSI   |dest_mmsi   |u|9 decimal digits
        //|70      |  1 |Retransmit flag    |retransmit  |b|0 = no retransmit (default),
        //                                                  1 = retransmitted
        //|71      |  1 |Spare              |            |x|Not used
        //|72      |936 |Text               |text        |t|1-156 chars of six-bit text.
        //                                                  May be shorter than 936 bits.
        //|==============================================================================

        public int    RepeatIndicator { get; private set; }
        public int    SourceMMSI      { get; private set; }
        public int    SequenceNumber  { get; private set; }
        public int    DestinationMMSI { get; private set; }
        public bool   RetransmitFlag  { get; private set; }
        public bool   Spare           { get; private set; }
        public string Text            { get; private set; }

        public AISMessage12(AISSentenceParser SentenceParser) :
            base("Addressed Safety Related Message", SentenceParser, AISMessageType.Message12)
        {
            RepeatIndicator = (int)SentenceParser.GetBits(2);
            SourceMMSI      = (int)SentenceParser.GetBits(30);
            SequenceNumber  = (int)SentenceParser.GetBits(2);
            DestinationMMSI = (int)SentenceParser.GetBits(30);
            RetransmitFlag  =      SentenceParser.GetBits(1) != 0;
            Spare           =      SentenceParser.GetBits(1) != 0;
            Text            =      GetString(936);
        }
    }
}
