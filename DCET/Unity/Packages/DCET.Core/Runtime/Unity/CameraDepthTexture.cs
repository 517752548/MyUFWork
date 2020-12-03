using UnityEngine;

namespace DCETRuntime
{
    public class CameraDepthTexture : MonoBehaviour
    {
        /// <summary>
        /// How and if camera generates a depth texture.
        /// </summary>
        public DepthTextureMode depthTextureMode = DepthTextureMode.Depth;

        public void Start()
        {
            var camera = GetComponent<Camera>();

            if (camera)
            {
                camera.depthTextureMode = depthTextureMode;
            }
        }
    }
}