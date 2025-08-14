using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public Rigidbody2D rb;
    public Weapon weapon;
    private Vector2 moveInput;
    private Vector2 mousePosition;
    public Animator anim;

    // Update is called once per frame - used for inputs and times
    void Update()
    {
        if (gameObject.CompareTag("player"))
        {
            moveInput.x = Input.GetAxisRaw("Horizontal"); //for A, D and left and right arrow keys
            moveInput.y = Input.GetAxisRaw("Vertical"); //for top, down and W, X arroy keys
        }

        if (Input.GetMouseButton(0))
        {
            anim.SetTrigger("isAttacking");
            weapon.Fire();
            
        }

        moveInput.Normalize(); //makes the diagonal movement be only 1 in magnitude
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Called once per physics frame - used for physics (movement)
    private void FixedUpdate()
    {
        rb.velocity = moveInput * speed;
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        // rb.rotation = aimAngle;
    }
}
