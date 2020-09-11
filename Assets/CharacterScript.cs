using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {

    public Animator animator;

    public void OnAnimationFinish()
    {
        animator.SetBool("IsEating", false);
    }
}
