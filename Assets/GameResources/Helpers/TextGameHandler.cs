using Sorter.Signals;
using TMPro;
using UnityEngine;
using Zenject;

namespace Sorter
{
    [RequireComponent(typeof(TMP_Text))]
    internal class TextGameHandler : MonoBehaviour
    {
        [SerializeField] private string LoseText;
        [SerializeField] private string WinText;
        private SignalBus signalBus;
        private TMP_Text tmp;


        [Inject]
        public void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        private void Awake()
        {
            tmp = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            signalBus.Subscribe<WinGame>(() => tmp.text = WinText);
            signalBus.Subscribe<LoseGame>(() => tmp.text = LoseText);
        }
    }
}
