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

        }

        private void FindComponent()
        {
            
        }
    }
}

