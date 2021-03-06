﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpaceCraftController : MonoBehaviour {

	#region Variables
	public float MaxEnginePower	=	40f;
	public float RollEffect	=	50f;
	public float PitchEffect	=	50f;
	public float YawEffect	=	0.2f;
	public float BankedTrunEffect	=	0.5f;
	public float AutoTurnPitch	=	0.5f;
	public float AutoRollLevel	=	0.1f;
	public float AutoPitchLevel	=	0.1f;
	public float AirBreaksEffect	=	3f;
	public float ThrottleChangeSpeed	=	0.3f;
	public float DragIncreaseFactor	=	0.001f;

	private float Throttle;
	private float ForwardSpeed;
	private float EnginePower;
	private float cur_MaxEnginePower;
	private float RollAngle;
	private float PitchAngle;
	private float RollInput;
	private float PitchInput;
	private float YawInput;
	private float ThrottleInput;

	private float OriginalDrag;
	private float OriginalAngularDrag;
	private float AeroFactor	=	1;
	private	float	BankedTurnAmount;
	private	Rigidbody	rigidbody;

	WheelCollider[] cols;


	private bool Immobilized	=	false;
	private bool	AirBrakes;

	#endregion Variables

	#region Functions
	void Start () {
		rigidbody	=	GetComponent<Rigidbody>();

		OriginalDrag	=	rigidbody.drag;
		OriginalAngularDrag	=	rigidbody.angularDrag;

		for(int i = 0; i	<	transform.childCount;	i++){

			foreach(var	componentsInChild in transform.GetChild(i).GetComponentsInChildren<WheelCollider>()){

				componentsInChild.motorTorque	=	0.18f;
			}
		}
	}
	

	void Update () {
		
	}
	#endregion Functions

	public void Move(float rollInput, float pitchInput, float yawInput, float throttle, bool airBrakes){

		this.RollInput	=	rollInput;
		this.PitchInput	=	pitchInput;
		this.YawInput	=	yawInput;
		this.Throttle	=	throttle;
		this.AirBrakes	=	airBrakes;

		 ClampInput();
		 CalculateRollAndPitchAngles();
		 AutoLevel();
		 CalculateForwardSpeed();
		 ControleThrottle();
		 CalculateDrag();
		 CalculateLineForces();

		 if(Throttle	<	0.1f){

			 Vector3	currenntVelocity	=	rigidbody.velocity;
			 Vector3	newVelocity	=	currenntVelocity	*	Time.deltaTime;
			 rigidbody.velocity	=	currenntVelocity	-	newVelocity;
		 }
	}

	void ClampInput(){

		RollInput	=	Mathf.Clamp(RollInput, -1, 1);
		PitchInput	=	Mathf.Clamp(PitchInput, -1, 1);
		YawInput	=	Mathf.Clamp(PitchInput, -1, 1);
		ThrottleInput	=	Mathf.Clamp(ThrottleInput, -1, 1);
	}

	void CalculateRollAndPitchAngles(){

		Vector3 flatForward	=	transform.forward;
		flatForward.y	=	0;

	if(flatForward.sqrMagnitude	>0){

		flatForward.Normalize();

		Vector3 localFlatForward	=	transform.InverseTransformDirection(flatForward);

		PitchAngle	=	Mathf.Atan2(localFlatForward.y, localFlatForward.z);

		Vector3 flatRight	=	Vector3.Cross(Vector3.up, flatForward);
		Vector3 localFlatRight	=	transform.InverseTransformDirection(flatRight);
		
		RollAngle	=	Mathf.Atan2(localFlatRight.y, localFlatRight.x);
	}
}

	void AutoLevel(){

		BankedTurnAmount	=	Mathf.Sin(RollAngle);

		if(RollInput == 0){

			RollInput	=	-RollAngle*AutoRollLevel;
		}

		if(PitchInput	==	0f){

			PitchInput	=	-PitchAngle*AutoPitchLevel;
			PitchInput	-=	Mathf.Abs(BankedTurnAmount*BankedTurnAmount*AutoTurnPitch);

		}
	}

	void CalculateForwardSpeed(){

		Vector3 localVelocity	=	transform.InverseTransformDirection(rigidbody.velocity);

		ForwardSpeed	=	Mathf.Max(0, localVelocity.z);
	}

	void ControleThrottle(){

		if(Immobilized){
			ThrottleInput	=	-0.5f;
		}

		Throttle	=	Mathf.Clamp01(Throttle	+	ThrottleInput*Time.deltaTime*ThrottleChangeSpeed);

		EnginePower	=	Throttle	*	MaxEnginePower;
	}

	void CalculateDrag(){

		float extraDrag	=	rigidbody.velocity.magnitude	*	DragIncreaseFactor;
		rigidbody.drag	=	(AirBrakes	?	(OriginalDrag + extraDrag) * AirBreaksEffect : OriginalDrag	+	extraDrag);
		rigidbody.angularDrag	=	OriginalAngularDrag	*	ForwardSpeed	/	1000	+	OriginalAngularDrag;
	}

	void CalculateLineForces(){

		Vector3 forces	=	Vector3.zero;

		forces	+=	EnginePower	*	transform.forward;
		rigidbody.AddForce(forces);
	}

	void CalculateTorque(){

		Vector3 torque = Vector3.zero;
		torque 	+= PitchInput	*	PitchEffect	*	transform.right;
		torque	+=	YawInput	*	YawEffect	*	transform.up;
		torque	+=	RollInput	*	RollEffect	*	transform.forward;
		torque	+=	BankedTurnAmount	*	BankedTrunEffect	*	transform.up;

		rigidbody.AddTorque(torque	*	AeroFactor);
	}

	public void Immobilize(){

		Immobilized	=	true;
	}

	public void Reset()
	{
		Immobilized	=	true;
	}
	
} // Main class
