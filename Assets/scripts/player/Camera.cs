using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if (Input.GetButton("Fire3")){
        //    transform.RotateAround(player.transform.position, Vector3.up, Input.GetAxis("Mouse X")*70 * Time.deltaTime);
        //    transform.LookAt(player);
        //}
    }
}
