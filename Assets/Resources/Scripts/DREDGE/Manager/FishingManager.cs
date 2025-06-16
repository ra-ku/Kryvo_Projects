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
        private float _currentfishingStickAngle;
        private float fishingGage;
        private int successTime;
        private int failureTime;

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
            successTime = 0;
            failureTime = 0;

            // block 초기화
            _block.InitializeHitZone();

            // hitZone 설정
            hitzones = _block.PickRandomZones(3,false);
            for(int i=0; i<hitzones.Length; i++)
            {
                float span = hitzones[i].maxAngle - hitzones[i].minAngle;
                if(span < 0)
                {
                    span += 360;
                }
                Debug.Log($"hitzone의 최저각도 {hitzones[i].minAngle}");
                Debug.Log($"hitzone의 최고각도 {hitzones[i].maxAngle}");
                Debug.Log($"hitzones {span}");
            }

            // UI 생성
            _ui = UIManager.ShowSceneUI<UI_DREDGE>("UI_DREDGE");            
        }

        public void FinishingFishing()
        {
            //TODO 
            isActiveFishing = false;
            successTime = 0;
            failureTime = 0;
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

        public void FishingGageHandle()
        {
            // HitZone을 맞추면 일정 비율 상승
            // HitZone을 못맞추면 일정 비율 하락
        }

        public void CheckFishingStickInHitZone()
        {
            if (!isActiveFishing || _ui == null)
                return;
            
            float angle = _ui.GetUIValue();
            Debug.Log($"{angle}");
            if (hitzones[0].minAngle <= angle && hitzones[0].maxAngle >= angle)
            {
                Debug.Log("성공");
            }
            if (hitzones[1].minAngle <= angle && hitzones[1].maxAngle >= angle)
            {
                Debug.Log("성공2");
            }
            if (hitzones[2].minAngle <= angle && hitzones[2].maxAngle >= angle)
            {
                Debug.Log("성공3");
            }
        }

        public bool IsActiveFishing()
        {
            return isActiveFishing;
        }

        public float GetFishingGage()
        {
            return fishingGage;
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
    }
}
