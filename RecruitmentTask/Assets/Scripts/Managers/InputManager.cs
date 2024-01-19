using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public string HorizontalInputName = "Horizontal";
    public string VerticalInputName = "Vertical";

    public string MouseXInputName = "Mouse X";
    public string MouseYInputName = "Mouse Y";

    public string RunInputName = "Run";
    public string EquipmentInputName = "Equipment";
    public string PickUpItemInputName = "PickUpItem";

    public float GetHorizontalMovementInput()
    {
        return GetAxis(HorizontalInputName);
    }
    public float GetVerticalMovementInput()
    {
        return GetAxis(VerticalInputName);
    }

    public float GetMouseXInput()
    {
        return GetAxis(MouseXInputName);
    }
    public float GetMouseYInput()
    {
        return GetAxis(MouseYInputName);
    }

    public bool GetRunInput()
    {
        return GetButton(RunInputName);
    }

    public bool GetEquipmentInput()
    {
        return GetButtonDown(EquipmentInputName);
    }
    public bool GetPickUpItemInput()
    {
        return GetButtonDown(PickUpItemInputName);
    }

    protected virtual float GetAxis(string name)
    {
        return Input.GetAxis(name);
    }
    protected virtual bool GetButton(string name)
    {
        return Input.GetButton(name);
    }
    protected virtual bool GetButtonDown(string name)
    {
        return Input.GetButtonDown(name);
    }

}
