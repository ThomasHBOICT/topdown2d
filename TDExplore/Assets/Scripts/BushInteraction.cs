using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushInteraction : MonoBehaviour
{

    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("touchBush");
    }
}
