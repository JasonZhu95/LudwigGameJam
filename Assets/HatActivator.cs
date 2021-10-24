using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatActivator : MonoBehaviour
{
    private GameObject player;
    private Animator anim;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            anim.runtimeAnimatorController =
                Resources.Load<RuntimeAnimatorController>("Animation/PlayerHatAC");
            player.transform.GetChild(3).name = "HatCheck";
            StartCoroutine(DisableStates());
        }
    }

    IEnumerator DisableStates()
    {
        
        yield return new WaitForSeconds(.02f);
        Destroy(gameObject);
    }

}
