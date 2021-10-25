using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SmashBall : MonoBehaviour
{
    private GameObject canvas;
    private CollectibleManager cm;
    public bool isCollected;
    public static int objectID = 0;
    public int id = 0;
    


    private void Awake()
    {
        isCollected = false;
        objectID++;
        
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        cm = canvas.GetComponent<CollectibleManager>();
    }

    void Start()
    {
        id = objectID;
        if (id > cm.smashBallsInStage) 
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);

        }
        else
        {
            DontDestroyOnLoad(gameObject);
            cm.updateTotal(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCollected = true;
            cm.Add();
            SoundManagerScript.PlaySound("smashBall");
            gameObject.SetActive(false);
            //cm.updateTotal(gameObject);
        }
    }



}
