using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

namespace Default
{
    public sealed class MouseClickableComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnObjectClick;
        [SerializeField] private UnityEvent OnObjectRightClick;



        public void LeftMouseClick()
        {
            Debug.Log("I clicked " + gameObject.name);
            OnObjectClick?.Invoke();
        }

        public void RightMouseClick()
        {
            Debug.Log("I right clicked " + gameObject.name);
            OnObjectRightClick?.Invoke();
        }
    }
}