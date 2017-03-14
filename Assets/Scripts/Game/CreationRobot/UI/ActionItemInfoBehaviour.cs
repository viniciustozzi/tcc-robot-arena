using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionItemInfoBehaviour : MonoBehaviour {

	public Text info;

	public void SetInfo(ActionType type, object parameters)
	{
		info.text = type.ToString();

		if (parameters != null) {
			info.text += " " + parameters.ToString();
			}
		}

	}
