﻿using System;
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
    }

    public class GeoLine
    {
       private double id;
       private double len;
       private double weight;

       private GeoPoint left;
       private GeoPoint right;

       public GeoLine(double pID, double w, GeoPoint lp, GeoPoint rp){
           id = pID;
           len = distance(lp, rp);
           weight = w;
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

    }
    public class GeoLineGroup{
        private double id;
        private List<GeoLine> lines;
        private double len;

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


    }
    
    public class GeoPolygonGroup{
        private double id;
        private double area;
        private double perimeter;
        private List<GeoPolygon> polygons;
        private GeoLineGroup boundary;
        private GeoPolygonGroup edgePolygons;
        private DVGroup dv;
    }

    public class DV{
       private double id;
       private double value;
       private string description;
    }

    public class DVGroup{
        private double id;
        private string description;
        private List<DV> dvList;
    }
}