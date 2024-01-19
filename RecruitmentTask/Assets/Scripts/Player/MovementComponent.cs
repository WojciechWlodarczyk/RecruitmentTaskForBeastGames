using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public float movementSpeed = 3;
    public float runMultiplier = 2;
    public float mouseSensitivityX = 2.0f;
    public float mouseSensitivityY = 4.0f;

    private float verticalRotation = 0f;

    protected CharacterController characterController;
    protected InputManager inputManager;

    [SerializeField]
    private Transform cameraTransform;

    private bool isControllingEnabled;
    public void EnableControlling() => isControllingEnabled = true;
    public void DisableControlling() => isControllingEnabled = false;


    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        characterController = GetComponent<CharacterController>();
        inputManager = GameManager.Instance.GetInputManager;
        isControllingEnabled = true;
    }

    private float HorizontalMovementInput()
    {
        return inputManager.GetHorizontalMovementInput();
    }
    private float VerticalMovementInput()
    {
        return inputManager.GetVerticalMovementInput();
    }
    private bool RunInput()
    {
        return inputManager.GetRunInput();
    }

    Vector3 CalculateMovement()
    {
        Vector3 movement = new Vector3(HorizontalMovementInput(), 0, VerticalMovementInput());
        movement *= movementSpeed;
        movement *= RunInput() ? runMultiplier : 1;
        movement = transform.TransformDirection(movement);

        return movement;
    }

    protected virtual void MoveCharacter(Vector3 movement)
    {
        characterController.SimpleMove(movement);
    }

    void Update()
    {
        if (!isControllingEnabled)
            return;

        Vector3 movement = CalculateMovement();
        MoveCharacter(movement);
    }
    void LateUpdate()
    {
        if (!isControllingEnabled)
            return;

        ManageCameraMovement();
    }

    void ManageCameraMovement()
    {
        float mouseX = inputManager.GetMouseXInput() * mouseSensitivityX;
        float mouseY = -inputManager.GetMouseYInput() * mouseSensitivityY;

        verticalRotation += mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);

        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);
    }

}
