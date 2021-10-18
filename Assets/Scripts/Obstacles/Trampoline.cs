using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounce = 25f;
    private GameObject player;
    private Animator anim;
    public float playerOffsetX;
    public float playerOffestY;


    [SerializeField] private Transform playerCheck;
    [SerializeField] private float playerCheckRadius = 0.75f;
    public LayerMask whatIsPlayer;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void Update()
    {
        if (CheckIfPlayer())
        {
            player.transform.position = new Vector3(transform.position.x + playerOffsetX,
                transform.position.y + playerOffestY, transform.position.z);
            player.GetComponent<Rigidbody2D>().velocity = Vector2.up * bounce;
        }
        anim.SetBool("isPushing", CheckIfPlayer());
    }


    public bool CheckIfPlayer()
    {
        return Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, whatIsPlayer);
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(playerCheck.position, playerCheckRadius);
    }

}
