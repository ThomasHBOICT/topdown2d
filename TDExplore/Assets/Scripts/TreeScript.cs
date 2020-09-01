using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hitting()
    {
        Debug.Log("treehitto");
        animator.SetBool("isHitting", true);
    }
    public void StopHitting()
    {
        Debug.Log("tree not hitto");
        animator.SetBool("isHitting", false);
    }
}
