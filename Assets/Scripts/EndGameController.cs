using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    [SerializeField] private GameObject spaceship;
    [SerializeField] private GameObject win, lose;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("be"+spaceship.GetComponent<PlayerCollision>().health);
        Debug.Log("be"+PlayerCollision.health);
        if(PlayerCollision.health <= 0){
        // if(spaceship.GetComponent<PlayerCollision>().health <= 0){
         lose.SetActive(true);   
        } else{
            win.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackHome(){
        lose.SetActive(false);
        win.SetActive(false);
        SceneManager.LoadScene("MainMenuScene");
    }

    public void Next(){

    }

    public void Return(){
        lose.SetActive(false);
        win.SetActive(false);
        SceneManager.LoadScene("GameplayScene");
    }
}
