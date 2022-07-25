namespace ais.Messages
{
    public sealed class AISMessage18 : AISMessage
    {
        // === Type 18: Standard Class B CS Position Report
        //|==============================================================================
        //|Field   |Len |Description        |Member   |T|Units
        //|0-5     | 6  |Message Type       |type     |u|Constant: 18
        //|6-7     | 2  |Repeat Indicator   |repeat   |u|As in Common Navigation Block
        //|8-37    |30  |MMSI               |mmsi     |u|9 decimal digits
        //|38-45   | 8  |Regional Reserved  |reserved |x|Not used
        //|46-55   |10  |Speed Over Ground  |speed    |u|As in common navigation block
        //|56-56   | 1  |Position Accuracy  |accuracy |b|See below
        //|57-84   |28  |Longitude          |lon      |I4|Minutes/10000 (as in CNB)
        //|85-111  |27  |Latitude           |lat      |I4|Minutes/10000 (as in CNB)
        //|112-123 |12  |Course Over Ground |course   |U1|0.1 degrees from true north
        //|124-132 | 9  |True Heading       |heading  |u|0 to 359 degrees, 511 = N/A
        //|133-138 | 6  |Time Stamp         |second   |u|Second of UTC timestamp.
        //|139-140 | 2  |Regional reserved  |regional |u|Uninterpreted
        //|141-141 | 1  |CS Unit            |cs       |b|0=Class B SOTDMA unit
        //                                               1=Class B CS (Carrier Sense) unit
        //|142-142 | 1  |Display flag       |display  |b|0=No visual display, 
        //                                               1=Has display,
        //                                               (Probably not reliable).
        //|143-143 | 1  |DSC Flag           |dsc      |b|If 1, unit is attached to a VHF
        //                                               voice radio with DSC capability.
        //|144-144 | 1  |Band flag          |band     |b|Base stations can command units
        //                                               to switch frequency. If this flag
        //                                               is 1, the unit can use any part
        //                                               of the marine channel.
        //|145-145 | 1  |Message 22 flag    |msg22    |b|If 1, unit can accept a channel
        //                                               assignment via Message Type 22.
        //|146-146 | 1  |Assigned           |assigned |b|Assigned-mode flag:
        //                                               0 = autonomous mode (default),
        //                                               1 = assigned mode.
        //|147-147 | 1  |RAIM flag          |raim     |b|As for common navigation block
        //|148-167 |20  |Radio status       |radio    |u|See <<IALA>> for details.
        //|==============================================================================

        public int    RepeatIndicator   { get; private set; }
        public int    MMSI              { get; private set; } 
        public int    RegionalReserved1 { get; private set; }
        public int    SpeedOverGround   { get; private set; }
        public int    PositionAccuracy  { get; private set; }
        public double Longitude         { get; private set; }
        public double Latitude          { get; private set; }
        public int    CourseOverGround  { get; private set; }
        public int    TrueHeading       { get; private set; }
        public int    TimeStamp         { get; private set; }
        public int    RegionalReserved2 { get; private set; }
        public bool   CSUnit            { get; private set; }
        public bool   DisplayFlag       { get; private set; }
        public bool   DSCFlag           { get; private set; }
        public bool   BandFlag          { get; private set; }
        public bool   Message22Flag     { get; private set; }
        public bool   Assigned          { get; private set; }
        public bool   RAIMFlag          { get; private set; }
        public int    RadioStatus       { get; private set; }

        public AISMessage18(AISSentenceParser SentenceParser) :
            base("Standard Class B CS Position Report", SentenceParser, AISMessageType.Message18)
        {
            int longitude;
            int latitude;

            RepeatIndicator   = (int)SentenceParser.GetBits(2);
            MMSI              = (int)SentenceParser.GetBits(30);
            RegionalReserved1 = (int)SentenceParser.GetBits(8);
            SpeedOverGround   = (int)SentenceParser.GetBits(10);
            PositionAccuracy  = (int)SentenceParser.GetBits(1);
            longitude         = (int)SentenceParser.GetBits(28);
            latitude          = (int)SentenceParser.GetBits(27);
            CourseOverGround  = (int)SentenceParser.GetBits(12);
            TrueHeading       = (int)SentenceParser.GetBits(9);
            TimeStamp         = (int)SentenceParser.GetBits(6);
            RegionalReserved2 = (int)SentenceParser.GetBits(2);
            CSUnit            =      SentenceParser.GetBits(1) != 0;
            DisplayFlag       =      SentenceParser.GetBits(1) != 0;
            DSCFlag           =      SentenceParser.GetBits(1) != 0;
            BandFlag          =      SentenceParser.GetBits(1) != 0;
            Message22Flag     =      SentenceParser.GetBits(1) != 0;
            Assigned          =      SentenceParser.GetBits(1) != 0;
            RAIMFlag          =      SentenceParser.GetBits(1) != 0;
            RadioStatus       = (int)SentenceParser.GetBits(20);

            Longitude = ConvertLongitude(longitude);
            Latitude  = ConvertLatitude(latitude);             
        }
    }
}
