using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWork
{
    class Program
    {
        static void Main(string[] args)
        {


            //查詢
            omgEntities selecttest = new omgEntities();
            string userID;
            Console.Write("輸入ID： ");
            userID = Console.ReadLine();
            int userid = int.Parse(userID);

            var select = from p in selecttest.Table1
                         where p.ID == userid
                         select p;
            foreach (var x in select)
            {
                Console.Write(string.Format("{0}--{1}",x.ID,x.Number));
                Console.Write($"{x.ID}--{x.Number}");
            }
            Console.ReadLine();


            //新增
            omgEntities test = new omgEntities();

            string createid;
            Console.Write("輸入Number：");
            createid = Console.ReadLine();

            var ad1 = test.Table1.Create();

            ad1.Number = createid;
            test.Table1.Add(ad1);
            test.SaveChanges();

            //修改
            string EditID;
            string upid;
            Console.Write("請輸入ID： ");
            EditID = Console.ReadLine();
            Console.Write("輸入Number：");
            upid = Console.ReadLine();
            int editid = int.Parse(EditID);

            omgEntities test = new omgEntities();
            Table1 Updatetest = test.Table1.Find(editid);

            Updatetest.Number = upid;

            test.Entry(Updatetest).State = EntityState.Modified;
            test.SaveChanges();


            //刪除
            omgEntities deletetest = new omgEntities();

            string deid;
            Console.Write("輸入ID：");
            deid = Console.ReadLine();
            int id = int.Parse(deid);

            var delete = from p in deletetest.Table1
                         where p.ID == userid
                         select p;
            Table1 t1 = delete.First();
            deletetest.Table1.Remove(t1);
            deletetest.SaveChanges();
        }
    }
}
