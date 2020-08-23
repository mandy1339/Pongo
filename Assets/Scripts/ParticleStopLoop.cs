using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStopLoop : MonoBehaviour
{
    private float timeLeftAlive;
    private bool finished;

    // Start is called before the first frame update
    void Start()
    {
        timeLeftAlive = 1.5f;
        finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (! finished && timeLeftAlive <= 0)
        {
            this.gameObject.SetActive(false);
            finished = true;
        }
        timeLeftAlive -= Time.deltaTime;
    }
}
