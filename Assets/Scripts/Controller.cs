using UnityEngine;
using System.Collections;

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

    public static GameObject ROBOT_EDIT;
}
