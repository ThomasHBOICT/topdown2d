using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatInteraction : MonoBehaviour
{

    public static bool inBoatRange;
    public static bool inPierRange;

    public GameObject player;

    private BoxCollider2D collider2d;

    private Transform pier;
    private Transform boat;
    private BoatScript boatScript;

    void Start()
    {
        collider2d = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inBoatRange)
        {
            player.transform.position = boat.position;
            collider2d.enabled = false;
            boatScript.EnterBoat(player);
        }
        if (Input.GetKeyDown(KeyCode.E) && inPierRange)
        {
            boatScript.ExitBoat();
            player.transform.position = pier.position;
            collider2d.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "boat")
        {
            boat = collision.GetComponent<Transform>();
            boatScript = collision.GetComponent<BoatScript>();
        }
        if (collision.tag == "Pier")
        {
            pier = collision.GetComponent<Transform>();
        }
    }
}
