using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Vector3 targetPosition;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            locateClick();
        }
        if (isMoving)
        {
            MovePlayer();
        }
    }



    void locateClick()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
        {
            targetPosition = ray.GetPoint(point);
        }
        isMoving = true;
    }


    void MovePlayer()
    {
        transform.LookAt(targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, GetComponent<PlayerAttributes>().WalkSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            isMoving = false;
        }

    }
}
