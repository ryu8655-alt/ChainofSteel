using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

//プレイヤーの移動処理　テスト用

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigitBody;//RigitBodyコンポーネント
    private Animator _animator;//Animatorコンポーネント

    [SerializeField, Header("プレイヤーの移動速度")]
    private float _speed = 5.0f;

    private float _inputHorizontal;//水平方向の入力
    private float _inputVertical;//奥行方向の入力

    private Vector3 _cameraForward;//カメラの前方向
    private Vector3 _moveForward;//移動方向


    void Start()
    {
        _rigitBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }


   void Update()
    {
        _inputHorizontal = Input.GetAxis("Horizontal");
        _inputVertical = Input.GetAxis("Vertical");

        //移動アニメーション制御
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
        //カメラの前方向を取得
        _cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        //移動方向を取得
        _moveForward = _cameraForward * _inputVertical + Camera.main.transform.right * _inputHorizontal;

        //移動速度を適用して、プレイヤーを移動させる
        _rigitBody.velocity= _moveForward * _speed + new Vector3(0, _rigitBody.velocity.y, 0);

        //移動方向がゼロでなければ、プレイヤーの移動方向に変更する
        if (_moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_moveForward);
        }

    }

}
