using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PunchPunchmaeum
{
    [System.Serializable]
    public struct DamageInfo
    {
        [Header("[Damage Info]")]
        public Character causer;
        public float damageAmount;
        public UnityEvent OnDamage;

        public DamageInfo(Character causer, float damageAmount, UnityEvent onDamage)
        {
            this.causer = causer;
            this.damageAmount = damageAmount;
            this.OnDamage = onDamage;
        }
    }

    public interface IDamageable
    {
        public void TakeDamage(DamageInfo damageInfo);
        public void Dead(DamageInfo damageInfo);
    }

}

