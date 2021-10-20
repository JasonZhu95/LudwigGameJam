using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMovement : MonoBehaviour
{
    private Player player;
    private GameManager GM;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            player.InputHandler.disableInputs = true;
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1f);
        player.InputHandler.disableInputs = false;
        GM.LoadNextLevel();
    }
}
