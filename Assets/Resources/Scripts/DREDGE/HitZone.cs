using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DREDGE
{
    public class HitZone
    {
        public float startAngle;
        public float endAngle;

        public HitZone(float start, float end)
        {
            this.startAngle = start;
            this.endAngle = end;
        }

        public bool IsWithin(float angle)
        {
            angle = (angle + 360f) % 360f;
            float start = (startAngle + 360f) % 360f;
            float end = (endAngle + 360f) % 360f;

            if (start <= end)
                return angle >= start && angle <= end;
            else 
                return angle >= start || angle <= end;
        }


    }
}

