using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//The custom robot prefab
	public GameObject robotPrefab;

    public Transform startPos1;
    public Transform startPos2;

	void Awake()
	{
		GameObject robot1 = (GameObject)Instantiate(robotPrefab, startPos1.position, Quaternion.identity);

		var robotComponent1 = robot1.GetComponent<Robot>();

		if (robotComponent1 != null)
			robotComponent1.LoadRobotInfo("Robo1");
	}
}
