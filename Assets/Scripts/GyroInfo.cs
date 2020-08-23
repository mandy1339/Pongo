using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroInfo : MonoBehaviour
{

    Gyroscope m_Gyro;
    GUIStyle style;

    void Start()
    {
        //Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;

        style = new GUIStyle();
        style.fontSize = 40;

    }

    //This is a legacy function, check out the UI section for other ways to create your UI
    void OnGUI()
    {
        //Output the rotation rate, attitude and the enabled state of the gyroscope as a Label
        //GUI.Label(new Rect(500, 300, 200, 40), "Gyro rotation rate " + m_Gyro.rotationRate, style);
        //GUI.Label(new Rect(500, 350, 200, 40), "Gyro attitude" + m_Gyro.attitude, style);
        //GUI.Label(new Rect(500, 400, 200, 40), "Gyro enabled : " + m_Gyro.enabled, style);
        //Quaternion q1 = new Quaternion(0, 0, -Input.gyro.attitude.z, Input.gyro.attitude.w);
        //GUI.Label(new Rect(500, 450, 200, 40), "Quaternion Angles: " + q1.eulerAngles, style);
        //GUI.Label(new Rect(500, 500, 200, 40), ": " + q1.w + "    " + q1.z, style);
        GUI.Label(new Rect(500, 100, 200, 40), "" + m_Gyro.gravity.x * 50, style);
    }
}
