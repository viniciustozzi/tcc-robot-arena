using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AvaibleActionsHUD : MonoBehaviour {
	
	public InputField moveFrontInput;
	public InputField moveBackInput;
	public InputField rotateRobotInput;
    public InputField rotateCannonInput;

	private CreationRobotManager m_creationManager;

	void Start()
	{
		m_creationManager = FindObjectOfType<CreationRobotManager> ();
	}

	public void MoveFrontClick(int actionListTypeIndex)
	{	
		ListActionType actionListType = (ListActionType)actionListTypeIndex;

		float speed = 0;
		float.TryParse (moveFrontInput.text, out speed);

		m_creationManager.AddActionItem (ActionType.MoveAhead, speed, actionListType);
	}

	public void MoveBackClick(int actionListTypeIndex)
	{
		ListActionType actionListType = (ListActionType)actionListTypeIndex;

		float speed = 0;
		float.TryParse (moveBackInput.text, out speed);

		m_creationManager.AddActionItem (ActionType.MoveBack, speed, actionListType);
	}

	public void RotateRobotClick(int actionListTypeIndex)
	{
		ListActionType actionListType = (ListActionType)actionListTypeIndex;

		float angles = 0;
		float.TryParse (rotateRobotInput.text, out angles);

		m_creationManager.AddActionItem(ActionType.RotateRobot, angles, actionListType);
	}

	public void RotateCannonClick(int actionListTypeIndex)
    {
		ListActionType actionListType = (ListActionType)actionListTypeIndex;

        float angles = 0;
		float.TryParse (rotateCannonInput.text, out angles);

		m_creationManager.AddActionItem(ActionType.RotateCannon, angles, actionListType);
    }

	public void ShootClick(int actionListTypeIndex)
	{
		ListActionType actionListType = (ListActionType)actionListTypeIndex;

		m_creationManager.AddActionItem (ActionType.Shoot, null, actionListType);
	}
}