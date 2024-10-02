using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceController : MonoBehaviour
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
        if (other.tag == "PlayerShipTag") {
            // Destroy(other.gameObject);
            PlayerCollision.health = 0;
            // other.gameObject.GetComponent<PlayerCollision>().= 0;
            // Debug.Log("nek" +other.gameObject.GetComponent<PlayerCollision>().health);
            Debug.Log("nek" +PlayerCollision.health);

            Destroy(other.gameObject);
            SceneManager.LoadScene("EndGameScene");
        }
        
    }
}
