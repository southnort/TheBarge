using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Default
{
    public sealed class MouseCliclableComponent : MonoBehaviour
    {

        public void OnMouseDown()
        {
            Debug.Log("I clicked " + gameObject.name);
        }


    }
}
