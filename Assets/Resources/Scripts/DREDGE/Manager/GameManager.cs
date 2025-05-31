using System.Collections.Generic;
using UnityEngine;

namespace DREDGE
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private List<IManager> _managers = new();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            _managers.Add(FishingManager.Instance);
            _managers.Add(RandomManager.Instance);
        }

        private void Start()
        {
            foreach (var manager in _managers)
            {
                manager.Init();
            }
        }
    }
}
