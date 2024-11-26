using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class giveCrown : MonoBehaviour
{
    public GameObject textPrefab;
    private bool hasSpawned; // New flag to control spawning

    void Start()
    {
        
        hasSpawned = false;

    }



    public Vector3 spawnPosition = new Vector3(-0.003000259F, 0.8003265f, 0.285f);
    public Vector3 spawnRotation = new Vector3(0, 143, 0);
    //public GameObject object2; // Reference to object2

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is object2
        if (other.gameObject.name == "kingHead")
        {
            Debug.Log("Collision with object2 detected, disabling object1.");
            
            
            if (!hasSpawned)
            {
                //sound.Play();
                SpawnText();
                hasSpawned = true; // Prevent further spawns
            }

        }
    }
    public void SpawnText()
    {
        if (textPrefab != null)
        {

            //crownSound.Play();
            Debug.Log("SpawnSphere called!");
            Quaternion customRotation = Quaternion.Euler(spawnRotation);

            //Vector3 spawnPosition = transform.position + new Vector3(0, 0.7f, 0); // Adjust Y offset
            Instantiate(textPrefab, spawnPosition, customRotation);
        }
    }
}
