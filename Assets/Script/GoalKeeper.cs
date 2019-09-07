using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeper : MonoBehaviour
{
    public Animator Animator;
    public GameObject GoalKeyobj;
    public GameObject HandPos;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponentInParent<Animator>();
        GoalKeyobj = GameObject.Find("GoalKepperAnimation1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if ( other.gameObject.tag == "Ball" && this.gameObject.tag == "Up" )
        {
            Animator.Play("Gk DiveUP");
            Debug.Log("dive up");
        }
        if (other.gameObject.tag == "Ball" && this.gameObject.tag == "Right")
        {
            Animator.Play("Gk Dive right");
            Debug.Log("dive right");
        }
        if (other.gameObject.tag == "Ball" && this.gameObject.tag == "Left")
        {
            Animator.Play("GK dive left");
            Debug.Log("dive left");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            collision.gameObject.transform.position = HandPos.transform.position;
            collision.gameObject.transform.parent = HandPos.transform;
            FindObjectOfType<BallKick>().Rigidbody.isKinematic = true;
            StartCoroutine(FindObjectOfType<BallKick>().Restart());
            ResetPosition();
        }
    }
    public void ResetPosition()
    {
        Debug.Log("GK pos Rest");
        GoalKeyobj.transform.localPosition = new Vector3(0, 0, 45);
        GoalKeyobj.transform.localRotation = new Quaternion(0, -90f, 0, 0);
        Animator.Play("Gk Idel");
    }
}
