using Scripts.Services.PlayerProgressService;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Infrastructure.Factory
{
    public interface IGameFactory
    {
        void CreateLevel();
        void CreateDeathVFX(Vector3 at);
    }
}