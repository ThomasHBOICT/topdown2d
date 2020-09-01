using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public TreeScript tree;

    private bool treeInRange = false;

    // Update is called once per frame
    void Update()
    {
        if (treeInRange)
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
            tree = collision.GetComponent<TreeScript>();
            treeInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "tree")
        {
            if (tree != null)
            {
                tree.StopHitting();

            }
            tree = null;
            treeInRange = false;
        }
    }
}
