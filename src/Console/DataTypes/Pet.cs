using System.Diagnostics.CodeAnalysis;

namespace LinqCourse.DataTypes
{
    public class PetByTypeComparer : IComparer<Pet>
    {
        public int Compare(Pet? x, Pet? y)
        {
            return x.PetType.CompareTo(y.PetType);
        }
    }
    public class PetEqualityById : IEqualityComparer<Pet>
    {
        public bool Equals(Pet? x, Pet? y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Pet obj)
        {
            return obj.Id;
        }
    }
    public class Pet: IComparable<Pet>
    {
        public int Id { get; }
        public string Name { get; }
        public PetType PetType { get; }
        public float Weight { get; }

        public Pet(int id, string name, PetType petType, float weight)
        {
            Id = id;
            Name = name;
            PetType = petType;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Type: {PetType}, Weight: {Weight}";
        }

        public int CompareTo(Pet? other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }
}
