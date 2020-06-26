using UnityEngine;
namespace Molecules.Actions.ThirdPersonController.RootMotion{
	using Molecules.Data;
	public class Turn : MonoBehaviour{
		public Transform targetObject;
		public Transform cameraPivot;
		public string horizontalInput = "Horizontal";
		public string verticalInput = "Vertical";
		public float lerpAmount = 0.3f;
		public void Start(){
			if(!States.all.ContainsKey("Player/LoopingMovement")){
                States.all["Player/LoopingMovement"] = false;
            }
		}
		public void Update(){
			if(States.all["Player/LoopingMovement"]){
				var direction = this.cameraPivot.right * Input.GetAxisRaw(this.horizontalInput);
				direction += this.cameraPivot.forward * Input.GetAxisRaw(this.verticalInput);
				direction.Set(direction.x,0f,direction.z);
				if(direction == Vector3.zero){
					return;
				}
				var target = Quaternion.LookRotation(direction);
				this.targetObject.rotation = Quaternion.Slerp(this.targetObject.rotation,target,lerpAmount);
			}
		}
    }
}
