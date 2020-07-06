namespace Molecules.Actions.Animator{
    using Molecules.Data;
    using UnityEngine;
    public class IsActive : StateMachineBehaviour{
        public string targetState;
        public override void OnStateEnter(Animator animator,AnimatorStateInfo stateInfo,int layerIndex){
            States.all[this.targetState] = true;
        }
		public override void OnStateExit(Animator animator,AnimatorStateInfo stateInfo,int layerIndex){
            States.all[this.targetState] = false;
        }
    }
}