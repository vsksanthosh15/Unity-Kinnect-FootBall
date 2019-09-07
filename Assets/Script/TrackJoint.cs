using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class TrackJoint : MonoBehaviour
{
    public BodySourceManager BodySourceManager;
    public Windows.Kinect.JointType RightLegJoint,LeftLegJoint;
    public Body[] bodies;

    public float Speed = 10;
    public float Ypos = 5;

    public GameObject LeftLeg, RightLeg;
    // Start is called before the first frame update
    void Start()
    {
        BodySourceManager = GetComponent<BodySourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BodySourceManager == null)
        {
            return;
        }
        bodies = BodySourceManager.GetData();
        if (bodies == null)
        {
            return;
        }
        foreach (var Body in bodies)
        {
            if (Body == null)
            {
                continue;
            }
            if (Body.IsTracked)
            {
                var _posRL = Body.Joints[RightLegJoint].Position;
                var _posLL = Body.Joints[LeftLegJoint].Position;
                LeftLeg.transform.position = new Vector3(_posLL.X * Speed, _posLL.Y *Speed+Ypos, _posLL.Z* Speed);
                RightLeg.transform.position = new Vector3(_posRL.X * Speed, _posRL.Y * Speed+Ypos, _posRL.Z*Speed);
            }
        }
    }
}
