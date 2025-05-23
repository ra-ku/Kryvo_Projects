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
        Blue_Mackerel,  //연어
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
        private static readonly Dictionary<FishType, int[,]> m_fish = new();

        public static void Initialize()
        {
            if (m_fish.Count > 0) return;

            foreach (var pair in Constant.FishSize.Sizes)
            {
                m_fish.TryAdd(pair.Key, pair.Value);
            }
        }

        public static int[,] GetFishSize(FishType type)
        {
            if (m_fish.TryGetValue(type, out var size))
                return size;

            Debug.LogWarning($"{type}에 대한 FishSize가 존재하지 않습니다.");
            return null;
        }

        public static Dictionary<FishType, int[,]> GetFishSizeDictionary()
        {
            return m_fish;
        }
    }
}

