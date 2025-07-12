using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DREDGE
{
    public class MouseEventHandler : IManager
    {
        #region instance
        private static MouseEventHandler _instance;
        public static MouseEventHandler Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new MouseEventHandler();
                return _instance;
            }
        }
        #endregion

        public IManager Init()
        {
            return this;
        }

        private Action<Vector2> OnMouseClick;
        private Action<Vector2> OnMouseDrag;
        private Action<Vector2> OnMouseRelease;

        private bool _isDragging = false;

        public void RegisterClickCallback(Action<Vector2> callback)
        {
            OnMouseClick += callback;
        }

        public void UnregisterClickCallback(Action<Vector2> callback)
        {
            OnMouseClick -= callback;
        }

        public void HandleMouseClick(Vector2 screenPos)
        {
            OnMouseClick?.Invoke(screenPos);
        }

    }
}

