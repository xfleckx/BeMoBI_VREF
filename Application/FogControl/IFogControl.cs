﻿using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets.ImageEffects;

namespace Assets.VREF.Application.FogControl
{
    public interface IFogControl
    {
        void DisappeareImmediately();
        void LetFogDisappeare();
        void RaisedImmediately();
        void RaiseFog();
    }

    public class BaseFogControl : MonoBehaviour, IFogControl
    {
        public virtual void DisappeareImmediately()
        {
            throw new NotImplementedException();
        }

        public virtual void LetFogDisappeare()
        {
            throw new NotImplementedException();
        }

        public virtual void RaisedImmediately()
        {
            throw new NotImplementedException();
        }

        public virtual void RaiseFog()
        {
            throw new NotImplementedException();
        }
    }
}