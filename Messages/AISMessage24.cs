namespace ais.Messages
{
    public sealed class AISMessage24 : AISMessage
    {
        // === Type 24: Static Data Report
        //|==============================================================================
        //||Field   |Len |Description            | Member         |T|Units
        //||0-5     |  6 | Message Type          | type           |u|Constant: 24
        //||6-7     |  2 | Repeat Indicator      | repeat         |u|As in CNB
        //||8-37    | 30 | MMSI                  | mmsi           |u|9 digits
        //||38-39   |  2 | Part Number           | partno         |u|0-1
        //||40-159  |120 | Vessel Name           | shipname       |t|(Part A) 20 sixbit chars
        //||160-167 |  8 | Spare                 |                |x|(Part A) Not used
        //||40-47   |  8 | Ship Type             | shiptype       |e|(Part B) See "Ship Types"
        //||48-89   | 42 | Vendor ID             | vendorid       |t|(Part B) 7 six-bit chars
        //||90-131  | 42 | Call Sign             | callsign       |t|(Part B) As in Message Type 5
        //||132-140 |  9 | Dimension to Bow      | to_bow         |u|(Part B) Meters
        //||141-149 |  9 | Dimension to Stern    | to_stern       |u|(Part B) Meters
        //||150-155 |  6 | Dimension to Port     | to_port        |u|(Part B) Meters
        //||156-161 |  6 | Dimension to Starboard| to_starboard   |u|(Part B) Meters
        //||132-161 | 30 | Mothership MMSI       | mothership_mmsi|u|(Part B) See below
        //||162-167 |  6 | Spare                 |                |x|(Part B) Not used
        //||===============================================================================
        //
        // If the Part Number field is 0, the rest of the message is interpreted
        // as a Part A; if it is 1, the rest of the message is interpreted
        // as a Part B; values 2 and 3 are not allowed.

        public int    RepeatIndicator      { get; private set; }
        public int    MMSI                 { get; private set; }
        public int    PartNumber           { get; private set; }
        public string VesselName           { get; private set; }
        public int    Spare1               { get; private set; }
        public int    ShipType             { get; private set; }
        public string VendorID             { get; private set; }
        public int    CallSign             { get; private set; }
        public int    DimensionToBow       { get; private set; }
        public int    DimensionToStern     { get; private set; }
        public int    DimensionToPort      { get; private set; }
        public int    DimensionToStarboard { get; private set; }
        public int    MothershipMMSI       { get; private set; }
        public int    Spare2               { get; private set; }

        public AISMessage24(AISSentenceParser SentenceParser) :
            base("Static Data Report", SentenceParser, AISMessageType.Message24)
        {
            RepeatIndicator      = (int)SentenceParser.GetBits(2);
            MMSI                 = (int)SentenceParser.GetBits(30);
            PartNumber           = (int)SentenceParser.GetBits(2);

            // Is this a part A message
            if (PartNumber == 0)
            {
                VesselName = GetString(120);
                Spare1 = (int)SentenceParser.GetBits(8);
            }
            // Or is it a part B message
            else if (PartNumber == 1)
            {
                ShipType = (int)SentenceParser.GetBits(8);
                VendorID = GetString(42);
                CallSign = (int)SentenceParser.GetBits(42);
                DimensionToBow = (int)SentenceParser.GetBits(9);
                DimensionToStern = (int)SentenceParser.GetBits(9);
                DimensionToPort = (int)SentenceParser.GetBits(6);
                DimensionToStarboard = (int)SentenceParser.GetBits(6);
                MothershipMMSI = (int)SentenceParser.GetBits(30);
                Spare2 = (int)SentenceParser.GetBits(6);
            }
        }
    }
}
