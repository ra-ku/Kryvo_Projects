using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PunchPunchmaeum
{
    [System.Serializable]
    public struct CharacterControllerSetting
    {
        public float slopeLimit;
        public float stepOffset;
        public float skinWidth;
        public float min_Move_Distance;
        public Vector3 center;
        public float radius;
        public float height;
    }

    [CreateAssetMenu(menuName ="PunchPunchmaeum/ScriptableObject/Locomotion Data" , fileName ="locomotionData")]
    public class LocomotionData : ScriptableObject
    {
        [Header("CharacterControllerSetting")]
        public CharacterControllerSetting CharacterControllerSetting;
        [Header("Character_EFightStance")]
        public EFightingStance stance;
        [Header("Character_ECharacterState")]
        public ECharacterState characterState;
    }

}
