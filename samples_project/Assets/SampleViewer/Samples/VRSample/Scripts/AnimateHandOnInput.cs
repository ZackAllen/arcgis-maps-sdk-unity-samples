using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    [SerializeField] private InputActionProperty pinchAnimationAction;
    [SerializeField] private InputActionProperty gripAnimationAction;
    private Animator handAnimator;

    void Start()
    {
        handAnimator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        handAnimator.SetFloat("Trigger", pinchAnimationAction.action.ReadValue<float>());

        handAnimator.SetFloat("Grip", gripAnimationAction.action.ReadValue<float>());
    }
}
