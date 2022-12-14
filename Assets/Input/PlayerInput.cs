//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Input/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""3b31e0e9-4062-421e-8734-8cb02861a761"",
            ""actions"": [
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""eb9926d5-0465-4c21-97bf-234fc9c04620"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""TouchTap"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6b750eb6-2271-4fbe-a703-d2a7edab7621"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""918750b1-298c-4b39-bf40-bc00b87ac5ad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""88163099-7267-453f-a4ff-ea555987ddc1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""20a061c5-c09a-4a43-bd7f-db15a638a7a3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f81d929-4a8d-4a6b-bb52-fec92101d799"",
                    ""path"": ""<Touchscreen>/primaryTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchTap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b306acb-4fc4-4fe2-9759-cf318843d901"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a1ee4ca-fb9b-4e63-bb5b-ee695a3e9acb"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_MouseClick = m_Main.FindAction("MouseClick", throwIfNotFound: true);
        m_Main_TouchTap = m_Main.FindAction("TouchTap", throwIfNotFound: true);
        m_Main_TouchPress = m_Main.FindAction("TouchPress", throwIfNotFound: true);
        m_Main_TouchPosition = m_Main.FindAction("TouchPosition", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_MouseClick;
    private readonly InputAction m_Main_TouchTap;
    private readonly InputAction m_Main_TouchPress;
    private readonly InputAction m_Main_TouchPosition;
    public struct MainActions
    {
        private @PlayerInput m_Wrapper;
        public MainActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseClick => m_Wrapper.m_Main_MouseClick;
        public InputAction @TouchTap => m_Wrapper.m_Main_TouchTap;
        public InputAction @TouchPress => m_Wrapper.m_Main_TouchPress;
        public InputAction @TouchPosition => m_Wrapper.m_Main_TouchPosition;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @MouseClick.started -= m_Wrapper.m_MainActionsCallbackInterface.OnMouseClick;
                @MouseClick.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnMouseClick;
                @MouseClick.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnMouseClick;
                @TouchTap.started -= m_Wrapper.m_MainActionsCallbackInterface.OnTouchTap;
                @TouchTap.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnTouchTap;
                @TouchTap.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnTouchTap;
                @TouchPress.started -= m_Wrapper.m_MainActionsCallbackInterface.OnTouchPress;
                @TouchPress.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnTouchPress;
                @TouchPress.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnTouchPress;
                @TouchPosition.started -= m_Wrapper.m_MainActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnTouchPosition;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseClick.started += instance.OnMouseClick;
                @MouseClick.performed += instance.OnMouseClick;
                @MouseClick.canceled += instance.OnMouseClick;
                @TouchTap.started += instance.OnTouchTap;
                @TouchTap.performed += instance.OnTouchTap;
                @TouchTap.canceled += instance.OnTouchTap;
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
            }
        }
    }
    public MainActions @Main => new MainActions(this);
    public interface IMainActions
    {
        void OnMouseClick(InputAction.CallbackContext context);
        void OnTouchTap(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
    }
}
