//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/PlayerControls.inputactions
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

namespace GILGAMESH
{
    public partial class @PlayerControls: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player Movements"",
            ""id"": ""441c7940-dbdd-4073-8108-36625e31a49f"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0ce61c73-2dc2-427a-9da3-1363909373f5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Left Stick"",
                    ""id"": ""163535ae-69cf-4c10-b992-0909ef66af7a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""64a3e50e-c4cb-4065-a652-f4c9d29d2009"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f7b70ff4-1be8-44a0-825f-71a45567b1ce"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""16b2ba14-bc02-4c79-abfd-05cc3f596ce4"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""da7a3b19-8c9e-4181-b812-ee0f963ea373"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Player Camera"",
            ""id"": ""4af1343f-95ec-4c77-8341-13f42eb12588"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""00bd429e-263e-4f69-a580-a2fff507b528"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Right Stick"",
                    ""id"": ""17563212-c347-4465-bebf-c25807d8385e"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bf660088-82f4-4776-bf21-fd1f50115ba7"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fa0d34aa-78ab-4e8a-af14-028d716c33fe"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8aa12917-8bc4-4913-b0f9-0a4b58dd29c4"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""47001baf-dc0c-472a-b24b-90b83ccd4b25"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Player Movements
            m_PlayerMovements = asset.FindActionMap("Player Movements", throwIfNotFound: true);
            m_PlayerMovements_Movement = m_PlayerMovements.FindAction("Movement", throwIfNotFound: true);
            // Player Camera
            m_PlayerCamera = asset.FindActionMap("Player Camera", throwIfNotFound: true);
            m_PlayerCamera_Movement = m_PlayerCamera.FindAction("Movement", throwIfNotFound: true);
        }

        ~@PlayerControls()
        {
            UnityEngine.Debug.Assert(!m_PlayerMovements.enabled, "This will cause a leak and performance issues, PlayerControls.PlayerMovements.Disable() has not been called.");
            UnityEngine.Debug.Assert(!m_PlayerCamera.enabled, "This will cause a leak and performance issues, PlayerControls.PlayerCamera.Disable() has not been called.");
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

        // Player Movements
        private readonly InputActionMap m_PlayerMovements;
        private List<IPlayerMovementsActions> m_PlayerMovementsActionsCallbackInterfaces = new List<IPlayerMovementsActions>();
        private readonly InputAction m_PlayerMovements_Movement;
        public struct PlayerMovementsActions
        {
            private @PlayerControls m_Wrapper;
            public PlayerMovementsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_PlayerMovements_Movement;
            public InputActionMap Get() { return m_Wrapper.m_PlayerMovements; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerMovementsActions set) { return set.Get(); }
            public void AddCallbacks(IPlayerMovementsActions instance)
            {
                if (instance == null || m_Wrapper.m_PlayerMovementsActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_PlayerMovementsActionsCallbackInterfaces.Add(instance);
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }

            private void UnregisterCallbacks(IPlayerMovementsActions instance)
            {
                @Movement.started -= instance.OnMovement;
                @Movement.performed -= instance.OnMovement;
                @Movement.canceled -= instance.OnMovement;
            }

            public void RemoveCallbacks(IPlayerMovementsActions instance)
            {
                if (m_Wrapper.m_PlayerMovementsActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IPlayerMovementsActions instance)
            {
                foreach (var item in m_Wrapper.m_PlayerMovementsActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_PlayerMovementsActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public PlayerMovementsActions @PlayerMovements => new PlayerMovementsActions(this);

        // Player Camera
        private readonly InputActionMap m_PlayerCamera;
        private List<IPlayerCameraActions> m_PlayerCameraActionsCallbackInterfaces = new List<IPlayerCameraActions>();
        private readonly InputAction m_PlayerCamera_Movement;
        public struct PlayerCameraActions
        {
            private @PlayerControls m_Wrapper;
            public PlayerCameraActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_PlayerCamera_Movement;
            public InputActionMap Get() { return m_Wrapper.m_PlayerCamera; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerCameraActions set) { return set.Get(); }
            public void AddCallbacks(IPlayerCameraActions instance)
            {
                if (instance == null || m_Wrapper.m_PlayerCameraActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_PlayerCameraActionsCallbackInterfaces.Add(instance);
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }

            private void UnregisterCallbacks(IPlayerCameraActions instance)
            {
                @Movement.started -= instance.OnMovement;
                @Movement.performed -= instance.OnMovement;
                @Movement.canceled -= instance.OnMovement;
            }

            public void RemoveCallbacks(IPlayerCameraActions instance)
            {
                if (m_Wrapper.m_PlayerCameraActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IPlayerCameraActions instance)
            {
                foreach (var item in m_Wrapper.m_PlayerCameraActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_PlayerCameraActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public PlayerCameraActions @PlayerCamera => new PlayerCameraActions(this);
        public interface IPlayerMovementsActions
        {
            void OnMovement(InputAction.CallbackContext context);
        }
        public interface IPlayerCameraActions
        {
            void OnMovement(InputAction.CallbackContext context);
        }
    }
}
