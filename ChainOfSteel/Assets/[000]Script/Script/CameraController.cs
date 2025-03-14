using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField,Header("�Ǐ]����v���C���[�I�u�W�F�N�g")]
    private GameObject _player;

    [SerializeField, Header("�J�����̉�]���x")]
    private float _speed = 500.0f;

    private Vector3 _playerPos;//�v���C���[�̍��W

    private float _mouseInputX;//�}�E�X��X���̈ړ���
    private float _mouseInputY;//�}�E�X��Y���̈ړ���

    // Start is called before the first frame update
    void Start()
    {
        _playerPos = _player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //�J�����̈ʒu���v���C���[�ɍ��킹��
        transform.position += _player.transform.position - _playerPos;
        _playerPos = _player.transform.position;

        //�}�E�X��X����y���̓��͂��擾
        _mouseInputX = Input.GetAxis("Mouse X");
        _mouseInputY = Input.GetAxis("Mouse Y");

        //�J�����𐅕���]
        transform.RotateAround(_player.transform.position, Vector3.up, _mouseInputX * Time.deltaTime * _speed);

        //�J�����𐂒���]
        transform.RotateAround(_player.transform.position, transform.right, -_mouseInputY * Time.deltaTime * _speed);


    }
}
