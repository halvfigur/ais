namespace ais.Messages
{
    public sealed class AISMessage5 : AISMessage
    {
        // |==============================================================================
        // |Field   |Len |Description            |Member/Type  |T|Encoding
        // |0-5     |  6 |Message Type           |type         |u|Constant: 5
        // |6-7     |  2 |Repeat Indicator       |repeat       |u|Message repeat count
        // |8-37    | 30 |MMSI                   |mmsi         |u|9 digits
        // |38-39   |  2 |AIS Version            |ais_version  |u|0=<<ITU1371>>,
        //                                                        1-3 = future editions
        // |40-69   | 30 |IMO Number             |imo          |u|IMO ship ID number
        // |70-111  | 42 |Call Sign              |callsign     |t|7 six-bit characters
        // |112-231 |120 |Vessel Name            |shipname     |t|20 six-bit characters
        // |232-239 |  8 |Ship Type              |shiptype     |e|See "Codes for Ship Type"
        // |240-248 |  9 |Dimension to Bow       |to_bow       |u|Meters
        // |249-257 |  9 |Dimension to Stern     |to_stern     |u|Meters
        // |258-263 |  6 |Dimension to Port      |to_port      |u|Meters
        // |264-269 |  6 |Dimension to Starboard |to_starboard |u|Meters
        // |270-273 |  4 |Position Fix Type      |epfd         |e|See "EPFD Fix Types"
        // |274-277 |  4 |ETA month (UTC)        |month        |u|1-12, 0=N/A (default)
        // |278-282 |  5 |ETA day (UTC)          |day          |u|1-31, 0=N/A (default)
        // |283-287 |  5 |ETA hour (UTC)         |hour         |u|0-23, 24=N/A (default)
        // |288-293 |  6 |ETA minute (UTC)       |minute       |u|0-59, 60=N/A (default)
        // |294-301 |  8 |Draught                |draught      |U1|Meters/10
        // |302-421 |120 |Destination            |destination  |t|20 6-bit characters
        // |422-422 |  1 |DTE                    |dte          |b|0=Data terminal ready,
        //                                                        1=Not ready (default).
        // |423-423 |  1 |Spare                  |             |x|Not used
        // | ==============================================================================

        public int    RepeatIndicator      { get; private set; }
        public int    MMSI                 { get; private set; }
        public int    AISVersion           { get; private set; }
        public int    IMONumber            { get; private set; }
        public string CallSign             { get; private set; }
        public string VesselName           { get; private set; }
        public int    ShipType             { get; private set; }
        public int    DimensionToBow       { get; private set; }
        public int    DimensionToStern     { get; private set; }
        public int    DimensionToPort      { get; private set; }
        public int    DimensionToStarboard { get; private set; }
        public int    PositionFixType      { get; private set; }
        public int    ETAMonth             { get; private set; }
        public int    ETADay               { get; private set; }
        public int    ETAHour              { get; private set; }
        public int    ETAMinute            { get; private set; }
        public int    Draught              { get; private set; }
        public string Destination          { get; private set; }
        public bool   DTE                  { get; private set; }
        public int    Spare                { get; private set; }

        public AISMessage5(AISSentenceParser SentenceParser) :
            base("Static and Voyage Related Data", SentenceParser, AISMessageType.Message5)
        {
            RepeatIndicator          = (int)SentenceParser.GetBits(2);
            MMSI                     = (int)SentenceParser.GetBits(30);    
            AISVersion               = (int)SentenceParser.GetBits(2);
            IMONumber                = (int)SentenceParser.GetBits(30);
            CallSign                 =      GetString(42);
            VesselName               =      GetString(120); 
            ShipType                 = (int)SentenceParser.GetBits(8);
            DimensionToBow           = (int)SentenceParser.GetBits(9);
            DimensionToStern         = (int)SentenceParser.GetBits(9);
            DimensionToPort          = (int)SentenceParser.GetBits(6);
            DimensionToStarboard     = (int)SentenceParser.GetBits(6);
            PositionFixType          = (int)SentenceParser.GetBits(4);
            ETAMonth                 = (int)SentenceParser.GetBits(4);
            ETADay                   = (int)SentenceParser.GetBits(5);
            ETAHour                  = (int)SentenceParser.GetBits(5);
            ETAMinute                = (int)SentenceParser.GetBits(6);
            Draught                  = (int)SentenceParser.GetBits(8);
            Destination              =      GetString(120);
            DTE                      =      SentenceParser.GetBits(1) != 0;
            Spare                    = (int)SentenceParser.GetBits(1);

        }
    }
}
