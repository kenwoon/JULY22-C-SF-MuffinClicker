using UnityEngine;

public static class MyToolbox
{
    public static Vector2 GetRandomVector2(float xmin, float xmax, float ymin, float ymax)
    {
        Vector2 value = new Vector2();
        value.x = Random.Range(xmin, xmax);
        value.y = Random.Range(ymin, ymax);
        return value;
    }
}
