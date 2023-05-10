using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 10;
    private GameManager gm;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        gm = GameObject.FindObjectOfType<GameManager>(); // azt az objektumot keessük, amelyiknek van GameManager-e
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate // itt vector alapú. A másik az erõ hatású. Aharmadik a karakter kontroller
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        controller.SimpleMove(dir * speed);
        if (horizontal == 0 && vertical == 0)
        {
            animator.SetBool("Walk_b", false);
        } else
        {
            animator.SetBool("Walk_b", true);
            transform.forward = -dir; // ezzek fordul irányba
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        gm.IncreaseScore();
    }
}
