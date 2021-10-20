using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public static int objectID = 0;
    
    private void Awake()
    {

        objectID++;
        //for (int i = 0; i < Object.FindObjectsOfType<DontDestroy>().Length; i++)
        //{
        //    if (Object.FindObjectsOfType<DontDestroy>()[i] != this)
        //    {
        //        if (Object.FindObjectsOfType<DontDestroy>()[i].objectID == objectID)
        //        {
        //            DestroyImmediate(gameObject);
        //        }
        //    }
        //}

        

    }
    void Start()
    {
        if (objectID > MenuScript.staticSmashBallNum) 
        {
            DestroyImmediate(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
