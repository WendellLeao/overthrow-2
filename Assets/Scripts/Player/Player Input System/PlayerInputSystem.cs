// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/Player Input System/PlayerInputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputSystem"",
    ""maps"": [
        {
            ""name"": ""CharacterControls"",
            ""id"": ""0350dd04-1e39-4161-83dc-898946436fc0"",
            ""actions"": [
                {
                    ""name"": ""HorizontalMouse"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e2bf92c2-63a9-4899-aa81-844fb9e7badb"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""VerticalMouse"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4b686f01-6005-4840-aa3b-bbbff456dc24"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""cae2ce4c-c0a2-42ce-b2e1-798814e94450"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9673b706-612a-420e-a515-b6643cd1b152"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8cce268a-bbfa-45e3-ba71-abf6611220eb"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54f10131-3a44-4658-8ac4-bdac6863d169"",
                    ""path"": ""<Mouse>/position/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterControls
        m_CharacterControls = asset.FindActionMap("CharacterControls", throwIfNotFound: true);
        m_CharacterControls_HorizontalMouse = m_CharacterControls.FindAction("HorizontalMouse", throwIfNotFound: true);
        m_CharacterControls_VerticalMouse = m_CharacterControls.FindAction("VerticalMouse", throwIfNotFound: true);
        m_CharacterControls_Shoot = m_CharacterControls.FindAction("Shoot", throwIfNotFound: true);
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

    // CharacterControls
    private readonly InputActionMap m_CharacterControls;
    private ICharacterControlsActions m_CharacterControlsActionsCallbackInterface;
    private readonly InputAction m_CharacterControls_HorizontalMouse;
    private readonly InputAction m_CharacterControls_VerticalMouse;
    private readonly InputAction m_CharacterControls_Shoot;
    public struct CharacterControlsActions
    {
        private @PlayerInputSystem m_Wrapper;
        public CharacterControlsActions(@PlayerInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @HorizontalMouse => m_Wrapper.m_CharacterControls_HorizontalMouse;
        public InputAction @VerticalMouse => m_Wrapper.m_CharacterControls_VerticalMouse;
        public InputAction @Shoot => m_Wrapper.m_CharacterControls_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_CharacterControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControlsActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControlsActions instance)
        {
            if (m_Wrapper.m_CharacterControlsActionsCallbackInterface != null)
            {
                @HorizontalMouse.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnHorizontalMouse;
                @HorizontalMouse.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnHorizontalMouse;
                @HorizontalMouse.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnHorizontalMouse;
                @VerticalMouse.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnVerticalMouse;
                @VerticalMouse.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnVerticalMouse;
                @VerticalMouse.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnVerticalMouse;
                @Shoot.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_CharacterControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @HorizontalMouse.started += instance.OnHorizontalMouse;
                @HorizontalMouse.performed += instance.OnHorizontalMouse;
                @HorizontalMouse.canceled += instance.OnHorizontalMouse;
                @VerticalMouse.started += instance.OnVerticalMouse;
                @VerticalMouse.performed += instance.OnVerticalMouse;
                @VerticalMouse.canceled += instance.OnVerticalMouse;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public CharacterControlsActions @CharacterControls => new CharacterControlsActions(this);
    public interface ICharacterControlsActions
    {
        void OnHorizontalMouse(InputAction.CallbackContext context);
        void OnVerticalMouse(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
