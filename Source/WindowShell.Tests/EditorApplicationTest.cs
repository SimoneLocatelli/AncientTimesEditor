using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Common;

namespace Editor.WindowShell.Tests
{
    public class EditorApplicationTest : EditorBaseTestClass
    {
        public void AssertPathFacadeHasValue()
        {
            Assert.IsNotNull(new EditorApplication().PathFacade);
        }
    }
}