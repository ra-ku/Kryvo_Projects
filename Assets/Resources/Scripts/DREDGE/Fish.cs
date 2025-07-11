using DREDGE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DREDGE
{
    public class Fish
    {
        private FishType _type = FishType.None;

        public string name { get; private set; }
        public int[,] size { get; private set; }

        public int Width => size.GetLength(1);
        public int Height => size.GetLength(0);
        private string description;

        public Fish(FishType type, string name, int[,] size, string description ="")
        {
            this._type = type;
            this.name = name;
            this.size = size;
            this.description = description;
        }

        public void SetDescription(string description)
        {
            Debug.Log($"Description Set: {description}");
        }
    }
}

