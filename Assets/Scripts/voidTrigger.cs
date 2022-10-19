using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class voidTrigger : MonoBehaviour
{
    public MeshRenderer cubeRenderer;
    public Transform terrain;

    private float timeActivated;
    private bool isActivated;
    private Vector3 originalPos;

    private void Start()
    {
        isActivated = false;
    }

    private void Update()
    {
        if (isActivated)
        {
            timeActivated -= Time.deltaTime;

            terrain.position = originalPos + Random.onUnitSphere * (5.0f - timeActivated);

            if (timeActivated < 0)
            {
                SceneManager.LoadScene("stageTP2");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    { // OnCollisionEnter
        if (other.tag == "Player")
        {
            isActivated = true;
            timeActivated = 5.0f;
            cubeRenderer.enabled = false;
        }
    }
}
