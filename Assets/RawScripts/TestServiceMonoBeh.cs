using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Yarigg
{
    internal sealed class TestServiceMonoBeh : MonoBehaviour
    {

        public void TestMethod()
        {
            Debug.Log(this.GetType().Name + " Succcess");
        }
    }
}
