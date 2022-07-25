namespace ais.Messages
{
    public sealed class AISMessage6 : AISMessage
    {
        // |=== Type 6: Binary Addressed Message
        // |==============================================================================
        // |Field   |Len |Description          |Member    |T|Units
        // |0-5     |  6 |Message Type         |type      |u|Constant: 6
        // |6-7     |  2 |Repeat Indicator     |repeat    |u|As in Common Navigation Block
        // |8-37    | 30 |Source MMSI          |mmsi      |u|9 decimal digits
        // |38-39   |  2 |Sequence Number      |seqno     |u|Unsigned integer 0-3
        // |40-69   | 30 |Destination MMSI     |dest_mmsi |u|9 decimal digits
        // |70      |  1 |Retransmit flag      |retransmit|u|0 = no retransmit (default)
        //                                                   1 = retransmitted
        // |71      |  1 |Spare                |          |x|Not used
        // |72-81   | 10 |Designated Area Code |dac       |u|Unsigned integer
        // |82-87   |  6 |Functional ID        |fid       |u|Unsigned integer
        // |88      |920 |Data                 |data      |d|Binary data
        //                                                   May be shorter than 920 bits.
        // |==============================================================================
        
        public int    RepeatIndicator    { get; private set; }
        public int    SourceMMSI         { get; private set; }    
        public int    SequenceNumber     { get; private set; }
        public int    DestinationMMSI    { get; private set; }
        public bool   Retransmit         { get; private set; }
        public bool   Spare              { get; private set; }
        public int    DesignatedAreaCode { get; private set; }
        public int    FunctionalID       { get; private set; }
        public byte[] Data               { get; private set; } 

        public AISMessage6(AISSentenceParser SentenceParser) :
            base("Binary Addressed Message", SentenceParser, AISMessageType.Message6)
        {
            int    RepeatIndicator    = (int)SentenceParser.GetBits(2);
            int    SourceMMSI         = (int)SentenceParser.GetBits(30);
            int    SequenceNumber     = (int)SentenceParser.GetBits(2);
            int    DestinationMMSI    = (int)SentenceParser.GetBits(30);
            bool   Retransmit         =      SentenceParser.GetBits(1) != 0;
            bool   Spare              =      SentenceParser.GetBits(1) != 0; 
            int    DesignatedAreaCode = (int)SentenceParser.GetBits(10);
            int    FunctionalID       = (int)SentenceParser.GetBits(6);
            byte[] SubareaPayload     = GetDataPayload();
        }                                    
    }
}
