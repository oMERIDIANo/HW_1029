using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public SpawnPlayer2 spawnPlayer2;
    public Player2Health player2Health;
    public PlayerHealth playerHealth;
	public float restartDelay = 5f;


    Animator anim;
	float restartTimer;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0 && spawnPlayer2.isPlayer2Active == false)
        {
            Debug.Log("1");
            anim.SetTrigger("GameOver");

			restartTimer += Time.deltaTime;

			if (restartTimer >= restartDelay) {
				Application.LoadLevel(Application.loadedLevel);
			}
        }
        
        else if(playerHealth.currentHealth <= 0 && player2Health.currentHealth <= 0)
        {
            Debug.Log("2");
            anim.SetTrigger("GameOver");

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
