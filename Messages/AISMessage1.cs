namespace ais.Messages
{
        public sealed class AISMessage1 : AISMessage
        {
            // |=== Type 1: Position Report Class A
            // |==============================================================================
            // |Field   |Len |Description             |Member    |T|Units
            // |0-5     | 6  |Message Type            |type      |u|Constant: 1-3
            // |6-7     | 2  |Repeat Indicator        |repeat    |u|Message repeat count
            // |8-37    |30  |MMSI                    |mmsi      |u|9 decimal digits
            // |38-41   | 4  |Navigation Status       |status    |e|See "Navigation Status"
            // |42-49   | 8  |Rate of Turn (ROT)      |turn      |I3|See below
            // |50-59   |10  |Speed Over Ground (SOG) |speed     |U1|See below
            // |60-60   | 1  |Position Accuracy       |accuracy  |b|See below
            // |61-88   |28  |Longitude               |lon       |I4|Minutes/10000 (see below)
            // |89-115  |27  |Latitude                |lat       |I4|Minutes/10000 (see below)
            // |116-127 |12  |Course Over Ground (COG)|course    |U1|Relative to true north, to 0.1 degree precision
            // |128-136 | 9  |True Heading (HDG)      |heading   |u|0 to 359 degrees, 511 = not available.
            // |137-142 | 6  |Time Stamp              |second    |u|Second of UTC timestamp
            // |143-144 | 2  |Maneuver Indicator      |maneuver  |e|See "Maneuver Indicator"
            // |145-147 | 3  |Spare                   |          |x|Not used
            // |148-148 | 1  |RAIM flag               |raim      |b|See below
            // |149-167 |19  |Radio status            |radio     |u|See below
            // |==============================================================================

            public int    RepeatIndicator  { get; private set; }
            public int    MMSI             { get; private set; }
            public int    NavigationStatus { get; private set; }
            public int    RateOfTurn       { get; private set; }
            public int    SpeedOverGroup   { get; private set; }
            public bool   PositionAccuracy { get; private set; }
            public double Longitude        { get; private set; }
            public double Latitude         { get; private set; }
            public int    CourseOverGround { get; private set; }
            public int    TrueHeading      { get; private set; }
            public int    TimeStamp        { get; private set; }
            public int    ManuverIndicator { get; private set; }
            public int    Spare            { get; private set; }
            public bool   RAIMFlag         { get; private set; }
            public uint   RadioStatus      { get; private set; }


            public AISMessage1(AISSentenceParser SentenceParser) :
                base("Position Report Class A", SentenceParser, AISMessageType.Message1)
            {
                int longitude;
                int latitude;

                RepeatIndicator  = (int) SentenceParser.GetBits(2);
                MMSI             = (int) SentenceParser.GetBits(30);
                NavigationStatus = (int) SentenceParser.GetBits(4);
                RateOfTurn       = (int) SentenceParser.GetBits(8);
                SpeedOverGroup   = (int) SentenceParser.GetBits(10);
                PositionAccuracy =       SentenceParser.GetBits(1) != 0;
                longitude        = (int) SentenceParser.GetBits(28);
                latitude         = (int) SentenceParser.GetBits(27);
                CourseOverGround = (int) SentenceParser.GetBits(12);
                TrueHeading      = (int) SentenceParser.GetBits(9);
                TimeStamp        = (int) SentenceParser.GetBits(6);
                ManuverIndicator = (int) SentenceParser.GetBits(2);
                Spare            = (int) SentenceParser.GetBits(3);
                RAIMFlag         =       SentenceParser.GetBits(1) != 0;
                RadioStatus      = (uint)SentenceParser.GetBits(19);

                Longitude = ConvertLongitude(longitude);
                Latitude  = ConvertLatitude(latitude);
            }
        }
}
