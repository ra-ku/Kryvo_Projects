using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PunchPunchmaeum
{
    public class ResourceManager
    {
        //1. 생성
        public GameObject Instantiate(string path, Transform parent = null)
        {
            GameObject prefab = Load<GameObject>($"Prefab/{path}");

            if(prefab == null ) 
            {
                Debug.Log($"Failed to Load prefabs: {path}");
                return null;
            }

            return Object.Instantiate(prefab, parent);
        }

        //2. 삭제
        public void Destroy(GameObject go , float? time = null)
        {
            if(go ==null)
            {
                return;
            }

            if(time.HasValue)
            {
                Object.Destroy(go, time.Value);
            }
            else
                Object.Destroy(go);
        }

        //3. 경로 설정
        public T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);            
        }       
    }
}

