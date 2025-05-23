using UnityEngine;

namespace DREDGE
{
    public class FishingManager : IManager
    {
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

        private FishingManager()
        {
            
        }

        public IManager Init()
        {
            Debug.Log("FishingManager Initialized");
            return this;
        }
    }
}
