using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float movementSpeed = 100.0f;


    bool moveRight, moveLeft = false;

    //VARAIBLES FOR CUSTOM DRAG
    [SerializeField]
    float dragAmount = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal = Input.GetAxis("Horizontal");
        
        //transform.Translate(new Vector3(horizontal, 0.0f, 0.0f) * movementSpeed * Time.deltaTime);

        //trying out impluse forces based on input direction
        if(Input.GetKeyUp(KeyCode.RightArrow) && !moveRight)
        {
            moveRight = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && !moveLeft)
        {
            moveLeft = true;
        }

    }

    private void FixedUpdate()
    {
        //continous force moveing the obj forward
       // rb.AddForce(transform.forward * Time.deltaTime * movementSpeed, ForceMode.Force);

        //trying out impluse force based on the input collected in Update()
        if (moveRight)
        {
            rb.AddForce(transform.right * Time.deltaTime * movementSpeed, ForceMode.Impulse);
            moveRight = false;

        } 
        else if (moveLeft)
        {
            rb.AddForce(transform.right * Time.deltaTime * -movementSpeed, ForceMode.Impulse);
            moveLeft = false;
        }

        Drag();
        


    }

    private void Drag()
    {
        float sideVelocity = rb.velocity.x;
        Vector3 dragForce = new Vector3(-dragAmount * (Mathf.Abs(sideVelocity) > 0.5 ? sideVelocity : 0), 0, 0);
        rb.AddForce(dragForce, ForceMode.Force);
        Debug.Log("side: " + sideVelocity);

        //(Mathf.Abs(sideVelocity) > 1 ? sideVelocity : 0)
    }


}
