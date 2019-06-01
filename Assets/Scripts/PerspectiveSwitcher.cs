using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MatrixBlender))]
public class PerspectiveSwitcher : MonoBehaviour
{
    private Matrix4x4 ortho, perspective;
    private float fov, near, far, orthographicSize;
    private float aspect;
    private MatrixBlender blender;
    private bool orthoOn;

    private Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
        blender = GetComponent<MatrixBlender>();

        //Get current camera ortho data
        fov = camera.fieldOfView;
        near = camera.nearClipPlane;
        far = camera.farClipPlane;
        orthographicSize = camera.orthographicSize;

        aspect = (float)Screen.width / (float)Screen.height;

        ortho = Matrix4x4.Ortho(-orthographicSize * aspect, orthographicSize * aspect, -orthographicSize, orthographicSize, near, far);
        perspective = Matrix4x4.Perspective(fov, aspect, near, far);

        camera.projectionMatrix = ortho;
        orthoOn = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            blender.BlendToMatrix(perspective, 0.3f);
        }

        if (Input.GetMouseButtonUp(1))
        {
            blender.BlendToMatrix(ortho, 0.3f);
        }
    }
}