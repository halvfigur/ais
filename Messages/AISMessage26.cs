namespace ais.Messages
{
    public sealed class AISMessage26 : AISMessage
    {
        public AISMessage26(AISSentenceParser SentenceParser) :
            base("Multiple Slot Binary Message With Communications State", SentenceParser, AISMessageType.Message26) { }
    }
}
