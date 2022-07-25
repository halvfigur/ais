using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ais.Messages;

namespace ais
{
    public class AISMessageFactory
    {

        private AISMessageFactory() { }

        public static AISMessage CreateMessage(string sentence, int padLength)
        {
            AISSentenceParser sentenceParser = new AISSentenceParser(sentence, padLength);

            AISMessage message = null;
            int messageType = (int)sentenceParser.GetBits(6);            
            uint nbrOfBits = sentenceParser.TotalNumberOfBits;

            switch (messageType) { 
                case 1:
                    if (nbrOfBits == 168)
                    {
                        message = new AISMessage1(sentenceParser);
                    }
                    break;
                case 2:
                    if (nbrOfBits == 168)
                    {
                        message = new AISMessage2(sentenceParser);
                    }
                    break;
                case 3:
                    if (nbrOfBits == 168)
                    {
                        message = new AISMessage3(sentenceParser);
                    }
                    break;
                case 4:
                    if (nbrOfBits == 168)
                    {
                        message = new AISMessage4(sentenceParser);
                    }
                    break;
                case 5:
                    if (nbrOfBits == 424)
                    {
                        message = new AISMessage5(sentenceParser);
                    }
                    break;
                case 6:
                    if (nbrOfBits >= 88 && nbrOfBits <= 1008)
                    {
                        message = new AISMessage6(sentenceParser);
                    }
                    break;
                case 7:
                    if (nbrOfBits >= 72 && nbrOfBits <= 168)
                    {
                        message = new AISMessage7(sentenceParser);
                    }
                    break;
                case 8:
                    if (nbrOfBits >= 56 && nbrOfBits <= 1008)
                    {
                        message = new AISMessage8(sentenceParser);
                    }
                    break;
                case 9:
                    if (nbrOfBits == 168)
                    {
                        message = new AISMessage9(sentenceParser);
                    }
                    break;
                case 10:
                    if (nbrOfBits == 72)
                    {
                        message = new AISMessage10(sentenceParser);
                    }
                    break;
                case 11:
                    if (nbrOfBits == 72)
                    {
                        message = new AISMessage11(sentenceParser);
                    }
                    break;
                case 12:
                    if (nbrOfBits >= 72 && nbrOfBits <= 1008)
                    {
                        message = new AISMessage12(sentenceParser);
                    }
                    break;
                case 13:
                    if (nbrOfBits >= 72 && nbrOfBits <= 168)
                    {
                        message = new AISMessage13(sentenceParser);
                    }
                    break;
                case 14:
                    if (nbrOfBits >= 40 && nbrOfBits <= 1008)
                    {
                        message = new AISMessage14(sentenceParser);
                    }
                    break;
                case 15:
                    if (nbrOfBits >= 88 && nbrOfBits <= 160)
                    {
                        message = new AISMessage15(sentenceParser);
                    }
                    break;
                case 16:
                    message = new AISMessage16(sentenceParser);
                    break;
                case 17:
                    message = new AISMessage17(sentenceParser);
                    break;
                case 18:
                    if (nbrOfBits == 168)
                    {
                        message = new AISMessage18(sentenceParser);
                    }
                    break;
                case 19:
                    if (nbrOfBits == 312)
                    {
                        message = new AISMessage19(sentenceParser);
                    }
                    break;
                case 20:
                    message = new AISMessage20(sentenceParser);
                    break;
                case 21:
                    message = new AISMessage21(sentenceParser);
                    break;
                case 22:
                    message = new AISMessage22(sentenceParser);
                    break;
                case 23:
                    message = new AISMessage23(sentenceParser);
                    break;
                case 24:
                    if (nbrOfBits == 168)
                    {
                        message = new AISMessage24(sentenceParser);
                    }
                    break;
                case 25:
                    message = new AISMessage25(sentenceParser);
                    break;
                case 26:
                    message = new AISMessage26(sentenceParser);
                    break;
                case 27:
                    message = new AISMessage27(sentenceParser);
                    break;
                default:
                    return null;
            };

            return message;
        }
    }
}
