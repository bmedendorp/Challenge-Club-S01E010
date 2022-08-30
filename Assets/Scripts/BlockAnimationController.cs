using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Update()
    {
        animator = GetComponent<Animator>();
    }

    public void DoFlash()
    {
        animator.SetTrigger("flash");
    }
}
