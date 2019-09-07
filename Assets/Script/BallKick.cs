using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallKick : MonoBehaviour
{
    //gesture try
    private KinectManager KinectManager;
    public KinectGestures KinectGestures;
    public KinectGestures.Gestures Gestures;

    public bool RightKick, LeftKick, RightSwipe;

    //Ball propertys
    public Rigidbody Rigidbody;
    public float Ballspeed = 5f;
    public Vector3 InitialPos;
    public float Minx, Maxx, Minz, Maxz;


    public bool IsRightKick()
    {
        if (RightKick)
        {
            RightKick = false;
            return true;
        }
        return false;
    }
    public bool IsLeftKick()
    {
        if (LeftKick)
        {
            LeftKick = false;
            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        KinectManager = KinectManager.Instance;
        KinectGestures = GetComponent<KinectGestures>();
        Rigidbody = GetComponent<Rigidbody>();
        InitialPos = transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {

        if (Gestures == KinectGestures.Gestures.KickRight)
        {
            RightKick = true;
        }
        else if (Gestures == KinectGestures.Gestures.KickRight)
        {
            LeftKick = true;
        }
        if (IsLeftKick())
        {
            Debug.Log("Left Kick");
        }
        if (IsRightKick())
        {
            Debug.Log("RightLick");
        }

        if (transform.position.z < Minz || transform.position.z > Maxz)
        {
            StartCoroutine(Restart());
        }
        if (transform.position.x < Minx || transform.position.x > Maxx)
        {
            StartCoroutine(Restart());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            Debug.Log("Ball in Goal post");
            StartCoroutine(Restart());
            FindObjectOfType<GameManager>().Score++;
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Leg")
        {
            Debug.Log("kicked");
            Rigidbody.AddForce(Vector3.forward * Ballspeed);
        }
    }
    
    public IEnumerator Restart()
    {
        Debug.Log("Ball pos reset");
        yield return new WaitForSeconds(2f);
        this.gameObject.transform.position = InitialPos;
        this.gameObject.transform.localRotation = Quaternion.identity;
        FindObjectOfType<GameManager>().GameCount++;
        Rigidbody.velocity = Vector3.zero;
        Rigidbody.isKinematic = false;
        transform.parent = null;
    }
}
