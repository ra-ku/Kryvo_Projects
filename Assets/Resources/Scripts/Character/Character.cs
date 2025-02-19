using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PunchPunchmaeum
{
    public class Character : CharacterBase
    {
        [Header("Character - Component")]
        [HideInInspector] CharacterController characterController;
        [HideInInspector] AnimationEvent animationEvent;
        [HideInInspector] ComboComponent comboComponent;
        [HideInInspector] AttributeManager attributeManager;

        [Header("Character - Coroutine")]
        [HideInInspector] Coroutine C_LookAt;
        void Start()
        {
            Initialize();
        }

        protected override void Initialize()
        {
            characterController = GetComponent<CharacterController>();
            animationEvent = GetComponent<AnimationEvent>();
            comboComponent = GetComponent<ComboComponent>();
            attributeManager = GetComponent<AttributeManager>();
        }
    }
}

