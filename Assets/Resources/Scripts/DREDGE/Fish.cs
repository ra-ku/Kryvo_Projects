using DREDGE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DREDGE
{
    public class Fish : IFishData
    {
        private FishType _type = FishType.None;
        public string name { get; private set; }
        private string description;

        public Fish(FishType type, string name)
        {
            this._type = type;
            this.name = name;
        }

        public void SetDescription(string description)
        {
            this.description = description;
            Debug.Log($"Description Set: {description}");
        }
    }
}

