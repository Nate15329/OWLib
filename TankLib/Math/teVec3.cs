﻿using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace TankLib.Math {
    /// <summary>3 component XYZ vector</summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct teVec3 {
        /// <summary>X component</summary>
        public float X;
        
        /// <summary>Y component</summary>
        public float Y;
        
        /// <summary>Z component</summary>
        public float Z;

        public teVec3(float x, float y, float z) {
            X = x;
            Y = y;
            Z = z;
        }

        public teVec3(IReadOnlyList<float> val) {
            if (val.Count != 3) {
                throw new InvalidDataException();
            }
            X = val[0];
            Y = val[1];
            Z = val[2];
        }
        
        public static teVec3 operator -(teVec3 left, teVec3 right) {
            return new teVec3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }
    }
}