﻿using SixLabors.ImageSharp;

namespace YoloDotNet.Models
{
    public class ObjectResult
    {
        /// <summary>
        /// Label information associated with the detected object.
        /// </summary>
        public LabelModel Label { get; set; } = new();

        /// <summary>
        /// Confidence score of the detected object.
        /// </summary>
        public double Confidence { get; set; }

        /// <summary>
        /// Region of interest (bounding box) of the detected object.
        /// </summary>
        public Rectangle BoundingBox { get; set; }

        /// <summary>
        /// Index of bounding box
        /// </summary>
        public int BoundingBoxIndex { get; set; }

        /// <summary>
        /// Segmented pixels coordinates (x,y) and pixel confidence value
        /// </summary>
        public Pixel[] SegmentedPixels { get; set; } = [];

        #region Mapping methods
        public static explicit operator ObjectDetection(ObjectResult result) => new()
        {
            Label = result.Label,
            Confidence = result.Confidence,
            Rectangle = result.BoundingBox
        };

        public static explicit operator Segmentation(ObjectResult result) => new()
        {
            Label = result.Label,
            Confidence = result.Confidence,
            Rectangle = result.BoundingBox,
            SegmentedPixels = result.SegmentedPixels
        };
        #endregion
    }
}
