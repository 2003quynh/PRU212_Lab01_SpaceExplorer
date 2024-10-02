using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x - speed * Time.deltaTime, position.y);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.x < min.x){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "PlayerBulletTag") {
            // Destroy(other.gameObject);
            Destroy(other.gameObject);
        }
        if (other.tag == "PlayerShipTag") {
            // Destroy(other.gameObject);
            // if(other.gameObject.GetComponent<PlayerCollision>().health <= 0){
            //     Destroy(other.gameObject);
            // } else {
            //     other.gameObject.GetComponent<PlayerCollision>().health--;
            // }
            if(PlayerCollision.health <= 0){
                Destroy(other.gameObject);
            } else {
               PlayerCollision.health--;
            }
        }
    }
}
