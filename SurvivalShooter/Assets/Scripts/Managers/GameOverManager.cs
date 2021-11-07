using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    Player2Health player2Health;
	public float restartDelay = 5f;
    public SpawnPlayer2 spawnPlayer2;

    Animator anim;
	float restartTimer;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0 && spawnPlayer2.player2 == null)
        {
            anim.SetTrigger("GameOver");

			restartTimer += Time.deltaTime;

			if (restartTimer >= restartDelay) {
				Application.LoadLevel(Application.loadedLevel);
			}
        }

        else if(spawnPlayer2.player2 != null)
        {
            player2Health = spawnPlayer2.player2.GetComponent<Player2Health>();

            if (playerHealth.currentHealth <= 0 && player2Health.currentHealth <= 0)
            {
                anim.SetTrigger("GameOver");

                restartTimer += Time.deltaTime;

                if (restartTimer >= restartDelay)
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
            }
        }
    }
}
