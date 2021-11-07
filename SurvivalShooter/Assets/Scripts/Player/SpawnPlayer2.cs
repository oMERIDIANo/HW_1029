using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlayer2 : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject player2UI;
    Vector3 playerPosition;
    public GameObject player2;
    public Transform cam2;
    public float smoothing = 5f;
    private Vector3 offset;
    public Player2Health player2Health;

    // Start is called before the first frame update
    void Start()
    {
        player2UI = GameObject.Find("HealthUI_Player2");
        player2UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Spawn") && player2 == null)
        {
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
            player2UI.SetActive(true);

            player2 = GameObject.Find("Player 2(Clone)");

            offset = cam2.transform.position - playerPosition;

            player2Health.healthSlider = GameObject.Find("Player2_HealthSlider").GetComponent<Slider>();
        }

        if (player2 != null)
        {
            playerPosition = player2.transform.position;

            Vector3 targetCamPos = playerPosition + offset;

            cam2.transform.position = Vector3.Lerp(cam2.transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }
}
