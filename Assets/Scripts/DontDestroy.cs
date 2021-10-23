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

    }
    void Start()
    {
        
        
       //DontDestroyOnLoad(gameObject);
      
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
