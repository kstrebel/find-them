using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed;

    [Header("Camera")]
    [SerializeField] private Camera cameraController;
    [SerializeField] private float sensitivity;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;

        movement = new Vector3(Input.GetAxis("Horizontal"), -10f, Input.GetAxis("Vertical"));
        movement *= speed * Time.deltaTime;

        characterController.Move(movement);

        //Vector3 camera = Vector3.zero;
        //
        //camera = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f);
        //camera *= sensitivity;

        transform.RotateAround(transform.position, transform.right, Input.GetAxis("Mouse Y") * sensitivity * -1f);
        transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * sensitivity);
    }
}