using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WayPointCross : MonoBehaviour {

    public Transform    Mercury;
    public Transform    Venus;
    public Transform    Earth;
    public Transform    Mars;
    public Transform    Jupiter;
    public Transform    Saturn;
    public Transform    Uranus;
    public Transform    Neptune; 
    public float        speed;
    public Transform SpaceShip;

    public Text fuelText;
	public Image fuelImage;

    [SerializeField]
    private float FuelConsumptionRate  = 10f;
    [SerializeField]
    private float MaxFuelConsumptionRate = 2000f;

    float currentFuel;

    void Start()
    {
        currentFuel = MaxFuelConsumptionRate;
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        FuelGauge();
       

    }

    public void PlayerMovement(){

        if(Input.GetKey(KeyCode.Keypad1)){

       float step  =   speed   *   Time.deltaTime;
        transform.position  =   Vector3.MoveTowards(transform.position, Mercury.position, step);
        transform.LookAt(Mercury);
        }

        else if(Input.GetKey(KeyCode.Keypad2)){

            float   step    =   speed   *   Time.deltaTime;
            transform.position  =   Vector3.MoveTowards(transform.position, Venus.position, step);
            transform.LookAt(Venus);
        }

        else if(Input.GetKey(KeyCode.Keypad3)){

            float step  =   speed   *   Time.deltaTime;
            transform.position  =   Vector3.MoveTowards(transform.position, Earth.position, step);
            transform.LookAt(Earth);
        }
        else if(Input.GetKey(KeyCode.Keypad4)){

            float step  =   speed   *   Time.deltaTime;
            transform.position  =   Vector3.MoveTowards(transform.position, Mars.position, step);
            transform.LookAt(Mars);
        }
        else if(Input.GetKey(KeyCode.Keypad5)){

            float step  =   speed   *   Time.deltaTime;
            transform.position  =   Vector3.MoveTowards(transform.position, Jupiter.position, step);
            transform.LookAt(Jupiter);
        }

        else if(Input.GetKey(KeyCode.Keypad6)){

            float step  =   speed   *   Time.deltaTime;
            transform.position  =   Vector3.MoveTowards(transform.position, Saturn.position, step);
            transform.LookAt(Saturn);
        }
        else if(Input.GetKey(KeyCode.Keypad7)){

            float step  =   speed   *   Time.deltaTime;
            transform.position  =   Vector3.MoveTowards(transform.position, Uranus.position, step);
            transform.LookAt(Uranus);
        }
        else if(Input.GetKey(KeyCode.Keypad8)){

            float step  =   speed   *   Time.deltaTime;
            transform.position  =   Vector3.MoveTowards(transform.position, Neptune.position, step);
            transform.LookAt(Neptune);
        }
    }
    public void FuelGauge(){

        currentFuel -= FuelConsumptionRate * Time.fixedDeltaTime;
        fuelImage.fillAmount = Mathf.InverseLerp(0, MaxFuelConsumptionRate, currentFuel);
//        Debug.Log(MaxFuelConsumptionRate);
//      Debug.Log(currentFuel);

        if(currentFuel <= 0){

            SceneManager.LoadScene(0);
        }

    }


} // Main class
