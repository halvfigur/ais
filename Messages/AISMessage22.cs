namespace ais.Messages
{
    public sealed class AISMessage22 : AISMessage
    {
        public AISMessage22(AISSentenceParser SentenceParser) :
            base("Channel Management", SentenceParser, AISMessageType.Message22) { }
    }
}
