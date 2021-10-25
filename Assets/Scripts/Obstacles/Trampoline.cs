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

    private float audioPlayPeriod = .2f;
    private bool playAudio;


    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void Update()
    {
        audioPlayPeriod -= Time.deltaTime;
        if (audioPlayPeriod < 0)
        {
            playAudio = true;
            audioPlayPeriod = .2f;
        }

        if (CheckIfPlayer())
        {
            if (playAudio)
            {
                SoundManagerScript.PlaySound("trampoline");
                playAudio = false;
            }
            StartCoroutine(DisableVelocitySet());
            player.GetComponent<Player>().DashState.ResetCanDash();
            player.GetComponent<Player>().DashState.dashCount = 0;
            if (player.GetComponent<Player>().hasHat)
            {
                player.GetComponent<Player>().DashState.dashCount = 0;
            }
            else
            {
                player.GetComponent<Player>().trampolineHatCheck = false;
            }

            if (transform.rotation.eulerAngles.z == 90)
            {
                player.transform.position = new Vector3(transform.position.x + playerOffsetX,
                    transform.position.y + playerOffestY, transform.position.z);
                player.GetComponent<Rigidbody2D>().velocity = -Vector2.right * bounce;
            }
            else if (transform.rotation.eulerAngles.z == 180)
            {
                player.transform.position = new Vector3(transform.position.x + playerOffsetX,
                    transform.position.y + playerOffestY, transform.position.z);
                player.GetComponent<Rigidbody2D>().velocity = -Vector2.up * bounce;
            }
            else if (transform.rotation.eulerAngles.z == 270)
            {
                player.transform.position = new Vector3(transform.position.x + playerOffsetX,
                    transform.position.y + playerOffestY, transform.position.z);
                player.GetComponent<Rigidbody2D>().velocity = Vector2.right * bounce;
            }
            else
            {
                player.transform.position = new Vector3(transform.position.x + playerOffsetX,
                    transform.position.y + playerOffestY, transform.position.z);
                player.GetComponent<Rigidbody2D>().velocity = Vector2.up * bounce;
            }
        }
        anim.SetBool("isPushing", CheckIfPlayer());
    }

    IEnumerator DisableVelocitySet()
    {
        player.GetComponent<Player>().disableVelocitySet = true;
        yield return new WaitForSeconds(.2f);
        player.GetComponent<Player>().disableVelocitySet = false;
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
