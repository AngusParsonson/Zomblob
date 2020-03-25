using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public float gameTime = 0.0f;

    private float playerScore = 0.0f;
    private float playerMultiplier = 1.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
    }

    public void RegisterKill(float pointReward)
    {
        playerScore += pointReward * playerMultiplier;
        Debug.Log(playerScore);
    }
}
