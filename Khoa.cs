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
    public class Khoa
    {
        string _MaKhoa;
        string _TenKhoa;
        string _DiaChi;
        string _DienThoai;

        public Khoa(string mk, string tk, string dc, string dt)
        {
            _MaKhoa = mk;
            _TenKhoa = tk;
            _DiaChi = dc;
            _DienThoai = dt;
        }

        //public string MaKhoa { get; set; }
        //public string TenKhoa { get; set; }
        //public string DiaChi { get; set; }
        //public string DienThoai { get; set; }



        public string MaKhoa
        {
            get
            {
                return _MaKhoa;
            }
        }

        public string TenKhoa
        {
            get
            {
                return _TenKhoa;
            }
        }

        public string DiaChi
        {
            get
            {
                return _DiaChi;
            }
        }

        public string DienThoai
        {
            get
            {
                return _DienThoai;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}", _TenKhoa);
        }
    }
}
