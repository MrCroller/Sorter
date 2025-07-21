using UnityEngine;

namespace Sorter
{
    [RequireComponent(typeof(Animator))]
    internal class AnimatorHandler : MonoBehaviour
    {
        [SerializeField] public string AnimatorName;
        [SerializeField] public Animator Animator;

        private void Awake()
        {
            if (Animator == null)
            {
                Animator = GetComponent<Animator>();
            }
        }

        public void Invoke()
        {
            Animator.Play(AnimatorName);
        }
    }
}
