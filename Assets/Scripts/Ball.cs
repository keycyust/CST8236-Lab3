using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {
    public ParticleSystem[] particlesSystem;
    public float explosionRadius = 5.0f;
    public float explosionPower = 8.0f;
    public AudioSource explosion;
    private int currentPS = 0;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = new Vector3();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction.z = -1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction.z = 1;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction.x = 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))

        {
            direction.x = -1;
        }

        
                RaycastHit hit;
                bool didHit = Physics.Raycast(transform.position, direction, out hit, direction.magnitude);

                if (didHit)
                {
                    Vector3 vectorPosition = transform.position;
                   Collider[] hitColliders = Physics.OverlapSphere(vectorPosition, explosionRadius);
                    foreach (Collider collider in hitColliders)
                    {
                        Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

                        if (rigidbody != null)
                        {
                            rigidbody.isKinematic = false;
                            rigidbody.AddExplosionForce(explosionPower, vectorPosition, explosionRadius, 3.0f);
                        }
                    }
                    /*play th eexplosion audio track*/
                     explosion.Play();

            particlesSystem[currentPS].transform.position = vectorPosition;
            particlesSystem[currentPS].Play();
            currentPS = (currentPS + 1) % particlesSystem.Length;
            transform.position += (hit.distance * direction.normalized);

        }
        else {
            transform.position += direction;
        } 
    }
}
