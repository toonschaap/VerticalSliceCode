using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int movementSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();  
    }


    void Move()
    {
        //Geeft de buttons input
        float xAs = Input.GetAxisRaw("Horizontal");
        float yAs = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(xAs, 0.0f, yAs);
        //Smooth beweging
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        //Laat de player bewegen
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        
    }
}
