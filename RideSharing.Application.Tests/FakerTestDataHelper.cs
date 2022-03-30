using Bogus;
using System;

namespace RideSharing.Application.Tests
{
    internal static class FakerTestDataHelper
    {

        public static Faker<T> UsePrivateConstructor<T>(this Faker<T> faker) where T : class
        {
            return faker.CustomInstantiator(f => Activator.CreateInstance(typeof(T), nonPublic: true) as T);
        }
    }
}