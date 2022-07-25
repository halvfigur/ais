namespace ais.Messages
{
    public sealed class AISMessage23 : AISMessage
    {
        public AISMessage23(AISSentenceParser SentenceParser) :
            base("Group Assignment Command", SentenceParser, AISMessageType.Message23) { }
    }
}
