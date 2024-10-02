using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject enemyBulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireBullet", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FireBullet(){
       GameObject playerShip = GameObject.Find("Spaceship");
        if(playerShip != null){
            GameObject bullet = (GameObject)Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
            Vector2 direction = playerShip.transform.position - transform.position;
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}   

