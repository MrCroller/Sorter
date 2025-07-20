using System;
using System.Collections.Generic;
using Sorter.Conveyor;
using Sorter.Types;
using UnityEngine;
using Zenject;

namespace Sorter.Figure
{
    public class Spawner : ITickable, IDisposable
    {
        private readonly Settings settings;
        private readonly List<IFactory<FigureView>> factories;
        private readonly List<ConveyorLine> conveyors;
        private float time;

        public Spawner(Settings settings, List<IFactory<FigureView>> factories, List<ConveyorLine> conveyors)
        {
            this.settings = settings;
            this.factories = factories;
            this.conveyors = conveyors;
        }

        public void Dispose()
        {
            factories.Clear();
        }

        public void Tick()
        {
            if (time < 0)
            {
                time = settings.DelaySpawn.GetRandom();
                var view = factories.GetRandom().Create();
                conveyors.GetRandom().RegisterView(view);
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
