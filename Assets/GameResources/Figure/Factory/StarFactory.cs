using System;
using Sorter.Types;
using UnityEngine;
using Zenject;

namespace Sorter.Figure
{
    public class StarFactory : BaseFactory
    {
        protected override FigureType Type => FigureType.Star;

        public StarFactory(Setting setting, Spawner.Settings spawnSetting, MonoPool<FigureView> pool) : base(setting, spawnSetting, pool)
        {
        }
    }
}
