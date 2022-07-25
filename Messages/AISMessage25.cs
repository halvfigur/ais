namespace ais.Messages
{
    public sealed class AISMessage25 : AISMessage
    {
        public AISMessage25(AISSentenceParser SentenceParser) :
            base("Single Slot Binary Message", SentenceParser, AISMessageType.Message25) { }
    }
}
