using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinGun : MonoBehaviour
{

    public AimingControll _Aiming;
    public GameObject BulletPrefab;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // reset Rotation for Player Target
        if (_Aiming.isShootRay)
        {
            RaycastHit NewShootHit = _Aiming.Shoothit;
            Vector3 Direction = NewShootHit.point - transform.position;
            Quaternion NewRotation = Quaternion.LookRotation(Direction);
            transform.rotation = Quaternion.Lerp(transform.rotation , NewRotation , Time.deltaTime * _Aiming.InventoryFS);  
        }else{
            Vector3 Direction = (( Camera.main.transform.forward * 100) + Camera.main.transform.position ) - transform.position;
            Quaternion NewRotation = Quaternion.LookRotation(Direction);
            transform.rotation = Quaternion.Lerp(transform.rotation , NewRotation , Time.deltaTime * _Aiming.InventoryFS);  
        }


        // Shooting Controll
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }


    }


    // Shooting Method
    void ShootBullet()
    {
        GameObject Bullet = Instantiate(BulletPrefab , transform.position , transform.rotation);
        if (_Aiming.isShootRay)
        {
            Bullet.GetComponent<ShotBehavior>().SetTarget(_Aiming.Shoothit.point);
        }else{
            Bullet.GetComponent<ShotBehavior>().SetTarget( Camera.main.transform.forward * 1000 ) ;
        }
        Destroy(Bullet , 5f);
        
    }









}
