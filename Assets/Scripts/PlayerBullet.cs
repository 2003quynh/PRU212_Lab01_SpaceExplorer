using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        //Get position of bullet
        Vector2 position = transform.position;

        //compute new position
        position = new Vector2(position.x  + bulletSpeed * Time.deltaTime, position.y);
        
        //update position
        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if (transform.position.x > max.x)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "EnemyTag") {
            Destroy(other.gameObject);
        }
    }
}
