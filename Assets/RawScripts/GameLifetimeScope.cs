using VContainer;
using VContainer.Unity;
using Yarigg;
using UnityEngine;
using System.Collections.Generic;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private MonoBehaviour[] monobehServices;

    protected override void Configure(IContainerBuilder builder)
    {
        foreach (var service in monobehServices)
        {
            var type = service.GetType();
            builder.Register(type, Lifetime.Singleton);

        }
        builder.Register<TestScriptService>(Lifetime.Singleton);
    }
}
