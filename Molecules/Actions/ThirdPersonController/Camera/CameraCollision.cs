using UnityEngine;
namespace Molecules.Actions.ThirdPersonController.Camera{
	public class CameraCollision : MonoBehaviour{
        public new Transform transform;
        public Transform pivot;
        public LayerMask layer;
        [HideInInspector] public Vector3 direction;
        [HideInInspector] public Vector3 distance;
        public void Start(){
            this.direction = this.transform.localPosition.normalized;
            this.distance = this.transform.localPosition;
        }
        public void Update(){
            var ray = new Ray();
            var raycastHit = new RaycastHit();
            ray.origin = this.pivot.position;
            ray.direction = this.pivot.TransformDirection(this.direction);
            if(Physics.Raycast(ray,out raycastHit,this.distance.magnitude,this.layer)){
                this.transform.position = raycastHit.point;
            }
            else{
                var destination = Vector3.Project(this.distance,this.direction);
                this.transform.localPosition = Vector3.Slerp(this.transform.localPosition,destination,Time.deltaTime);
            }
        }
    }
}

