using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private float x;
    private float y;
    private Vector3 rotateValue;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetButton("Fire3")){

            transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
            transform.LookAt(player);

            //y = Input.GetAxis("Mouse X");
            //x = Input.GetAxis("Mouse Y");
            //rotateValue = new Vector3(x, y * -1, 0);
            //transform.eulerAngles = transform.eulerAngles - rotateValue;
        }
    }
}
