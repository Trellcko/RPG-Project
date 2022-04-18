using System;
using UnityEngine;

namespace Trell.Core.Input
{
    public class InputHandler : MonoBehaviour
    {

        public static InputHandler Instace
        {
            get
            {
                if (s_instance == null)
                {
                    s_instance = new GameObject(nameof(InputHandler)).AddComponent<InputHandler>();
                }
                return s_instance;
            }
        }

        private static InputHandler s_instance;

        public event Action LeftButtonClicked;

        public event Action LeftButtonReleased;

        public bool IsMouseDown { get; private set; }

        private void Awake()
        {
            if (FindObjectsOfType<InputHandler>().Length > 1)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                LeftButtonClicked?.Invoke();
                IsMouseDown = true;
            }
            else if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                LeftButtonReleased?.Invoke();
                IsMouseDown = false;
            }
        }
    }
}