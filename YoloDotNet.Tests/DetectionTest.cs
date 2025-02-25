﻿namespace YoloDotNet.Tests
{
    public class DetectionTest
    {
        [Fact]
        public void RunClassification_LabelImageCorrectly_AssertTrue()
        {
            // Arrange
            var model  = Config.GetTestModel(ModelType.Classification);
            var testImage = Config.GetTestImage(ImageType.Hummingbird);

            var yolo = new Yolo(model, false);
            var image = Image.Load<Rgba32>(testImage);

            // Act
            var classification = yolo.RunClassification(image);

            // Assert
            Assert.Equal("hummingbird", classification[0].Label);
        }

        [Fact]
        public void RunObjectDetection_GetExpectedNumberOfObjects_AssertTrue()
        {
            // Arrange
            var model = Config.GetTestModel(ModelType.ObjectDetection);
            var testImage = Config.GetTestImage(ImageType.Street);

            var yolo = new Yolo(model, false);
            var image = Image.Load<Rgba32>(testImage);

            // Act
            var results = yolo.RunObjectDetection(image);

            // Assert
            Assert.Equal(27, results.Count);
        }

        [Fact]
        public void RunSegmentation_GetExpectedNumberOfSegmentations_AssertTrue()
        {
            // Arrange
            var model = Config.GetTestModel(ModelType.Segmentation);
            var testImage = Config.GetTestImage(ImageType.People);

            var yolo = new Yolo(model, false);
            var image = Image.Load<Rgba32>(testImage);

            // Act
            var results = yolo.RunSegmentation(image);

            // Assert
            Assert.Equal(20, results.Count);
        }
    }
}
