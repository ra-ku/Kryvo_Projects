using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using Unity.VisualScripting;

namespace PunchPunchmaeum
{   
    public class PlayerController : MonoBehaviour
    {
        static PlayerController Instance;
        public static PlayerController _playerController { get { return Instance; } }

        [Header("Input Actions")]
        [SerializeField] private InputActionReference moveActionReference;
        [SerializeField] private InputActionReference AttackActionReference;

        [Header("[Character]")]
        [SerializeField] private Character owner;

        [Header("Character - state")]
        public EFightingStance eFightingStance;
        public ECharacterState eCharacterState;

        [Header("Field")]
        public bool isattack;
        private void OnEnable()
        {
            moveActionReference.action.Enable();
            AttackActionReference.action.Enable();

            AttackActionReference.action.performed += OnAttackPerformed;
            moveActionReference.action.performed += OnMovePerformed;
        }

        private void OnDisable()
        {
            AttackActionReference.action.performed -= OnAttackPerformed;
            moveActionReference.action.performed -= OnMovePerformed;
            moveActionReference.action.Disable();
            AttackActionReference.action.Disable();
        }

        private void Awake()
        {
            Init();
            Instance = this;
        }
        private void Start()
        {
            
        }

        private void Init()
        {
            owner = GetComponent<Character>();
            if (owner == null)
            {
                Debug.LogError("Init failed: owner is null.");
                return;
            }

            eFightingStance = EFightingStance.DefaultStance;
            eCharacterState = ECharacterState.Alive;
        }

        private void OnAttackPerformed(InputAction.CallbackContext context)
        {

            if (context.performed && eFightingStance == EFightingStance.DefaultStance)
            {
                if(isattack)
                {
                    return;
                }
                print("공격실행");
                owner.characterAnim.SetInteger(AnimationParams.HASH_FIGHT, 2);
            }  
        }      

        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            Debug.Log("Weaving!");
        }
    }
}
