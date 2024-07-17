using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySenses : MonoBehaviour
{

    public float viewRadius;
    public float viewAngle;


    public LayerMask targetPlayer;
    public LayerMask obstacleMask;

    public GameObject player;
    public GunSystem gunSystem;
    public Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        gunSystem = GetComponentInChildren<GunSystem>();
        enemy = GetComponentInChildren<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerTarget = (player.transform.position - transform.position).normalized;

        //Checks if player is in line-of-sight
        if (Vector3.Angle(transform.forward, playerTarget) < viewAngle / 2)
        {
            float distanceToTarget = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToTarget <= viewRadius)
            {

                if (Physics.Raycast(transform.position, playerTarget, distanceToTarget, obstacleMask) == false)
                {
                    //Checks to see what type of object this script is attached too and runs it's functions

                    //Turret Enemy
                    Debug.Log("I can see you!");
                    if (gunSystem != null)
                    {
                        gunSystem.Fire();
                    }
                    //BuzzSaw Enemey
                    if (enemy != null)
                    {
                        enemy.RotateTowardsPlayer();
                        enemy.MoveTowardsPlayer();
                    }
                }
            }
        }
    }
}