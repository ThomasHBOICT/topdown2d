using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour
{
    public GameObject boat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            BoatInteraction.inBoatRange = true;
        }
        if (collision.tag == "Pier")
        {
            BoatInteraction.inPierRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            BoatInteraction.inBoatRange = false;
        }
        if (collision.tag == "Pier")
        {
            BoatInteraction.inPierRange = false;
        }
    }

    public void EnterBoat(GameObject player)
    {
        Debug.Log("boat enter");
        boat.transform.parent = player.transform;
        //transform.localRotation = player.transform.localRotation;
    }
    public void ExitBoat()
    {
        Debug.Log("boat exit, doei");
        boat.transform.parent = null;
        BoatInteraction.inPierRange = false;
    }
}
