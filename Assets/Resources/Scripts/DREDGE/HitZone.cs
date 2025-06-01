using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DREDGE
{
    public class HitZone
    {
        public float minAngle { get; private set; }
        public float maxAngle { get; private set; }


        public HitZone(float start, float end)
        {
            this.minAngle = start;
            this.maxAngle = end;
        }

        public bool IsWithin(float angle)
        {
            angle = (angle + 360f) % 360f;
            float start = (minAngle + 360f) % 360f;
            float end = (maxAngle + 360f) % 360f;

            if (start <= end)
                return angle >= start && angle <= end;
            else 
                return angle >= start || angle <= end;
        }
    }
}

