using System.Collections.Generic;
using NUnit.Framework;

namespace _30._Substring_with_Concatenation_of_All_Words {
    public class Tests {
        [SetUp]
        public void Setup() {
        }


        public IList<int> FindSubstring(string s, string[] words) {
            return new List<int>();
        }

        [Test]
        public void Test1() {
            var res = FindSubstring("barfoothefoobarman", new[] { "foo", "bar" });
            Assert.That(res, Is.EquivalentTo(new[] { 0, 9 }));
        }
    }
}