using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PunchPunchmaeum
{
    public class Managers : MonoBehaviour
    {
        static Managers s_Instance;
        public static Managers Instance { get { return s_Instance; } }
        PlayerController playerController = new PlayerController();
        public static PlayerController _playerController  { get { return Instance.playerController; } }


    void Start()
        {
            //√ ±‚»≠
            s_Instance = this;

            GameObject go = GameObject.Find("@Managers");
            s_Instance = go.GetComponent<Managers>();
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
