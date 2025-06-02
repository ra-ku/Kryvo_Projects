using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DREDGE
{
    public class Constant
    {
        public class Path
        {
            public const string DEFAULT_UI_SCENE_PATH = "UI/Scene";
        }

        public static class FishSize
        {
            public static readonly int[,] BLUE_MACKEREL = new int[,]
            {
                { 1, 1 } 
            };
            public static readonly int[,] COD = new int[,]
            {
                { 1, 1 }, 
                { 0, 1 } 
            };
            public static readonly int[,] ARROW_SQUID = new int[,]
            {
                { 1, 1 } 
            };
            public static readonly int[,] GREY_EEL = new int[,]
            { 
                { 1, 1, 1 }
            };
            public static readonly int[,] GULF_FLOUNDER = new int[,]
            { 
                { 1, 1 }, { 1, 1 }
            };
            public static readonly int[,] BLACK_GROUPER = new int[,]
            { 
                { 1, 1 }, { 1, 1 }
            };
            public static readonly int[,] STINGRAY = new int[,] {
                { 0, 1, 1 }, 
                { 1, 1, 1 }, 
                { 0, 1, 1 }
            };
            public static readonly int[,] SAILFISH = new int[,] 
            {
                { 0, 1, 1, 1, 0, 0 }, 
                { 1, 1, 1, 1, 1, 1 } 
            };
            public static readonly int[,] BRONZE_WHALER = new int[,]
            { 
                { 0, 1, 0, 0 },
                { 1, 1, 1, 1 },
                { 0, 0, 1, 0 }
            };
            public static readonly int[,] SWORD_FISH = new int[,]
            {
                { 0, 0, 1, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1 }
            };

            public static readonly Dictionary<FishType, int[,]> Sizes = new()
            {
                { FishType.Blue_Mackerel, BLUE_MACKEREL },
                { FishType.Cod, COD },
                { FishType.Arrow_Squid, ARROW_SQUID },
                { FishType.Grey_Eel, GREY_EEL },
                { FishType.Gulf_Flounder, GULF_FLOUNDER },
                { FishType.Black_Grouper, BLACK_GROUPER },
                { FishType.Stingray, STINGRAY },
                { FishType.Sailfish, SAILFISH },
                { FishType.Bronze_Whaler, BRONZE_WHALER },
                { FishType.Swordfish, SWORD_FISH },
            };
        }

        public static class DefineAngle
        {

        }

        public static class BoatSize
        {

        }
    }
}
