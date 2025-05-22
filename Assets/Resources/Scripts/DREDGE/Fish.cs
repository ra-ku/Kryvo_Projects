using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DREDGE
{
    public enum FishType
    {
        Blue_Mackerel,
        Cod,
        Arrow_Squid,
    }

    public class Fish
    {
        Dictionary<FishType, int[,] > m_fish = new Dictionary<FishType, int[,]>();

        
        public string[] GetFishTypeName()
        {
            string[] names = Enum.GetNames(typeof(FishType));
            return names;
        }


        public void SetFishSizeValue(string[] names)
        {
            if(names.Length <= 0)
            {
                return;
            }

            ////TODO
            ////names에 따라서 value가 정해지는데 value 는 배열임
            ////switchcase문으로 할듯
            
            foreach (string name in names)
            {
                switch(name)
                {
                    case "Cod":
                        int[,] size = new int[2, 2];
                        size[0, 0] = 1; size[0,1] = 1; size[1, 0] = 1; size[2, 2] = 0;
                        m_fish.Add(FishType.Cod , size) ;
                        break;
                    case "Blue_Mackerel":
                        
                        break;
                }
            }

            return;            
        }       
    }
}

