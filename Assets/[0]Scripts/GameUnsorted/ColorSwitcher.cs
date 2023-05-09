using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Default
{
    internal sealed class ColorSwitcher : MonoBehaviour
    {
        [SerializeField] private MeshRenderer mRenderer;
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color inUseColor;


        private void Start()
        {
            defaultColor = mRenderer.material.color;
        }

        public void SetColorInUse()
        {
            mRenderer.material.color = inUseColor;
        }

        public void SetColorDefault()
        {
            mRenderer.material.color = defaultColor;
        }
    }
}
