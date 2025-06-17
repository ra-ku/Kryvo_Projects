using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DREDGE
{
    public class FishingManager : IManager
    {
        // 낚시 미니게임의 전반적인 시작과 끝을 다루기 위한 코드
        #region instance
        private static FishingManager _instance;
        public static FishingManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FishingManager();
                }
                return _instance;
            }
        }
        #endregion 

        [Header("Value")]
        private bool isActiveFishing;
        private float fishingGage;
        private float maxFishingGage;

        [Header("Component")]
        private FishingBlock _block = new();
        private UI_DREDGE _ui;
        private HitZone[] hitzones;

        public IManager Init()
        {
            Debug.Log("FishingManager Initialized");
            return this;
        }

        public void StartFishing()
        {
            isActiveFishing = true;
            fishingGage = 0;
            maxFishingGage = 300;
          
            _block.InitializeHitZone();
            hitzones = _block.PickRandomZones(3,false);
            _ui = UIManager.ShowSceneUI<UI_DREDGE>("UI_DREDGE");            
        }

        public void FinishingFishing()
        {
            isActiveFishing = false;
        }

        public void Tick()
        {
            if (!isActiveFishing)
            {                
                return;
            }

            Debug.Log("키를 입력함!");
            
            CheckFishingStickInHitZone();
        }

        public void FishingGageHandle(float value =0.0f)
        {
            
            if (fishingGage < maxFishingGage)
            {
                fishingGage += value;
                Debug.Log($"fishingGage = {fishingGage}");
            }
            else                                                                     
            {
                FinishingFishing();
            }
        }

        public void CheckFishingStickInHitZone()
        {
            if (!isActiveFishing || _ui == null)
                return;
            
            float angle = _ui.GetUIValue();
            bool inZone = false;

            foreach(var hitzone in hitzones)
            {
                if(angle >= hitzone.minAngle && angle <= hitzone.maxAngle)
                {
                    inZone = true;
                    Debug.Log("성공");
                }
            }

            if(inZone)
            {
                FishingGageHandle(100.0f);
            }
            else
            {
                Debug.Log("실패");
                FishingGageHandle(-150.0f);
            }
        }



        #region Get
        public bool IsActiveFishing()
        {
            return isActiveFishing;
        }

        public float GetFishingGage()
        {
            return fishingGage;
        }
        public float GetMaxFishingGage()
        {
            return maxFishingGage;
        }

        public HitZone[] GetHitZone()
        {            
            if (hitzones.Length < 3 )
            {
                Debug.Log("hitZone is Null");
                return null;
            }
            else
            {
                return hitzones;
            }
        }
        #endregion
    }
}
