using System;
using System.Collections.Generic;
using Sorter.Types;
using UnityEngine;
using Zenject;

namespace Sorter.Figure
{
    public class Spawner : ITickable
    {
        private readonly Settings settings;
        private readonly List<IFactory<FigureView>> factories;
        private float time;

        public Spawner(Settings settings, List<IFactory<FigureView>> factories)
        {
            this.settings = settings;
            this.factories = factories;
        }

        public void Tick()
        {
            if (time < 0)
            {
                time = settings.DelaySpawn.GetRandom();
                factories.GetRandom().Create();
            }
            time -= Time.deltaTime;
        }


        [Serializable]
        public class Settings
        {
            [field: SerializeField] public Range<float> DelaySpawn { get; private set; } = new() { min = 2f, max = 3f };
            [field: SerializeField] public Range<float> SpeedRange { get; private set; } = new() { min = 1f, max = 6f };

            public void Validate()
            {
                DelaySpawn.Validate();
                SpeedRange.Validate();
            }
        }
    }
}
