// GENERATED AUTOMATICALLY FROM 'Assets/_Scrips/_Inputs/Player_Inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player_Inp : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player_Inp()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player_Inputs"",
    ""maps"": [
        {
            ""name"": ""Inp"",
            ""id"": ""ca9848b8-0b83-4549-b580-96639877b73c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""d938f93b-27d3-40b3-ae75-f8c5a9714d64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""8120e4f0-693b-4402-83b6-ae232573bb0a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""7c33e649-1754-45ea-b39a-b01b4faa2e65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""5df4a093-0270-48ef-8758-8d826f95a076"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""b84f7e7b-4a66-484a-8a9e-2eec84b6750b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grapple"",
                    ""type"": ""Button"",
                    ""id"": ""f31d687c-542a-4c6a-9013-ad306f6ed9ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""65cd21e3-be1e-48d6-8795-1c8f8a4c1a8b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7b2dadaf-bdc9-493e-8139-b39087c82fbf"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cf1351c4-daec-4790-a4be-043841fa60af"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e120d90c-ef80-4b09-adac-28dffce3a188"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c39ec8c3-e3ba-4db4-bb05-a5f7dc205908"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""989e2b7d-ee74-4af2-a526-df0ed1554efa"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1ba2e29d-c585-4920-97b9-a7421f506e5e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6a5a01fc-c5c3-402c-a9e2-c3e7ec4956d7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fadc570b-eec7-497d-9be8-05b2c98ab6e2"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d8982396-d589-4513-ab19-73b345a41f4c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""25a1df51-b8a9-4e37-a573-24489528e044"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7756e04-69e2-4a6e-a52b-6382f9b37ee3"",
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
                    ""id"": ""922442e9-cc3b-4ef8-9e01-3cee7f258416"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e95647a9-3663-49c9-ac33-dceff9409d7b"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b9f454c-1697-481a-98ed-816171a2d5cf"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grapple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Inp
        m_Inp = asset.FindActionMap("Inp", throwIfNotFound: true);
        m_Inp_Move = m_Inp.FindAction("Move", throwIfNotFound: true);
        m_Inp_Aim = m_Inp.FindAction("Aim", throwIfNotFound: true);
        m_Inp_Shoot = m_Inp.FindAction("Shoot", throwIfNotFound: true);
        m_Inp_Reload = m_Inp.FindAction("Reload", throwIfNotFound: true);
        m_Inp_SwitchWeapon = m_Inp.FindAction("SwitchWeapon", throwIfNotFound: true);
        m_Inp_Grapple = m_Inp.FindAction("Grapple", throwIfNotFound: true);
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

    // Inp
    private readonly InputActionMap m_Inp;
    private IInpActions m_InpActionsCallbackInterface;
    private readonly InputAction m_Inp_Move;
    private readonly InputAction m_Inp_Aim;
    private readonly InputAction m_Inp_Shoot;
    private readonly InputAction m_Inp_Reload;
    private readonly InputAction m_Inp_SwitchWeapon;
    private readonly InputAction m_Inp_Grapple;
    public struct InpActions
    {
        private @Player_Inp m_Wrapper;
        public InpActions(@Player_Inp wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Inp_Move;
        public InputAction @Aim => m_Wrapper.m_Inp_Aim;
        public InputAction @Shoot => m_Wrapper.m_Inp_Shoot;
        public InputAction @Reload => m_Wrapper.m_Inp_Reload;
        public InputAction @SwitchWeapon => m_Wrapper.m_Inp_SwitchWeapon;
        public InputAction @Grapple => m_Wrapper.m_Inp_Grapple;
        public InputActionMap Get() { return m_Wrapper.m_Inp; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InpActions set) { return set.Get(); }
        public void SetCallbacks(IInpActions instance)
        {
            if (m_Wrapper.m_InpActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_InpActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_InpActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_InpActionsCallbackInterface.OnMove;
                @Aim.started -= m_Wrapper.m_InpActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_InpActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_InpActionsCallbackInterface.OnAim;
                @Shoot.started -= m_Wrapper.m_InpActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_InpActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_InpActionsCallbackInterface.OnShoot;
                @Reload.started -= m_Wrapper.m_InpActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_InpActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_InpActionsCallbackInterface.OnReload;
                @SwitchWeapon.started -= m_Wrapper.m_InpActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.performed -= m_Wrapper.m_InpActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.canceled -= m_Wrapper.m_InpActionsCallbackInterface.OnSwitchWeapon;
                @Grapple.started -= m_Wrapper.m_InpActionsCallbackInterface.OnGrapple;
                @Grapple.performed -= m_Wrapper.m_InpActionsCallbackInterface.OnGrapple;
                @Grapple.canceled -= m_Wrapper.m_InpActionsCallbackInterface.OnGrapple;
            }
            m_Wrapper.m_InpActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @SwitchWeapon.started += instance.OnSwitchWeapon;
                @SwitchWeapon.performed += instance.OnSwitchWeapon;
                @SwitchWeapon.canceled += instance.OnSwitchWeapon;
                @Grapple.started += instance.OnGrapple;
                @Grapple.performed += instance.OnGrapple;
                @Grapple.canceled += instance.OnGrapple;
            }
        }
    }
    public InpActions @Inp => new InpActions(this);
    public interface IInpActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnSwitchWeapon(InputAction.CallbackContext context);
        void OnGrapple(InputAction.CallbackContext context);
    }
}
