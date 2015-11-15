using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public GameObject explosionParticles;

    void OnCollisionEnter(Collision col)
    {
        GameObject explosion = Instantiate(explosionParticles, transform.position, Quaternion.identity) as GameObject;
        if (col.gameObject.tag == "Cat")
        {
            Destroy(col.gameObject, 0.05f);
        }
        Destroy(gameObject);
        Destroy(explosion, 10.0f);
    }

    void OnTriggerEnter(Collider col)
    {
        
        if (col.tag == "Cat")
        {
            GameObject explosion = Instantiate(explosionParticles, transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject, 0.05f);
            Destroy(gameObject);
            Destroy(explosion, 10.0f);
        }
       
    }
}
