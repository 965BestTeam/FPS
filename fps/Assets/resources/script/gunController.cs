using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{
    public static gunController Instance;
    public GameObject bullet;
    public Transform bulletPoint;
    private float shootCD = 0.2f;
    private float timer = 0f;
    public AudioClip shootSound;
    private AudioSource Audio;
    public bool isShoot;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetMouseButton(0) && timer > shootCD){
            isShoot = true;
            timer = 0f;
            Audio.PlayOneShot(shootSound);
            player.Instance.m_Animator.SetBool("isShoot", true);
            Instantiate(bullet,bulletPoint.position,bulletPoint.rotation);
        }
        else
        {
            player.Instance.m_Animator.SetBool("isShoot", false);
        }
       // player.Instance.m_Animator.SetBool("isShoot", false);
    }
}
