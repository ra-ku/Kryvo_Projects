using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PunchPunchmaeum
{
    public class PlayerCharacter : Character
    {
        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            base.Update();
        }
        protected override void Initialize()
        {
            base.Initialize();
            SetCharacterTag("Player");
        }

        protected override void PostInitialize()
        {
            base.PostInitialize();
            print("½ÇÇà");
        }

        protected override void OnControllerColliderHit(ControllerColliderHit hit)
        {
            base.OnControllerColliderHit(hit);
        }


    }
}

