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
        private int successTime;
        private int failureTime;

        private FishingBlock _block = new ();

        public IManager Init()
        {
            Debug.Log("FishingManager Initialized");
            return this;
        }

        public void StartFishing()
        {
            ////TODO 
            isActiveFishing = true;
            successTime = 0;
            failureTime = 0;


            // block 초기화
            _block.InitializeHitZone();
            
        }

        public void FinishingFishing()
        {
            ////TODO 
            isActiveFishing = false;
        }

        public void Tick()
        {
            if (!isActiveFishing)
            {
                return;
            }
        }

        public bool IsActiveFishing()
        {
            return isActiveFishing;
        }

    }
}
