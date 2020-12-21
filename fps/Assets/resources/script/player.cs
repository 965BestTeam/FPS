using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5;
    public float mouseSpeed = 50;
    public float jumpForce = 10000;
    private new Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");//-1 ~ 1
        float v = Input.GetAxis("Vertical");
        // float mouse = Input.GetAxis("Mouse ScrollWheel");
        this.transform.Translate(new Vector3(h * speed,0, v * speed) * Time.deltaTime, Space.World);
        if (Input.GetButtonDown("Jump")){
            rig.AddForce(new Vector3(0f, jumpForce, 0f));
        }
        this.transform.eulerAngles = transform.FindChild("Main Camera").transform.eulerAngles;
    }
}
