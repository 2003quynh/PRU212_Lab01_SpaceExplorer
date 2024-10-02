using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Movement : MonoBehaviour
{
    public float speed = 2f;  // Tốc độ di chuyển của background
    
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Di chuyển background sang trái
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Kiểm tra nếu background ra khỏi màn hình và reset vị trí (tạo hiệu ứng lặp lại)
        if (transform.position.x < -10f)  // -10f là vị trí giới hạn bên trái của màn hình
        {
            // Reset vị trí background về bên phải
            transform.position = startPosition;
        }
    }
}
