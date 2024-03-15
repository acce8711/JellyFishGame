using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    private float movementSpeed;


    bool moveRight, moveLeft, moved = false;

    //VARAIBLES FOR CUSTOM DRAG
    [SerializeField]
    private float dragAmount;


    //vars for rows
    public float left = -5.0f;
    public float center = 0f;
    public float right = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //varaible init
        movementSpeed = 500.0f;
        dragAmount = 3.0f;

    }

    // Update is called once per frame
    void Update()
    {
        //horizontal = Input.GetAxis("Horizontal");

        //transform.Translate(new Vector3(horizontal, 0.0f, 0.0f) * movementSpeed * Time.deltaTime);
        if (rb.velocity.x == 0)

        {
            moved = false;
        }

        //trying out impluse forces based on input direction
        if (!moveRight && !moveLeft && !moved)
        {
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                moveRight = true;
                //moved = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                moveLeft = true;
                //moved= true;
            }
            moved = true;
            
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
        if(Mathf.Abs(sideVelocity) > 1)
        {
            Vector3 dragForce = new Vector3(-dragAmount * sideVelocity, 0, 0);
            rb.AddForce(dragForce, ForceMode.Force);
        }
        else
        {
            //rb.transform.position = rb.transform.position;
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        }
        
        
        Debug.Log("side: " + sideVelocity);

        //(Mathf.Abs(sideVelocity) > 1 ? sideVelocity : 0)
    }


}
