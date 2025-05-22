using UnityEngine;

public class EnemyAnimationData : MonoBehaviour
{
    public static class Parameters
    {
        public static readonly int Idle = Animator.StringToHash(nameof(Idle));
        public static readonly int Run = Animator.StringToHash(nameof(Run));
    }
}
