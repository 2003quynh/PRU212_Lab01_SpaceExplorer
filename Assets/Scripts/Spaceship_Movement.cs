using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship_Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody2D myRigidbody;    
    [SerializeField] float jumpForce;
    // private bool isGrounded;
    // private bool _isFacingRight;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        // _isFacingRight = true;
        // isGrounded = true;
    }

    void Update()
    {
        // myRigidbody.velocity = new Vector2 (moveSpeed, 0f);
        HorizotalMovement();
        // if(isGrounded){
        //     Jump();
        // }
        
        Jump();
        RestrictMovementWithinScreen();
    }

    // void OnTriggerExit2D(Collider2D other) 
    // {
    //     moveSpeed = -moveSpeed;
    //     FlipEnemyFacing();
    // }

    void FlipEnemyFacing()
    {
        // transform.localScale = new Vector2 (-(Mathf.Sign(myRigidbody.velocity.x)), 1f);
        transform.Rotate(0f,180f,0f);
    }

    void HorizotalMovement(){
        float move = Input.GetAxis("Horizontal");

        myRigidbody.velocity = new Vector2 (move * moveSpeed, myRigidbody.velocity.y);
       

        // if(move > 0 && !_isFacingRight){
        //     _isFacingRight = true;
        //     FlipEnemyFacing();
        // } else if(move < 0 && _isFacingRight){
        //     _isFacingRight = false;
        //     FlipEnemyFacing();
        // }        
    }
    void Jump(){
        float move = Input.GetAxis("Vertical");
        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
        myRigidbody.AddForce(new Vector2(0f, move * jumpForce), ForceMode2D.Impulse);
        // isGrounded=false;       
    }
    void RestrictMovementWithinScreen()
    {
        // Lấy kích thước của camera theo hệ tọa độ thế giới
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // Lấy kích thước của máy bay
        float objectHalfWidth = GetComponent<Collider2D>().bounds.extents.x;
        float objectHalfHeight = GetComponent<Collider2D>().bounds.extents.y;

        // Lấy vị trí hiện tại của máy bay
        Vector3 currentPosition = transform.position;

        // Giới hạn vị trí máy bay không ra khỏi màn hình
        float clampedX = Mathf.Clamp(currentPosition.x, -screenBounds.x + objectHalfWidth, screenBounds.x - objectHalfWidth);
        float clampedY = Mathf.Clamp(currentPosition.y, -screenBounds.y + objectHalfHeight, screenBounds.y - objectHalfHeight);

        // Đặt lại vị trí của máy bay nếu vượt ra ngoài biên
        transform.position = new Vector3(clampedX, clampedY, currentPosition.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        
    }
}
