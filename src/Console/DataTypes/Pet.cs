﻿using System.Diagnostics.CodeAnalysis;

namespace LinqCourse.DataTypes
{
    public class PetCompareById : IEqualityComparer<Pet>
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
    public class Pet
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
    }
}
