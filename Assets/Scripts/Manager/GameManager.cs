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

    private int roomTracker = 0;

    private void Awake()
    {
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (reload)
        {
            player = GameObject.FindWithTag("Player");
            player.transform.position = new Vector3(playerPosX, playerPosY, 0);
        }
    }

    private void Update()
    {
        for (int i = 0; i < activeRooms.Length; i++)
        {
            if (activeRooms[i].activeSelf == true)
            {
                roomTracker = i;
                Debug.Log(roomTracker);
            }
        }
    }

    public void Respawn()
    {
        reload = true;
        playerPosX = spawnLocations[roomTracker].transform.position.x;
        playerPosY = spawnLocations[roomTracker].transform.position.y;
        ReloadScene();
    }

    public void ReloadScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transitionAnim.SetTrigger("FadeStart");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
