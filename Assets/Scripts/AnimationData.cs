using UnityEngine;

public class AnimationData : MonoBehaviour
{
    public static readonly int IsIdle = Animator.StringToHash(nameof(IsIdle));
    public static readonly int IsRun = Animator.StringToHash(nameof(IsRun));
    public static readonly int IsJump = Animator.StringToHash(nameof(IsJump));
}
