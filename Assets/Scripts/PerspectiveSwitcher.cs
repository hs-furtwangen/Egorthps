using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MatrixBlender))]
public class PerspectiveSwitcher : MonoBehaviour
{
    private Matrix4x4 ortho, perspective;
    private float fov, near, far, orthographicSize;
    private float aspect;
    private MatrixBlender blender;
    private GameObject ppOrtho;
    private GameObject ppPerspective;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        blender = GetComponent<MatrixBlender>();

        ppOrtho = GameObject.Find("PostPro-Ortho");
        ppPerspective = GameObject.Find("PostPro-Perspective");

        ppOrtho.SetActive(true);
        ppPerspective.SetActive(false);

        //Get current camera ortho data
        fov = cam.fieldOfView;
        near = cam.nearClipPlane;
        far = cam.farClipPlane;
        orthographicSize = cam.orthographicSize;

        aspect = (float)Screen.width / (float)Screen.height;

        ortho = Matrix4x4.Ortho(-orthographicSize * aspect, orthographicSize * aspect, -orthographicSize, orthographicSize, near, far);
        perspective = Matrix4x4.Perspective(fov, aspect, near, far);

        cam.projectionMatrix = ortho;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            blender.BlendToMatrix(perspective, 0.3f);
            ppOrtho.SetActive(false);
            ppPerspective.SetActive(true);
        }

        if (Input.GetMouseButtonUp(1))
        {
            blender.BlendToMatrix(ortho, 0.3f);
            ppOrtho.SetActive(true);
            ppPerspective.SetActive(false);
        }
    }
}