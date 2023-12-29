using System;
using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSystem : MonoBehaviour
{
    private Vector3 oldPosition= new Vector3(0,0,0);
    private float BulletSpeed = 100f;

    private float Vpx;
    public Vector3 coord(Vector3 coordinate, Vector3 myPosition)
    {
        Vector3 newPosition = coordinate;

        float Xr = coordinate.x - myPosition.x;
        float Yr = coordinate.y - myPosition.y;
        float Zr = coordinate.z - myPosition.z;

        float Vox = newPosition.x - oldPosition.x;
        float Voy = newPosition.y - oldPosition.y;
        float Voz = newPosition.z - oldPosition.z;

        float a = Xr/Yr;
        float b = (Xr*Voy-Yr*Vox)/Xr;
        float c = Zr/Xr;
        float d = (Xr*Voz-Zr*Vox)/Xr;

        float root = MathF.Sqrt(BulletSpeed*BulletSpeed*(1+a*a+c*c) - MathF.Pow((b*c-a*d),2) - b*b - d*d);
        if(root < 0){
            return coordinate;
        }

        float Vpx1 = (-(a*b+c*d) + root)/(1+a*a+c*c);
        float Vpx2 = (-(a*b+c*d) - root)/(1+a*a+c*c);
        
        if(MathF.Abs(Vpx1) > BulletSpeed){
            Vpx1 = 0;
        }
        if(MathF.Abs(Vpx2) > BulletSpeed){
            Vpx2 = 0;
        }

        if(Xr <0 && Vpx1 >0){
            Vpx1 = 0;
        }
        if(Xr >0 && Vpx1 <0){
            Vpx1 = 0;
        }

        if(Xr <0 && Vpx2 >0){
            Vpx2 = 0;
        }
        if(Xr >0 && Vpx2 <0){
            Vpx2 = 0;
        }

        if(Vpx1 == 0f && Vpx2 == 0f){
            return coordinate;
        }
        

        if(Vpx1 == 0){
            Vpx = Vpx2;
        }
        else{
            Vpx = Vpx1;
        }

        float Vpy = a*Vpx+b;
        float Vpz = c*Vpx+d;

        Debug.Log(new Vector3(Vpx,Vpy,Vpz));
        oldPosition = newPosition;
        return new Vector3(Vpx,Vpy,Vpz);
    }
}
