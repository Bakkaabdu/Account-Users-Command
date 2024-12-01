using Bogus;
using System.Runtime.CompilerServices;

namespace Anis.SubcategoryFillingMechanism.Commands.Test.Fakers
{
    public class CustomConstructorFaker<T> : Faker<T> where T : class
    {
        public CustomConstructorFaker()
        {
            CustomInstantiator(_ => Initialize());
        }

        private static T Initialize() =>
           RuntimeHelpers.GetUninitializedObject(typeof(T)) as T ?? throw new TypeLoadException();

    }
}
