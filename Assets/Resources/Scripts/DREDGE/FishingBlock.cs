using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DREDGE
{
    public class FishingBlock
    {        
        // HitZone을 몇번 성공시켰는지 확인 하기 위한 코드 
        [Tooltip("field")]
        private int successTime =0;
        private int successfulHitsRequired;

        private List<HitZone> hitZone = new();
        

        public void InitializeHitZone()
        {
            
            hitZone.Add(new HitZone(10f, 20f));

        }

        public bool CheckHit(float currentAngle)
        {
            foreach (var zone in hitZone)
            {
                if (zone.IsWithin(currentAngle))
                {
                    successTime++;
                    return true;
                }
            }
            return false;
        }








    }
}
