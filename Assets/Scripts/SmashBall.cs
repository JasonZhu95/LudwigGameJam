using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SmashBall : MonoBehaviour
{
    private GameObject canvas;
    private CollectibleManager cm;
    public static int objectID = 0;
    public int id = 0;
    


    private void Awake()
    {
        objectID++;
        id = objectID;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        cm = canvas.GetComponent<CollectibleManager>();
    }

    void Start()
    {

        if (objectID > cm.smashBallsInStage)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cm.Add();
            gameObject.SetActive(false);
        }
    }



}
