namespace ais.Messages
{
    public sealed class AISMessage9 : AISMessage
    {
        //=== Type 9: Standard SAR Aircraft Position Report
        //|==============================================================================
        //|Field   |Len |Description        |Member     |T|Encoding
        //|0-5     | 6  |Message Type       |type       |u|Constant: 9
        //|6-7     | 2  |Repeat Indicator   |repeat     |u|As in Common Navigation Block
        //|8-37    |30  |MMSI               |mmsi       |u|9 decimal digits
        //|38-49   |12  |Altitude           |alt        |u|See below
        //|50-59   |10  |SOG                |speed      |u|See below
        //|60-60   | 1  |Position Accuracy  |accuracy   |u|See below
        //|61-88   |28  |Longitude          |lon        |I4|Minutes/10000 (as in CNB)
        //|89-115  |27  |Latitude           |lat        |I4|Minutes/10000 (as in CNB)
        //|116-127 |12  |Course Over Ground |course     |U1|True bearing, 0.1 degree units
        //|128-133 | 6  |Time Stamp         |second     |u|UTC second.
        //|134-141 | 8  |Regional reserved  |regional   |x|Reserved
        //|142-142 | 1  |DTE                |dte        |b|0=Data terminal ready,
        //                                                 1=Data terminal not ready (default)
        //|143-145 | 3  |Spare              |           |x|Not used
        //|146-146 | 1  |Assigned           |assigned   |b|Assigned-mode flag
        //|147-147 | 1  |RAIM flag          |raim       |b|As for common navigation block
        //|148-167 |19  |Radio status       |radio      |u|See <<IALA>> for details.
        //|==============================================================================

        public int  RepeatIndicator  { get; private set; }
        public int  MMSI             { get; private set; }
        public int  Altitude         { get; private set; }
        public int  SOG              { get; private set; }
        public int  PositionAccuracy { get; private set; }
        public int  Longitude        { get; private set; }
        public int  Latitude         { get; private set; }
        public int  CourseOverGround { get; private set; }
        public int  TimeStamp        { get; private set; }
        public int  Regionalreserved { get; private set; }
        public bool DTE              { get; private set; }
        public int  Spare            { get; private set; }
        public bool Assigned         { get; private set; }
        public bool RAIMflag         { get; private set; }
        public int  RadioStatus      { get; private set; }

        public AISMessage9(AISSentenceParser SentenceParser) :
            base("Standard SAR Aircraft Position Data", SentenceParser, AISMessageType.Message9)
        {
            RepeatIndicator  = (int)SentenceParser.GetBits(2);
            MMSI             = (int)SentenceParser.GetBits(30);
            Altitude         = (int)SentenceParser.GetBits(12);
            SOG              = (int)SentenceParser.GetBits(10);
            PositionAccuracy = (int)SentenceParser.GetBits(1);
            Longitude        = (int)SentenceParser.GetBits(28);
            Latitude         = (int)SentenceParser.GetBits(27);
            CourseOverGround = (int)SentenceParser.GetBits(12);
            TimeStamp        = (int)SentenceParser.GetBits(6);
            Regionalreserved = (int)SentenceParser.GetBits(8);
            DTE              =      SentenceParser.GetBits(1) != 0;
            Spare            = (int)SentenceParser.GetBits(3);
            Assigned         =      SentenceParser.GetBits(1) != 0;
            RAIMflag         =      SentenceParser.GetBits(1) != 0;
            RadioStatus      = (int)SentenceParser.GetBits(19);
        }
    }
}
