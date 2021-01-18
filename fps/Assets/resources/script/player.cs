using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public static player Instance;
    public float speed = 5;
    public float mouseSpeed = 50;
    public float jumpForce = 10000;
    private Transform playObj;
    private Rigidbody rig;
    private Transform head;
    Vector3 playerEu;
    Vector3 cameraEu;
    public Animator m_Animator;
    public bool isWalking;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
        rig = GetComponent<Rigidbody>();
        head = transform.Find("Soldier_mesh");
        m_Animator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       // Vector3 angle = transform.Find("Main Camera").transform.eulerAngles;
      //  angle = new Vector3(0,angle.y,0);
      //  this.transform.eulerAngles = angle;
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
        playerEu = this.transform.eulerAngles;
        playerEu.y += Input.GetAxis("Mouse X")*15;
        cameraEu.x+= Input.GetAxis("Mouse Y") * -5;
        cameraEu.x = Mathf.Clamp(cameraEu.x, -45, 45);
        transform.eulerAngles = playerEu;
        transform.Find("Main Camera").eulerAngles = cameraEu+ playerEu;
        //   Input.GetAxis("Mouse Y");
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
        bool hasHorizontalInput = !Mathf.Approximately(h, 0f);  //判断是否为相近的两个数
        bool hasVerticalInput = !Mathf.Approximately(v, 0f);
        isWalking = hasHorizontalInput || hasVerticalInput;
        if (isWalking && gunController.Instance.isShoot)
        {
            m_Animator.SetBool("isRunAnim", true);
        }
        Debug.Log(isWalking);
        m_Animator.SetBool("isRun", isWalking);
        this.transform.Translate(new Vector3(h,0,v) * Time.deltaTime * speed,Space.Self);
    }
}
