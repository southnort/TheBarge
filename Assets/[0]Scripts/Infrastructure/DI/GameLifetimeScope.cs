using Game.Infrastructure.GameSystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;


public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private MonoBehaviour[] monobehServices;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<GameManager>(Lifetime.Singleton);

        foreach (var service in monobehServices)
        {
            var type = service.GetType();
            builder.Register(type, Lifetime.Singleton);

        }
    }
}
