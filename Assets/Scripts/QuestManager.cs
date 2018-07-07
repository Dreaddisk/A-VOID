using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestManager : MonoBehaviour {

    public static int numberOfPlanet = 0;
    public int activeCoroutine = 1;
    public int keyNum;
    public GameObject Mission;
    public int timer;

    
    // Time.timeSinceLevelLoad > seconds
    private void Start()
    {
        
    }

    private void Update()
    {
        if (activeCoroutine == 1)
        {
            StartCoroutine(Wait());
        }
    }

    public IEnumerator Wait()
    {
        activeCoroutine = 0;
        yield return new WaitForSeconds(3);
        numberOfPlanet = Random.Range(1, 8);
        {
            switch (numberOfPlanet)
            {
                case 8:
                    Mission.GetComponent<Text>().text = "Go to Neptune [" + numberOfPlanet + "]";

                    break;
                case 7:
                    Mission.GetComponent<Text>().text = "Go to Uranus [" + numberOfPlanet + "]";
                    break;
                case 6:
                    Mission.GetComponent<Text>().text = "Go to Saturn [" + numberOfPlanet + "]";
                    break;
                case 5:
                    Mission.GetComponent<Text>().text = "Go to Jupiter [" + numberOfPlanet + "]";
                    break;
                case 4:
                    Mission.GetComponent<Text>().text = "Go to Mars [" + numberOfPlanet + "]";
                    break;
                case 3:
                    Mission.GetComponent<Text>().text = "Go to Earth [" + numberOfPlanet + "]";
                    break;
                case 2:
                    Mission.GetComponent<Text>().text = "Go to Venus [" + numberOfPlanet + "]";
                    break;
                case 1:
                    Mission.GetComponent<Text>().text = "Go to Mercury [" + numberOfPlanet + "]";
                    break;
            }
        }
        timer = timer + 1;
        //   Debug.Log(timer);
        activeCoroutine = 1;
    }

} // Main class

/*
 [Serializable]
public class Planet
{
    public string name;
    public Vector3 position;
}

public class QuestManager : MonoBehaviour
{
    public Planet[] availablePlanets;
    public Planet actualQuest;

    public Text questText;

    public void PickQuest()
    {
        int questIndex = Random.Range(0,availablePlanets.Length);
        actualQuest = availablePlanets[questIndex];
        questText.text = "Current Destination is: " + actualQuest.name;
    }
    void Update()
    {
    //Do quest related stuff here if you want
    }
} 
 
 */
