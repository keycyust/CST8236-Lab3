using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wall : MonoBehaviour
{

    public AudioSource exploding;
    public List<ParticleSystem> particles;

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name + " collision begins");
        if (exploding != null)
        {
            exploding.Play();
        }
        if (particles.Count > 0)
        {
            foreach (ParticleSystem particlesSystem in particles)
            {

                particlesSystem.transform.position = collider.transform.position;
                particlesSystem.Play();
            }
        }
    }

    void OnTriggerStay(Collider collider)
    {
        Debug.Log(collider.gameObject.name + " collision is taking place");
    }

    void OnTriggerExit(Collider collider)
    {
        Debug.Log(collider.gameObject.name + " collision is finished");

    }
}
