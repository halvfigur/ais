using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ais
{
    public class AISTranslationService
    {
        private AISTranslationService() { }

        public static string ShipTypeToString(int shiptype)
        {
            int mainType = shiptype / 10;
            int subType = shiptype % 10;
            string value = null;

            switch (mainType)
            {
                case 0:
                    value = "Not available";
                    break;
                case 1:
                    value = "Reserved for future use";
                    break;
                case 2:
                    value = ShipTypeToStringCategory2(subType);
                    break;
                case 3:
                    value = ShipTypeToStringCategory3(subType);
                    break;
                case 4:
                    value = "High speed craft" + ShipTypeToStringCategoryDescription(subType);
                    break;
                case 5:
                    value = ShipTypeToStringCategory5(subType);
                    break;
                case 6:
                    value = "Passenger ship" + ShipTypeToStringCategoryDescription(subType);
                    break;
                case 7:
                    value = "Cargo ship" + ShipTypeToStringCategoryDescription(subType);
                    break;
                case 8:
                    value = "Tanker" + ShipTypeToStringCategoryDescription(subType);
                    break;
                case 9:
                    value = "Other" + ShipTypeToStringCategoryDescription(subType);
                    break;
            }
            
            return value;
        }

        private static string ShipTypeToStringCategory2(int subType)
        {
            string value = null;

            switch (subType)
            {
                case 0:
                    value = "Wing in ground";
                    break;
                case 1:
                    value = "Tug";
                    break;
                case 2:
                    value = "Tug";
                    break;
                case 3:
                    value = "Light boat engaged in towing";
                    break;
                case 4:
                    value = "";
                    break;
                case 5:
                    value = "";
                    break;
                case 6:
                    value = "";
                    break;
                case 7:
                    value = "";
                    break;
                case 8:
                    value = "";
                    break;
                case 9:
                    value = "";
                    break;
            }

            return value ?? ", " + value;
        }

        private static string ShipTypeToStringCategory3(int subType)
        {
            string value = null;

            return value;
        }

        private static string ShipTypeToStringCategory5(int subType)
        {
            string value = null;

            return value;
        }

        private static string ShipTypeToStringCategoryDescription(int subType)
        {
            string value = null;

            return value;
        }
    }
}
