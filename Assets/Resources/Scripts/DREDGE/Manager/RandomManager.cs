using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DREDGE
{
    public class RandomManager : IManager
    {
        #region Instance
        private static RandomManager _instance;
        public static RandomManager Instance
        {
            get
            {
                if( _instance == null )
                    _instance = new RandomManager();
                return _instance;
            }
        }
        #endregion

        //랜덤매니저 구현
        public IManager Init()
        {
            Debug.Log("RandomManager is Initialized");
            return this;         
        }
    }
}


