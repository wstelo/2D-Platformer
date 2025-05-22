using UnityEngine;

public static class PlayerAnimationData 
{
    public static class Parameters
    {
        public static readonly int Idle = Animator.StringToHash(nameof(Idle));
        public static readonly int Run = Animator.StringToHash(nameof(Run));
        public static readonly int Jump = Animator.StringToHash(nameof(Jump));
    }
}
