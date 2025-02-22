using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace PunchPunchmaeum
{
    public enum EAttributeType
    {
        Health,
        Stamina,
        Posture
    }

    public class AttributeManager : MonoBehaviour
    {
        public UnityAction<DamageInfo> OnDeadAction;

        public void DecreaseAttribute(EAttributeType eAttributeType , float Amount)
        {


        }

        public float GetAttributeAmount(EAttributeType eAttributeType)
        {
            return 0.0f;
        }
    }

    class Attribute
    {
        [Header("Attribute-Component")]
        [SerializeField]
        EAttributeType type;

        [Header("Attribute-Coroutine")]
        [SerializeField]
        Coroutine Regen;
    }
}

