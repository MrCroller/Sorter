using System;
using System.Collections.Generic;
using Sorter.Conveyor;
using Sorter.Types;
using UnityEngine;
using Zenject;

namespace Sorter.Figure
{
    public abstract class BaseFactory : IFactory<FigureView>
    {
        protected abstract FigureType Type { get; }
        private readonly Setting setting;
        private readonly Spawner.Settings spawnSetting;
        private readonly MonoPool<FigureView> pool;

        public BaseFactory(Setting setting, Spawner.Settings spawnSetting, MonoPool<FigureView> pool)
        {
            this.setting = setting;
            this.spawnSetting = spawnSetting;
            this.pool = pool;
        }

        public virtual FigureView Create()
        {
            var view = pool.Get();
            view.Construct(Type,
                spawnSetting.SpeedRange.GetRandom(),
                setting.sprites.GetRandom());
            return view;
        }

        [Serializable]
        public class Setting
        {
            public Sprite[] sprites;
        }
    }
}
