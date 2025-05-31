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
            
        }

        public void FinishingFishing()
        {
            ////TODO 
            isActiveFishing = false;
        }

        private void Tick()
        {
            if(isActiveFishing && Input.GetKeyDown(KeyCode.F))
            {
                //성공 판정 및 실패 판정
            }
        }


    }
}
