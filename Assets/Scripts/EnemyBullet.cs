using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private bool isReady;
    // Start is called before the first frame update
    private void Awake() {
        isReady = false;
        speed = 5f;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(isReady) {
        Vector2 position = transform.position;
        position = _direction * speed * Time.deltaTime + position;
        transform.position = position;
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.x > max.x || transform.position.x < min.x || transform.position.y > max.y || transform.position.y < min.y) {
            Destroy(gameObject);
        }
       }
    }

    public void SetDirection(Vector2 direction) {
        _direction = direction.normalized;
        isReady = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "PlayerShipTag") {
            // if(other.gameObject.GetComponent<PlayerCollision>().health <= 0) {
            //     Destroy(other.gameObject);
                
            // };
            if(PlayerCollision.health <= 0) {
                Destroy(other.gameObject);
                
            };
        }
    }
}
