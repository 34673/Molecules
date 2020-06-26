namespace Molecules.Animator.ThirdPersonController.RootMotion{
    using Molecules.Data;
    using UnityEngine;
    public class CheckTurn : StateMachineBehaviour{
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
            States.all["Player/LoopingMovement"] = true;
        }
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
            States.all["Player/LoopingMovement"] = false;   
        }
    }
}