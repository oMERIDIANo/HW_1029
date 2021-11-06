using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer2 : MonoBehaviour
{
    public GameObject playerPrefab;
    public bool isPlayer2Active;
    GameObject player2UI;
    Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        player2UI = GameObject.Find("HealthUI_Player2");
        player2UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Spawn") && isPlayer2Active == false)
        {
            isPlayer2Active = true;
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
            player2UI.SetActive(true);

            GameObject player2 = GameObject.Find("Player 2(Clone)");
            playerPosition = player2.transform.position;
            Debug.Log(playerPosition);
        }
    }
}
