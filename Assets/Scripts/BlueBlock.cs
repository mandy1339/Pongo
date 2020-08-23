using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlock : MonoBehaviour
{
    GameManager gm;
    public GameObject blueBlockExplodeParticles;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("game_manager_tag").GetComponent<GameManager>();
        gm.IncrementBlueBlockCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("pelota_tag"))
        {
            gm.PlayPop01Sound();
            GameObject particlesParent = GameObject.Instantiate(blueBlockExplodeParticles, transform.position, Quaternion.identity);
            GameObject actualParticles = particlesParent.transform.GetChild(0).gameObject;
            actualParticles.transform.localScale = actualParticles.transform.localScale * transform.localScale.y * 2;
            this.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        gm.DecrementBlueBlockCount();
    }
}
