using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour 
{
    public float velocidadMovimiento = 3f;

    public float sensibilidadMouse = 100f;
    public Transform playerBody;
    public float xRotacion;
    public float yRotacion;
    

    
    void Start()
    {
       
    }

   
    void Update()
    {
      Move();  
      MouseLook();

    }


    void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 inputPlayer = new Vector3(hor,0,ver);
        transform.Translate(new Vector3(hor,0,ver) * velocidadMovimiento * Time.deltaTime);
    }

    void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") *sensibilidadMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") *sensibilidadMouse * Time.deltaTime;

        xRotacion -= mouseY;
        xRotacion -= mouseX;
    }
}
