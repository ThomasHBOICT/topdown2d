using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererSorter : MonoBehaviour
{
    public int offset;
    public bool runOnlyOnce = false;
    private int sortingOrderBase = 5000;
    private Renderer myRenderer;

    private float timer;
    private float timerMax = 0.1f;
    // Start is called before the first frame update
    private void Awake()
    {
        myRenderer = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timerMax;
            myRenderer.sortingOrder = (int)(sortingOrderBase - transform.position.y * 2 - offset);
            if (runOnlyOnce)
            {
                Destroy(this);
            }
        }
    }
}
