using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace ScringloGames.ColorClash.Runtime.Tests
{
    public class PlaceholderTests
    {
        [UnityTest]
        public IEnumerator GivenAnything_WhenAnything_AlwaysPasses()
        {
            Assert.Pass();
            yield break;
        }
    }
}
