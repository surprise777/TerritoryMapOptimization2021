using System;
using System.Collections.Generic;

namespace MapLibrary
{
   public class GeoPoint
    {
       private double id;
       private double lat;
       private double lon;

       public GeoPoint(double pID, double pLat, double pLon){
           id = pID;
           lat = pLat;
           lon = pLon;
       }
       public void setLat(double num){
           lat = num;
       }

          public void setLon(double num){
           lon = num;
       }
       public double getLat(){
           return lat;
       }
       public double getLon(){
           return lon;
       }
       
        public double getId(){
            return id;
        }    
    }

    public class GeoLine
    {
       private double id;
       private double len;
       private double weight;

       private GeoPoint left;
       private GeoPoint right;

       public GeoLine(double pID, GeoPoint lp, GeoPoint rp){
           id = pID;
           len = distance(lp, rp);
           weight = -1;
           left = lp;
           right = rp;
       }
       public double distance(GeoPoint x1, GeoPoint x2){
           double m1, m2;
           m1 = Math.Pow(x1.getLat() - x2.getLat(), 2);
           m2 = Math.Pow(x1.getLon()-x2.getLon(), 2);
           return Math.Sqrt(m1+m2);
       }

          public void setWt(double num){
           weight = num;
       }

          public void setPt(GeoPoint x1, GeoPoint x2){
              if (x1.getLat()<= x2.getLat()){
                  left = x1;
                  right = x2;
              }
              else{
                  left = x2;
                  right = x1;
              }
          }
          public double getWt(){
              return weight;
          }
          public GeoPoint GetLeftPt(){
              return left;
          }
          public GeoPoint GetRightPt(){
              return right;
          }
          public double getLenth(){
              return len;
          }
          
        public double getId(){
            return id;
        }    

    }
    public class GeoLineGroup{
        private double id;
        private List<GeoLine> lines;
        private double len;

        public GeoLineGroup(double lId){
        id = lId;
        lines = new List<GeoLine>(4);
        len = lines.Count;
        }

        public double getId(){
            return id;
        }
        public List<GeoLine> getLineList(){
            return lines;
        }
        public GeoLine getLineById(double lId){
            foreach (GeoLine item in lines){
                if (item.getId() == lId){
                    return item;
                }
            }
            return null;
        }
        public double getLenth(){
              return len;
          }
        public void addLine(GeoLine newLine){
            lines.Add(newLine);
            len = len+1;
        }
        public bool popLineById(double lId){
            GeoLine aim = getLineById(lId);
            if(aim!=null){
                return lines.Remove(aim);
            }
            return false;
        } 
        public bool popLine(GeoLine aim){
            return lines.Remove(aim);
        }
    }

    public class GeoPolygon{
        private double id;
        private double area;
        private double perimeter;
        private GeoPoint center;
        private double weight;
        private GeoLineGroup boundary;
        private GeoPolygonGroup neighbors;
        private DVGroup dv;

        public GeoPolygon(double pId, GeoLineGroup b){
            id = pId;
            area = countArea(b);
            perimeter = countPerimeter(b);
            center = findCenter(b);
            weight = -1;
            boundary = b;
            dv = new DVGroup(pId);

        }

        public void setWt(double num){
           weight = num;
        }
        public double countArea(GeoLineGroup b){
            double a = 0;
            // TODO
            return a;
        }
        public double countPerimeter(GeoLineGroup b){
            double p = 0;
            foreach(GeoLine i in b.getLineList()){
                p = p + i.getLenth();
            }
            return p;
        }
        public GeoPoint findCenter(GeoLineGroup b){
            double cLat=-1;//TODO
            double cLon=-1;//TODO
            double cId = cLat * Math.Pow(10, 6 + Math.Floor(cLon / 10))+ cLon;
            GeoPoint c = new GeoPoint(cId, cLat, cLon);
            return c;

        }
        public void setBoundary(GeoLineGroup b){
            boundary = b;
        }
        public void setNeighbors(GeoPolygonGroup n){
            neighbors = n;
        }

