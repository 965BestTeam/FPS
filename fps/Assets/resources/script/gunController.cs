using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPoint;
    private float shootCD = 0.2f;
    private float timer = 0f;
    public AudioClip shootSound;
    private AudioSource Audio;
    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetMouseButton(0) && timer > shootCD){
            timer = 0f;
            Audio.PlayOneShot(shootSound);
            Instantiate(bullet,bulletPoint.position,bulletPoint.rotation);
        }
    }
}
