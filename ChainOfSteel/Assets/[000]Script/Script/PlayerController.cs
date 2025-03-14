using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

//�v���C���[�̈ړ������@�e�X�g�p

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigitBody;//RigitBody�R���|�[�l���g
    private Animator _animator;//Animator�R���|�[�l���g

    [SerializeField, Header("�v���C���[�̈ړ����x")]
    private float _speed = 5.0f;

    private float _inputHorizontal;//���������̓���
    private float _inputVertical;//���s�����̓���

    private Vector3 _cameraForward;//�J�����̑O����
    private Vector3 _moveForward;//�ړ�����


    void Start()
    {
        _rigitBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }


   void Update()
    {
        _inputHorizontal = Input.GetAxis("Horizontal");
        _inputVertical = Input.GetAxis("Vertical");

        //�ړ��A�j���[�V��������
        if(_inputHorizontal != 0 || _inputVertical != 0)
        {
            _animator.SetBool("Run", true);
        }

        if(_inputHorizontal == 0 && _inputVertical == 0)
        {
            _animator.SetBool("Run", false);
        }


    }

    void FixedUpdate()
    {
        //�J�����̑O�������擾
        _cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        //�ړ��������擾
        _moveForward = _cameraForward * _inputVertical + Camera.main.transform.right * _inputHorizontal;

        //�ړ����x��K�p���āA�v���C���[���ړ�������
        _rigitBody.velocity= _moveForward * _speed + new Vector3(0, _rigitBody.velocity.y, 0);

        //�ړ��������[���łȂ���΁A�v���C���[�̈ړ������ɕύX����
        if (_moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_moveForward);
        }

    }

}
