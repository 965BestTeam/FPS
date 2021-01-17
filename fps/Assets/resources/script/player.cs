using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5;
    public float mouseSpeed = 50;
    public float jumpForce = 10000;
    private Transform playObj;
    private Rigidbody rig;
    private Transform head;

    // Start is called before the first frame update
    void Start()
    {
        // playObj = 
        rig = GetComponent<Rigidbody>();
        Animator ator = GetComponent<Animator>();
        head = transform.Find("Soldier_mesh");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angle = transform.Find("Main Camera").transform.eulerAngles;
        angle = new Vector3(0,angle.y,0);
        this.transform.eulerAngles = angle;
        player_move();
        if (Input.GetButtonDown("Jump")){
            rig.AddForce(new Vector3(0f, jumpForce, 0f));
        }
        //鼠标锁定
        if (Input.GetKeyDown(KeyCode.P))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    float anger(float a)	//换算
    {
        a = a * 2;
        a = a*Mathf.Deg2Rad;	//这里是因为Mathf.sin(cos)是对弧度进行计算，所以要将角度转换成弧度。
        return a;
    }

    void player_move(){
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        this.transform.Translate(new Vector3(h,0,v) * Time.deltaTime * speed,Space.Self);
    }
}
