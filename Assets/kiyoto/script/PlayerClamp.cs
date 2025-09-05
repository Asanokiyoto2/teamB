using UnityEngine;

public class PlayerClamp : MonoBehaviour

{

    private Camera mainCamera;

    private float halfHeight;

    private float halfWidth;

    private float playerHalfWidth;

    private float playerHalfHeight;

    void Start()

    {

        mainCamera = Camera.main;

        // �v���C���[��Collider�̃T�C�Y���擾�i�Ȃ����SpriteRenderer�ł�OK�j

        BoxCollider2D col = GetComponent<BoxCollider2D>();

        if (col != null)

        {

            playerHalfWidth = col.bounds.extents.x;

            playerHalfHeight = col.bounds.extents.y;

        }

        else

        {

            SpriteRenderer sr = GetComponent<SpriteRenderer>();

            if (sr != null)

            {

                playerHalfWidth = sr.bounds.extents.x;

                playerHalfHeight = sr.bounds.extents.y;

            }

        }

    }

    void LateUpdate()

    {

        // �J�����̔����̍����ƕ����v�Z�iOrthographic�̏ꍇ�j

        halfHeight = mainCamera.orthographicSize;

        halfWidth = halfHeight * mainCamera.aspect;

        // �J�����̒��S���W

        Vector3 camPos = mainCamera.transform.position;

        // �v���C���[�̌��ݍ��W

        Vector3 pos = transform.position;

        // X���W�𐧌��i�v���C���[�̔����̕����l���j

        pos.x = Mathf.Clamp(pos.x, camPos.x - halfWidth + playerHalfWidth, camPos.x + halfWidth - playerHalfWidth);

        // Y���W�𐧌��i�v���C���[�̔����̍������l���j

        pos.y = Mathf.Clamp(pos.y, camPos.y - halfHeight + playerHalfHeight, camPos.y + halfHeight - playerHalfHeight);

        // ������̍��W��K�p

        transform.position = pos;

    }

}


