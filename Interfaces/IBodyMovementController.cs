﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Assets.VREF.Interfaces
{
    public interface IBodyMovementController : IInputController
    {
        CharacterController Body
        {
            get; set;
        }
    }    

  /*  public interface IInputController
    {
        string Identifier { get; }

        void Enable();

        void Disable();
    }

    public interface IInputCanCalibrate
    {
        void Calibrate();
    }
    */    
}