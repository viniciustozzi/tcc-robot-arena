using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Controller : MonoBehaviour
{
    private static Controller m_instance;

    public static Controller Instance
    {
        get
        {
            //If the controller instance already exists and is not null, return itself
            if (m_instance != null)
                return m_instance;

            //On contrary, find the Controller component on the scene
            var controller = FindObjectOfType<Controller>();

            //If the controller script is on the scene, return this instance
            if (controller != null)
                return controller;
            
            //Otherwise, creates a new gameobject, add the Controller component
            //Then get this component, and returns the controller component that was created
            var controllerGO = new GameObject();
            controllerGO.AddComponent(typeof(Controller));
            controller = controllerGO.GetComponent<Controller>();
            return controller;       
        }
    }

    public GameObject CURRENT_EDIT_ROBOT;

    public List<RobotMain> AllRobotsSaved = new List<RobotMain>();

    public void EnableModal(string message = "", Action onCloseCallback = null)
    {
        ModalBehaviour modal = FindObjectOfType<ModalBehaviour>();

        //Se já existir uma modal na cena
        if (modal != null)
        {
            //Mata a modal
            Destroy(modal.gameObject);
        }
        else
        {
            //Carrega o prefab de modal do resources
            var modalGO = Resources.Load<GameObject>("Prefabs/pnl_MessageModal");

            //Instancia o modal e preenche a informação da mensagem
            Instantiate(modalGO).GetComponent<ModalBehaviour>().SetInfo(message, onCloseCallback);
        }
    }
}
