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
    public float rotationDamping;

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
        Vector3 direction = player.transform.position - this.transform.position;
        if (Vector3.Distance(player.transform.position, this.transform.position) < 6f && Vector3.Distance(player.transform.position, this.transform.position) > 5.5f)
        {
            Debug.Log(Vector3.Distance(player.transform.position, this.transform.position));
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", true);
            Attack();
        }
        else if (Vector3.Distance(player.transform.position, this.transform.position) < 10f)
        {
            anim.SetBool("isIdle", false);
            direction.y = 0;
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

    void Attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                hit.collider.gameObject.GetComponent<PlayerHealth>().health -= 5f;
                this.transform.rotation = Quaternion.identity;
                Debug.Log("Hit");
            }
        }
    }

    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
    }
}
