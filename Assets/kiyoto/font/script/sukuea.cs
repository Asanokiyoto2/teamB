using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        // Z軸を中心に回転（2DではZ軸がカメラから見た奥行き）
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
