using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paleta : MonoBehaviour
{
    public float speedRange = 5f;
    private GameManager gm;
    private float _tiltValue;

    

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("game_manager_tag").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
#if UNITY_ANDROID
        if(Settings.IsPlayWithMotion())
        {
            _tiltValue = GyroscopeManager.GetXFlatTilt();
            if (_tiltValue < 0)
            {
                if (_tiltValue >= -11)
                {
                    // move left slowly
                    //transform.Translate(Vector2.left * Time.fixedDeltaTime * -_tiltValue * speedRange / 11);
                    // 5.6 for speed range of 6    4.6 for speed range of 5
                    transform.Translate(Vector2.left * Time.fixedDeltaTime * (Mathf.Log10(-_tiltValue + 1) * 4.6f));  // if you change speedrange you should change 4.6
                }
                else if (_tiltValue < 11)
                {
                    // move left at max speed allowed
                    transform.Translate(Vector2.left * Time.fixedDeltaTime * 4.79f);    //log(11) * 4.6 = 4.79
                }
                else
                {
                    // don't move
                }
            }
            if (_tiltValue > 0)
            {
                //transform.Rotate(Vector3.up, Time.fixedDeltaTime * angularSpeed * tiltValue);
                if (_tiltValue <= 11)
                {
                    // move right slowly
                    // transform.Translate(Vector2.right * Time.fixedDeltaTime * _tiltValue * speedRange / 11);
                    transform.Translate(Vector2.left * Time.fixedDeltaTime * -(Mathf.Log10(_tiltValue + 1) * 4.6f));  // if you change speedrange you should change 4.6
                }
                else if (_tiltValue > 11)
                {
                    // move right at max speed allowed
                    transform.Translate(Vector2.right * Time.fixedDeltaTime * 4.79f);   
                }
                else
                {
                    // don't move
                }
            }
        }
        else // no motion
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.position.x < Screen.width/2)
                {
                    transform.Translate(Vector2.left * Time.fixedDeltaTime * speedRange * .68f);
                }
                else
                {
                    transform.Translate(Vector2.right * Time.fixedDeltaTime * speedRange * .68f);
                }
            }
        }

        
#endif
    }

    public float getPaletaTiltValue()
    {
        return _tiltValue;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("pelota_tag")) 
        {
            gm.PlayTapSound();
        }
    }
}
