using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject model;
    public Animator animator;
    public float speed = 15.0f;


    public const float dash_delay = 1.0f;
    public float dash_timer = 0.0f;

    public int hp = 100;

    bool isAttacking = false;

    // 애니메이터용 해시 값
    int Animator_isNormalAttacking;
    int Animator_isAttackKeyInputted;
    int Animator_isCharging;
    int Animator_isCanDashing;
    int Animator_DashTrigger;
    // Use this for initialization
    void Start () {
        animator = model.GetComponent<Animator>();

        Animator_isCharging = Animator.StringToHash("isCharging");
        Animator_isNormalAttacking = Animator.StringToHash("isNormalAttacking");
        Animator_isAttackKeyInputted = Animator.StringToHash("isAttackKeyInputted");
        Animator_DashTrigger = Animator.StringToHash("DashTrigger");
    }
	
	// Update is called once per frame
	void Update () {

        dash_timer += Time.deltaTime;

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        CharacterController characterController = GetComponent<CharacterController>();

        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger(Animator_isNormalAttacking);
            animator.SetBool(Animator_isAttackKeyInputted, true);
        }

        if (Input.GetKeyDown(KeyCode.K)  && dash_timer > dash_delay)
        {
            dash_timer = 0.0f;
            animator.SetBool(Animator_isAttackKeyInputted, false);
            animator.SetTrigger(Animator_DashTrigger);
            characterController.Move(animator.transform.forward*5.0f);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            animator.SetBool(Animator_isAttackKeyInputted, false);
            animator.SetBool(Animator_isCharging, true);
        }

        if (Input.GetKeyUp(KeyCode.L) && animator.GetBool(Animator_isCharging))
        {
            animator.SetBool(Animator_isAttackKeyInputted, false);
            animator.SetBool(Animator_isCharging, false);
        }

    }

    private void FixedUpdate()
    {

        float x_velocity = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        float y_velocity = Input.GetAxis("Vertical") * Time.fixedDeltaTime * speed;

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        CharacterController characterController = GetComponent<CharacterController>();
        rigidbody.velocity = new Vector3(x_velocity ,0 , y_velocity);

        // 캐릭터 컨트롤러 컴퍼넌트를 사용할 경우 Move를 사용해야한다.
        // 중력 적용
        characterController.Move( Physics.gravity * Time.deltaTime );

        characterController.Move(rigidbody.velocity);
        model.transform.LookAt(model.transform.position+rigidbody.velocity);

    }


}
