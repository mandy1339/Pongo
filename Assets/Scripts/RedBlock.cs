using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlock : MonoBehaviour
{
    GameManager gm;
    public GameObject redBlockExplodeParticles;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("game_manager_tag").GetComponent<GameManager>();
        gm.IncrementRedBlockCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pelota_tag"))
        {
            gm.PlayPop02Sound();
            GameObject particlesParent = Instantiate(redBlockExplodeParticles, transform.position, Quaternion.identity);
            GameObject actualParticles = particlesParent.transform.GetChild(0).gameObject;
            actualParticles.transform.localScale = actualParticles.transform.localScale * transform.localScale.y * 2;
            this.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        gm.DecrementRedBlockCount();
    }
}
