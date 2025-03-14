using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField,Header("追従するプレイヤーオブジェクト")]
    private GameObject _player;

    [SerializeField, Header("カメラの回転速度")]
    private float _speed = 500.0f;

    private Vector3 _playerPos;//プレイヤーの座標

    private float _mouseInputX;//マウスのX軸の移動量
    private float _mouseInputY;//マウスのY軸の移動量

    // Start is called before the first frame update
    void Start()
    {
        _playerPos = _player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //カメラの位置をプレイヤーに合わせる
        transform.position += _player.transform.position - _playerPos;
        _playerPos = _player.transform.position;

        //マウスのX軸とy軸の入力を取得
        _mouseInputX = Input.GetAxis("Mouse X");
        _mouseInputY = Input.GetAxis("Mouse Y");

        //カメラを水平回転
        transform.RotateAround(_player.transform.position, Vector3.up, _mouseInputX * Time.deltaTime * _speed);

        //カメラを垂直回転
        transform.RotateAround(_player.transform.position, transform.right, -_mouseInputY * Time.deltaTime * _speed);


    }
}
