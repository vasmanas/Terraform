using System;
using Terraform.Core.Storage;

namespace Terraform.ResourceDomain
{
    public partial class Resource : ValueObject, IEquatable<Resource>
    {
        public Resource(string displayName)
        {
            this.DisplayName = displayName;
        }

        public string DisplayName { get; private set; }
        
        public static bool operator ==(Resource obj1, Resource obj2)
        {
            if (ReferenceEquals(obj1, null))
            {
                return false;
            }

            if (ReferenceEquals(obj2, null))
            {
                return false;
            }

            if (ReferenceEquals(obj1, obj2))
            {
                return true;
            }

            return obj1.DisplayName == obj2.DisplayName;
        }

        // this is second one '!='
        public static bool operator !=(Resource obj1, Resource obj2)
        {
            return !(obj1 == obj2);
        }

        public bool Equals(Resource other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return DisplayName.Equals(other.DisplayName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Resource)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = DisplayName.GetHashCode();
                //hashCode = (hashCode * 397) ^ length.GetHashCode();
                //hashCode = (hashCode * 397) ^ breadth.GetHashCode();
                return hashCode;
            }
        }


    }
}
