using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SunRotator : MonoBehaviour {

	#region Variables
	/// code
	#endregion Variables

	#region Functions
	void Start () {
		
	}
	

	void Update () {
		
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
    #endregion Functions

    // restart the game when collides with player.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {

            SceneManager.LoadScene(0);
        }
    }

} // Main class
