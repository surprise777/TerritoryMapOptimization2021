using System;
using System.Collections.Generic;
namespace MapLibrary
{
    public class DecisionVariable
    {
        private string id;
        private Object result;
        private string description;
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public Object Value
        {
            get { return result; }
            set { result = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public DecisionVariable()
        {
        }
        public DecisionVariable(string dId)
        {
            id = dId;
        }
        public DecisionVariable(string dId, Object o)
        {
            id = dId;
            result = o;
        }
    }

    public class DecisionVarGroup
    {
        private string id;
        private string description;
        private List<DecisionVariable> dvList;
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public List<DecisionVariable> DVList
        {
            get { return dvList; }
            set { dvList = value; }
        }
        public DecisionVarGroup()
        {
            dvList = new List<DecisionVariable>(1);//Temp
        }
        public DecisionVarGroup(string gId)
        {
            id = gId;
            dvList = new List<DecisionVariable>(1);//Temp
        }

        public DecisionVariable getDecisionVarById(string dId)
        {
            foreach (DecisionVariable item in dvList)
            {
                if (item.ID == dId)
                {
                    return item;
                }
            }
            return null;
        }
        public void addDV(DecisionVariable newDV)
        {
            dvList.Add(newDV);
        }
        public bool removeDecisionVarById(string dId)
        {
            DecisionVariable aim = getDecisionVarById(dId);
            if (aim != null)
            {
                return dvList.Remove(aim);
            }
            return false;
        }
        public bool removeDecisionVar(DecisionVariable aim)
        {
            return dvList.Remove(aim);
        }
    }

}