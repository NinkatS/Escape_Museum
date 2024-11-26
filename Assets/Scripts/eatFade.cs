/*using System.Collections;
using UnityEngine;

public class eatFade : MonoBehaviour
{
    public GameObject object2; // Reference to object2
    public float fadeDuration = 2.0f; // Duration of the fade effect in seconds

    private bool isFading = false; // To prevent multiple fade routines

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is object2
        if (other.gameObject == object2 && !isFading)
        {
            StartCoroutine(FadeOut()); // Start fading out
        }
    }

    private IEnumerator FadeOut()
    {
        isFading = true;

        // Get the renderer and material of object1
        Renderer renderer = GetComponent<Renderer>();
        Color originalColor = renderer.material.color;

        // Fade out over the specified duration
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration); // Gradually decrease alpha
            renderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        // Completely transparent and then destroy object1
        renderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        Destroy(gameObject); // Destroy object1 after fading out
    }
}*/

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;



public class eatFade : MonoBehaviour
{

    public GameObject crownPrefab;

    private AudioSource eatingSound;
    private AudioSource crownSound;

    private bool hasSpawned; // New flag to control spawning

    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        eatingSound = audioSources[0];
        crownSound = audioSources[1];
        hasSpawned = false;

    }



    public Vector3 spawnPosition = new Vector3(-9.9f, 0.882f, -5.533f);
    //public GameObject object2; // Reference to object2

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is object2
        if (other.gameObject.name == "dogMouth")
        {
            Debug.Log("Collision with object2 detected, disabling object1.");
            //Destroy(gameObject);

            //StartCoroutine(DelayAfterEating(6.0f));

            StartCoroutine(HandleCollision());

            //gameObject.SetActive(false); // Disable object1
            // Alternatively, use Destroy(gameObject); to completely remove it
            //gameObject.SetActive(false); // Disable object1
            // Alternatively, you can use Destroy(gameObject); to completely remove it



            /*if (!hasSpawned)
            {
                //sound.Play();
                SpawnCrown();
                hasSpawned = true; // Prevent further spawns
            }*/

        }
    }
    public void SpawnCrown()
    {
        if (crownPrefab != null)
        {
           
            crownSound.Play();
            Debug.Log("SpawnSphere called!");
            //Vector3 spawnPosition = transform.position + new Vector3(0, 0.7f, 0); // Adjust Y offset
            Instantiate(crownPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private IEnumerator HandleCollision()
    {
        eatingSound.Play(); // Play eating sound
        yield return new WaitForSeconds(eatingSound.clip.length); // Wait until eatingSound is done

        // After eating sound completes, disable object and spawn crown
        gameObject.SetActive(false);

        if (!hasSpawned)
        {
            SpawnCrown(); // Play crown sound and spawn crown
            hasSpawned = true;
        }
    }

}

