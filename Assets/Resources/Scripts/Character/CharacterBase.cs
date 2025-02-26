using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PunchPunchmaeum
{
    public enum ECharacterType
    {
        Default = 0,

        Player,
        Enemy
    }

    public enum EFightingStance
    {
        Default = 0,
        
        DefaultStance,
        AttackStance,
        MovingStance
    }
    
    public enum ECharacterState
    {
        Default =0,

        Alive,
        Death,
    }

    [Serializable]
    public struct CharacterOptional
    {
        [Header("[Character Optional]")]
        public bool useRagdoll;

        [Header("[Camera Settings]")]
        public Transform cameraPivot;
    }

    // 캐릭터 필수 요소 필드 선언
    public abstract class CharacterBase : MonoBehaviour
    {

        [Header("component")]
        public  AudioSource characterAudio;
        public Animator characterAnim;

        protected virtual void Awake()
        {
            characterAudio = GetComponent<AudioSource>();
            characterAnim = GetComponent<Animator>();
        }

        protected abstract void Initialize();

    }
}

