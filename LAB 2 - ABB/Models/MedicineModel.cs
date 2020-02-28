using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAB_2___ABB.Helpers;

namespace LAB_2___ABB.Models
{
    public class MedicineModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }      

        //INSERT TREE
        public static void Add(MedicineModel medicine)
        {
            Storage.Instance.MedicineTree.Insert(medicine, NameComparison);
        }

        //SEARCH TREE
        public static int Search(MedicineModel medicine)
        {
            return Storage.Instance.MedicineTree.Find(medicine, NameComparison, NameConverter);
        }

        public static void Save(MedicineModel medicine)
        {
            Storage.Instance.MedicineList.Add(medicine);
        }

        //DELEGATES
        public static Comparison<MedicineModel> NameComparison = delegate (MedicineModel medicine1, MedicineModel medicine2)
        {
            return medicine1.Name.CompareTo(medicine2.Name);
        };

        public static Comparison<MedicineModel> NameConverter = delegate (MedicineModel medicine1, MedicineModel medicine2)
        {
            return medicine1.Name.CompareTo(medicine2.Name); //PREDICATE CONVERTER
        };
    }
}