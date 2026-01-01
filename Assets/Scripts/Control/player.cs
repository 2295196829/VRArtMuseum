using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class player : MonoBehaviour
{
    //Player
    CharacterController playerCtrl;
    public Transform playerTran;
    public float speed = 3.0f;
    public float gravity = 2.0f;

    //Camera
    public Transform cameraTran;
    Vector3 cameraRotate;
    float cameraHeight = 1.0f;
    void Start()
    {
        playerTran = this.transform;

        //Component
        playerCtrl = GetComponent<CharacterController>();
        cameraTran = Camera.main.transform;

        //Camera fixed
        cameraTran.position = playerTran.TransformPoint(0, cameraHeight, 0);
        cameraTran.rotation = playerTran.rotation;
        cameraRotate = playerTran.eulerAngles;

        //Cursor Lock
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Control();
    }

    void Control()
    {
        //Move
        Vector3 moveTo = Vector3.zero;
        moveTo.x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        moveTo.z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        moveTo.y -= gravity * Time.deltaTime;
        playerCtrl.Move(playerTran.TransformDirection(moveTo));

        //Camera
        float rh = Input.GetAxis("Mouse X");
        float rv = Input.GetAxis("Mouse Y");

        cameraRotate.x -= rv;
        cameraRotate.y += rh;
        cameraTran.eulerAngles = cameraRotate; //旋转摄像机
        Vector3 camRot = cameraTran.eulerAngles;
        camRot.x = 0;
        camRot.z = 0;
        playerTran.eulerAngles = camRot; //仅仅只需要让主角的面朝向相机的方向就行，不用旋转别的方向
        cameraTran.position = transform.TransformPoint(0, cameraHeight, 0);
    }
}

