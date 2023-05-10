using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public GameObject player;
    PlayerController pc;

    int score = 0;
    public TextMeshProUGUI scoreText;
    int maxCoins;

    public TextMeshProUGUI timeText;
    public int timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        pc = player.GetComponent<PlayerController>();
        maxCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        scoreText.SetText("Coins: " + score + "/" + maxCoins);

        timeText.SetText("Time: " + timeLeft);
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
            timeText.SetText("Time: " + timeLeft);
        }
        GameOver();
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        gameOverText.gameObject.SetActive(true);
        //pc.enabled = false;
        Time.timeScale = 0; // nem telik az idõ a játékban. Ez mindent befagyaszt
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.SetText("Coins: " + score + "/" + maxCoins);
    }
}
