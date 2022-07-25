namespace ais.Messages
{
    public sealed class AISMessage14 : AISMessage
    {
        // === Type 14: Safety-Related Broadcast Message
        //|==============================================================================
        //|Field   |Len |Description        |Member    |T|Units
        //|0-5     |  6 |Message Type       |type      |u|Constant: 14
        //|6-7     |  2 |Repeat Indicator   |repeat    |u|As in Common Navigation Block
        //|8-37    | 30 |Source MMSI        |mmsi      |u|9 decimal digits
        //|38-39   |  2 |Spare              |          |x|Not used
        //|40      |968 |Text               |text      |t|1-161 chars of six-bit text.
        //                                                May be shorter than 968 bits.
        //|==============================================================================

        public int    RepeatIndicator { get; private set; }
        public int    MMSI            { get; private set; }
        public int    Spare           { get; private set; }
        public string Text            { get; private set; }

        public AISMessage14(AISSentenceParser SentenceParser) :
            base("Safety Related Broadcast Message", SentenceParser, AISMessageType.Message14)
        {
            RepeatIndicator = (int)SentenceParser.GetBits(2);
            MMSI            = (int)SentenceParser.GetBits(30);
            Spare           = (int)SentenceParser.GetBits(2);
            Text            =      GetString(968);
        }
    }
}
