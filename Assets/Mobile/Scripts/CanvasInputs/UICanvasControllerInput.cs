using UnityEngine;

namespace StarterAssets
{
    public class UICanvasControllerInput : MonoBehaviour
    {
        public ServerManager serverManager;
        [Header("Output")]
        public StarterAssetsInputs starterAssetsInputs;

        private void Start()
        {
            Invoke("Atama", 2f);
        }
        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            starterAssetsInputs.MoveInput(virtualMoveDirection);
        }

        public void VirtualLookInput(Vector2 virtualLookDirection)
        {
            starterAssetsInputs.LookInput(virtualLookDirection);
        }

        public void VirtualJumpInput(bool virtualJumpState)
        {
            starterAssetsInputs.JumpInput(virtualJumpState);
        }

        public void VirtualSprintInput(bool virtualSprintState)
        {
            starterAssetsInputs.SprintInput(virtualSprintState);
        }
        void Atama()
        {
            starterAssetsInputs = serverManager.oyuncular[serverManager.oyuncular.Count - 1].transform.GetComponent<StarterAssetsInputs>();

        }
    }

}
