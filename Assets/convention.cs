using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class convention : MonoBehaviour
{
    private GameManager GM;
    private MusicManager mm;
    private void Awake()
    {
       
        mm = GameObject.FindGameObjectWithTag("Music Manager").GetComponent<MusicManager>();
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {

            mm.StopMusic();
            SceneManager.LoadScene("MainStage2021");
            
        }
    }

}
