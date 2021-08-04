using System.Collections.Generic;

namespace MapLibrary
{
    public class GeoLine
    {
        private string id;
        private double len;
        private double weight;
        private GeoPoint fromPoint;
        private GeoPoint toPoint;
        private GeoPolygon leftPolygon;
        private GeoPolygon rightPolygon;
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public double Len
        {
            get { return len; }
            set { len = value; }
        }
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public GeoPoint FromPoint
        {
            get { return fromPoint; }
            set { fromPoint = value; }
        }
        public GeoPoint ToPoint
        {
            get { return toPoint; }
            set { toPoint = value; }
        }
        public GeoPolygon LeftPolygon
        {
            get { return leftPolygon; }
            set { leftPolygon = value; }
        }
        public GeoPolygon RightPolygon
        {
            get { return rightPolygon; }
            set { rightPolygon = value; }
        }

        public GeoLine()
        {
            ;
        }
        public GeoLine(string pID)
        {
            id = pID;
        }
        public GeoLine(string pID, GeoPoint lp, GeoPoint rp)
        {
            id = pID;
            fromPoint = lp;
            toPoint = rp;
        }
        public GeoLine(string pID, GeoPoint lp, GeoPoint rp, GeoPolygon left, GeoPolygon right)
        {
            id = pID;
            fromPoint = lp;
            toPoint = rp;
            leftPolygon = left;
            rightPolygon = right;
        }
        public GeoLine(string pID, GeoPoint lp, GeoPoint rp, double lenth, GeoPolygon left, GeoPolygon right)
        {
            id = pID;
            len = lenth;
            fromPoint = lp;
            toPoint = rp;
            leftPolygon = left;
            rightPolygon = right;
        }
        public GeoLine(string pID, GeoPoint lp, GeoPoint rp, double lenth, double wt, GeoPolygon left, GeoPolygon right)
        {
            id = pID;
            len = lenth;
            weight = wt;
            fromPoint = lp;
            toPoint = rp;
            leftPolygon = left;
            rightPolygon = right;
        }

        /// <summary>
        /// Set the endpoint of the line simultaneously as (x1, x2). Check and let the min-latitude point as fromPoint.
        /// </summary>
        /// <param name="x1">GeoPoint</param>
        /// <param name="x2">GeoPoint</param>
        public void setPoints(GeoPoint x1, GeoPoint x2)
        {
            if (x1.Lat <= x2.Lat)
            {
                fromPoint = x1;
                toPoint = x2;
            }
            else
            {
                fromPoint = x2;
                toPoint = x1;
            }
        }

    }
    public class GeoLineGroup
    {
        private string id;
        private List<GeoLine> lines;
        private double len;
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public double Len
        {
            get { return len; }
            set { len = value; }
        }
        public List<GeoLine> Lines
        {
            get { return lines; }
            set { lines = value; }
        }

        public GeoLineGroup()
        {
            lines = new List<GeoLine>(1);
        }
        public GeoLineGroup(string lId)
        {
            id = lId;
            lines = new List<GeoLine>(1);
        }

        public GeoLine getLineById(string lId)
        {
            foreach (GeoLine item in lines)
            {
                if (item.ID == lId)
                {
                    return item;
                }
            }
            return null;
        }
        public void addLine(GeoLine newLine)
        {
            lines.Add(newLine);
            len = len + 1;
        }
        public bool removeLineById(string lId)
        {
            GeoLine aim = getLineById(lId);
            if (aim != null)
            {
                return lines.Remove(aim);
            }
            return false;
        }
        public bool removeLine(GeoLine aim)
        {
            return lines.Remove(aim);
        }
    }

}