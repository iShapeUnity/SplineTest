using iShape.Spline;
using Unity.Mathematics;
using UnityEngine;

public class CubicTest : MonoBehaviour {

    public Vector2 A = new Vector2(0,0);
    public Vector2 B = new Vector2(1,1);
    public Vector2 AB = new Vector2(0.4f,0.2f);
    public Color color = Color.cyan;
    
    private void OnDrawGizmos() {
        float3 pos = this.transform.position;
        var spline = new CubicSpline(A, B, AB);

        Gizmos.color = color;
        Vector3 a = new float3(spline.Point(0), 0) + pos;
        int n = 20;
        for (int i = 1; i <= n; ++i) {
            Vector3 b = new float3(spline.Point((float)i / n), 0) + pos;
            Gizmos.DrawLine(a, b);
            a = b;
        }
    }

}
