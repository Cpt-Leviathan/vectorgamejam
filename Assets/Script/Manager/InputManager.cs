using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager 
{

    public static InputPkg GetKeysInput()
        {
            //Create package
            InputPkg toRet = new InputPkg();

        toRet.A = Input.GetKey(KeyCode.A);
        toRet.S = Input.GetKey(KeyCode.S);
        toRet.D = Input.GetKey(KeyCode.D);
        toRet.W = Input.GetKey(KeyCode.W);
        toRet.F = Input.GetKey(KeyCode.F);
        toRet.uno = Input.GetKeyDown(KeyCode.Alpha1);
        toRet.dos = Input.GetKeyDown(KeyCode.Alpha2);
        toRet.tres = Input.GetKeyDown(KeyCode.Alpha3);


        return toRet;
        }

        public class InputPkg
        {
        public bool A;
        public bool S;
        public bool D;
        public bool W;
        public bool F;
        public bool uno;
        public bool dos;
        public bool tres;
    }

    }
