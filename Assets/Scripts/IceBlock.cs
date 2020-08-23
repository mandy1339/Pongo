using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : MonoBehaviour
{
    private int _hitCounter;
    GameManager gm;
    [SerializeField] private GameObject iceBreakParticles;
    BoxCollider2D bounceCollider;
    BoxCollider2D triggerCollider;

    // Start is called before the first frame update
    void Start()
    {
        _hitCounter = 2;
        gm = GameObject.FindGameObjectWithTag("game_manager_tag").GetComponent<GameManager>();
        bounceCollider = GetComponents<BoxCollider2D>()[0];
        triggerCollider = GetComponents<BoxCollider2D>()[1];
        triggerCollider.enabled = false;
        gm.IncrementIceBlockCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("pelota_tag"))
        {
            GetHit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("pelota_tag"))
        {
            GetHit();
        }
    }

    private void GetHit()
    {
        _hitCounter--;
        if(_hitCounter == 1)
        {
            bounceCollider.enabled = false;
            triggerCollider.enabled = true;
            gm.PlayIceCrack02Sound();
            transform.GetChild(0).gameObject.SetActive(true);
        }
        if (_hitCounter <= 0)
        {
            Explode();
        }
    }

    private void Explode()
    {
        gm.PlayIceCrackSound();
        GameObject particles = Instantiate(iceBreakParticles, transform.position, Quaternion.identity);
        Transform iceShards = particles.transform.GetChild(0);
        Transform snowFlakes = particles.transform.GetChild(1);
        iceShards.localScale = iceShards.localScale * (transform.localScale.y) * 2;
        snowFlakes.localScale = snowFlakes.localScale * (transform.localScale.y) * 2;
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        gm.DecrementIceBlockCount();
    }
}
