﻿using System;
using System.IO;

namespace CachedPathSuggestBoxDemo.Infrastructure
{
    public class PathInformation : IEquatable<PathInformation>
    {
        public PathInformation(string argValue)
        {
            Name = new DirectoryInfo(argValue).Parent == null ? argValue : Path.GetFileName(argValue);
            FullName = argValue;
        }

        public string Name { get; }

        public string FullName { get; }


        public bool Equals(PathInformation other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && FullName == other.FullName;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PathInformation)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, FullName);
        }
    }
}