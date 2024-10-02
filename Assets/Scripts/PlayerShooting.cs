using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject playerBulletPrefab;
    [SerializeField] GameObject bulletPosition0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(playerBulletPrefab, bulletPosition0.transform.position, Quaternion.identity);
            GetComponent<AudioSource>().Play(); 
            
        }
    }
}
