namespace Dependencies
{
    public interface IAssemblyImporter
    {
        /// <summary>
        ///     Composes the injectable Properties inside the input object.
        /// </summary>
        /// <param name="instance">The instance to compose with the dependecies.</param>
        void Compose(object instance);
    }
}