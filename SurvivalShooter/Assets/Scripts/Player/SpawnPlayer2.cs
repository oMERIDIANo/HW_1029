using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer2 : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPoint;
    public bool isPlayer2Active;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Spawn") && isPlayer2Active == false)
        {
            isPlayer2Active = true;
            GameObject player2 = Instantiate(playerPrefab, spawnPoint);
        }
    }
}
