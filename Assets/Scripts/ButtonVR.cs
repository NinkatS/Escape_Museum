/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject meatPrefab;


    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!isPressed)
        {
            button.transform.localPosition = new Vector3(0.321f, 1.378f, -0.774f);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0.321f, 1.412f, -0.774f);
            onRelease.Invoke();
            //isPressed = false;
        }
        
    }
    public void SpawnSphere()
    {

        if(meatPrefab != null) { 
        Debug.Log("SpawnSphere called!");
            

            Vector3 spawnPosition = transform.position + new Vector3(0, 1.0f, 0); // Adjust Y offset as needed
            Instantiate(meatPrefab, spawnPosition, Quaternion.identity);
            
        }
        
    }

  
}
*/

/*GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            sphere.transform.localPosition = new Vector3(0.321f, 1.378f, -0.774f);
            sphere.AddComponent<Rigidbody>();*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject meatPrefab;
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;

    private GameObject presser;
    private AudioSource sound;
    private AudioSource dogBark;
    private bool isPressed;
    private bool hasSpawned; // New flag to control spawning

    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound = audioSources[0];
        dogBark = audioSources[1];

        //sound = GetComponent<AudioSource>();
        //dogBark = GetComponent<AudioSource>();
        isPressed = false;
        hasSpawned = false; // Initialize hasSpawned to false
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0.321f, 1.378f, -0.774f);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;


            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0.321f, 1.412f, -0.774f);
            onRelease.Invoke();

            // Only spawn the object on the first press
            if (!hasSpawned)
            {
                
                SpawnSphere();
                //dogBark.Play();
                StartCoroutine(PlayDogBarkWithDelay(2.0f)); // Delay of 1 second
                hasSpawned = true; // Prevent further spawns
            }

            isPressed = false; // Reset isPressed so button can be pressed again
        }
    }

    public void SpawnSphere()
    {
        if (meatPrefab != null)
        {
            Debug.Log("SpawnSphere called!");
            Vector3 spawnPosition = transform.position + new Vector3(0, 0.3f, 0); // Adjust Y offset
            Instantiate(meatPrefab, spawnPosition, Quaternion.identity);
            //dogBark.Play();
        }
    }

    private IEnumerator PlayDogBarkWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        dogBark.Play(); // Play dog bark sound after the delay
        yield return new WaitForSeconds(delay);
        dogBark.Play(); // Play dog bark sound after the delay
    }
}
