using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShineRedash : MonoBehaviour
{
    private Player player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            if (transform.GetChild(0).gameObject.activeSelf)
            {
                SoundManagerScript.PlaySound("shineRedash");
                player.DashState.ResetCanDash();
                player.GetComponent<Player>().DashState.dashCount = 0;
            }
            StartCoroutine(RespawnShine());
        }

    }

    IEnumerator RespawnShine()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
