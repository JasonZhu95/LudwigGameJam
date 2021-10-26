using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTimer : MonoBehaviour
{
    private Timer timer;
    private GameObject timercanvas;
    void Start()
    {
        timercanvas = GameObject.FindGameObjectWithTag("Timer");
        timer = timercanvas.GetComponent<Timer>();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
