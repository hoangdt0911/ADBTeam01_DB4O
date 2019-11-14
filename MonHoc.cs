using System;
using System.IO;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADBTeam01_DB4O
{
    [Serializable]
    public class MonHoc
    {
        int _MaMH;
        string _TenMon;
        string _MoTa;
        Khoa _KhoaQuanLy;
        List<MonHoc> _MonDieuKien;
        double _SoTinChi;

        public MonHoc(int mm, string tm, Khoa khoa, List<MonHoc> mdk, int v2)
        {
            _MaMH = mm;
            _TenMon = tm;
            _MoTa = null;
            _KhoaQuanLy = khoa;
            _MonDieuKien = mdk;
            _SoTinChi = v2;
        }





        //public Guid MaMH { get; set; }
        //public string TenMon { get; set; }
        //public string MoTa { get; set; }
        //public Khoa KhoaQuanLy { get; set; }
        //public List<MonHoc> MonDieuKien { get; set; }
        //public double SoTinChi { get; set; }



        public int MaMH
        {
            get
            {
                return _MaMH;
            }
        }

        public string TenMon
        {
            get
            {
                return _TenMon;
            }
        }

        public string MoTa
        {
            get
            {
                return _MoTa;
            }
        }

        public Khoa KhoaQuanLy
        {
            get
            {
                return _KhoaQuanLy;
            }
        }

        public List<MonHoc> MonDieuKien
        {
            get
            {
                return _MonDieuKien;
            }
            set
            {
                _MonDieuKien = value;
            }
        }

        public double SoTinChi
        {
            get
            {
                return _SoTinChi;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1} ({2})", _MaMH, _TenMon, _SoTinChi);
        }
    }
}