        public double getId(){
            return id;
        }   
        public double getWt(){
              return weight;
          } 
       public double getArea(){
           return area;
       }
       public double getPerimeter(){
           return perimeter;
       }
       public GeoPoint getCenter(){
           return center;
       }
       public GeoPolygonGroup getNeibors(){
           return neighbors;
       }
       public GeoLineGroup getBoundary(){
           return boundary;
       }
       public DVGroup GetDV(){
           return dv;
       }
    }
    
    public class GeoPolygonGroup{
        private double id;
        private double area;
        private double perimeter;
        private List<GeoPolygon> polygons;
        private GeoLineGroup boundary;
        private GeoPolygonGroup edgePolygons;
        private DVGroup dv;

        public GeoPolygonGroup(double gId){
            id = gId;
            polygons = new List<GeoPolygon>(10);//Temp max load
            boundary = new GeoLineGroup(gId);
            dv = new DVGroup(gId);

        }        

        public double countArea(){
            double a = 0;
            foreach(GeoPolygon p in polygons){
                a = a + p.getArea();
            }
            area = a;
            return area;
        }
        public double countPerimeter(){
            double p = 0;
            foreach(GeoLine i in boundary.getLineList()){
                p = p + i.getLenth();
            }
            perimeter = p;
            return perimeter;
        }

        public void addPolygon(GeoPolygon p){
            polygons.Add(p);
        }
        public bool removePolygonById(double pId){
            GeoPolygon aim = getPolygonById(pId);
            if(aim!=null){
                return polygons.Remove(aim);
            }
            return false;
        } 
        public bool removePolygon(GeoPolygon aim){
            return polygons.Remove(aim);
        }

        public void countBoundary(){
            //TODO
        }
        public void countEdges(double num){
            GeoPolygonGroup e = new GeoPolygonGroup(num);
            //TODO
            edgePolygons = e;
        }

        public double getId(){
            return id;
        }
        public List<GeoPolygon> getPolygonList(){
            return polygons;
        }
        public GeoPolygon getPolygonById(double pId){
            foreach (GeoPolygon item in polygons){
                if (item.getId() == pId){
                    return item;
                }
            }
            return null;
        }
        public double getArea(){
           return area;
       }
       public double getPerimeter(){
           return perimeter;
       }
        public GeoPolygonGroup getEdges(){
              return edgePolygons;
          } 
        public GeoLineGroup getBoundary(){
           return boundary;
       }
       public DVGroup GetDV(){
           return dv;
       }   
    }

    public class DV{
       private double id;
       private Object value;
       private string description;
       
       public DV(double dId, Object o){
           id = dId;
           value = o;
       }
       public void setValue(Object o){
           value = o;
       }
       public void setDescription(string s){
           description = s;
       }
        public double getId(){
            return id;
        }  
        public Object getValue(){
            return value;
        } 
        public string getDescription(){
            return description;
        } 
    }

    public class DVGroup{
        private double id;
        private string description;
        private List<DV> dvList;
        
        public DVGroup(double gId){
            id = gId;
            dvList = new List<DV>(5);//Temp
        }
        public void setDescription(string s){
           description = s;
       }
        public List<DV> getList(){
            return dvList;
        }
        public DV getDVById(double dId){
            foreach (DV item in dvList){
                if (item.getId() == dId){
                    return item;
                }
            }
            return null;
        }
        public void addDV(DV newDV){
            dvList.Add(newDV);
        }
        public bool popDVById(double dId){
            DV aim = getDVById(dId);
            if(aim!=null){
                return dvList.Remove(aim);
            }
            return false;
        } 
        public bool popDV(DV aim){
            return dvList.Remove(aim);
        }
        public double getId(){
            return id;
        }
        public string getDescription(){
            return description;
        }     
    }

    
}
