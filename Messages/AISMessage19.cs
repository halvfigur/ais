namespace ais.Messages
{
    public sealed class AISMessage19 : AISMessage
    {
        // === Type 19: Extended Class B CS Position Report
        //|==============================================================================
        //|Field    |Len |Description            |Member       |T|Units
        //|0-5      |  6 |Message Type           |type         |u|Constant: 19
        //|6-7      |  2 |Repeat Indicator       |repeat       |u|As in CNN
        //|8-37     | 30 |MMSI                   |mmsi         |u|9 digits
        //|38-45    |  8 |Regional Reserved      |reserved     |u|
        //|46-55    | 10 |Speed Over Ground      |speed        |u|As in CNB.
        //|56-56    |  1 |Position Accuracy      |accuracy     |b|As in CNB.
        //|57-84    | 28 |Longitude              |lon          |I4|Minutes/10000 (as in CNB)
        //|85-111   | 27 |Latitude               |lat          |I4|Minutes/10000 (as in CNB)
        //|112-123  | 12 |Course Over Ground     |course       |U1|Relative to true north,
        //                                                         units of 0.1 degrees
        //|124-132  |  9 |True Heading           |heading      |u|0 to 359 degrees,
        //                                                        511 = N/A
        //|133-138  |  6 |Time Stamp             |second       |u|Second of UTC timestamp.
        //|139-142  |  4 |Regional reserved      |regional     |u|Uninterpreted
        //|143-262  |120 |Name                   |shipname     |s|20 6-bit characters
        //|263-270  |  8 |Type of ship and cargo |shiptype     |u|As in Message 5
        //|271-279  |  9 |Dimension to Bow       |to_bow       |u|Meters
        //|280-288  |  9 |Dimension to Stern     |to_stern     |u|Meters
        //|289-294  |  6 |Dimension to Port      |to_port      |u|Meters
        //|295-300  |  6 |Dimension to Starboard |to_starboard |u|Meters
        //|301-304  |  4 |Position Fix Type      |epfd         |e|See "EPFD Fix Types"
        //|305-305  |  1 |RAIM flag              |raim         |b|As in CNB.
        //|306-306  |  1 |DTE                    |dte          |b|0=Data terminal ready,
        //                                                        1=Not ready (default).
        //|307-307  |  1 |Assigned mode flag     |assigned     |u|See <<IALA>> for details
        //|308-311  |  4 |Spare                  |             |x|Unused, should be zero
        //|==============================================================================

        public int    RepeatIndicator      { get; private set; }
        public int    MMSI                 { get; private set; }
        public int    RegionalReserved1    { get; private set; }
        public int    SpeedOverGround      { get; private set; }
        public bool   PositionAccuracy     { get; private set; }
        public double Longitude            { get; private set; }
        public double Latitude             { get; private set; }
        public int    CourseOverGround     { get; private set; }
        public int    TrueHeading          { get; private set; }
        public int    TimeStamp            { get; private set; }
        public int    RegionalReserved2    { get; private set; }
        public string Name                 { get; private set; }
        public int    TypeOfShipAndCargo   { get; private set; }
        public int    DimensionToBow       { get; private set; }
        public int    DimensionToStern     { get; private set; }
        public int    DimensionToPort      { get; private set; }
        public int    DimensionToStarboard { get; private set; }
        public int    PositionFixType      { get; private set; }
        public bool   RAIMFlag             { get; private set; }
        public bool   DTE                  { get; private set; }
        public bool   AssignedModeFlag     { get; private set; }
        public int    Spare                { get; private set; }

        public AISMessage19(AISSentenceParser SentenceParser) :
            base("Extended Class B Equipment Position Report", SentenceParser, AISMessageType.Message19)
        {
            RepeatIndicator      = (int)SentenceParser.GetBits(2);
            MMSI                 = (int)SentenceParser.GetBits(30);
            RegionalReserved1    = (int)SentenceParser.GetBits(8);
            SpeedOverGround      = (int)SentenceParser.GetBits(10);
            PositionAccuracy     =      SentenceParser.GetBits(1) != 0;
            Longitude            = (int)SentenceParser.GetBits(28);
            Latitude             = (int)SentenceParser.GetBits(27);
            CourseOverGround     = (int)SentenceParser.GetBits(12);
            TrueHeading          = (int)SentenceParser.GetBits(9);
            TimeStamp            = (int)SentenceParser.GetBits(6);
            RegionalReserved2    = (int)SentenceParser.GetBits(4);
            Name                 =      GetString(120);
            TypeOfShipAndCargo   = (int)SentenceParser.GetBits(8);
            DimensionToBow       = (int)SentenceParser.GetBits(9);
            DimensionToStern     = (int)SentenceParser.GetBits(9);
            DimensionToPort      = (int)SentenceParser.GetBits(6);
            DimensionToStarboard = (int)SentenceParser.GetBits(6);
            PositionFixType      = (int)SentenceParser.GetBits(4);
            RAIMFlag             =      SentenceParser.GetBits(1) != 0;
            DTE                  =      SentenceParser.GetBits(1) != 0;
            AssignedModeFlag     =      SentenceParser.GetBits(1) != 0;
            Spare                = (int)SentenceParser.GetBits(4);
        }
    }
}
