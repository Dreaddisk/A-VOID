using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlanetScripts : MonoBehaviour {

    private void Update()
    {
        transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("First Colllision");
        if (other.gameObject.CompareTag("Player"))
        {

            ScoreCounter.scoreValue += 1;
            Debug.Log("Is hitting something");
        }
    }
} // Main class
