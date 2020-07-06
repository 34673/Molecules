namespace Molecules.Actions.Animator{
    using UnityEngine;
    public class CancelMoveBeforeTime : StateMachineBehaviour{
        public string inputMagnitude;
        public string trigger;
        [Range(0f,1f)] public float normalizedTime = 0.5f;
	    public override void OnStateUpdate(Animator animator,AnimatorStateInfo stateInfo,int layerIndex){
            var input = animator.GetFloat(this.inputMagnitude) != 0;
            if(!input && stateInfo.normalizedTime < this.normalizedTime){
                animator.SetTrigger(this.trigger);
            }
	    }
	    public override void OnStateExit(Animator animator,AnimatorStateInfo stateInfo,int layerIndex){
            animator.ResetTrigger(this.trigger);
        }
    }
}