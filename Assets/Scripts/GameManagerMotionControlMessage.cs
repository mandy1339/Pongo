using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMotionControlMessage : MonoBehaviour
{
    [SerializeField] GameObject checkImage;
    private bool _checkBoxDontShowAgain = false;
    // Start is called before the first frame update
    void Start()
    {
        checkImage.SetActive(false);
        PlayerPrefs.SetInt("ShowMotionMessage", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickCheckboxButton()
    {
        if (_checkBoxDontShowAgain == false)
        {
            _checkBoxDontShowAgain = true;
            checkImage.SetActive(true);
        }
        else
        {
            _checkBoxDontShowAgain = false;
            checkImage.SetActive(false);
        }
    }

    public void OnClickMotionMessageOKButton()
    {
        if (_checkBoxDontShowAgain == true)
        {
            PlayerPrefs.SetInt("ShowMotionMessage", 0);
        }
        if (PlayerPrefs.GetString("ChosenProjectile", "none").Equals("none") || PlayerPrefs.GetString("ChosenProjectile", "none").Equals(""))
        {
            PlayerPrefs.SetString("ChosenProjectile", "Ball01");
            SceneManager.LoadScene("ProjectileSelectionScreen");
        }
        else
        {
            SceneManager.LoadScene("LevelSelectionScreen");
        }
    }
}
