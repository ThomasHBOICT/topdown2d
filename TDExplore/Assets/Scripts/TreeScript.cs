using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    
    public float maxHealth;

    public GameObject dropItem;
   
    private float currentHealth;
    private bool isHitting;
    

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHitting)
        {
            currentHealth -= Time.deltaTime;
            if (currentHealth <= 0)
            {
                isHitting = false;
                animator.SetTrigger("treeIsCut");
                
                StartCoroutine("SpawnLog");
                Destroy(gameObject, 2f);
            }
        }
    }

    public void Hitting()
    {
        isHitting = true;
        Debug.Log("treehitto");
        animator.SetBool("isHitting", true);
    }
    public void StopHitting()
    {
        isHitting = false;
        Debug.Log("tree not hitto");
        animator.SetBool("isHitting", false);
    }

    IEnumerator SpawnLog()
    {
        Debug.Log("waiting for log drop");
        yield return new WaitForSeconds(1.9f);
        Instantiate(dropItem, transform.position, Quaternion.identity);

    }
}
