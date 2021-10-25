using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Animator transitionAnim;
    public float transitionTime = 1f;

    private GameObject player;
    public GameObject[] spawnLocations;
    public GameObject[] activeRooms;


    public static float playerPosX = 0;
    public static float playerPosY = 0;
    public static bool reload;
    private static bool loadNextLevel;

    private int roomTracker = 0;

    private void Awake()
    {
        
    }

    private void Start()
    {
        
        player = GameObject.FindWithTag("Player");
        if (reload && !loadNextLevel)
        {
            player = GameObject.FindWithTag("Player");
            player.transform.position = new Vector3(playerPosX, playerPosY, 0);
        }

        if (PlayerStats.playerDied)
        {
            SoundManagerScript.PlaySound("playerRevive");
            PlayerStats.playerDied = false;
        }

        loadNextLevel = false;
    }

    private void Update()
    {
        for (int i = 0; i < activeRooms.Length; i++)
        {
            if (activeRooms[i].activeSelf == true)
            {
                roomTracker = i;
            }
        }
        
    }

    public void Respawn()
    {
        reload = true;
        playerPosX = spawnLocations[roomTracker].transform.position.x;
        playerPosY = spawnLocations[roomTracker].transform.position.y;
        if (PlayerStats.stockCount == 0)
        {
            if (PlayerStats.totalLossCount == 2)
            {
                reload = false;
                PlayerStats.totalLossCount = 0;
                SceneManager.LoadScene(17);
            }
            playerPosX = spawnLocations[0].transform.position.x;
            playerPosY = spawnLocations[0].transform.position.y;
            HitTheBoss.amountOfTimesHit = 0;
            HitTheBoss.destroyedPlatformsCount = 0;
            PlayerStats.stockCount = 4;
        }
        ReloadScene();
        
       
    }

    public void ReloadScene()
    {  
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }


    public void LoadNextLevel()
    {
        loadNextLevel = true;
        PlayerStats.stockCount = 4;
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transitionAnim.SetTrigger("FadeStart");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
 
    }

    public void LoadArenaLevel()
    {
        loadNextLevel = true;
        PlayerStats.stockCount = 4; 
        StartCoroutine(LoadLevel(2));
    }
}
