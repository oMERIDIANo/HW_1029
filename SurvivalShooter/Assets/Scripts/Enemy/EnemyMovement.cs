using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    
    Transform player;
    Transform player2;
    PlayerHealth playerHealth;
    Player2Health player2Health;
    SpawnPlayer2 spawnPlayer2;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;

    float playerDistance;
    float player2Distance;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        spawnPlayer2 = GameObject.Find("Player2SpawnPoint").GetComponent<SpawnPlayer2>();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
        playerDistance = Vector3.Distance(player.transform.position, transform.position);

        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && spawnPlayer2.player2 == null)
        {
            nav.SetDestination(player.position);
        }

        if (spawnPlayer2.player2 != null)
        {
            player2 = GameObject.FindGameObjectWithTag("Player 2").transform;
            player2Health = player2.GetComponent<Player2Health>();

            player2Distance = Vector3.Distance(player2.transform.position, transform.position);

            if(player2Distance < playerDistance || playerHealth.currentHealth <= 0 && player2Health.currentHealth > 0)
            {
                nav.SetDestination(player2.position);
            }
            else
            {
                nav.SetDestination(player.position);
            }
        }
    }
}
