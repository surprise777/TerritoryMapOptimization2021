using System;
using System.Collections.Generic;

namespace MapLibrary
{
   public class GeoPoint
    {
       private int id;
       private double lat;
       private double lon;

       public GeoPoint(int pID, double pLat, double pLon){
           id = pID;
           lat = pLat;
           lon = pLon;
       }
       public int ID{
           get {return id;}
       }
       public double Lat{
           get {return lat;}
           set {lat = value;}
       }
       public double Lon{
           get {return lon;}
           set {lon = value;}
       }
    //    public void setLat(double num){
    //        lat = num;
    //    }

    //       public void setLon(double num){
    //        lon = num;
    //    }
    //    public double getLat(){
    //        return lat;
    //    }
    //    public double getLon(){
    //        return lon;
    //    }
       
    //     public double getId(){
    //         return id;
    //     }    
    }

    public class GeoLine
    {
       private int id;
       private double len;
       private double weight;
       private GeoPoint from;
       private GeoPoint to;
       private GeoPolygon leftPolygon;
       private GeoPolygon rightPolygon;
       public int ID{
           get {return id;}
       }
       public double Len{
           get {return len;}
           set {len = value;}
       }
       public double Weight{
           get {return weight;}
           set {weight = value;}
       }
       public GeoPoint From{
           get {return from;}
           set {from = value;}
       }
       public GeoPoint To{
           get {return to;}
           set {to = value;}
       }
       public GeoPolygon LeftPolygon{
           get{ return leftPolygon;}
           set{ leftPolygon = value;}
       }
       public GeoPolygon RightPolygon{
           get{ return rightPolygon;}
           set{ rightPolygon = value;}
       }
       public GeoLine(int pID, GeoPoint lp, GeoPoint rp, double lenth, double wt, GeoPolygon left, GeoPolygon right){
           id = pID;
           len = lenth;
           weight = wt;
           from = lp;
           to = rp;
           leftPolygon = left;
           rightPolygon = right;
       }
       public void setPoints(GeoPoint x1, GeoPoint x2){
              if (x1.Lat<= x2.Lat){
                  from = x1;
                  to = x2;
              }
              else{
                  from = x2;
                  to = x1;
              }
        }
    //       public void setWt(double num){
    //        weight = num;
    //    }
    //       public double getWt(){
    //           return weight;
    //       }
    //       public GeoPoint GetLeftPt(){
    //           return left;
    //       }
    //       public GeoPoint GetRightPt(){
    //           return right;
    //       }
    //       public double getLenth(){
    //           return len;
    //       }
          
    //     public double getId(){
    //         return id;
    //     }    

    }
    public class GeoLineGroup{
        private int id;
        private List<GeoLine> lines;
        private double len;
        public int ID{
           get {return id;}
        }
        public double Len{
           get {return len;}
           set {len = value;}
        }
        public List<GeoLine> Lines{
            get { return lines;}
            set { lines = value;}
        }

        public GeoLineGroup(int lId){
        id = lId;
        lines = new List<GeoLine>(1);
        }

        // public double getId(){
        //     return id;
        // }
        // public List<GeoLine> getLineList(){
        //     return lines;
        // }
                // public double getLenth(){
        //       return len;
        //   }
        public GeoLine getLineById(int lId){
            foreach (GeoLine item in lines){
                if (item.ID == lId){
                    return item;
                }
            }
            return null;
        }
        public void addLine(GeoLine newLine){
            lines.Add(newLine);
            len = len+1;
        }
        public bool popLineById(int lId){
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
        private int id;
        private double area;
        private double perimeter;
        private GeoPoint center;
        private double weight;
        private GeoLineGroup boundary;
        private GeoPolygonGroup neighbors;
        private DVGroup dv;

        public int ID{
           get {return id;}
        }  
        public double Weight{
           get {return weight;}
           set {weight = value;}
       }
        public double Area{
           get {return area;}
           set {area = value;}
        }
        public double Perimeter{
           get {return perimeter;}
           set {perimeter = value;}
        }
        public GeoPoint Center{
           get {return center;}
           set {center = value;}
        }    
        public GeoLineGroup Boundary{
           get {return boundary;}
           set {boundary = value;}
        }
        public GeoPolygonGroup Neighbors{
           get {return neighbors;}
           set {neighbors = value;}
        }
        public DVGroup DVs{
            get{ return dv;}
            set{ dv = value;}
        }
        

        public GeoPolygon(int pId, GeoLineGroup b, double a, double p, double wt){
            id = pId;
            area = a;
            perimeter = p;
            center = findCenter(b);
            weight = wt;
            boundary = b;
            dv = new DVGroup(pId);

        }

        // public void setWt(double num){
        //    weight = num;
        // }
        // public double countArea(GeoLineGroup b){
        //     double a = 0;
        //     // TODO
        //     return a;
        // }
        // public double countPerimeter(GeoLineGroup b){
        //     double p = 0;
        //     foreach(GeoLine i in b.getLineList()){
        //         p = p + i.getLenth();
        //     }
        //     return p;
        // }
        public GeoPoint findCenter(GeoLineGroup b){ //Temp
            double cLat=-1;//TODO
            double cLon=-1;//TODO
           
            GeoPoint c = new GeoPoint(-1, cLat, cLon);
            return c;

        }
    //     public void setBoundary(GeoLineGroup b){
    //         boundary = b;
    //     }
    //     public void setNeighbors(GeoPolygonGroup n){
    //         neighbors = n;
    //     }

    //     public double getId(){
    //         return id;
    //     }   
    //     public double getWt(){
    //           return weight;
    //       } 
    //    public double getArea(){
    //        return area;
    //    }
    //    public double getPerimeter(){
    //        return perimeter;
    //    }
    //    public GeoPoint getCenter(){
    //        return center;
    //    }
    //    public GeoPolygonGroup getNeibors(){
    //        return neighbors;
    //    }
    //    public GeoLineGroup getBoundary(){
    //        return boundary;
    //    }
    //    public DVGroup GetDV(){
    //        return dv;
    //    }
    }
    
