using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoundaryAreaCollider : MonoBehaviour
{
    #region 場外に出た際に、所持コインをドロップする範囲
    [SerializeField] Transform rangePointA; // positionのパラメータを全てrangePointBより小さくする
    [SerializeField] Transform rangePointB; // positionのパラメータを全てrangePointAより大きくする
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        var compornent = collision.gameObject.GetComponent<PlayerController>();
        if (compornent != null)
        {
            if (!compornent.enabled) return;
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            PlayerAnimatorController playerAnimatorController = collision.gameObject.GetComponent<PlayerAnimatorController>();

            playerController.Respawn();
            playerController.IsControlEnabled = false;
            playerController.IsStandUp = false;
            playerAnimatorController.SetInt(PlayerAnimatorController.ANIM_ID.Respawn);

            collision.gameObject.layer = 8;
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            if (rangePointA != null && rangePointB != null) OutOfBoundsAsynk();
        }
    }

    async void OutOfBoundsAsynk()
    {
        if (rangePointA != null && rangePointB != null)
            await RoomModel.Instance.OutOfBoundsAsynk(rangePointA.position, rangePointB.position);
    }
}
