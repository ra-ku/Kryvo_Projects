using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DREDGE
{
    public enum EBoatState
    {
        None = 0,        
    }
    public class BoatSizeStateManager : IManager
    {
        #region instance
        private static BoatSizeStateManager _instance;
        public static BoatSizeStateManager Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new BoatSizeStateManager();
                return _instance;
            }
        }
        #endregion

        public IManager Init()
        {
            return this;
        }

        private int[,] currentBoatGrid;
        public int[,] GetCurrentGrid() => currentBoatGrid;

        public BoatSizeStateManager ()
        {
            int[,] baseGrid = Constant.BoatSize.DEFAULT_SHIP;
            currentBoatGrid = (int[,]) baseGrid.Clone();
        }

        public bool CanPlaceFish(int startX, int startY, Fish fish)
        {
            ////TODO
            return false;
        }

        public void PlaceFish(int startX, int startY, Fish fish)
        {
            ////TODO
        }

        public void CancelFish(int startX, int startY, Fish fish)
        {
            ////TODO 
        }
    }
}

