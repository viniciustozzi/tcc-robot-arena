using System.Collections.Generic;
using UnityEngine;

public class RobotAnalyser : MonoBehaviour
{
	void Start()
	{
        var executeRobot = new GameObject();
        executeRobot.AddComponent(typeof(ExecuteCycle));

        var executeComponent = executeRobot.GetComponent<ExecuteCycle>();

	}
}
