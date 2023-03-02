using iShape.Spline;
using Unity.Mathematics;
using UnityEngine;

public class QuarticTest : MonoBehaviour {
    
    public AnimationCurve curve = new AnimationCurve();
    public Color color = Color.green;
    
    private void OnDrawGizmos() {
        float3 pos = this.transform.position;
        
        curve.
        
        var spline = new QuarticSpline(A, B, AB);
        
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