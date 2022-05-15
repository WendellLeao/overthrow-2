// GENERATED AUTOMATICALLY FROM 'Assets/_Project/InputActions/InputActionsSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace _Project.Scripts.Inputs
{
    public class @InputActionsSystem : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputActionsSystem()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActionsSystem"",
    ""maps"": [
        {
            ""name"": ""CharacterControls"",
            ""id"": ""0350dd04-1e39-4161-83dc-898946436fc0"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""cae2ce4c-c0a2-42ce-b2e1-798814e94450"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PowerShoot"",
                    ""type"": ""Button"",
                    ""id"": ""a9b4888b-bc8d-413b-a3b1-9b20d2a344b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseLook"",
                    ""type"": ""PassThrough"",
                    ""id"": ""eb7ad548-3341-479d-a3a8-0882db6a1048"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""c6dd3146-f449-4c0b-8622-7739ced8fc37"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
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
                    ""id"": ""1fbaf58f-08a9-40bc-ac34-38e3a8f0ed9d"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00f3d276-ecf8-4c24-9d34-f322621a1383"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81b103e3-644d-46f7-b66d-caae0a340bc8"",
                    ""path"": ""<Touchscreen>/primaryTouch/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b55ee52-59b6-4763-8451-7f7dde741c00"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ad3e65c-63fc-486f-a229-04e730234181"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PowerShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuControls"",
            ""id"": ""7cc6d022-008b-425a-a371-ab2caf98b3af"",
            ""actions"": [
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""64dcba63-6cb3-476d-936b-623707ca5adf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""917ceb6c-3ee4-4ec6-a2d9-0f889910d69b"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
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
            m_CharacterControls_Shoot = m_CharacterControls.FindAction("Shoot", throwIfNotFound: true);
            m_CharacterControls_PowerShoot = m_CharacterControls.FindAction("PowerShoot", throwIfNotFound: true);
            m_CharacterControls_MouseLook = m_CharacterControls.FindAction("MouseLook", throwIfNotFound: true);
            m_CharacterControls_PauseGame = m_CharacterControls.FindAction("PauseGame", throwIfNotFound: true);
            // MenuControls
            m_MenuControls = asset.FindActionMap("MenuControls", throwIfNotFound: true);
            m_MenuControls_PauseGame = m_MenuControls.FindAction("PauseGame", throwIfNotFound: true);
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
        private readonly InputAction m_CharacterControls_Shoot;
        private readonly InputAction m_CharacterControls_PowerShoot;
        private readonly InputAction m_CharacterControls_MouseLook;
        private readonly InputAction m_CharacterControls_PauseGame;
        public struct CharacterControlsActions
        {
            private @InputActionsSystem m_Wrapper;
            public CharacterControlsActions(@InputActionsSystem wrapper) { m_Wrapper = wrapper; }
            public InputAction @Shoot => m_Wrapper.m_CharacterControls_Shoot;
            public InputAction @PowerShoot => m_Wrapper.m_CharacterControls_PowerShoot;
            public InputAction @MouseLook => m_Wrapper.m_CharacterControls_MouseLook;
            public InputAction @PauseGame => m_Wrapper.m_CharacterControls_PauseGame;
            public InputActionMap Get() { return m_Wrapper.m_CharacterControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CharacterControlsActions set) { return set.Get(); }
            public void SetCallbacks(ICharacterControlsActions instance)
            {
                if (m_Wrapper.m_CharacterControlsActionsCallbackInterface != null)
                {
                    @Shoot.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnShoot;
                    @Shoot.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnShoot;
                    @Shoot.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnShoot;
                    @PowerShoot.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPowerShoot;
                    @PowerShoot.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPowerShoot;
                    @PowerShoot.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPowerShoot;
                    @MouseLook.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMouseLook;
                    @MouseLook.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMouseLook;
                    @MouseLook.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMouseLook;
                    @PauseGame.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPauseGame;
                    @PauseGame.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPauseGame;
                    @PauseGame.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPauseGame;
                }
                m_Wrapper.m_CharacterControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Shoot.started += instance.OnShoot;
                    @Shoot.performed += instance.OnShoot;
                    @Shoot.canceled += instance.OnShoot;
                    @PowerShoot.started += instance.OnPowerShoot;
                    @PowerShoot.performed += instance.OnPowerShoot;
                    @PowerShoot.canceled += instance.OnPowerShoot;
                    @MouseLook.started += instance.OnMouseLook;
                    @MouseLook.performed += instance.OnMouseLook;
                    @MouseLook.canceled += instance.OnMouseLook;
                    @PauseGame.started += instance.OnPauseGame;
                    @PauseGame.performed += instance.OnPauseGame;
                    @PauseGame.canceled += instance.OnPauseGame;
                }
            }
        }
        public CharacterControlsActions @CharacterControls => new CharacterControlsActions(this);

        // MenuControls
        private readonly InputActionMap m_MenuControls;
        private IMenuControlsActions m_MenuControlsActionsCallbackInterface;
        private readonly InputAction m_MenuControls_PauseGame;
        public struct MenuControlsActions
        {
            private @InputActionsSystem m_Wrapper;
            public MenuControlsActions(@InputActionsSystem wrapper) { m_Wrapper = wrapper; }
            public InputAction @PauseGame => m_Wrapper.m_MenuControls_PauseGame;
            public InputActionMap Get() { return m_Wrapper.m_MenuControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MenuControlsActions set) { return set.Get(); }
            public void SetCallbacks(IMenuControlsActions instance)
            {
                if (m_Wrapper.m_MenuControlsActionsCallbackInterface != null)
                {
                    @PauseGame.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnPauseGame;
                    @PauseGame.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnPauseGame;
                    @PauseGame.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnPauseGame;
                }
                m_Wrapper.m_MenuControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @PauseGame.started += instance.OnPauseGame;
                    @PauseGame.performed += instance.OnPauseGame;
                    @PauseGame.canceled += instance.OnPauseGame;
                }
            }
        }
        public MenuControlsActions @MenuControls => new MenuControlsActions(this);
        public interface ICharacterControlsActions
        {
            void OnShoot(InputAction.CallbackContext context);
            void OnPowerShoot(InputAction.CallbackContext context);
            void OnMouseLook(InputAction.CallbackContext context);
            void OnPauseGame(InputAction.CallbackContext context);
        }
        public interface IMenuControlsActions
        {
            void OnPauseGame(InputAction.CallbackContext context);
        }
    }
}
