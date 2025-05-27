using UnityEngine;

namespace DREDGE
{
    public class FishingManager : IManager
    {
        #region ΩÃ±€≈Ê
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
            
        }

        public void FinishingFishing()
        {
            ////TODO 
            isActiveFishing = false;
        }
    }
}
