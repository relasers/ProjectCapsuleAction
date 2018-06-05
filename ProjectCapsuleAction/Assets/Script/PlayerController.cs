using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject model;
    public Animator animator;
    public float speed = 15.0f;

    bool isAttacking = false;

    // 애니메이터용 해시 값
    int Animator_isNormalAttacking;
    int Animator_isAttackKeyInputted;
    // Use this for initialization
    void Start () {
        animator = model.GetComponent<Animator>();


        Animator_isNormalAttacking = Animator.StringToHash("isNormalAttacking");
        Animator_isAttackKeyInputted = Animator.StringToHash("isAttackKeyInputted");

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger(Animator_isNormalAttacking);
            animator.SetBool(Animator_isAttackKeyInputted, true);
        }

	}

    private void FixedUpdate()
    {

        float x_velocity = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        float y_velocity = Input.GetAxis("Vertical") * Time.fixedDeltaTime * speed;

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        CharacterController characterController = GetComponent<CharacterController>();
        rigidbody.velocity = new Vector3(x_velocity ,0 , y_velocity);

        // 중력 적용
        characterController.Move( Physics.gravity * Time.deltaTime );

        characterController.Move(rigidbody.velocity);
        model.transform.LookAt(model.transform.position+rigidbody.velocity);

    }


}
