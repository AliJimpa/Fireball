using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dammage : MonoBehaviour
{
    public float Health = 100;
    public GameObject DestroyObj;

    public void ApplyDamage(float Damage)
    {
        Health -= Damage;
        if (Health < 0)
        {

            Destroy(gameObject);

            if (DestroyObj != null)
            {
                GameObject NewExpolision = Instantiate(DestroyObj, transform.position, transform.rotation);
                Destroy(NewExpolision, 2f);
            }

        }
    }


}
