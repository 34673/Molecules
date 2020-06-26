namespace Molecules.Actions.ThirdPersonController.RootMotion{
	using UnityEngine;
	public class UpdateMovement : MonoBehaviour{
		public Transform cameraPivot;
		public Transform target;
		[Header("Animations")]
		public Animator animator;
		public string angleVariable;
		public string magnitudeVariable;
		[Header("Input")]
		public string horizontalAxis = "Horizontal";
		public string verticalAxis = "Vertical";
		public void Update(){
			var input = this.cameraPivot.right * Input.GetAxisRaw(this.horizontalAxis);
			input += this.cameraPivot.forward * Input.GetAxisRaw(this.verticalAxis);
			if(input != Vector3.zero){
				var currentAngle = this.target.rotation.eulerAngles.y;
				var inputAngle = Quaternion.LookRotation(input,Vector2.up).eulerAngles.y;
				if(inputAngle > 180f){inputAngle -= 360f;}
				var newAngle = currentAngle - inputAngle;
				if(newAngle > 180f){newAngle -= 360f;}
				newAngle = -newAngle;
				this.animator.SetFloat(this.angleVariable,newAngle);
			}
			this.animator.SetFloat(this.magnitudeVariable,input.magnitude);
		}
	}
}