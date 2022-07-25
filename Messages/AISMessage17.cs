namespace ais.Messages
{
    public sealed class AISMessage17 : AISMessage
    {
        public AISMessage17(AISSentenceParser SentenceParser) :
            base("DGNSS Binary Broadcast Message", SentenceParser, AISMessageType.Message17) { }
    }
}
