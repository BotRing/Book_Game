using UnityEngine;
using UnityEngine.InputSystem;

namespace StarterAssets
{
    public class UICanvasControllerInput : MonoBehaviour
    {

        [Header("Output")]
        public FloatRotateLaunch starterAssetsInputs;

        public void NotTheOtherTwoInput(bool virtualJumpState)
        {
            starterAssetsInputs.NotTheOtherTwoInput(virtualJumpState);
        }

        public void LeftInput(bool virtualJumpState)
        {
            starterAssetsInputs.LeftInput(virtualJumpState);
        }

        public void RightinatorInput(bool virtualJumpState)
        {
            starterAssetsInputs.RightinatorInput(virtualJumpState);
        }
    }

}
