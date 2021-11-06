using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    SpawnPlayer2 spawnPlayer2;

    Animator anim;
    GameObject player;
    GameObject player2;
    PlayerHealth playerHealth;
    Player2Health player2Health;
    EnemyHealth enemyHealth;
    bool isHittingPlayer1;
    bool isHittingPlayer2;
    bool playerInRange;
    float timer;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        spawnPlayer2 = GameObject.Find("Player2SpawnPoint").GetComponent<SpawnPlayer2>();
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            isHittingPlayer1 = true;
            playerInRange = true;
        }

        if(other.gameObject == player2)
        {
            isHittingPlayer2 = true;
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            isHittingPlayer1 = false;
            playerInRange = false;
        }
        if(other.gameObject == player2)
        {
            isHittingPlayer2 = false;
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead");
        }

        if (spawnPlayer2.isPlayer2Active == true)
        {
            player2 = GameObject.FindGameObjectWithTag("Player 2");

            player2Health = player2.GetComponent<Player2Health>();

            if (player2Health.currentHealth <= 0)
            {
                anim.SetTrigger("PlayerDead");
            }
        }
    }


    void Attack ()
    {
        timer = 0f;

        if(isHittingPlayer1 == true && playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }

        if(isHittingPlayer2 == true && player2Health.currentHealth > 0)
        {
            player2Health.TakeDamage(attackDamage);
        }
    }
}
