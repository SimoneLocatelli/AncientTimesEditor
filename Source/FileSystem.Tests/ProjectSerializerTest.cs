namespace Editor.FileSystem.Tests
{
    #region Usings

    using FileEntities;
    using global::FileSystem.Dependencies.FileManagers.Fakes;
    using global::Tests.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Serializers;
    using System;

    #endregion Usings

    [TestClass]
    public class ProjectSerializerTest : EditorBaseTestClass<ProjectSerializer>
    {
        [TestMethod]
        public void ShouldHaveDefaultValues()
        {
            Test(resolver => ResolveClassToTest(resolver));
        }

        [TestMethod]
        public void Serialize()
        {
            Test(resolver =>
            {
                resolver.RegisterInstance(new StubIXmlSerializer
                {
                    SerializeObject = o => "<project />"
                });

                var instance = ResolveClassToTest(resolver);

                var project = new Project("Test", "C:\\");
                instance.Serialize(project);
            });
        }

        [TestMethod]
        public void SerializeWithNullProject()
        {
            TestExpectedArgumentException<ArgumentNullException>(resolver =>
            {
                var instance = ResolveClassToTest(resolver);

                instance.Serialize(null);
            }, "project");
        }
    }
}