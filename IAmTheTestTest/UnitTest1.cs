using TestTechniqueNGUYEN;

namespace IAmTheTestTest
{
    public class Tests
    {
        private IAmTheTest _service;

        [SetUp]
        public void Setup()
        {     
            _service = new IAmTheTest();    
        }

        [Test]
        public void ShouldReturnBestMatches()
        {
            var choices = new[]{"agressif","grossier","gros","gras","progressif"};

            // Act
            var result = _service
                .GetSuggestions("gros", choices, 3)
                .ToList();

            // Assert
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("gros", result[0]);
            Assert.AreEqual("grossier", result[1]);
        }

        [Test]
        public void CalculateDifferenceScore_ShouldCompareAllSubstrings()
        {
            // Arrange
            string term = "gros";
            string word = "agressif";

            // Act
            int score = IAmTheTest.CalculateDifferenceScore(term, word);

            // Assert
            Assert.AreEqual(1, score);
        }

        [Test]
        public void CalculateDifferenceScore_ExactSubstring_ShouldReturnZero()
        {
            // Arrange
            string term = "gres";
            string word = "agressif";

            // Act
            int score = IAmTheTest.CalculateDifferenceScore(term, word);

            // Assert
            Assert.AreEqual(0, score);
        }
    }
}