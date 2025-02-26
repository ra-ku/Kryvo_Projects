using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PunchPunchmaeum
{
    public class Managers : MonoBehaviour
    {
        static Managers s_Instance;
        public static Managers Instance { get { return s_Instance; } }
        ResourceManager resourcesManager = new ResourceManager();
        public static ResourceManager _resourcesManager { get { return Instance.resourcesManager; } }

        void Start()
        {
            init();
        }

        static void init()
        {            
            if (s_Instance == null)
            {
                GameObject go = GameObject.Find("@Managers");
                if (go == null)
                {
                    go = new GameObject { name = "@Managers" };
                    go.AddComponent<Managers>();
                }

                DontDestroyOnLoad(go);
                s_Instance = go.GetComponent<Managers>();
            }
        }
    }
}
