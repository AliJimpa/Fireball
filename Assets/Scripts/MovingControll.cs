using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingControll : MonoBehaviour
{
    public GameObject CameraHandel;
    public GameObject Inventory;
    public float JumpPower = 200;
    public float NormalPower = 200;
    public float SuperPower = 500;
    public float FallowSpeed = 2;
    

    private Rigidbody playerPhysics;
    private bool isJumping = false;
    private bool isInAir = false;
    private float Power;


    // Start is called before the first frame update
    void Start()
    {
        playerPhysics = GetComponent<Rigidbody>();
        Power = NormalPower;
    }



    // Update is called once per frame
    void Update()
    {

        // Set Power system
        PowerState();

        // Set Inventory Position
        Inventory.transform.position = transform.position;

        // Set Camera Poition
        CameraHandel.transform.position = Vector3.Slerp(CameraHandel.transform.position, transform.position, Time.deltaTime * FallowSpeed);

        // Moving System
        Vector3 MakeDirection = CameraHandel.transform.forward * -1 * Input.GetAxis("Horizontal") * Time.deltaTime;
        playerPhysics.AddForce(MakeDirection * Power);
        MakeDirection = CameraHandel.transform.right * Input.GetAxis("Vertical") * Time.deltaTime;
        playerPhysics.AddForce(MakeDirection * Power);


        // Jumping & DoubleJump
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !isInAir)
        {
            playerPhysics.AddForce(0, JumpPower, 0, ForceMode.Force);
            isJumping = true;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && isInAir && isJumping)
            {
                playerPhysics.AddForce(0, JumpPower, 0, ForceMode.Force);
                isJumping = false;
            }
        }

        
        





    }


    

    


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isInAir = false;

            if (isJumping)
                isJumping = false;
        }
    }

    private void OnCollisionExit(Collision other) {

        if (other.gameObject.CompareTag("Ground"))
        {
            isInAir = true;
        }
        
    }

    


    void PowerState()
    {
        if (isInAir)
        {
            Power = 0;
        }else{
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Power = SuperPower;
            }else{
                Power = NormalPower;
            }
        }
    }




}
