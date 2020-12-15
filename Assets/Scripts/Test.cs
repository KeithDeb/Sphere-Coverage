using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Vector3 dir;
    List<Vector3> directions = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DrawDirection());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DrawDirection()
    {
        for(float angle=0; angle<Mathf.PI*2; angle += 0.1f)
        {
            for (float angle2 = 0; angle2 < Mathf.PI * 2; angle2 += 0.1f)
            {
                dir = new Vector3(Mathf.Cos(angle) * Mathf.Sin(angle2), Mathf.Sin(angle) * Mathf.Sin(angle2), Mathf.Cos(angle2));
                directions.Add(dir);
                yield return new WaitForSeconds(0.01f);

            }
               

        }
        
        
    
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(Vector3.zero, 0.1f);
        Gizmos.DrawWireSphere(Vector3.zero, 1.5f);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, dir * 1.5f);

        if (directions != null)
        {
            foreach (Vector3 point in directions)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(Vector3.zero, point);
            }
        }
    }
}
