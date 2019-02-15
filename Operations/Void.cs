﻿using System;

namespace Operations
{
    public struct Void : IEquatable<Void>
    {
        public static Void Value { get; } = new Void();
        public override bool Equals(object obj) => true;
        public override int GetHashCode() => 0;
        public bool Equals(Void other) => true;
        public static bool operator ==(Void x, Void y) => true;
        public static bool operator !=(Void x, Void y) => false;
    }
}
