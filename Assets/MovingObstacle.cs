using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour {

    public float moveSpeed = 3.0f;
    public bool left = true;
    public LayerMask Moving;
    Vector3 moveDirection;
    // Use this for initialization
    void Start () {
        moveDirection = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hitInfo;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ray intoScreen = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(intoScreen, out hitInfo, 1000, Moving))
            {
                if (left == true)
                {
                    moveDirection = Vector3.right;
                    left = false;
                }
                else
                {
                    moveDirection = Vector3.left;
                    left = true;
                }
            }
        }
        moveDirection.Normalize();
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
