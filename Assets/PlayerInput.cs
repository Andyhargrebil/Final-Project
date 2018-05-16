using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public LayerMask floorOnly;
    private Vector3 whereClick;
    public GameObject eyes;

    public GameObject[] needToGet;

    // Use this for initialization
    void Start()
    {
        eyes.SetActive(false);
        whereClick = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        needToGet = GameObject.FindGameObjectsWithTag("pickup");
        RaycastHit hitInfo;

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetMouseButtonDown(0))
        {
            Ray intoScreen = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(intoScreen, out hitInfo, 1000, floorOnly))
            {
                whereClick = hitInfo.point + new Vector3(0, 1, 0);
            }
        }

        if (Vector3.Distance(whereClick, transform.position) < 0.1)
        {
            whereClick = transform.position;
        }

        moveDirection = whereClick - transform.position;
        moveDirection.Normalize();
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (moveDirection != Vector3.zero)
            transform.forward = moveDirection;

        if (needToGet.Length == 0)
        {
            eyes.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision hits)
    {
        if (hits.gameObject.tag == "pickup")
        {
            Destroy (hits.gameObject);
        }
    }
}
