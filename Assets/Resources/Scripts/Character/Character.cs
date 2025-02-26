using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.Events;


namespace PunchPunchmaeum
{
    public class Character : CharacterBase , IDamageable
    {
        [Header("Character - Component")]
        [HideInInspector] CharacterController characterController;
        [HideInInspector] AnimationEvent animationEvent;
        [HideInInspector] ComboComponent comboComponent;
        [HideInInspector] AttributeManager attributeManager;
        [HideInInspector] PlayerController playerController;

        [Header("Character-Data")]
        public LocomotionData locomotionData;
        [SerializeField] private string characterTag;

        [Header("Character - Option")]
        public CharacterOptional characterOptional;
        [SerializeField] private List<Rigidbody> ragdollRigs = new List<Rigidbody>();


        protected override void Awake()
        {
            base.Awake();
            Initialize();
        }
        protected virtual void Start()
        {
            PostInitialize();           
        }

        protected virtual void Update()
        {

        }

        protected override void Initialize()
        {
            characterController = GetComponent<CharacterController>();
            animationEvent = GetComponent<AnimationEvent>();
            comboComponent = GetComponent<ComboComponent>();
            attributeManager = GetComponent<AttributeManager>();
            playerController = GetComponent<PlayerController>();


            SetLocomotionData();
        }

        protected virtual  void PostInitialize()
        {
            InitRagdoll();
        }

        protected virtual void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.rigidbody != null)
            {
                if (characterAnim.applyRootMotion)
                {
                    hit.rigidbody.AddForce(hit.moveDirection * characterAnim.velocity.magnitude, ForceMode.Impulse);
                }
            }
        }

        protected virtual void  SetLocomotionData()
        {
            //characterController
            characterController.skinWidth = locomotionData.CharacterControllerSetting.skinWidth;
            characterController.slopeLimit = locomotionData.CharacterControllerSetting.slopeLimit;
            characterController.stepOffset = locomotionData.CharacterControllerSetting.stepOffset;
            characterController.minMoveDistance = locomotionData.CharacterControllerSetting.min_Move_Distance;
            characterController.center = locomotionData.CharacterControllerSetting .center;
            characterController.radius = locomotionData.CharacterControllerSetting.radius;
            characterController.height = locomotionData.CharacterControllerSetting.height;
        }
        public virtual void TakeDamage(DamageInfo damageinfo)
        {
            if(damageinfo.damageAmount > 0.0f)
            {
                attributeManager.DecreaseAttribute(EAttributeType.Health, damageinfo.damageAmount);
                if(attributeManager.GetAttributeAmount(EAttributeType.Health) <0.0f)
                {
                    attributeManager.OnDeadAction?.Invoke(damageinfo);
                }
            }

            damageinfo.OnDamage?.Invoke();
        }
        
        public virtual void Dead(DamageInfo damageInfo)
        {
            Vector3 direction = Util.GetDirection(damageInfo.causer.transform.position, transform.position, false);
            if (characterOptional.useRagdoll)
            {
                SetRagdoll(true);
                Rigidbody hipsRig = characterAnim.GetBoneTransform(HumanBodyBones.Hips).GetComponent<Rigidbody>();
                if (hipsRig != null)
                {
                    hipsRig.AddForce(direction * ((hipsRig.mass * damageInfo.damageAmount) * 0.5f), ForceMode.Impulse);
                }
            }
            else
            {
                characterAnim.CrossFadeInFixedTime(AnimationParams.HASH_DEAD, 0.1f);
            }
            Physics.IgnoreCollision(characterController, damageInfo.causer.characterController, true);
        }

        private void InitRagdoll()
        {
            Rigidbody[] rigs = GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody rig in rigs)
            {
                ragdollRigs.Add(rig);
                rig.isKinematic = true;
            }
        }

        public void SetRagdoll(bool isEnable)
        {
            print("렉돌 세팅");
            characterAnim.enabled = !isEnable;
            ragdollRigs.ForEach(rig => rig.isKinematic = !isEnable);
        }

        public virtual void SetCharacterTag(string tag)
        {
            gameObject.tag = tag;
            characterTag = tag;
        }


    }
    
}

