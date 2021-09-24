using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class WeaponPivot : MonoBehaviour {

    private Vector3 mousePos;

    private void Awake() {
        mousePos = new Vector3();

    }

    private void Update() {
        mousePos = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDir = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
