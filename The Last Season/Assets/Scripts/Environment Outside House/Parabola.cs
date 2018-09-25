using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Parabola{

    /*Parabelfunktion
     * @param start - Startposition bei der Parabel anfängt -> Elefantenruessel
     * @param end - Endposition bei der Parabel aufhört -> Player
     * @param height - Hoehe der Parabel
     * @param t - Zeit von Startposition bis zur Endposition 
     * Func f - speichert normale Parabelfunktion
     * mid - speichert Punkte zwichen start und end um Parabel aufzubauen
     * return - gibt neuen Vector Punkt zurueck um Parabel aufzubauen 
     */

    public static Vector3 Parabola1(Vector3 start, Vector3 end, float height, float t)
    {

            Func<float, float> f = x => -4 * height * x * x + 4 * height * x;

            var mid = Vector3.Lerp(start, end, t);

            return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);

    }
}

