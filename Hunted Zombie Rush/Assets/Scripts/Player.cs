using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


public class Player : MonoBehaviour {

    private Animator anim;
    private Rigidbody rigidbody;
    [SerializeField] private float jumpForce = 100.0f;
    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private AudioClip sfxDeath;

    private bool jump = false;
    private AudioSource audioSource;

    void Awake() {
        Assert.IsNotNull(sfxJump);
        Assert.IsNotNull(sfxDeath);
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.instance.GameOver && GameManager.instance.GameStarted) {

            if (Input.GetMouseButtonDown(0)) {
                GameManager.instance.PlayerStartedGame();
                Debug.Log("Jump");
                anim.Play("Jump");
                audioSource.PlayOneShot(sfxJump);
                rigidbody.useGravity = true;
                jump = true;
            }
        }
	}
    private void FixedUpdate() {
        if (jump == true) {
            jump = false;

            rigidbody.velocity = new Vector2(0, 0);
            rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);

        }
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "obstacle") {
            rigidbody.AddForce(new Vector2(50, 20), ForceMode.Impulse);
            rigidbody.detectCollisions = false;
            audioSource.PlayOneShot(sfxDeath);
            GameManager.instance.PlayerCollided(); 
        }
    }
}
