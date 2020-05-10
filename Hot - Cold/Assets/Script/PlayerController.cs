using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Tooltip("How many seconds the object remains in attack mode")] [SerializeField] float duration = 1f;
    Animator animator;
    [SerializeField] float speed = 10f;
    [SerializeField] float rotationSpeed = 100.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("stand", true);
    }

   
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(GoToWalkMode());
            
        }
    }

    IEnumerator GoToWalkMode()
    {
        animator.SetBool("stand", false);
        animator.SetBool("walking", true);
        yield return new WaitForSeconds(duration);
        animator.SetBool("walking", false);
        animator.SetBool("stand", true);
        
    }


}

 






