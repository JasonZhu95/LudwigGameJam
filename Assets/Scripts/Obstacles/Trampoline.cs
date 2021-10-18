using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounce = 25f;
    private GameObject player;
    private Animator anim;
    private bool isPushing;
    public float playerOffsetX;
    public float playerOffestY;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void Update()
    {
        anim.SetBool("isPushing", isPushing);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            isPushing = true;
            player.GetComponent<Player>().DashState.ResetCanDash();
            StartCoroutine(DisableMovement());
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.transform.position = new Vector3(transform.position.x + playerOffsetX,
                transform.position.y + playerOffestY, transform.position.z);
            player.GetComponent<Rigidbody2D>().velocity = Vector2.up * bounce;
        }
    }

    IEnumerator DisableMovement()
    {
        player.GetComponent<Player>().canMove = false;
        yield return new WaitForSeconds(.2f);
        player.GetComponent<Player>().canMove = true;
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            isPushing = false;
        }
    }

}
