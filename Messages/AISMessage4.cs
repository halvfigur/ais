namespace ais.Messages
{
    public sealed class AISMessage4 : AISMessage
    {
        // |=== Type 4: Base Station Report ==
        // |==============================================================================
        // |Field   |Len  |Description      |Member   |T|Units
        // |0-5     |  6  |Message Type     |type     |u|Constant: 4
        // |6-7     |  2  |Repeat Indicator |repeat   |u|As in Common Navigation Block
        // |8-37    | 30  |MMSI             |mmsi     |u|9 decimal digits
        // |38-51   | 14  |Year (UTC)       |year     |u|UTC, 1-999, 0 = N/A (default)
        // |52-55   |  4  |Month (UTC)      |month    |u|1-12; 0 = N/A (default)
        // |56-60   |  5  |Day (UTC)        |day      |u|1-31; 0 = N/A (default)
        // |61-65   |  5  |Hour (UTC)       |hour     |u|0-23; 24 = N/A (default)
        // |66-71   |  6  |Minute (UTC)     |minute   |u|0-59; 60 = N/A (default)
        // |72-77   |  6  |Second (UTC)     |second   |u|0-59; 60 = N/A (default)
        // |78-78   |  1  |Fix quality      |accuracy |b|As in Common Navigation Block
        // |79-106  | 28  |Longitude        |lon      |I4|As in Common Navigation Block
        // |107-133 | 27  |Latitude         |lat      |I4|As in Common Navigation Block
        // |134-137 |  4  |Type of EPFD     |epfd     |e|See "EPFD Fix Types"
        // |138-147 | 10  |Spare            |         |x|Not used
        // |148-148 |  1  |RAIM flag        |raim     |b|As for common navigation block
        // |149-167 | 19  |SOTDMA state     |radio    |u|As in same bits for Type 1
        // |==============================================================================

        public int    RepeatIndicator { get; private set;}
        public int    MMSI            { get; private set; }
        public int    Year            { get; private set; }
        public int    Month           { get; private set; }
        public int    Day             { get; private set; }
        public int    Hour            { get; private set; }
        public int    Minute          { get; private set; }
        public int    Second          { get; private set; }
        public bool   FixQuality      { get; private set; }
        public double Longitude       { get; private set; }
        public double Latitude        { get; private set; }
        public int    EPDF            { get; private set; }
        public int    Spare           { get; private set; }
        public bool   RAIM            { get; private set; }
        public int    SOTDMA          { get; private set; }

        public AISMessage4(AISSentenceParser SentenceParser) :
            base("Base Station Report", SentenceParser, AISMessageType.Message4)
        {
            int longitude;
            int latitude;

            RepeatIndicator = (int)SentenceParser.GetBits(2);
            MMSI            = (int)SentenceParser.GetBits(30);
            Year            = (int)SentenceParser.GetBits(14);
            Month           = (int)SentenceParser.GetBits(4);
            Day             = (int)SentenceParser.GetBits(5);
            Hour            = (int)SentenceParser.GetBits(5);
            Minute          = (int)SentenceParser.GetBits(6);
            Second          = (int)SentenceParser.GetBits(6);
            FixQuality      =      SentenceParser.GetBits(1) != 0;
            longitude       = (int)SentenceParser.GetBits(28);
            latitude        = (int)SentenceParser.GetBits(27);
            EPDF            = (int)SentenceParser.GetBits(4);
            Spare           = (int)SentenceParser.GetBits(10);
            RAIM            =      SentenceParser.GetBits(1) != 0;
            SOTDMA          = (int)SentenceParser.GetBits(19);

            Longitude = ConvertLongitude(longitude);
            Latitude = ConvertLatitude(latitude);
        }
    }
}
