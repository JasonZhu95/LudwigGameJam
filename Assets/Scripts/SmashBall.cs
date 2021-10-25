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
    public static int objectID = 0;




    private void Awake()
    {
        Debug.Log(FindObjectsOfType(typeof(SmashBall)).Length);
        objectID++;
        id = objectID;

        
        if (objectID > CollectibleManager.allowedNumOfSmashBalls)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            CollectibleManager.smashBallList.Add(gameObject);
        }

    }

    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        cm = canvas.GetComponent<CollectibleManager>();
        if (objectID > CollectibleManager.allowedNumOfSmashBalls)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            CollectibleManager.smashBallList.Add(gameObject);
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
        }
    }



}
