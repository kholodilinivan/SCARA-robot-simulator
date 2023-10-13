using System.Collections;
using UnityEngine;


namespace BLINDED_AM_ME{

	[ExecuteInEditMode]
	public class SetDepthTextureMode : MonoBehaviour {

        public DepthTextureMode mode = DepthTextureMode.Depth;
        public Camera[] RendCam;

		public void Start(){

		}

		// before a camera renders this 
		public void OnWillRenderObject()
		{

			if(!enabled)
				return;

            Camera[] cam = RendCam;
		//	Camera cam = Camera.current;
		//	if( !cam )
		//		return;
		//	cam.depthTextureMode = mode;

            for (int i = 0; i < cam.Length; i++)
            {
                cam[i].depthTextureMode = mode;
            }

		}
			
	}
}