using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour
{

	public float DammageValue = 20;
    public Vector3 m_target;
    public GameObject CollisionExplotion;
    public float Speed = 100;

	private bool isTarget = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //transform.position += transform.forward * Time.deltaTime * 1000f;

        float step = Speed * Time.deltaTime;

        if (m_target != null)
        {
            if (transform.position == m_target)
            {
                expolotion();
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, m_target, step);

        }




    }

    private void OnTriggerEnter(Collider other)
    {
		Dammage otherdamage = other.GetComponent<Dammage>();
		if ( otherdamage != null)
		{
			otherdamage.ApplyDamage(DammageValue);
			isTarget = true;
		}
		if ( !other.CompareTag("Player") )
		{
			expolotion();
		}

    }



    public void SetTarget(Vector3 target)
    {
        m_target = target;
    }


    void expolotion()
    {
        if (CollisionExplotion != null)
        {
            GameObject NewExpolision = Instantiate(CollisionExplotion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(NewExpolision, 2f);
        }
    }


















}
