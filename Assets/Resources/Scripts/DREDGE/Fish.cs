using DREDGE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DREDGE
{
    public class Fish
    {
        private FishType _type = FishType.None;
        private string description;
        public string name { get; private set; }
        public int[,] size { get; private set; }




        public Fish(FishType type, string name, int[,] size)
        {
            this._type = type;
            this.name = name;
            this.size = size;
        }

        public void SetDescription(string description)
        {
            this.description = description;
            Debug.Log($"Description Set: {description}");
        }
    }
}

