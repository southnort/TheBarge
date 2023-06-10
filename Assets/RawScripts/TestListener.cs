using UnityEngine;
using UnityEngine.UI;
using TMPro;
using VContainer;
using Game.Infrastructure.GameSystem;

namespace Yarigg
{
    internal sealed class TestListener : MonoBehaviour,ITickable
    {
        private TickableProcessor _monoBeh;
        private TestScriptService _noMonoBeh;

        [Inject]
        public void Construct(TickableProcessor tick)
        {
            Debug.Log("Inject");
            //_noMonoBeh = nomonoBeh;
            //_noMonoBeh.TestMethod();

            _monoBeh = tick;
            _monoBeh.AddTickable(this);            
        }

        public void Tick(float deltaTime)
        {
            Debug.Log("Im im m");
        }
    }
}
