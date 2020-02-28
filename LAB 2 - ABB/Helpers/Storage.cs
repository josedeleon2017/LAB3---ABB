﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAB_2___ABB.Models;

namespace LAB_2___ABB.Helpers
{
    public class Storage
    {
        private static Storage _instance = null;

        public static Storage Instance
        {
            get
            {
                if (_instance == null) _instance = new Storage();
                return _instance;
            }
        }

        public List<MedicineModel> MedicineList = new List<MedicineModel>();
        public NoLinealStructures.Structures.Tree<MedicineModel> MedicineTree = new NoLinealStructures.Structures.Tree<MedicineModel>();

    }
}