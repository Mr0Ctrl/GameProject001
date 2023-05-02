using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3D : MonoBehaviour
{
    [Range(1f,10f)]
    public float speed = 0.1f;
    Transform mainCam;
    Vector3 vievPosition;
    Vector3 movement;

    public Vector2 startPos;
    public Vector2 direction;

    private void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Transform>();
        vievPosition = mainCam.position;
    }

    void Update()
    {
        PlayerMove();

        mainCam.position = Vector3.Lerp(mainCam.position, transform.position + vievPosition, 0.05f);//kamera takip

        
    }

    private void PlayerMove()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);


            switch (touch.phase)
            {

                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    break;

                case TouchPhase.Ended:
                    direction = Vector2.zero;
                    break;
            }

            movement.x = direction.x;
            movement.z = direction.y;

            movement /= 500;
            Debug.Log(movement);

        }
        else
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.z = Input.GetAxisRaw("Vertical");
        }

        

        if (movement != Vector3.zero)
        {
            if (movement.magnitude > 1)
            {
                movement = movement.normalized;
            }
            transform.forward = movement; 
            transform.position += movement * Time.deltaTime * speed;
        }
    }// daha fizik tabanli bir yontem kullanilabilir
}
// bu kod tamam daha bir hafta kurcalama