using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// コントローラーでplayer移動するために、CameraRigにRigidbodyを追加し、これを利用する方法も検討
public class MoveController : MonoBehaviour
{
    private Rigidbody rb;
    private float moveSpeed = 5.0f;
    private float angleSpeed = 10.0f;
    private Transform tf;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        tf = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        //右スティックの値を格納、右側に倒すとｘ軸１に近づき、左に倒すと-1に近ずく。上下の場合、ｙ軸方向。ｚの値はない。最大値は１で、最小値は−１である。
        Vector3 rightStick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        //ｙ軸をｚ軸に変換
        Vector3 velocity = new Vector3(rightStick.x /10, 0, rightStick.y / 10);

        // rb.velocity = velocity * moveSpeed;  //加速度を与えて移動

        tf.Translate(velocity);

        //左スティック操作で角度を変換
        Vector3 leftStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 angle = new Vector3(0, leftStick.x * angleSpeed, 0);
        //回転した時身体方向へ進むように修正すること
        // rb.angularVelocity = angle * angleSpeed;

        tf.Rotate(angle / 2);

    }
}
