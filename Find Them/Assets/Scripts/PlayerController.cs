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
    [SerializeField] private float reachDist;

    private bool Fire1LastFrame = false;
    private GameObject lastTarget = null;

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

        transform.RotateAround(transform.position, transform.right, Input.GetAxis("Mouse Y") * sensitivity * -1f);
        transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * sensitivity);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, reachDist))
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
            Debug.Log("Click");

        }
        else if (Fire1LastFrame && 0 == Input.GetAxis("Fire1"))
        {
            Fire1LastFrame = false;
        }
    }
}