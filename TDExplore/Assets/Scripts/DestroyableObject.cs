using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    
    public float maxHealth;

    public GameObject dropItem;
    public float dropAfterTime;
   
    private float currentHealth;
    private bool isHitting;
    

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
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
                animator.SetTrigger("destroyed");
                
                StartCoroutine("SpawnItem");
                Destroy(gameObject, dropAfterTime + 0.1f);
            }
        }
    }

    public void Hitting()
    {
        isHitting = true;
        Debug.Log("hitting");
        animator.SetBool("isHitting", true);
    }
    public void StopHitting()
    {
        isHitting = false;
        Debug.Log("unhitting");
        animator.SetBool("isHitting", false);
    }

    IEnumerator SpawnItem()
    {
        Debug.Log("waiting for log drop");
        yield return new WaitForSeconds(dropAfterTime);
        Instantiate(dropItem, transform.position, Quaternion.identity);

    }
}
