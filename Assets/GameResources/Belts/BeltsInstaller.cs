using Sorter.Signals;
using UnityEngine;
using Zenject;

namespace Sorter.Belt
{
    internal class BeltsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            foreach (IBeltView item in FindObjectsByType<BeltsLineView>(FindObjectsSortMode.None))
            {
                Container.BindInterfacesAndSelfTo<BeltLine>().AsCached().WithArguments(item);
            }
            BindSignals();
        }

        public void BindSignals()
        {
            //Container.BindSignal<EndLineSignal>()
            //    .ToMethod<BeltLine>((line, signal) => line.UnregisterView(signal.view))
            //    .FromResolveAll();

            Container.BindSignal<DropSignal>()
                .ToMethod<BeltLine>((line, signal) => line.UnregisterView(signal.view.ItemBelt))
                .FromResolveAll();

            //Container.BindSignal<DragSignal>()
            //    .ToMethod<BeltLine>((line, signal) =>
            //    {
            //        if (signal.isDragged)
            //            line.UnregisterView(signal.view);
            //        else
            //            line.RegisterView(signal.view);
            //    })
            //    .FromResolveAll();
        }
    }
}
