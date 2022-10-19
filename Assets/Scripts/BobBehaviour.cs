using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobBehaviour : MonoBehaviour
{
    public GameObject fx;

    private AudioSource aud;
    public GameObject worldObject;


    void Start()
    {
        aud = GameObject.Find("Audio").GetComponent<AudioSource>();
        worldObject = GameObject.Find("World");
    }
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    { // OnCollisionEnter
        if (other.tag == "Player")
        {
            worldObject.SendMessage("AddHit");
            Instantiate(fx, transform.position, Quaternion.identity);
            Destroy(gameObject);
            if (aud)
            {
                aud.Play();
            }
        }
    }
}
