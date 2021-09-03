using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField]
    Animator CharacterAnimator;

    public void PlayRunning()
    {
        CharacterAnimator.Play("Run");
    }
    
    public void StopAnimation()
    {
        CharacterAnimator.Play("Idle");
    }

    public void DancingAnimation()
    {
        CharacterAnimator.Play("Dancing");
    }

    
}