    public class GeoPolygonGroup{
        private int id;
        private double area;
        private double perimeter;
        private List<GeoPolygon> polygons;
        private GeoLineGroup boundary;
        private GeoPolygonGroup edgePolygons;
        private DVGroup dv;
        public int ID{
           get {return id;}
        }  
        public double Area{
           get {return area;}
           set {area = value;}
        }
        public double Perimeter{
           get {return perimeter;}
           set {perimeter = value;}
        }      
        public List<GeoPolygon> Polygons{
            get { return polygons;}
            set { polygons = value;}
        } 
        public GeoLineGroup Boundary{
           get {return boundary;}
           set {boundary = value;}
        }
        public GeoPolygonGroup EdgePolygons{
           get {return edgePolygons;}
           set {edgePolygons = value;}
        }
        public DVGroup DVs{
            get{ return dv;}
            set{ dv = value;}
        }
        public GeoPolygonGroup(int gId){
            id = gId;
            polygons = new List<GeoPolygon>(10);//Temp max load
            boundary = new GeoLineGroup(gId);
            // area = polyArea;
            // perimeter = polyPerimeter;
            dv = new DVGroup(gId);

        }        

        // public double countArea(){
        //     double a = 0;
        //     foreach(GeoPolygon p in polygons){
        //         a = a + p.getArea();
        //     }
        //     area = a;
        //     return area;
        // }
        // public double countPerimeter(){
        //     double p = 0;
        //     foreach(GeoLine i in boundary.getLineList()){
        //         p = p + i.getLenth();
        //     }
        //     perimeter = p;
        //     return perimeter;
        // }

        public void addPolygon(GeoPolygon p){
            polygons.Add(p);
        }
        public bool removePolygonById(int pId){
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
        public void countEdges(int num){
            GeoPolygonGroup e = new GeoPolygonGroup(num);
            //TODO
            edgePolygons = e;
        }

        // public double getId(){
        //     return id;
        // }
        // public List<GeoPolygon> getPolygonList(){
        //     return polygons;
        // }
        public GeoPolygon getPolygonById(int pId){
            foreach (GeoPolygon item in polygons){
                if (item.ID == pId){
                    return item;
                }
            }
            return null;
        }
    //     public double getArea(){
    //        return area;
    //    }
    //    public double getPerimeter(){
    //        return perimeter;
    //    }
    //     public GeoPolygonGroup getEdges(){
    //           return edgePolygons;
    //       } 
    //     public GeoLineGroup getBoundary(){
    //        return boundary;
    //    }
    //    public DVGroup GetDV(){
    //        return dv;
    //    }   
    }

    public class DV{
       private int id;
       private Object result;
       private string description;
       public int ID{
           get {return id;}
        }  
        public Object Result{
           get {return result;}
           set {result = value;}
        }
        public string Description{
           get {return description;}
           set {description = value;}
        }       
       
       public DV(int dId, Object o){
           id = dId;
           result = o;
       }
    //    public void setValue(Object o){
    //        value = o;
    //    }
    //    public void setDescription(string s){
    //        description = s;
    //    }
    //     public double getId(){
    //         return id;
    //     }  
    //     public Object getValue(){
    //         return value;
    //     } 
    //     public string getDescription(){
    //         return description;
    //     } 
    }

    public class DVGroup{
        private int id;
        private string description;
        private List<DV> dvList;
          public int ID{
           get {return id;}
        }  
        public string Description{
           get {return description;}
           set {description = value;}
        }    
        public List<DV> DVList{
            get { return dvList;}
            set { dvList = value;}
        } 
        public DVGroup(int gId){
            id = gId;
            dvList = new List<DV>(5);//Temp
        }
    //     public void setDescription(string s){
    //        description = s;
    //    }
    //     public List<DV> getList(){
    //         return dvList;
    //     }
        public DV getDVById(int dId){
            foreach (DV item in dvList){
                if (item.ID == dId){
                    return item;
                }
            }
            return null;
        }
        public void addDV(DV newDV){
            dvList.Add(newDV);
        }
        public bool popDVById(int dId){
            DV aim = getDVById(dId);
            if(aim!=null){
                return dvList.Remove(aim);
            }
            return false;
        } 
        public bool popDV(DV aim){
            return dvList.Remove(aim);
        }
        // public double getId(){
        //     return id;
        // }
        // public string getDescription(){
        //     return description;
        // }     
    }

    
}
