using System;
using System.Collections.Generic;
using Sorter.Signals;
using Sorter.Types;
using UnityEngine;
using Zenject;

namespace Sorter.Belt
{
    public class BeltLine : ITickable, IDisposable
    {
        private const float MULTIPLAYER_OF_SPEED = 0.001f;

        private readonly Vector2 MoveVector = Vector2.right;
        private readonly List<IItemOnBelt> Items = new();
        private readonly List<IItemOnBelt> itemsToRemove = new();
        private readonly IBeltView line;
        private readonly Spawner.Settings spawnerSettings;
        private readonly SignalBus signalBus;

        public BeltLine(IBeltView line, Spawner.Settings spawnerSettings, SignalBus signalBus)
        {
            this.line = line;
            this.spawnerSettings = spawnerSettings;
            this.signalBus = signalBus;
        }

        public void Dispose()
        {
            Items.Clear();
        }

        public void RegisterView(IItemOnBelt view)
        {
            view.Init(line.StartPosX, line.EndPosX, spawnerSettings.SpeedRange.GetRandom());
            Items.Add(view);
        }

        public void UnregisterView(IItemOnBelt view)
        {
            if (!Items.Contains(view)) return;
            Items.Remove(view);
            view.ClearItem();
        }

        public void Tick()
        {
            Moving();
        }

        private void Moving()
        {
            itemsToRemove.Clear();

            foreach (var view in Items)
            {
                if (view.Draggable.IsDragging) continue;
                var adding = view.Speed * MULTIPLAYER_OF_SPEED;
                view.ProgressInterop += adding;
                if (view.ProgressInterop + adding > ItemOnBelt.MAX) itemsToRemove.Add(view);
            }

            foreach (var item in itemsToRemove)
            {
                UnregisterView(item);
                signalBus.Fire(new EndOfBeltSignal() { Position = item.Position });
            }
        }
    }
}
