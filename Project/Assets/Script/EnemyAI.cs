using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    GameObject player;
    NavMeshAgent enemy;
    static Animator anim;
    public static bool isPlayerAlive;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
        Moving();
    }

    void Shooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Destroy(gameObject);
        }
    }

    void Moving()
    {
        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance < 1)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", true);
        }
        else if (Vector3.Distance(player.transform.position, this.transform.position) < 10)
        {
            anim.SetBool("isIdle", false);
            enemy.destination = player.transform.position;
            anim.SetBool("isWalking", true);

        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }
    }
}
