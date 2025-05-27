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

        }

        enum Images
        {

        }

        enum GameObjects
        {

        }

        [Header("component")]
        UIManager ui = new UIManager();

        // Start is called before the first frame update
        void Start()
        {
            init();
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

