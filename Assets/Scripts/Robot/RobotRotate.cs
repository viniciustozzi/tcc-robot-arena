using UnityEngine;
using System.Collections;
using System;

public class RobotRotate : MonoBehaviour {

	public float rotationSpeed;

    public Transform transformToChange;

    private float m_degrees;
    private Action m_onFinishTurn;

	public void SetParameter(object value)
	{
		float.TryParse(value.ToString(), out m_degrees);
	}

    IEnumerator RotateObject(Transform objToRotate, float yRotation, float speed, Action onRotateCompleted)
    {
        float inc = (yRotation / speed) * Time.deltaTime;
        float finalRotation = objToRotate.eulerAngles.y + yRotation;

        do{
            
            objToRotate.rotation = Quaternion.Slerp(objToRotate.rotation, Quaternion.Euler(objToRotate.eulerAngles.x, finalRotation, objToRotate.eulerAngles.z), inc);  //Quaternion.Euler(0, objToRotate.eulerAngles.y + inc , 0);
        
            yield return null;

            if ( Math.Round(objToRotate.eulerAngles.y,1) == Math.Round(finalRotation,1))
            {
                if (onRotateCompleted != null)
                    onRotateCompleted.Invoke();
                
                break;
            }

        }while(true);
    }

	public void TurnCommand(Action callback)
	{
		turnCommand(callback);
	}

    /// <summary>
    /// Rotate the robot an amount of degrees
    /// </summary>
	private void turnCommand(Action callback = null)
    {
        StartCoroutine(RotateObject(transformToChange, m_degrees, rotationSpeed, callback));
    }

    private Vector3 DegreeToVector(float degrees)
    {
        float radians = degrees * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0);
    }
}
