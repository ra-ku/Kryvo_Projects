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
            FishingStick,            
            Fish,
            FishingBackGround,
            HitZone,
            HitZone1,
            HitZone2,
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

            HitZone[] hitzones = FishingManager.Instance.GetHitZone();
            OnHitZoneChanged(hitzones);
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

