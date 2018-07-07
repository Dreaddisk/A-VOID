using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	#region Variables

	public float speed;
	public Text fuelText;
	public Image fuelImage;

	[SerializeField]
	private float _fuelTime;
	[SerializeField]
	private float _maxTime;
	#endregion Variables

	#region Functions
	void Start () {
		
	}
	

	void Update () {
		PlayerMove();
	}
	#endregion Functions

	public void PlayerMove(){

		if(Input.GetKey(KeyCode.W)){

			transform.position	+=	Vector3.forward	*	speed	*	Time.deltaTime;
		}
		else if(Input.GetKey(KeyCode.A)){

			transform.position	+= Vector3.left	*	speed	*	Time.deltaTime;
		}
		else if(Input.GetKey(KeyCode.S)){

			transform.position	+=	Vector3.back	*	speed	*	Time.deltaTime;
		}
		else if(Input.GetKey(KeyCode.D)){

			transform.position	+= Vector3.right * speed	*	Time.deltaTime;
		}
		
	}

	public void UpdateUI(){

		fuelImage.fillAmount	=	_fuelTime/_maxTime;
		fuelText.text	=	"Fuel: "	+	(_fuelTime	/	_maxTime).ToString();
	}
} // Main class
