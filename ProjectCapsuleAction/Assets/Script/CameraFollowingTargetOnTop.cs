using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowingTargetOnTop : MonoBehaviour {

    public GameObject FollowingTarget;

    // 목표 기준 얼마나 공중에 있을 것인가.
    public float AirDistance = 20.0f;

    //X,Z 평면 플레이어와 얼마나 떨어져 있을 것인가.
    public float BackOffDistance = 13.0f ;

    // 목표 기준 얼마나 정면을 바라볼 것인가.
    public float LookDistance = 5.0f;
    public float CameraTargetFocusSpeed = 0.2125f;
    Vector3 LookTargetDirection;

	// Use this for initialization
	void Start () {
        LookTargetDirection = FollowingTarget.transform.position + FollowingTarget.transform.forward * LookDistance;

    }

    private void FixedUpdate()
    {
        if (FollowingTarget)
        {

            transform.position = new Vector3
                (FollowingTarget.transform.position.x,
                FollowingTarget.transform.position.y + AirDistance,
                FollowingTarget.transform.position.z - BackOffDistance);
            LookTargetDirection = Vector3.Lerp(LookTargetDirection, (FollowingTarget.transform.position + FollowingTarget.transform.forward * LookDistance), CameraTargetFocusSpeed);

            transform.LookAt(LookTargetDirection);

        }
    }

    // Update is called once per frame
    void Update () {

       


	}
}
