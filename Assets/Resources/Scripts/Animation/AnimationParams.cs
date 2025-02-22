using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PunchPunchmaeum
{
    public static class AnimationParams
    {
        [Header("Enum Params")]

        [Header("Integer Params")]

        [Header("Float Params")]

        [Header("Bool Params")]

        [Header("Trigger Params")]
        public static readonly int HASH_DEAD = Animator.StringToHash("Dead");

        [Header("Animation Curve Params")]
        public static readonly int HASH_MOVE_SPEED = Animator.StringToHash("MoveSpeed");
    }
}
