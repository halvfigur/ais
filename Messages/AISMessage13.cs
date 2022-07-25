namespace ais.Messages
{
    public sealed class AISMessage13 : AISMessage
    {
        // === Type 7: Safety Related Acknowledgement ===
        //|==============================================================================
        //|Field   |Len |Description      |Member   |T|Units
        //|0-5     |  6 |Message Type     |type     |u|Constant: 7
        //|6-7     |  2 |Repeat Indicator |repeat   |u|As in Common Navigation Block
        //|8-37    | 30 |Source MMSI      |mmsi     |u|9 decimal digits
        //|38-39   |  2 |Spare            |         |x|Not used
        //|40-69   | 30 |MMSI number 1    |mmsi1    |u|9 decimal digits
        //|70-71   |  2 |Spare            |         |x|Not used
        //|62-101  | 30 |MMSI number 2    |mmsi2    |u|9 decimal digits
        //|102-103 |  2 |Spare            |         |x|Not used
        //|104-133 | 30 |MMSI number 3    |mmsi3    |u|9 decimal digits
        //|134-135 |  2 |Spare            |         |x|Not used
        //|136-165 | 30 |MMSI number 4    |mmsi4    |u|9 decimal digits
        //|166-167 |  2 |Spare            |         |x|Not used
        //|==============================================================================

        public int RepeatIndicator { get; private set; }
        public int SourceMMSI      { get; private set; }
        public int Spare1          { get; private set; } 
        public int MMSI1           { get; private set; }
        public int Spare2          { get; private set; } 
        public int MMSI2           { get; private set; } 
        public int Spare3          { get; private set; } 
        public int MMSI3           { get; private set; } 
        public int Spare4          { get; private set; } 
        public int MMSI4           { get; private set; } 
        public int Spare5          { get; private set; }

        public AISMessage13(AISSentenceParser SentenceParser) :
            base("Safety Related Acknowledgement", SentenceParser, AISMessageType.Message13)
        {
            RepeatIndicator = (int)SentenceParser.GetBits(2);
            SourceMMSI      = (int)SentenceParser.GetBits(30);
            Spare1          = (int)SentenceParser.GetBits(2);
            MMSI1           = (int)SentenceParser.GetBits(30);
            Spare2          = (int)SentenceParser.GetBits(2);
            MMSI2           = (int)SentenceParser.GetBits(30);
            Spare3          = (int)SentenceParser.GetBits(2);
            MMSI3           = (int)SentenceParser.GetBits(30);
            Spare4          = (int)SentenceParser.GetBits(2);
            MMSI4           = (int)SentenceParser.GetBits(30);
            Spare5          = (int)SentenceParser.GetBits(2);
        }
    }
}
