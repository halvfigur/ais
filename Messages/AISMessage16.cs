namespace ais.Messages
{
    public sealed class AISMessage16 : AISMessage
    {
        public AISMessage16(AISSentenceParser SentenceParser) :
            base("Assignment Mode Command", SentenceParser, AISMessageType.Message16) { }
    }
}
