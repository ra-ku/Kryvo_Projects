using PunchPunchmaeum;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    public static Vector3 GetDirection(Vector3 to, Vector3 from , bool ignoreY = true )
    {
        if(ignoreY)
        {
            to.y = 0.0f; from.y = 0.0f;
        }

        Vector3 direction = (to - from).normalized;
        return direction;
    }
}
