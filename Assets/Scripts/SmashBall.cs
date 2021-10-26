using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SmashBall : MonoBehaviour
{
    private GameObject canvas;
    private CollectibleManager cm;
    public bool isCollected = false;
    //public bool loaded = false;
    public int id;
    public int id2;
    public static int objectID = 0;




    private void Awake()
    {   
        
    }

    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        cm = canvas.GetComponent<CollectibleManager>();

        DontDestroyOnLoad(gameObject);
        if (objectID >= CollectibleManager.allowedNumOfSmashBalls)
        {
            Destroy(gameObject);
        }
        else
        {
            objectID++;
            id = objectID;
            CollectibleManager.smashBallList.Add(gameObject);
        }
        
            Debug.Log(objectID);
        
        

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCollected = true;
            cm.Add();
            SoundManagerScript.PlaySound("smashBall");
            gameObject.SetActive(false);
        }
    }



}
