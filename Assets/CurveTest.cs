using iShape.Spline;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public class CurveTest : MonoBehaviour {

    public Anchor[] anchors;
    public bool isClosed;
    public bool isContour;
    public float step = 0.5f;
    
    private void OnDrawGizmos() {
        if (anchors is { Length: >= 3 }) {
            float3 pos = this.transform.position;
            NativeArray<float2> points;
            NativeArray<Anchor> nAnchors = new NativeArray<Anchor>(anchors, Allocator.Temp);
            if (isContour) {
                var contour = new Contour(nAnchors, isClosed, 20, Allocator.Temp);
                points = contour.GetPoints(step, new float2(pos.x, pos.y), Allocator.Temp);
                contour.Dispose();
            } else {
                var curve = new Curve(nAnchors, isClosed, 20, Allocator.Temp);
                points = curve.GetPoints(step, new float2(pos.x, pos.y), Allocator.Temp);
                curve.Dispose();
            }

            nAnchors.Dispose();
            
            int n = points.Length;

            int start;
            int last;
            if (isClosed) {
                start = 0;
                last = n - 1;
            } else {
                start = 1;
                last = 0;
            }

            Gizmos.color = Color.magenta;
            Vector3 a = new float3(points[last], 0);

            for (int i = start; i < n; ++i) {
                Vector3 b = new float3(points[i], 0);
                Gizmos.DrawLine(a, b);
                a = b;
            }

            points.Dispose();
        }


    }
}
