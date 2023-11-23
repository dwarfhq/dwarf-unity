﻿using UnityEngine;
/******************************************************************************
  Copyright (c) 2008-2012 Ryan Juckett
  http://www.ryanjuckett.com/
 
  This software is provided 'as-is', without any express or implied
  warranty. In no event will the authors be held liable for any damages
  arising from the use of this software.
 
  Permission is granted to anyone to use this software for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:
 
  1. The origin of this software must not be misrepresented; you must not
     claim that you wrote the original software. If you use this software
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
 
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original software.
 
  3. This notice may not be removed or altered from any source
     distribution.
******************************************************************************/

/******************************************************************************
  EDITED FROM ORIGINAL SOURCE FOR C# / UNITY USEAGE
******************************************************************************/
public static class SpringUtils
{
    //******************************************************************************
    // Cached set of motion parameters that can be used to efficiently update
    // multiple springs using the same time step, angular frequency and damping
    // ratio.
    //******************************************************************************
    public class DampedSpringMotionParams
    {
        // newPos = posPosCoef*oldPos + posVelCoef*oldVel
        public float PosPosCoef, PosVelCoef;
        // newVel = velPosCoef*oldPos + velVelCoef*oldVel
        public float VelPosCoef, VelVelCoef;
    };

    //******************************************************************************
    // This function will compute the parameters needed to simulate a damped spring
    // over a given period of time.
    // - An angular frequency is given to control how fast the spring oscillates.
    // - A damping ratio is given to control how fast the motion decays.
    //     damping ratio > 1: over damped
    //     damping ratio = 1: critically damped
    //     damping ratio < 1: under damped
    //******************************************************************************
    public static void CalcDampedSpringMotionParams(
        DampedSpringMotionParams springMotionParameters,       // motion parameters result
        float deltaTime,        // time step to advance
        float angularFrequency, // angular frequency of motion
        float dampingRatio)     // damping ratio of motion
    {
        const float epsilon = 0.0001f;

        // force values into legal range
        if (dampingRatio < 0.0f) dampingRatio = 0.0f;
        if (angularFrequency < 0.0f) angularFrequency = 0.0f;

        // if there is no angular frequency, the spring will not move and we can
        // return identity
        if (angularFrequency < epsilon)
        {
            springMotionParameters.PosPosCoef = 1.0f; springMotionParameters.PosVelCoef = 0.0f;
            springMotionParameters.VelPosCoef = 0.0f; springMotionParameters.VelVelCoef = 1.0f;
            return;
        }

        if (dampingRatio > 1.0f + epsilon)
        {
            // over-damped
            float za = -angularFrequency * dampingRatio;
            float zb = angularFrequency * Mathf.Sqrt(dampingRatio * dampingRatio - 1.0f);
            float z1 = za - zb;
            float z2 = za + zb;

            float e1 = Mathf.Exp(z1 * deltaTime);
            float e2 = Mathf.Exp(z2 * deltaTime);

            float invTwoZb = 1.0f / (2.0f * zb); // = 1 / (z2 - z1)

            float e1_Over_TwoZb = e1 * invTwoZb;
            float e2_Over_TwoZb = e2 * invTwoZb;

            float z1e1_Over_TwoZb = z1 * e1_Over_TwoZb;
            float z2e2_Over_TwoZb = z2 * e2_Over_TwoZb;

            springMotionParameters.PosPosCoef = e1_Over_TwoZb * z2 - z2e2_Over_TwoZb + e2;
            springMotionParameters.PosVelCoef = -e1_Over_TwoZb + e2_Over_TwoZb;

            springMotionParameters.VelPosCoef = (z1e1_Over_TwoZb - z2e2_Over_TwoZb + e2) * z2;
            springMotionParameters.VelVelCoef = -z1e1_Over_TwoZb + z2e2_Over_TwoZb;
        }
        else if (dampingRatio < 1.0f - epsilon)
        {
            // under-damped
            float omegaZeta = angularFrequency * dampingRatio;
            float alpha = angularFrequency * Mathf.Sqrt(1.0f - dampingRatio * dampingRatio);

            float expTerm = Mathf.Exp(-omegaZeta * deltaTime);
            float cosTerm = Mathf.Cos(alpha * deltaTime);
            float sinTerm = Mathf.Sin(alpha * deltaTime);

            float invAlpha = 1.0f / alpha;

            float expSin = expTerm * sinTerm;
            float expCos = expTerm * cosTerm;
            float expOmegaZetaSin_Over_Alpha = expTerm * omegaZeta * sinTerm * invAlpha;

            springMotionParameters.PosPosCoef = expCos + expOmegaZetaSin_Over_Alpha;
            springMotionParameters.PosVelCoef = expSin * invAlpha;

            springMotionParameters.VelPosCoef = -expSin * alpha - omegaZeta * expOmegaZetaSin_Over_Alpha;
            springMotionParameters.VelVelCoef = expCos - expOmegaZetaSin_Over_Alpha;
        }
        else
        {
            // critically damped
            float expTerm = Mathf.Exp(-angularFrequency * deltaTime);
            float timeExp = deltaTime * expTerm;
            float timeExpFreq = timeExp * angularFrequency;

            springMotionParameters.PosPosCoef = timeExpFreq + expTerm;
            springMotionParameters.PosVelCoef = timeExp;

            springMotionParameters.VelPosCoef = -angularFrequency * timeExpFreq;
            springMotionParameters.VelVelCoef = -timeExpFreq + expTerm;
        }
    }

    //******************************************************************************
    // This function will update the supplied position and velocity values over
    // according to the motion parameters.
    //******************************************************************************
    public static (float posittion, float velocity) UpdateDampedSpringMotion(
        float position,           // position value to update
        float velocity,           // velocity value to update
        float equilibriumPosition, // position to approach
        DampedSpringMotionParams springParams)   // motion parameters to use
    {
        float oldPos = position - equilibriumPosition; // update in equilibrium relative space
        float oldVel = velocity;

        position = oldPos * springParams.PosPosCoef + oldVel * springParams.PosVelCoef + equilibriumPosition;
        velocity = oldPos * springParams.VelPosCoef + oldVel * springParams.VelVelCoef;

        return (position, velocity);
    }
}
