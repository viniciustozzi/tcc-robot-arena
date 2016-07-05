using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class CreationRobotManager : MonoBehaviour 
{
	public List<ActionItemInfo> ActionItens { get; set;}

	public Transform pnl_usedActions;
    public Transform pnl_onWallCollision;
	public GameObject ActionInfoPrefab;
	public InputField inputName;

	void Start()
	{
		ActionItens = new List<ActionItemInfo> ();
	}

	/// <summary>
	/// Chamado pelos clicks dos botoes na cena
	/// </summary>
	/// <param name="actionType">Action type.</param>
	/// <param name="parameters">Parameters.</param>
    public void AddActionItem(ActionType actionType, object parameters, ListActionType actionListType)
	{
        GameObject infoGO = (GameObject)Instantiate (ActionInfoPrefab);
        ActionItemInfoBehaviour info = infoGO.GetComponent<ActionItemInfoBehaviour> ();

        //Adiciona as informações corretas na tela no botão
        info.SetInfo (actionType, parameters);

        switch (actionListType)
        {
            case ListActionType.Main:
                
                info.gameObject.transform.SetParent(pnl_usedActions);
                info.transform.localScale = new Vector3(1, 1, 1);

                break;
            case ListActionType.OnWallCollision:
                info.gameObject.transform.SetParent(pnl_onWallCollision);
                info.transform.localScale = new Vector3(1, 1, 1);

                break;
            case ListActionType.OnScanRobot:
                break;
        }   

        ActionItens.Add (new ActionItemInfo() { ActionType = actionType, Parameters = parameters, ListType = actionListType});
	}

	public void SaveRobot()
	{
		RobotInfo robotInfo = new RobotInfo ();
		robotInfo.ActionsList = ActionItens;
		robotInfo.Name = inputName.text;
	
		string json = JsonConvert.SerializeObject(robotInfo);

		PlayerPrefs.SetString(robotInfo.Name, json);
		PlayerPrefs.Save();

        Debug.Log("Json salvo: " + json);

		SceneManager.LoadScene("TesteScene");
	}
}