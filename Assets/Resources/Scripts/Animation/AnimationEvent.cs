using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PunchPunchmaeum
{
    public class AnimationEvent : MonoBehaviour
    {
        [Tooltip("[This is an event script used in animation clips]")]
        private Character owner;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            owner = GetComponent<Character>();
            if (owner == null)
                Debug.Log("Failed to Find Owner");
        }

        public void OnAttack()
        {
            if (PlayerController._playerController == null)
            {
                Debug.LogError("PlayerController is not initialized.");
                return;
            }
            else
            {                
                PlayerController._playerController.eFightingStance = EFightingStance.AttackStance;
                PlayerController._playerController.isattack = true;
                print(PlayerController._playerController.eFightingStance);
            }
        }

        public void OffAttack()
        {
            if (PlayerController._playerController == null)
            {
                Debug.LogError("PlayerController is not initialized.");
                return;
            }
            else
            {
                PlayerController._playerController.eFightingStance = EFightingStance.DefaultStance;
                print(PlayerController._playerController.eFightingStance);
                PlayerController._playerController.isattack = false;
                owner.characterAnim.SetInteger(AnimationParams.HASH_FIGHT, 1);
            }
        }
    }
}
