using System;
using System.Collections.Generic;
namespace MapLibrary
{
    public class DecisionVarible
    {
        private string id;
        private Object result;
        private string description;
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public Object Result
        {
            get { return result; }
            set { result = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public DecisionVarible()
        {
            ;
        }
        public DecisionVarible(string dId)
        {
            id = dId;
        }
        public DecisionVarible(string dId, Object o)
        {
            id = dId;
            result = o;
        }
    }

    public class DecisionVarGroup
    {
        private string id;
        private string description;
        private List<DecisionVarible> dvList;
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
        public List<DecisionVarible> DVList
        {
            get { return dvList; }
            set { dvList = value; }
        }
        public DecisionVarGroup()
        {
            dvList = new List<DecisionVarible>(1);//Temp
        }
        public DecisionVarGroup(string gId)
        {
            id = gId;
            dvList = new List<DecisionVarible>(1);//Temp
        }

        public DecisionVarible getDecisionVarById(string dId)
        {
            foreach (DecisionVarible item in dvList)
            {
                if (item.ID == dId)
                {
                    return item;
                }
            }
            return null;
        }
        public void addDV(DecisionVarible newDV)
        {
            dvList.Add(newDV);
        }
        public bool removeDecisionVarById(string dId)
        {
            DecisionVarible aim = getDecisionVarById(dId);
            if (aim != null)
            {
                return dvList.Remove(aim);
            }
            return false;
        }
        public bool removeDecisionVar(DecisionVarible aim)
        {
            return dvList.Remove(aim);
        }
    }

}