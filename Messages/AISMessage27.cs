namespace ais.Messages
{
    public sealed class AISMessage27 : AISMessage
    {
        public AISMessage27(AISSentenceParser SentenceParser) :
            base("Position Report For Long-Range Applications", SentenceParser, AISMessageType.Message27) { }
    }
}
