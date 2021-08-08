using System;
using System.Collections.Generic;
namespace MapLibrary
{
    public class GeoPolygon
    {
        private string id;
        private double area;
        private double perimeter;
        private GeoPoint center;
        private double weight;
        private GeoLineGroup boundary;
        private GeoPolygonGroup neighbors;
        private DecisionVarGroup decisionVar;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public double Area
        {
            get { return area; }
            set { area = value; }
        }
        public double Perimeter
        {
            get { return perimeter; }
            set { perimeter = value; }
        }
        public GeoPoint Center
        {
            get { return center; }
            set { center = value; }
        }
        public GeoLineGroup Boundary
        {
            get { return boundary; }
            set { boundary = value; }
        }
        public GeoPolygonGroup Neighbors
        {
            get { return neighbors; }
            set { neighbors = value; }
        }
        public DecisionVarGroup DecisionVariables
        {
            get { return decisionVar; }
            set { decisionVar = value; }
        }


        public GeoPolygon()
        {
            decisionVar = new DecisionVarGroup();

        }
        public GeoPolygon(string pId)
        {
            id = pId;
            decisionVar = new DecisionVarGroup(pId);

        }
        public GeoPolygon(string pId, double a, double p, double wt)
        {
            id = pId;
            area = a;
            perimeter = p;
            weight = wt;
            decisionVar = new DecisionVarGroup(pId);

        }
        public GeoPolygon(string pId, GeoLineGroup b)
        {
            id = pId;
            center = FindCenter(b);
            boundary = b;
            decisionVar = new DecisionVarGroup(pId);

        }
        public GeoPolygon(string pId, GeoLineGroup b, double a, double p, double wt)
        {
            id = pId;
            area = a;
            perimeter = p;
            center = FindCenter(b);
            weight = wt;
            boundary = b;
            decisionVar = new DecisionVarGroup(pId);

        }
        /// <summary>
        /// Find the center of the polygon group by using the boundary lines.
        /// </summary>
        /// <param name="b">GeoLineGroup => the boundary lines of the poly group</param>
        /// <returns>GeoPoint => the center</returns>
        public GeoPoint FindCenter(GeoLineGroup b)
        { //Temp
            double cLat = -1;//TODO
            double cLon = -1;//TODO

            GeoPoint c = new GeoPoint("-1", cLat, cLon);
            return c;
        }
    }

    public class GeoPolygonGroup
    {
        private string id;
        private double area;
        private double perimeter;
        private List<GeoPolygon> polygons;
        private GeoLineGroup boundary;
        private GeoPolygonGroup edgePolygons;
        private DecisionVarGroup decisionVar;
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public double Area
        {
            get { return area; }
            set { area = value; }
        }
        public double Perimeter
        {
            get { return perimeter; }
            set { perimeter = value; }
        }
        public List<GeoPolygon> Polygons
        {
            get { return polygons; }
            set { polygons = value; }
        }
        public GeoLineGroup Boundary
        {
            get { return boundary; }
            set { boundary = value; }
        }
        public GeoPolygonGroup EdgePolygons
        {
            get { return edgePolygons; }
            set { edgePolygons = value; }
        }
        public DecisionVarGroup DecisionVariables
        {
            get { return decisionVar; }
            set { decisionVar = value; }
        }
        public GeoPolygonGroup()
        {
            polygons = new List<GeoPolygon>(1);//Temp max load
            boundary = new GeoLineGroup();
            decisionVar = new DecisionVarGroup();

        }
        public GeoPolygonGroup(string gId)
        {
            id = gId;
            polygons = new List<GeoPolygon>(1);//Temp max load
            boundary = new GeoLineGroup(gId);
            // area = polyArea;
            // perimeter = polyPerimeter;
            decisionVar = new DecisionVarGroup(gId);

        }
        public GeoPolygonGroup(string gId, double polyArea, double polyPerimeter)
        {
            id = gId;
            polygons = new List<GeoPolygon>(1);//Temp max load
            boundary = new GeoLineGroup(gId);
            area = polyArea;
            perimeter = polyPerimeter;
            decisionVar = new DecisionVarGroup(gId);

        }

        public void AddPolygon(GeoPolygon p)
        {
            polygons.Add(p);
        }
        public bool RemovePolygonById(string pId)
        {
            GeoPolygon aim = GetPolygonById(pId);
            if (aim != null)
            {
                return polygons.Remove(aim);
            }
            return false;
        }
        public bool RemovePolygon(GeoPolygon aim)
        {
            return polygons.Remove(aim);
        }

        public void CountBoundary()
        {
            //TODO
        }
        public void CountEdges()
        {
            GeoPolygonGroup e = new GeoPolygonGroup();
            //TODO
            edgePolygons = e;
        }
        public GeoPolygon GetPolygonById(string pId)
        {
            foreach (GeoPolygon item in polygons)
            {
                if (item.ID == pId)
                {
                    return item;
                }
            }
            return null;
        }
        /// <summary>
        /// return the amount of the holes in this polygon group.
        /// </summary>
        /// <returns>int => #holes</returns>
        public int CountHole()
        {
            int num = 0;
            return num;
        }
        /// <summary>
        /// Return Boolean value to check if the area of the polygon group is continuous.
        /// </summary>
        /// <returns>bool => whether the area is not isolated.</returns>
        public bool IsContiniousArea()
        {
            return true;
        }
    }
}