using System;

namespace ObjectInformation.Infrastructure.Types
{
    public struct RectangleInfo
    {
        #region Properties
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        #endregion

        #region Operators
        public static bool operator ==(RectangleInfo a, RectangleInfo b) => a.X1 == b.X1 && a.Y1 == b.Y1 && a.X2 == b.X2 && a.Y2 == b.Y2;
        public static bool operator !=(RectangleInfo a, RectangleInfo b) => a.X1 != b.X1 || a.Y1 != b.Y1 || a.X2 != b.X2 || a.Y2 != b.Y2;
        #endregion

        #region Methods
        public override bool Equals(object obj) => obj is RectangleInfo info && this == info;

        public override int GetHashCode() => Tuple.Create(X1, Y1, X2, Y2).GetHashCode();
        #endregion
    }
}
