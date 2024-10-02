using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public static int health;           // Player health
    public static int score;            // Player score
    // public Text healthText; 
    public TextMeshProUGUI healthText;         // UI Text for health
    public TextMeshProUGUI time;         // UI Text for health
    public TextMeshProUGUI scoreText;           // UI Text for score
    public TextMeshProUGUI playerInfoText;      // UI Text for your personal information

    void Start()
    {
        health = 1000;
        score = 0;
        UpdateUI();
        playerInfoText.text = "HE171282 - Nguyen Thi Quynh - SE1745 - Lab01";  // Add your information here
    }

    private void Update() {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyTag" || collision.gameObject.tag == "EnemyBulletTag")
        {
            Destroy(collision.gameObject);
            health--;  // Decrease health on asteroid collision
            if (health <= 0)
            {
                // End game if health is 0
                SceneManager.LoadScene("EndGameScene");
            }
            UpdateUI();
        }
        if (collision.gameObject.tag == "CoinTag")
        {
            score+=10;  // Increase score when collecting a star
            Destroy(collision.gameObject);  // Destroy star after collecting
            UpdateUI();
        }
    }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.tag == "Star")
    //     {
    //         score++;  // Increase score when collecting a star
    //         Destroy(collision.gameObject);  // Destroy star after collecting
    //         UpdateUI();
    //     }
    // }

    void UpdateUI()
    {
        healthText.text = ""+health;
        scoreText.text = ""+score;
    }
}
