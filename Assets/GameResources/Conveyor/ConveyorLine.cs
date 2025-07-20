using System;
using System.Collections.Generic;
using Sorter.Figure;
using UnityEditor.Analytics;
using UnityEngine;
using Zenject;

namespace Sorter.Conveyor
{
    public class ConveyorLine : ITickable, IDisposable
    {
        private readonly Vector2 MoveVector = Vector2.right;
        private readonly List<FigureView> views = new();
        private readonly Transform startPoint;

        public ConveyorLine(Transform startPoint)
        {
            this.startPoint = startPoint;
        }

        public void Dispose()
        {
            views.Clear();
        }

        public void RegisterView(FigureView view)
        {
            views.Add(view);
            view.transform.position = startPoint.position;
        }

        public void UnregisterView(FigureView view)
        {
            views.Remove(view);
        }

        public void Tick()
        {
            Moving();
        }

        private void Moving()
        {
            foreach (var view in views)
            {
                view.transform.position += Time.deltaTime * view.Speed * (Vector3)MoveVector;
            }
        }
    }
}
