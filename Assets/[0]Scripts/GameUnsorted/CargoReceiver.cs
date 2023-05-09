using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System.Linq;

namespace Default
{
    internal sealed class CargoReceiver : MonoBehaviour
    {
        [SerializeField] private GatherableComponentType[] collectableTypes;
        [SerializeField] private AnimatedMover animatedMover;

        [Space]
        [SerializeField] private UnityEvent OnTriggerEnterAction;
        [SerializeField] private UnityEvent OnTriggerExitAction;



        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<GatherableComponent>(out var comp))
            {
                if (comp.IsGathering)
                    return;

                if (collectableTypes.Length > 0 && collectableTypes.Contains(comp.GatherType))
                {
                    comp.IsGathering = true;
                    OnTriggerEnterAction?.Invoke();
                }

                animatedMover.Move(other.transform,()=>
                {
                    LevelManager.Instance.CurrentCounterMission++;
                    Destroy(other.gameObject);
                    OnTrigerExit(other);
                });
            }            
        }

        private void OnTrigerExit(Collider other)
        {
            if (other.TryGetComponent<GatherableComponent>(out var comp))
            {
                if (!comp.IsGathering)
                    return;

                comp.IsGathering = false;
                OnTriggerExitAction?.Invoke();
            }
        }

        private void GatherComponent(GatherableComponent component)
        {

        }

    }
}
