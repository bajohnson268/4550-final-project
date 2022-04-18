using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class movingStuff
{

    public static IEnumerator move(GameObject obj, Vector3 target)
    {

        while (!obj.transform.position.Equals(target))
        {

            obj.transform.position = Vector3.MoveTowards(obj.transform.position, target, 3 * Time.deltaTime);

            yield return new WaitForEndOfFrame();

        }

    }

    public static IEnumerator rotate(GameObject obj, Quaternion target)
    {

        while (!Quaternion.Angle(obj.transform.rotation, target).Equals(0))
        {

            obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, target, 8 * Time.deltaTime);

            yield return new WaitForEndOfFrame();

        }

    }

    public static IEnumerator move(GameObject obj, Vector3 target, float speed)
    {

        while (!obj.transform.position.Equals(target))
        {

            obj.transform.position = Vector3.MoveTowards(obj.transform.position, target, speed * Time.deltaTime);

            yield return new WaitForEndOfFrame();

        }

    }

    public static IEnumerator rotate(GameObject obj, Quaternion target, float speed)
    {

        while (!Quaternion.Angle(obj.transform.rotation, target).Equals(0))
        {

            obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, target, speed * Time.deltaTime);

            yield return new WaitForEndOfFrame();

        }

    }

}
