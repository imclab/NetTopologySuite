using System;
using System.Collections;
using System.Text;

using GisSharpBlog.NetTopologySuite.Geometries;

namespace GisSharpBlog.NetTopologySuite.Geometries.Utilities
{
    /// <summary> 
    /// Extracts all the 2-dimensional (<c>Polygon</c>) components from a <c>Geometry</c>.
    /// </summary>
    public class PolygonExtracter : IGeometryFilter
    {
        /// <summary> 
        /// Returns the Polygon components from a single point.
        /// If more than one point is to be processed, it is more
        /// efficient to create a single <c>PolygonExtracterFilter</c> instance
        /// and pass it to multiple geometries.
        /// </summary>
        /// <param name="geom"></param>
        public static IList GetPolygons(Geometry geom)
        {
            IList comps = new ArrayList();
            geom.Apply(new PolygonExtracter(comps));
            return comps;
        }

        private IList comps;

        /// <summary> 
        /// Constructs a PolygonExtracterFilter with a list in which to store Polygons found.
        /// </summary>
        /// <param name="comps"></param>
        public PolygonExtracter(IList comps)
        {
            this.comps = comps;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="geom"></param>
        public virtual void Filter(Geometry geom)
        {
            if (geom is Polygon) 
                comps.Add(geom);
        }
    }
}