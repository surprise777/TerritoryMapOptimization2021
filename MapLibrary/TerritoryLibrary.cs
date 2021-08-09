using System.Collections.Generic;
namespace MapLibrary
{
    public class TerritoryPlan
    {
        private string id;
        private List<GeoPolygonGroup> polygonGroupList;
        private double totalArea;
        private double totalEdgeLen;
        private int groupCount;
        private DecisionVarGroup decisionVars;
        private double utility;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public List<GeoPolygonGroup> PolygonGroupList
        {
            get { return polygonGroupList; }
            set { polygonGroupList = value; }
        }
        public double TotalArea
        {
            get { return totalArea; }
            set { totalArea = value; }
        }
        public double TotalEdgeLength
        {
            get { return totalEdgeLen; }
            set { totalEdgeLen = value; }
        }
        public int GroupCount
        {
            get { return groupCount; }
            set { groupCount = value; }
        }
        public DecisionVarGroup DecisionVariables
        {
            get { return decisionVars; }
            set { decisionVars = value; }
        }
        public double Utility
        {
            get { return utility; }
            set { utility = value; }
        }

        public TerritoryPlan()
        {
            polygonGroupList = new List<GeoPolygonGroup>(1);//temp max load.
            decisionVars = new DecisionVarGroup();
        }
        public TerritoryPlan(string pId)
        {
            id = pId;
            polygonGroupList = new List<GeoPolygonGroup>(1);//temp max load.
            decisionVars = new DecisionVarGroup(pId);
        }

        public double CountTotalArea()
        {//TODO
            double num = 0;
            return num;
        }
        public double CountTotalEdgeLenth()
        {//TODO
            double num = 0;
            return num;
        }

    }
}