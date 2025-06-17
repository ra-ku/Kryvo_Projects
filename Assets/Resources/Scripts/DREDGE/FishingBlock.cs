using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DREDGE
{
    public class FishingBlock
    {        
        private List<HitZone> hitZone = new();        

        public void InitializeHitZone()
        {            
            hitZone.Add(new HitZone(10f, 30f));
            hitZone.Add(new HitZone(110f, 130f));
            hitZone.Add(new HitZone(210f, 230f));
            hitZone.Add(new HitZone(60f, 80f));
            hitZone.Add(new HitZone(300f, 320f));
            hitZone.Add(new HitZone(250, 270f));
        }

        public HitZone PickRandomZone()
        {
            HitZone[] result = RandomManager.Instance.RandomInCollection(hitZone, 1, false);
            return (result != null && result.Length > 0) ? result[0] : null;
        }

        public HitZone[] PickRandomZones(int amount, bool allowDuplicate)
        {
            return RandomManager.Instance.RandomInCollection(hitZone, amount, allowDuplicate);
        }
    }
}
