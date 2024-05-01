using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float gravity = 1;
    public float jump = 5;
    public float jumpCount = 2;
    public float speed = 5;
    public float yVelocity = 0;
    public Rigidbody rb;
    private bool attacking;
    public GameObject hitBox1;
    public GameObject hitBox2;
    public GameObject Character;

    public GameObject direction1;
    public GameObject direction2;

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.down * gravity);

        //Flipping
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine("AttackOne");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine("AttackTwo");
        }

        //rbMovement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left * speed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right * speed, ForceMode.Acceleration);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
    }
        

    //HitBoes
    private IEnumerator AttackOne()
    {
        if (attacking == true)
        {
            hitBox1.SetActive(true);
            attacking = false;
        }
        yield return new WaitForSeconds(.5f);
        hitBox1.SetActive(false);
        yield return new WaitForSeconds(.5f);
        attacking = true;
    }

    private IEnumerator AttackTwo()
    {
        if (attacking == true)
        {
            hitBox2.SetActive(true);
            attacking = false;
        }
        yield return new WaitForSeconds(.5f);
        hitBox2.SetActive(false);
        yield return new WaitForSeconds(.5f);
        attacking = true;
    }
}
