using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DREDGE
{
    public class UI_DREDGE : UI_Base
    {
        enum Sliders
        {
            FishingGage,
        }

        enum Images
        {
            //Fishing
            FishingStick,            
            Fish,
            FishingBackGround,
            HitZone,
            HitZone1,
            HitZone2,

            //Freight
            FishingFreightBackGround,
            BoatSize,
            BoatSize1,
            BoatSize2,
            BoatSize3,
            BoatSize4,
            BoatSize5,
            BoatSize6,
            BoatSize7,
            BoatSize8,
            BoatSize9,
            BoatSize10,
            BoatSize11,
            BoatSize12,
            BoatSize13,
            BoatSize14,
            BoatSize15,
            BoatSize16,
            BoatSize17,
            BoatSize18,
            BoatSize19,
            BoatSize20,
            BoatSize21,
            BoatSize22,
            BoatSize23,
            BoatSize24,
            BoatSize25,
            BoatSize26,
            BoatSize27,
            BoatSize28,
            BoatSize29,
            BoatSize30,
            BoatSize31,
            BoatSize32,
            BoatSize33,
            BoatSize34,
            BoatSize35,
        }

        enum GameObjects
        {

        }

        [Header("component")]
        UIManager ui = new UIManager();

        [Header("Image")]
        private Image fishingStick;
        private Image fish;
        private Image fishingBackground;
        private Image hitZone;
        private Image hitZone1;
        private Image hitZone2;

        private Image[] boatSize = new Image[36];  

        [Header("Slider")]
        private Slider fishingGage;

        void Start()
        {
            init();

            //mapping
            fishingStick = Get<Image>((int)Images.FishingStick);
            fish = Get<Image>((int)Images.Fish);
            fishingBackground = Get<Image>((int)Images.FishingBackGround);
            hitZone = Get<Image>((int)Images.HitZone);
            hitZone1 = Get<Image>((int)Images.HitZone1);
            hitZone2 = Get<Image>((int)Images.HitZone2);

            fishingGage = Get<Slider>((int)Sliders.FishingGage);


            for (int i = 0; i < boatSize.Length; i++)
            {
                boatSize[i] = Get<Image>((int)Images.BoatSize + i);
            }

            HitZone[] hitzones = FishingManager.Instance.GetHitZone();
            OnHitZoneChanged(hitzones);
            ApplyBoatSize();
        }

        private void init()
        {
            ui.SetCanvas(gameObject, false);

            Bind<Slider>(typeof(Sliders));
            Bind<GameObject>(typeof(GameObjects));
            Bind<Image>(typeof(Images));

            FindComponent();
        }

        // Update is called once per frame
        void Update()
        {
            FishingStick_UI();
            FishingGage_UI();
            UpdateBoatUI();
        }

        public void FishingStick_UI()
        {
            if (fishingStick != null)
            {
                float deltaAngle = Constant.RotationSpeed.STICK_ROTATION_SPEED * Time.deltaTime;
                RectTransform rt = fishingStick.rectTransform;                
                Vector3 euler = rt.localEulerAngles;

                float newZ = euler.z - deltaAngle;
                if (newZ >= 360f) newZ -= 360f;
                
                rt.localEulerAngles = new Vector3(0,0,newZ);
            }
            else
                return;
        }

        public void FishingGage_UI()
        {
            
            if (fishingGage != null)
            {
                
                float currentFishingGage = FishingManager.Instance.GetFishingGage();                
                float maxFishingGage = FishingManager.Instance.GetMaxFishingGage();

                if (maxFishingGage <= 0f)
                    return;

                fishingGage.normalizedValue = Mathf.Clamp01(currentFishingGage / maxFishingGage);
            }
            else
                return;
        }

        public void OnHitZoneChanged(HitZone[] hitzones)
        {
            if (hitzones.Length < 3 || hitzones == null)
                return;
            if (hitZone == null || hitZone1 == null || hitZone2 == null)
                return;

            float hitzone_min = hitzones[0].minAngle;
            float hitzone_max = hitzones[0].maxAngle;
            UpdateSingleHitZoneUI(hitZone, hitzone_min, hitzone_max);

            float hitzone1_min = hitzones[1].minAngle;
            float hitzone1_max = hitzones[1].maxAngle;
            UpdateSingleHitZoneUI(hitZone1, hitzone1_min, hitzone1_max);

            float hitzone2_min = hitzones[2].minAngle;
            float hitzone2_max= hitzones[2].maxAngle;
            UpdateSingleHitZoneUI(hitZone2, hitzone2_min, hitzone2_max);
        }

        public void UpdateSingleHitZoneUI(Image img, float minAngle, float maxAngle)
        {
            float span = maxAngle - minAngle;
            if (span < 0f) span += 360f;

            img.type = Image.Type.Filled;
            img.fillMethod = Image.FillMethod.Radial360;
            img.fillOrigin = 2;      
            img.fillClockwise = false;

            float clampedSpan = Mathf.Clamp(span, 0f, 360f);
            img.fillAmount = clampedSpan / 360f;

            img.rectTransform.localRotation = Quaternion.Euler(0f, 0f, minAngle);
        }

        public void ApplyBoatSize()
        {
            int[,] _boatGrid = Constant.BoatSize.DEFAULT_SHIP;
            int gridRows = _boatGrid.GetLength(0);
            int gridCols = _boatGrid.GetLength(1);

            int uiIndex = 0; 

            for(int y =0; y < gridRows; y++ )
            {
                for (int x = 0; x < gridCols; x++)
                {
                    if (_boatGrid[y, x] == 1)
                        continue;

                    Debug.Log($"행 : {y} , 열 : {x}");

                    Image img = boatSize[uiIndex];
                    
                    if (img == null)
                    {
                        Debug.LogError("boat image is null");
                    }
                    uiIndex++;
                }
            }
        }

        public void UpdateBoatUI()
        {
            // boatSize1 ~ 35개 이미지에서 36개의 그래픽 레이캐스트를 사용해서 물고기 ui가 해당 ray를 가린다면 boatSize의 이미지 색 변화
            // 

        }


        private void FindComponent()
        {
            
        }

        public float GetUIValue()
        {
            if (fishingStick == null)
            {
                return 0.0f;
            }
            else
            {
                float localZvalue = fishingStick.rectTransform.localEulerAngles.z;
                return localZvalue;
            }
        }
    }
}

