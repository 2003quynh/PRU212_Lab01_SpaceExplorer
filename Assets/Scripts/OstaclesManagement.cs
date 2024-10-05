using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OstaclesManagement : MonoBehaviour
{
   [SerializeField] private GameObject Enemy;
   [SerializeField] private GameObject Coin;
   [SerializeField] private GameObject[] Spaces;
   [SerializeField] private float TimeLimit;
    // [SerializeField] private float spawnRate = 10f;
   public float timer = 0f;
    private bool enemySpawnStarted = false;
   void Start(){
       InvokeRepeating("SpawnEnemy",1f, 5f);
       InvokeRepeating("SpawnCoin",5f, 7f);
       InvokeRepeating("SpawnSpace",5f, 10f);
   }
   void Update()
    {
        // Start counting time once the enemy starts spawning
        if (enemySpawnStarted)
        {
            timer += Time.deltaTime;

            // Check if 2 seconds have passed
            if (timer >= TimeLimit)
            {
                // Change scene here, assuming "EndGameScene" is the name of the scene to load
                SceneManager.LoadScene("EndGameScene");
            }
        }
    }
   void SpawnEnemy(){
        if (!enemySpawnStarted)
        {
            enemySpawnStarted = true; // Start the timer when first enemy spawns
        }
       Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
       Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
       GameObject anEnemy = (GameObject)Instantiate(Enemy);
       anEnemy.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));

   }
   void SpawnCoin(){

       Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
       Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
       GameObject aCoin = (GameObject)Instantiate(Coin);
       aCoin.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));

   }

   void SpawnSpace(){

       Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
       Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
       int random = Random.Range(0, Spaces.Length);
       GameObject aSpace = (GameObject)Instantiate(Spaces[random]);
       aSpace.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));

   }

   
}
