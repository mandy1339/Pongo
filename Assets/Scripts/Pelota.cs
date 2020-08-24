using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    public float ballSpeed;
    Rigidbody2D rb;
    private Vector3 _preVelocity;
    [SerializeField] private float maxAngleShift = 15f;
    [SerializeField] private bool _canRotate = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.8f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * ballSpeed;
        _preVelocity = rb.velocity;

        // Logic for object rotation;
        if(_canRotate)
        {
            var dir = rb.velocity;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rb.MoveRotation(angle - 90);
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.collider.CompareTag("paleta_tag"))
        //{
        //    // rb.velocity = Vector3.Reflect(downVelocity, Vector3.up);
            
        //    GameObject paleta = collision.collider.gameObject;
        //    //float paletaCenter = paleta.transform.position.x;
        //    //float pelotaCenter = this.transform.position.x;
        //    //float paletaHalfLength = collision.collider.bounds.extents.x;

        //    //float OutputAngleMultiplier = (pelotaCenter - paletaCenter) / paletaHalfLength;
        //    //float angleShift = OutputAngleMultiplier * maxAngleShift;

        //    //rb.velocity = Quaternion.Euler(0f, 0f, -angleShift) * Vector3.Reflect(downVelocity, Vector3.up);



        //    // new way:
        //    float paletaTiltValue = paleta.GetComponent<Paleta>().getTiltValue(); // tilt value is number between -50 and 50
        //    float angleShift2 = (paletaTiltValue / 50f) * maxAngleShift;
        //    rb.velocity = Quaternion.Euler(0f, 0f, -angleShift2) * Vector3.Reflect(_preVelocity, Vector3.up);
        //    return;
        //}

        float VerticalizeAmt = 5f;
        
        // apply verticallization on all horizontal collisions
        // a horizontal collision is one where the point of contact is at the same y value as the center of the ball

        //if (collision.contactCount == 1 && Mathf.Abs(collision.contacts[0].point.y - this.transform.position.y) < 0.05f)

        if (collision.contactCount == 1 && Mathf.Abs(collision.contacts[0].point.y - this.transform.position.y) < 0.06f && _preVelocity.x >= 0)
        {
            float hitAngle = Vector3.Angle(_preVelocity, Vector3.right);
            if (hitAngle > 0.8f && hitAngle < 27f && _preVelocity.y > 0)
            {
                rb.velocity = Quaternion.Euler(0f, 0f, -VerticalizeAmt) * Vector3.Reflect(_preVelocity, Vector3.left);
            }
            else if (hitAngle > 0.8f && hitAngle < 27f && _preVelocity.y < 0)
            {
                rb.velocity = Quaternion.Euler(0f, 0f, +VerticalizeAmt) * Vector3.Reflect(_preVelocity, Vector3.left);
            }
            else if (hitAngle <= 0.8)
            {
                rb.velocity = Quaternion.Euler(0f, 0f, +VerticalizeAmt) * Vector3.Reflect(_preVelocity, Vector3.left);
            }
        }
        else if (collision.contactCount == 1 && Mathf.Abs(collision.contacts[0].point.y - this.transform.position.y) < 0.06f && _preVelocity.x < 0)
        {
            
            float hitAngle = Vector3.Angle(_preVelocity, Vector3.left);
            if (hitAngle > 0.8f && hitAngle < 27f && _preVelocity.y > 0)
            {
                rb.velocity = Quaternion.Euler(0f, 0f, VerticalizeAmt) * Vector3.Reflect(_preVelocity, Vector3.right);
            }
            else if (hitAngle > 0.8f && hitAngle < 27f && _preVelocity.y < 0)
            {
                rb.velocity = Quaternion.Euler(0f, 0f, -VerticalizeAmt) * Vector3.Reflect(_preVelocity, Vector3.right);
            }
            else if (hitAngle <= 0.8)
            {
                rb.velocity = Quaternion.Euler(0f, 0f, -VerticalizeAmt) * Vector3.Reflect(_preVelocity, Vector3.right);
            }

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // if the ball is stuck at the top bring it down
        if(collision.collider.CompareTag("top_boundary_tag") && Mathf.Abs(rb.velocity.y) <= 0.06f)
        {
            rb.velocity = (Vector3)rb.velocity + (Vector3.down * 0.41f);
        }
        
        // if the ball is stuck on the right side bounce it back
        if(collision.collider.CompareTag("right_boundary_tag") && Mathf.Abs(rb.velocity.x) <= 0.06f ) {
            rb.velocity = (Vector3)rb.velocity + (Vector3.left * 0.41f);
        }
        
        // if the ball is stuck on the left side bounce it back
        if (collision.collider.CompareTag("left_boundary_tag") && Mathf.Abs(rb.velocity.x) <= 0.06f)
        {
            rb.velocity = (Vector3)rb.velocity + (Vector3.right * 0.41f);
        }
    }

    public void Die()
    {
        // TODO Explode pelota into particles

        Destroy(this.gameObject);
    }
}
