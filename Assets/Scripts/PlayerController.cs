using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("�̵� ����")]
    public float walkSpeed = 3.0f;
    public float runSpeed = 6.0f;
    public float rotationSpeed = 10.0f;

    [Header("���� ����")]
    public float attackDuration = 0.8f;     //���� ���� �ð�
    public bool canMoveWhileAttacking = false;  //���� �� �̵� ���� ���� �Ǵ� bool

    [Header("������Ʈ")]
    public Animator animator;          //������Ʈ ������ animator�� �����ϱ� ������

    private CharacterController controller;
    private Camera playerCamera;

    //���� ���� ����
    private float currentSpeed;
    private bool isAttaciking = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        UpdateAnimator();
    }

    void HandleMovement()               //�̵� �Լ� ����
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)         //�� �߿� �ϳ��� �з��� ���� ��
        {
            //ī�޶� ���� ������ �������� ����
            Vector3 cameraForward = playerCamera.transform.forward;
            Vector3 cameraRight = playerCamera.transform.right;
            cameraForward.y = 0;
            cameraRight.y = 0;
            cameraForward.Normalize();
            cameraRight.Normalize();

            Vector3 moveDirection = cameraForward * vertical + cameraRight * horizontal;     //�̵� ���� ����

            if(Input.GetKey(KeyCode.LeftShift))     //���� Shift�� ������ Run ���� ����
            {
                currentSpeed = runSpeed;
            }
            else
            {
                currentSpeed = walkSpeed;
            }

            controller.Move(moveDirection * currentSpeed * Time.deltaTime);         //ĳ���� ��Ʈ�ѷ��� �̵� �Է�

            //�̵� ���� ������ �ٶ󺸸鼭 �̵�
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation , targetRotation , rotationSpeed * Time.deltaTime);
        }
        else
        {
            currentSpeed = 0;
        }
    }

    void UpdateAnimator()
    {
        //��ü �ִ�ӵ� (runSpeed) �������� 0 ~ 1 ���
        float animatorSpeed = Mathf.Clamp01(currentSpeed / runSpeed);
        animator.SetFloat("speed", animatorSpeed);

    }
}
