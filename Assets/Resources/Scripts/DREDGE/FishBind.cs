using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DREDGE
{
    public enum FishType
    {
        None = 0,
        Blue_Mackerel,  //망치고등어
        Cod,            //대구
        Arrow_Squid,    //화살 오징어
        Grey_Eel,       //회색 장어
        Gulf_Flounder,  //넙치
        Black_Grouper,  //그루퍼
        Stingray,       //가오리
        Sailfish,       //돛새치
        Bronze_Whaler,  //무태상어
        Swordfish,      //황새치       
    }

    public class FishBind
    {
        private static readonly Dictionary<FishType, int[,]> m_fishSize = new();
        private static readonly Dictionary<FishType,Fish> m_fishData = new();

        public static void Initialize()
        {
            if (m_fishSize.Count > 0) return;

            // size mapping
            foreach (var pair in Constant.FishSize.Sizes)
            {
                m_fishSize.TryAdd(pair.Key, pair.Value);
            }
            

            // new Fish save in m_fishData
            foreach(FishType type in System.Enum.GetValues(typeof(FishType)))
            {
                if(type == FishType.None) continue;

                string fishName = type.ToString();
                var fish = new Fish(type, fishName);

                fish.SetDescription($" this is a {fishName}");

                m_fishData.TryAdd(type, fish);
            }
        }

        public static int[,] GetFishSize(FishType type)
        {
            if (m_fishSize.TryGetValue(type, out var size))
                return size;

            Debug.LogWarning($"{type}에 대한 FishSize가 존재하지 않습니다.");
            return null;
        }       

        public static Fish GetFishData(FishType type)
        {
            if (m_fishData.TryGetValue(type, out var fish))
                return fish;

            Debug.LogWarning($"{type}에 대한 FishData가 존재하지 않습니다.");
            return null;
        }
    }
}

