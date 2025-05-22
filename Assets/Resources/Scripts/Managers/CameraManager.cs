using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PunchPunchmaeum
{
    public enum ECameraState
    {
        Default = 0,

        Weaving,
        Sequence,
    }

    public class CameraManager : MonoBehaviour
    {
        [Header("Camera Manager")]
        [SerializeField] private CinemachineBrain brain;
        [SerializeField] private CinemachineVirtualCamera currentVirtualCamera;
        [SerializeField] private List<CinemachineVirtualCamera> virtualCameras;
        [SerializeField] private Transform virtualCameraGroup;
        public Dictionary<ECameraState, CinemachineVirtualCamera> Dic_Camera;

        [Header("Camera Extensions")]
        [SerializeField] private CinemachineImpulseSource impulseSource;

        [Header("Camera Values")]
        [SerializeField] private ECameraState currentCameraState;
        [SerializeField] private ECameraState prevCameraState;
        [SerializeField] private List<SO_CameraData> cameraSetting;
        [SerializeField] private SO_CameraData currentCameraData;
        [SerializeField] private SO_CameraShake cameraShake;
        [SerializeField] private Character owner;
        private Dictionary<Tuple<EFightingStance , ECharacterState>, SO_CameraData> Dic_CameraDatas;

        [Header("[Camera Dolly Track]")]
        [SerializeField] private CinemachineSmoothPath dollyPath;

        [Header("Coroutine")]
        private Coroutine C_CameraOffset;
        private Coroutine C_CameraScreen;
        private Coroutine C_CameraDistance;
        private Coroutine C_CameraDamping;

        private void Start()
        {
            OnInitialize();
        }

        private void LateUpdate()
        {
            
        }

        private void OnInitialize()
        {
            // 초기화

        }

        // owner 스탠스에 따른 카메라 업데이트 함수
        private void UpdateCamera()
        {
            if (owner == null)
                return;

            Tuple<EFightingStance, ECharacterState> key = new Tuple<EFightingStance, ECharacterState>(owner.locomotionData.stance, owner.locomotionData.characterState);
            if(Dic_CameraDatas.ContainsKey(key))
            {
                currentCameraData = GetCameraData(key.Item1, key.Item2);

                switch(currentCameraState)
                {
                    case ECameraState.Default:
                        
                        break;

                    case ECameraState.Weaving:
                        break;
                }
                
            }


        }
        private void SetCameraScreen(Vector2 cameraScreen , float duration)
        {
            if (C_CameraScreen != null) StopCoroutine(C_CameraScreen);
            C_CameraScreen = StartCoroutine(CameraScreen(cameraScreen, duration));
        }
        private void  SetOffsetData(Vector3 offset , float duration )
        {
            if (C_CameraOffset != null) StopCoroutine(C_CameraOffset);
            C_CameraOffset = StartCoroutine(CameraOffset(offset, duration));
            
        }

        // 카메라 데이터 가져오는 함수
        private SO_CameraData GetCameraData(EFightingStance mode , ECharacterState characterState)
        {
            return cameraSetting.Find(data => data.stance == mode & data.characterState == characterState);
        }


        // 코루틴
        private IEnumerator CameraOffset(Vector3 offset, float duration)
        {
            yield return new WaitForSeconds(duration);
        }

        private IEnumerator CameraScreen(Vector2 cameraScreen , float duration)
        {
            yield break;
        }

    }
}