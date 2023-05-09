using UnityEngine;

namespace TrickySpikes.Utils {
    public static class CircleUtils {
        
        public static int RandomAngle => Random.Range(0, 360);

        public static Vector2 GetCirclePointFromAngle(float angle, float radius) {
            angle *= Mathf.Deg2Rad;
            return new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        }

        public static Vector2 GetRandomPositionFromAngle(Vector2 circleCenter, float radius, float circleAngle, float rangeAngle, out float randomAngle) {
            float firstPart = (360f - rangeAngle * 2f) / 2f;

            float firstAngle = circleAngle + firstPart;
            float secondAngle = firstAngle + rangeAngle * 2f;

            randomAngle = Random.Range(firstAngle, secondAngle);
            if (randomAngle > 360f) randomAngle %= 360f;

            return circleCenter + GetCirclePointFromAngle(randomAngle, radius);
        }

        public static Vector2 GetPositionOnCircleEdge(Vector2 circleCenter, float radius, float angle) =>
            circleCenter + GetCirclePointFromAngle(angle, radius);

        public static Vector2 GetRandomPositionOnCircleEdge(Vector2 circleCenter, float radius) =>
            GetPositionOnCircleEdge(circleCenter, radius, RandomAngle);
    }
}
