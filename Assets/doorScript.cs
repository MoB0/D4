using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    bool isOpen;

    public float doorOpenAngle = 90.0f;
    float doorCloseAngle;
    public float doorAnimSpeed = 4.0f;

    private Quaternion doorOpen = Quaternion.identity;
    private Quaternion doorClose = Quaternion.identity;
    private bool doorGo = false;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        doorCloseAngle = transform.parent.eulerAngles.y;
        player = GameObject.Find("Player").transform;
        doorOpen = Quaternion.Euler(0, doorOpenAngle, 0);
        doorClose = Quaternion.Euler(0, doorCloseAngle, 0);
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !doorGo)
        {
            //Calculate distance between player and door
            if (Vector3.Distance(player.position, transform.position) < 4f)
            {
                if (isOpen)
                { //close door
                    StartCoroutine(moveDoor(doorClose));
                }
                else
                { //open door
                    StartCoroutine(moveDoor(doorOpen));
                }
            }
        }
    }
    public IEnumerator moveDoor(Quaternion dest)
    {
        doorGo = true;
        while (Quaternion.Angle(transform.parent.rotation, dest) > 0.001f)
        {
            transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, dest, Time.deltaTime * doorAnimSpeed);
            yield return null;
        }
        //Change door status
        isOpen = !isOpen;
        doorGo = false;
        yield return null;
    }
}
