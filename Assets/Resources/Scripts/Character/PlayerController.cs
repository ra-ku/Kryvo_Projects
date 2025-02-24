using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

namespace PunchPunchmaeum
{   
    public class PlayerController : MonoBehaviour
    {
        [Header("Input Actions")]
        [SerializeField] private InputActionReference moveActionReference;
        [SerializeField] private InputActionReference AttackActionReference;


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
            moveActionReference.action.performed += OnMovePerformed;
            moveActionReference.action.Disable();
            AttackActionReference.action.Disable();
        }

        private void Awake()
        {
            
        }
        private void Start()
        {
            
        }

        private void OnAttackPerformed(InputAction.CallbackContext context)
        {
            // 공격 로직 처리
            Debug.Log("Attack!");
            
        }

        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            Debug.Log("Weaving!");
        }
    }
}
