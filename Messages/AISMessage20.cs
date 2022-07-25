namespace ais.Messages
{
    public sealed class AISMessage20 : AISMessage
    {
        public AISMessage20(AISSentenceParser SentenceParser) :
            base("Data Link Management", SentenceParser, AISMessageType.Message20) { }
    }
}
