using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public DestroyableObject tree;

    // Update is called once per frame
    void Update()
    {
        if (tree != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                tree.Hitting();
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                tree.StopHitting();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "tree")
        {
            Debug.Log("tree in range");
            tree = collision.GetComponent<DestroyableObject>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "tree")
        {
            Debug.Log("tree no longer in range");
            if (tree != null)
            {
                tree.StopHitting();
            }
            tree = null;
        }
    }    
}
