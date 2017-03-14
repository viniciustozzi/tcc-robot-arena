using UnityEngine;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Linq.Expressions;
using Newtonsoft.Json;

public class Robot : MonoBehaviour
{
    public RobotMove move;
    public RobotRotate rotateRobot;
    public RobotRotate rotateCannon;
    public RobotShot shot;

	private RobotInfo m_robotInfo;

	private List<Action> m_robotActions;
	private List<MonoBehaviour> m_components; 
	private List<object> m_storedParams;

	private int m_currentAction = 0;

	public Action _OnHitWall { get ; set; }

	private void setupActions()
	{
		m_storedParams = new List<object>();
		m_robotActions = new List<Action>();
		m_components = new List<MonoBehaviour>();

		foreach (var item in m_robotInfo.ActionsList)
		{
            switch (item.ListType)
            {
                case ListActionType.Main:
                    break;
                case ListActionType.OnWallCollision:
                    break;
                case ListActionType.OnScanRobot:
                    break;
            }

			switch (item.ActionType)
			{
				case ActionType.MoveAhead:
					m_robotActions.Add (() => move.AheadCommand(_onEndExecuteAction));
					m_storedParams.Add(item.Parameters);
					m_components.Add(move);
					break;
				case ActionType.MoveBack:
					m_robotActions.Add(() => move.BackCommand(_onEndExecuteAction));
					m_storedParams.Add(item.Parameters);
					m_components.Add(move);
					break;
				case ActionType.RotateRobot:
					//m_robotActions.Add(() => rotateRobot.TurnCommand(_onEndExecuteAction));
					m_storedParams.Add(item.Parameters);
					m_components.Add(rotateRobot);
					break;
				case ActionType.RotateCannon:
					//m_robotActions.Add(() => rotateCannon.TurnCommand(_onEndExecuteAction));
					m_storedParams.Add(item.Parameters);
					m_components.Add(rotateCannon);
                    break;
				case ActionType.Shoot:
					m_robotActions.Add(() => shot.ShootCommand(_onEndExecuteAction));
					m_storedParams.Add(item.Parameters);
					m_components.Add(shot);
					break;
			}
		}
	}

	private void executeAllActions()
	{
		//if (m_components[m_currentAction] is RobotMove)
		//	((RobotMove)m_components[m_currentAction]).SetParameter(m_storedParams[m_currentAction]);
		//else if (m_components[m_currentAction] is RobotRotate)
		//	((RobotRotate)m_components[m_currentAction]).SetParameter(m_storedParams[m_currentAction]);
		//else if (m_components[m_currentAction] is RobotShot)
		//	((RobotShot)m_components[m_currentAction]).SetParameter(m_storedParams[m_currentAction]);
		
		m_robotActions[m_currentAction].Invoke();
	}

	private void _onEndExecuteAction()
	{
        m_currentAction++;

		if (m_currentAction >= m_robotActions.Count)
			m_currentAction = 0;
        
		executeAllActions();
	}

	public void LoadRobotInfo(string robotName)
	{
		if (!PlayerPrefs.HasKey(robotName))
		{
			Debug.LogWarning("Não há nenhum robo com esse nome");
			return;
		}

		string robotFile = PlayerPrefs.GetString(robotName);
		m_robotInfo = JsonConvert.DeserializeObject<RobotInfo>(robotFile);
		Debug.Log("Robot loaded: " + m_robotInfo.Name);

		setupActions();
		executeAllActions();
	}

	void OnCollisionEnter(Collision hit)
	{
		if (hit.transform.tag == "Wall")
		{
			if (_OnHitWall != null)
				_OnHitWall.Invoke();
		}
	}
}