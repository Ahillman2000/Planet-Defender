using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateHandler : MonoBehaviour
{
    public GameObject player;
    Player playerScript;

    public GameObject gameManager;
    RoundManager roundManagerScript;


    void Start()
    {
        playerScript = player.GetComponent<Player>();
        roundManagerScript = gameManager.GetComponent<RoundManager>();
    }

    void Update()
    {
        if(playerScript.currentHealth <= 0)
        {
            SceneManager.LoadScene("Lose");
        }

        else if(roundManagerScript.currentRound == roundManagerScript.MaxNumberOfRounds && roundManagerScript.enemyCount <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
