using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour {

	#region Variables
	SpaceCraftController	spaceCraftControl;

	#endregion Variables

	#region Functions
	void Start () {
		spaceCraftControl	=	GetComponent<SpaceCraftController>();
	}
	

	void FixedUpdate () {
		
		float 	roll	=	Input.GetAxis("Horizontal");
		float	pitch	=	Input.GetAxis	("Vertical");
		float	throttle	=	Input.GetAxis("Throttle");
		
		bool	airBrakes	=	Input.GetButton("Fire1");

		spaceCraftControl.Move (roll, pitch,0, throttle, airBrakes);
	}
	#endregion Functions

} // Main class
