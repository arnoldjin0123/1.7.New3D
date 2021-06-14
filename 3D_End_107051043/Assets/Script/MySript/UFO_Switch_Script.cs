using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO_Switch_Script : MonoBehaviour
{
    public LayerMask PlayerLayer;
    public float NearByCubeRedius = 3f;
    void Update()
    {
        Collider[] HitCollider = Physics.OverlapBox
    (transform.position, new Vector3(NearByCubeRedius, NearByCubeRedius, NearByCubeRedius), Quaternion.identity, PlayerLayer);
        if (HitCollider.Length >= 1) { this.GetComponent<WaypointsFollow>().enabled = false; this.GetComponent<MoveToGoal2>().enabled = true; }
        else if (HitCollider.Length == 0) { this.GetComponent<WaypointsFollow>().enabled = true; this.GetComponent<MoveToGoal2>().enabled = false; }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(NearByCubeRedius, NearByCubeRedius, NearByCubeRedius));
    }
}
