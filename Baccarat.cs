using System.Resources;

namespace BaccaratClient
{
    public static class Baccarat
    {
        public const uint BACCARAT_TYPE_WAIT = 0,
            BACCARAT_TYPE_PLAYER = 1,
            BACCARAT_TYPE_BANKER = 2,
            BACCARAT_TYPE_DRAW = 3;

        private const uint CARD_TYPE_CLUB = 0,
            CARD_TYPE_DIAMOND = 1,
            CARD_TYPE_HEART = 2,
            CARD_TYPE_SPADE = 3;
        
        public static string GetCardImageName(uint cardType, uint cardNum)
        {
            var imgName = "";
            imgName += GetCardNumName(cardNum);
            imgName += "_of_";

            var cardTypeName = GetCardTypeName(cardType);
            imgName += cardTypeName;
            return imgName;
        }

        public static string GetCardTypeName(uint cardType)
        {
            switch (cardType)
            {
                case CARD_TYPE_CLUB:
                    return "clubs";
                case CARD_TYPE_DIAMOND:
                    return "diamonds";
                case CARD_TYPE_HEART:
                    return "hearts";
                case CARD_TYPE_SPADE:
                    return "spades";
                default:
                    return "";
            }
        }
        
        public static string GetCardNumName(uint cardNum)
        {
            if (cardNum == 1)
            {
                return "ace";
            }
            if (cardNum <= 10)
            {
                return "_" + cardNum;
            }

            switch (cardNum)
            {
                case 11:
                    return "jack";
                case 12:
                    return "queen";
                case 13:
                    return "king";
                default:
                    return "";
            }
        }
    }
}