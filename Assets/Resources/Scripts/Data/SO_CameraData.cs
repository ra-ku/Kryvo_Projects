using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PunchPunchmaeum
{
    [CreateAssetMenu(menuName = "PunchPunchmaeum/ScriptableObject/Camera Data", fileName = "CameraData")]
    public class SO_CameraData : ScriptableObject
    {
        [Header("Camara Setting")]
        public ECameraState cameraState;
        public ECharacterState characterState;
        public EFightingStance stance;
        public Vector3 cameraOffset;
        public Vector2 cameraScreen;
        public Vector3 cameraDamping;
        public float cameraDistance;
        public float duration;
    }
}
