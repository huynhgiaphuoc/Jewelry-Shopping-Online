using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using static System.Web.Razor.Parser.SyntaxConstants;

namespace Jewelly.Models
{
    public class MyPurchase
    {
        public int? ID { get; set; }
        public int? quantity { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? le { get; set; }

        public string Image { get; set; }
        public string Path { get; set; }
        public string Status { get; set; }

    }

    public class JoinMyPurchase
    {
        JwelleyEntities db = new JwelleyEntities();
        public List<MyPurchase> SelectPurchase(int id)
        {
            var purChase = (from i in db.CartLists
                            join o in db.Orderdetails on i.ID equals o.ID
                         
                            where i.ID == o.ID  && i.userID == id
                            select new MyPurchase()
                            {
                                ID = o.ID
                            }).ToList();
            purChase.Count();
            Console.WriteLine("Số lượng đơn hàng: " + purChase.Count());
            return purChase;
        }

        public List<MyPurchase> SelectPending(int id,int qq)
        {
            if (qq == 1)
            {
                var purChase = (from i in db.CartLists
                                join o in db.Orderdetails on i.ID equals o.ID
                                join c in db.ItemMsts on o.Style_Code equals c.Style_Code
                                join g in db.Imgs on c.Img_ID equals g.ID
                                where i.ID == o.ID && o.Style_Code == c.Style_Code && c.Img_ID == g.ID && i.userID == id && i.Status == "Pending"
                                select new MyPurchase()
                                {
                                    ID = i.ID,
                                    Name = i.Product_Name,
                                    Price = c.MRP,
                                    Image = g.pic_1,
                                    Path = g.path_img,
                                    le = i.MRP,
                                    Status = i.Status,
                                    quantity = db.Orderdetails.Count(order => order.ID == i.ID)
                                }).GroupBy(o => o.ID)
                .Select(group => group.FirstOrDefault())
                .ToList();

                return purChase;

            }
            if (qq == 2)
            {
                var purChase = (from i in db.CartLists
                                join o in db.Orderdetails on i.ID equals o.ID
                                join c in db.ItemMsts on o.Style_Code equals c.Style_Code
                                join g in db.Imgs on c.Img_ID equals g.ID
                                where i.ID == o.ID && o.Style_Code == c.Style_Code && c.Img_ID == g.ID && i.userID == id && i.Status == "Cancel"
                                select new MyPurchase()
                                {
                                    ID = i.ID,
                                    Name = i.Product_Name,
                                    Price = c.MRP,
                                    Image = g.pic_1,
                                    Path = g.path_img,
                                    le = i.MRP,
                                    Status = i.Status,
                                    quantity = db.Orderdetails.Count(order => order.ID == i.ID)
                                }).GroupBy(o => o.ID)
                .Select(group => group.FirstOrDefault())
                .ToList();

                return purChase;

            }
            if (qq == 3)
            {
                var purChase = (from i in db.CartLists
                                join o in db.Orderdetails on i.ID equals o.ID
                                join c in db.ItemMsts on o.Style_Code equals c.Style_Code
                                join g in db.Imgs on c.Img_ID equals g.ID
                                where i.ID == o.ID && o.Style_Code == c.Style_Code && c.Img_ID == g.ID && i.userID == id && i.Status == "Delivering"
                                select new MyPurchase()
                                {
                                    ID = i.ID,
                                    Name = i.Product_Name,
                                    Price = c.MRP,
                                    Image = g.pic_1,
                                    Path = g.path_img,
                                    le = i.MRP,
                                    Status = i.Status,
                                    quantity = db.Orderdetails.Count(order => order.ID == i.ID)
                                }).GroupBy(o => o.ID)
                .Select(group => group.FirstOrDefault())
                .ToList();
                
                return purChase;
                

            }


            if (qq == 4)
            {
                var purChase = (from i in db.CartLists
                                join o in db.Orderdetails on i.ID equals o.ID
                                join c in db.ItemMsts on o.Style_Code equals c.Style_Code
                                join g in db.Imgs on c.Img_ID equals g.ID
                                where i.ID == o.ID && o.Style_Code == c.Style_Code && c.Img_ID == g.ID && i.userID == id && i.Status == "Approved"
                                select new MyPurchase()
                                {
                                    ID = i.ID,
                                    Name = i.Product_Name,
                                    Price = c.MRP,
                                    Image = g.pic_1,
                                    Path = g.path_img,
                                    le = i.MRP,
                                    Status = i.Status,
                                    quantity = db.Orderdetails.Count(order => order.ID == i.ID)
                                }).GroupBy(o => o.ID)
                .Select(group => group.FirstOrDefault())
                .ToList();

                return purChase;

            }
            if (qq == 5)
            {
                var purChase = (from i in db.CartLists
                                join o in db.Orderdetails on i.ID equals o.ID
                                join c in db.ItemMsts on o.Style_Code equals c.Style_Code
                                join g in db.Imgs on c.Img_ID equals g.ID
                                where i.ID == o.ID && o.Style_Code == c.Style_Code && c.Img_ID == g.ID && i.userID == id && i.Status == "Completed"
                                select new MyPurchase()
                                {
                                    ID = i.ID,
                                    Name = i.Product_Name,
                                    Price = c.MRP,
                                    Image = g.pic_1,
                                    Path = g.path_img,
                                    le = i.MRP,
                                    Status = i.Status,
                                    quantity = db.Orderdetails.Count(order => order.ID == i.ID)
                                }).GroupBy(o => o.ID)
                .Select(group => group.FirstOrDefault())
                .ToList();

                return purChase;

            }
            else
            {
                var purChase = (from i in db.CartLists
                                join o in db.Orderdetails on i.ID equals o.ID
                                join c in db.ItemMsts on o.Style_Code equals c.Style_Code
                                join g in db.Imgs on c.Img_ID equals g.ID
                                where i.ID == o.ID && o.Style_Code == c.Style_Code && c.Img_ID == g.ID && i.userID == id 
                                select new MyPurchase()
                                {
                                    ID = i.ID,
                                    Name = i.Product_Name,
                                    Price = c.MRP,
                                    Image = g.pic_1,
                                    Path = g.path_img,
                                    le = i.MRP,
                                    Status = i.Status,
                                    quantity = db.Orderdetails.Count(order => order.ID == i.ID)
                                }).GroupBy(o => o.ID)
                .Select(group => group.FirstOrDefault())
                .ToList();

                return purChase;
            }

        }
        public List<MyPurchase> selectall(int id,int qq) 
        {
            var purChase = (from i in db.CartLists
                            join o in db.Orderdetails on i.ID equals o.ID
                            join c in db.ItemMsts on o.Style_Code equals c.Style_Code
                            join g in db.Imgs on c.Img_ID equals g.ID
                            where i.ID == qq && i.ID == o.ID && o.Style_Code == c.Style_Code && c.Img_ID == g.ID && i.userID == id 
                            select new MyPurchase()
                            {
                                ID = i.ID,
                                Name = o.ItemMst.ProdMst.Prod_Type,
                                le = c.MRP,
                                Image = g.pic_1,
                                Path = g.path_img,
                                Status = i.Status,
                                quantity = o.Quantity
                            }).ToList();
            return purChase;
        }
    } 
}