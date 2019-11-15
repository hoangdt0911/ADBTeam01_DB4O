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
    class Program
    {
        readonly static string YapFileName = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), " K39104025_CourseManager.Yap");
        static void Main(string[] args)
        {
            File.Delete(YapFileName);
            IObjectContainer db = Db4oEmbedded.OpenFile(Db4oEmbedded.NewConfiguration(), YapFileName);
            try
            {
                Stored10MonHoc(db);
                RetrieveAllMonHoc(db);
                RetrieveCNTT(db);
                RetrieveKDK(db);
            }
            finally
            {

                db.Close();
            }
        }

        public static void Stored10MonHoc(IObjectContainer db)
        {
            Khoa khoa1 = new Khoa("COMP", "CNTT", "I101", "077896452");
            db.Store(khoa1);
            Khoa khoa2 = new Khoa("MATH", "TOAN-TIN", "C507", "078231654");
            db.Store(khoa2);
            Khoa khoa3 = new Khoa("PHYS", "TRIETHOC", "A302", "078963147");
            db.Store(khoa3);
            MonHoc mon1 = new MonHoc(1,"Co so du lieu", khoa1, null, 3);
            db.Store(mon1);
            MonHoc mon2 = new MonHoc(2,"Lap trinh huong doi tuong", khoa1, null, 3);
            db.Store(mon2);
            MonHoc mon3 = new MonHoc(3,"Co so du lieu nang cao", khoa1, null, 3);
            mon3.MonDieuKien = new List<MonHoc>() { mon1 };
            db.Store(mon3);
            MonHoc mon4 = new MonHoc(4,"Phan tich thiet ke huong doi tuong", khoa1, null, 3);
            mon4.MonDieuKien = new List<MonHoc>() { mon1, mon2, mon3 };
            db.Store(mon4);
            MonHoc mon5 = new MonHoc(5,"Bao mat co so du lieu", khoa1, null, 3);
            mon5.MonDieuKien = new List<MonHoc>() { mon1 };
            db.Store(mon5);
            MonHoc mon6 = new MonHoc(6,"Toan Roi Rac", khoa2, null, 3);
            db.Store(mon6);
            MonHoc mon7 = new MonHoc(7, "Xac suat thong ke", khoa2, null, 3);
            db.Store(mon7);
            MonHoc mon8 = new MonHoc(8, "Dai so tuyen tinh", khoa2, null, 3);
            db.Store(mon8);
            MonHoc mon9 = new MonHoc(9, "Triet hoc Mac-Lenin", khoa3, null, 2);
            db.Store(mon9);
            MonHoc mon10 = new MonHoc(10, "Tu tuong Ho Chi Minh", khoa3, null, 2);
            db.Store(mon10);
        }

        public static void ListResult(IObjectSet result)
        {

            Console.WriteLine(result.Count);
            foreach (object r in result)
            {
                Console.WriteLine(r);
            }
        }

        public static void RetrieveAllMonHoc(IObjectContainer db)
        {
            
            IObjectSet set = db.QueryByExample(typeof(MonHoc));
            ListResult(set);
        }

        public static void RetrieveCNTT(IObjectContainer db)
        {
            IList<MonHoc> result = db.Query(delegate (MonHoc m)
              {
                  return m.KhoaQuanLy.TenKhoa == "CNTT" && m.SoTinChi > 2 && m.MonDieuKien.Count > 1;
              });
            foreach(MonHoc m in result)
            {
                Console.WriteLine(m);
            }
        }

        public static void RetrieveKDK(IObjectContainer db)
        {
            IList<MonHoc> result = db.Query(delegate (MonHoc m)
            {
                return m.SoTinChi == 3 && m.MonDieuKien == null;
            });
            foreach (MonHoc m in result)
            {
                Console.WriteLine(m);
            }
        }
    }
}
