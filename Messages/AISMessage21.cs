namespace ais.Messages
{
    public sealed class AISMessage21 : AISMessage
    {
        public AISMessage21(AISSentenceParser SentenceParser) :
            base("Aid-to-Navigation Report", SentenceParser, AISMessageType.Message21) { }
    }
}
