﻿namespace Game.Infrastructure.GameSystem
{
    public interface ITickable
    {
        void Tick(float deltaTime);
    }
}
