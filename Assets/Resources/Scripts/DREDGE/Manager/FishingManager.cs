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
        private int successTime;
        private int failureTime;

        [Header("Component")]
        private FishingBlock _block = new();
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

            // UI 생성
            UIManager.ShowSceneUI<UI_DREDGE>("UI_DREDGE");
        }

        public void FinishingFishing()
        {
            ////TODO 
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
