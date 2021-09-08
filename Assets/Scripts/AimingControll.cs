using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingControll : MonoBehaviour
{
    public float Speed = 300;
    public GameObject Inventory;
    public float InventoryFS = 7;
    public RaycastHit Shoothit;
    public bool isShootRay ;



    private Vector3 NewRotation;
    


    // Start is called before the first frame update
    void Start()
    {
        NewRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //Make New Rotation With Mouse Axis
        NewRotation = new Vector3( 0 , ( NewRotation.y + (Input.GetAxis("Mouse X") * Speed * Time.deltaTime) ) , ( NewRotation.z + (Input.GetAxis("Mouse Y") * Speed * Time.deltaTime) ) ) ;
        transform.eulerAngles = NewRotation;

        //Make New Rotation For Inventory
        Vector3 NewRotation2 = new Vector3( Inventory.transform.eulerAngles.x , transform.eulerAngles.y  ,  Inventory.transform.eulerAngles.z);
        //Quaternion New = new Quaternion(Inventory.transform.rotation.x , Inventory.transform.rotation.z , Inventory.transform.rotation.z , transform.rotation.w);
        Inventory.transform.rotation = Quaternion.Slerp( Inventory.transform.rotation , Quaternion.Euler(NewRotation2) , Time.deltaTime * InventoryFS );
        
        
       
        
        


        
        
        // Does the ray intersect any objects excluding the player layer
        isShootRay = Physics.Raycast( Camera.main.transform.position, Camera.main.transform.forward * 100 , out Shoothit, Mathf.Infinity );
        Debug.DrawRay( Camera.main.transform.position , Camera.main.transform.forward * 100 , Color.yellow );
        


    }

}
