using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    //temporary, probably
    [Header("Placing Sensors")]
    [SerializeField] private GameObject instSensorAt;
    [SerializeField] private GameObject sensorCount;

    [Header("Movement")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed;

    [Header("Camera")]
    [SerializeField] private Camera cameraController;
    [SerializeField] private float sensitivity;
    [SerializeField] private float reachDist;
    private float rotX = 0f;
    private float rotY = 0f;

    private bool Fire1LastFrame = false;
    private GameObject lastTarget = null;
    private GameObject sensorToPlace = null;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        rotX += Input.GetAxis("Mouse X") * sensitivity;
        rotY += Input.GetAxis("Mouse Y") * sensitivity;

        rotY = Mathf.Clamp(rotY, -50f, 50f);

        transform.rotation = Quaternion.Euler(-rotY, rotX, 0f);

        Vector3 movement;

        movement = new Vector3(Input.GetAxis("Horizontal"), -10f, Input.GetAxis("Vertical"));
        movement *= speed * Time.deltaTime;

        movement = Quaternion.Euler(0f, rotX, 0f) * movement;

        characterController.Move(movement);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (0 < Input.GetAxis("Fire2"))
        {
            if (sensorToPlace == null)
            {
                sensorToPlace = GameObject.Instantiate(sensorCount, instSensorAt.transform);

                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), sensorToPlace.GetComponentInChildren<SensorRange_Logic>().transform.GetComponent<Collider>());
            }
            if (!Fire1LastFrame && 0 < Input.GetAxis("Fire1"))
            {
                instSensorAt.transform.DetachChildren();

                sensorToPlace.GetComponent<Sensor_Logic>().onPlacement();

                sensorToPlace = null;
            }
        }
        else if (sensorToPlace != null && 0 == Input.GetAxis("Fire2"))
        {
            GameObject.Destroy(sensorToPlace);
        }
        else if (Physics.Raycast(ray, out hit, reachDist))
        {
            GameObject target = hit.transform.gameObject;

            if (target != lastTarget)
            {
                if (target.tag == "Orb")
                {
                    target.GetComponent<Orb_Logic>().HighlightOrb(true);
                }
                if (lastTarget != null && lastTarget.tag == "Orb")
                {
                    lastTarget.GetComponent<Orb_Logic>().HighlightOrb(false);
                }

                lastTarget = target;
            }

            if (!Fire1LastFrame && 0 < Input.GetAxis("Fire1") && target.tag == "Orb")
            {
                lastTarget.GetComponent<Orb_Logic>().ClickOrb();
            }
        }
        else if (lastTarget != null && lastTarget.tag == "Orb")
        {
            lastTarget.GetComponent<Orb_Logic>().HighlightOrb(false);
            lastTarget = null;
        }

        if (!Fire1LastFrame && 0 < Input.GetAxis("Fire1"))
        {
            Fire1LastFrame = true;
            Debug.Log("Left Click");

        }
        else if (Fire1LastFrame && 0 == Input.GetAxis("Fire1"))
        {
            Fire1LastFrame = false;
        }
    }
}