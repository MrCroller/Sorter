using Sorter.Signals;
using UnityEngine;
using Zenject;

namespace Sorter.Conveyor
{
    internal class ConveyorsInstaller : MonoInstaller
    {
        [SerializeField] SpawnPointView[] convPoints;

        public override void InstallBindings()
        {
            foreach (var item in convPoints)
            {
                Container.BindInterfacesAndSelfTo<ConveyorLine>().AsCached().WithArguments(item.transform);
            }
            BindSignals();
        }

        public void BindSignals()
        {
            Container.BindSignal<EndLineSignal>()
                .ToMethod<ConveyorLine>((line, signal) => line.UnregisterView(signal.view))
                .FromResolveAll();

            Container.BindSignal<DropSignal>()
                .ToMethod<ConveyorLine>((line, signal) => line.UnregisterView(signal.view))
                .FromResolveAll();

            Container.BindSignal<DragSignal>()
                .ToMethod<ConveyorLine>((line, signal) =>
                {
                    if (signal.isDragged)
                        line.UnregisterView(signal.view);
                    else
                        line.RegisterView(signal.view);
                })
                .FromResolveAll();
        }
    }
}
