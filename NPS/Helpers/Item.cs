﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NPS
{
    [System.Serializable]
    public class Item : IEquatable<Item>
    {
        public string TitleId, Region, TitleName, zRif, pkg;
        public System.DateTime lastModifyDate = System.DateTime.MinValue;
        public int DLCs { get { return DlcItm.Count; } }
        public List<Item> DlcItm = new List<Item>();
        public bool IsDLC = false, ItsPsx = false, ItsPsp = false;
        public string ParentGameTitle = string.Empty;
        public string ContentId = null;
        public string contentType = "";
        public string DownloadFileName
        {
            get
            {
                if (string.IsNullOrEmpty(ContentId)) return TitleId;
                else return ContentId;
            }
        }

        public Item() { }



        public void CalculateDlCs(Item[] dlcDbs)
        {
            foreach (Item i in dlcDbs)
            {
                if (i.Region == this.Region && i.TitleId.Contains(this.TitleId))
                {
                    this.DlcItm.Add(i);
                }
            }
        }

        public bool CompareName(string name)
        {
            name = name.ToLower();

            if (this.TitleId.ToLower().Contains(name)) return true;
            if (this.TitleName.ToLower().Contains(name)) return true;
            return false;
        }

        public bool Equals(Item other)
        {
            if (other == null) return false;

            return this.TitleId == other.TitleId && this.Region == other.Region && this.TitleName == other.TitleName && this.zRif == other.zRif && this.pkg == other.pkg;
        }
    }


}
