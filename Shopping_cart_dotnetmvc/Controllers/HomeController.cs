using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping_cart_dotnetmvc.DataContexts;
using Shopping_cart_dotnetmvc.Models;

namespace Shopping_cart_dotnetmvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View(db.products.ToList());
        }
       [HttpPost]
        public JsonResult addtocart( int Product_id)
        {
            if(Session["cart"] != null)
            {
                List<Product_count> mainlist = Session["cart"] as List<Product_count>;
                int check = 0;
                foreach (var item in mainlist)
                {
                    if (item.Productcount_id == Product_id)
                    {

                        item.Product_quantity = item.Product_quantity + 1;
                        check = 0;
                        break;
                    }
                    else
                    {
                        check = 1;
                    }
                   
                        
                }
                if(check == 1)
                {
                    Product_count obj = new Product_count();
                    obj.Productcount_id = Product_id;
                    obj.Product_quantity = 1;
                    mainlist.Add(obj);
                }
                Session["cart"] = mainlist as List<Product_count>;
            }
            else
            {
                List<Product_count> firstlist = new List<Product_count>();
                Product_count obj = new Product_count();
                obj.Productcount_id = Product_id;
                obj.Product_quantity = 1;
                firstlist.Add(obj);
                Session["cart"] = firstlist as List<Product_count>;
            }
            return Json(Session["cart"], JsonRequestBehavior.AllowGet);
        }
        public ActionResult viewcart()
        {
            List<Product_count> mainlist = Session["cart"] as List<Product_count>;
            List<ViewCart> viewlist = new List<ViewCart>();
            foreach (var item in mainlist)
            {
                ViewCart obj = new ViewCart();
                Product pro = db.products.Where(x => x.Product_id == item.Productcount_id).FirstOrDefault();
                obj.Viewcart_product_id = pro.Product_id;
                obj.Viewcart_product_name = pro.Product_name;                
                obj.Viewcart_product_quantity = item.Product_quantity;
                obj.Viewcart_product_image = pro.Product_image;
                obj.Viewcart_product_price = pro.Product_price;
                obj.Viewcart_product_totalprice =Convert.ToString(item.Product_quantity * pro.Product_price);
                viewlist.Add(obj);
            }
            return View(viewlist);
        }
        [HttpPost]
        public ActionResult increase(int Product_id)
        {

            List<Product_count> mainlist = Session["cart"] as List<Product_count>;
            int qty = 0;
            for (int i = 0; i < mainlist.Count; i++)
            {
                if(mainlist[i].Productcount_id == Product_id)
                {
                    mainlist[i].Product_quantity = mainlist[i].Product_quantity + 1;
                    qty = mainlist[i].Product_quantity;
                    break;
                }
            }
            Session["cart"] = mainlist as List<Product_count>;

            return Json(qty, JsonRequestBehavior.AllowGet);
        }
        public ActionResult decrease(int Product_id)
        {

            List<Product_count> mainlist = Session["cart"] as List<Product_count>;
            int qty = 0;
            for (int i = 0; i < mainlist.Count; i++)
            {
                if (mainlist[i].Productcount_id == Product_id)
                {
                    if(mainlist[i].Product_quantity > 0)
                    {
                        mainlist[i].Product_quantity = mainlist[i].Product_quantity - 1;
                        qty = mainlist[i].Product_quantity;
                        break;
                    }
                    else
                    {
                        qty = 0;
                        break;
                    }
                  
                    
                }
            }
            Session["cart"] = mainlist as List<Product_count>;

            return Json(qty, JsonRequestBehavior.AllowGet);
        }

       
        public ActionResult Proceedtocheckout()
        {
            if(Session["global_id"] != "" && Session["global_id"] != null)
            {
                string uid = DateTime.Now.ToString("ddMMyyyyhhmmssfff");
                Session["current_cart_id"] = uid;
                List<Product_count> mainlist = Session["cart"] as List<Product_count>;

                for (int i = 0; i < mainlist.Count; i++)
                {
                    Cart crt = new Cart();
                    crt.Cart_user_id = Convert.ToInt64(uid);
                    crt.Cart_product_id = mainlist[i].Productcount_id;
                    crt.Cart_quantity = mainlist[i].Product_quantity;
                    db.carts.Add(crt);
                    db.SaveChanges();

                }
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }
            
           
        }
       [HttpPost]
        public ActionResult Proceedtocheckout(User_info info)
        {
            if(Session["global_id"] != null)
            {
                info.userinfo_id = Convert.ToInt32(Session["global_id"]);
                db.user_Infos.Add(info);
                db.SaveChanges();
                return RedirectToAction("confirmorder");
            }
            else
            {
                return RedirectToAction("login");
            }

        }
        public ActionResult confirmorder()
        {
            long cart_id = Convert.ToInt64(Session["current_cart_id"]);
            List<Cart> mnlst = db.carts.Where(x => x.Cart_user_id == cart_id).ToList();
            List<prod> prods = new List<prod>();
            int totalamount = 0;
            for (int i = 0; i < mnlst.Count; i++)
            {
                int iiid = Convert.ToInt32(mnlst[i].Cart_product_id);
                Product obj = db.products.Where(x => x.Product_id == iiid).FirstOrDefault();
                prod singledata = new prod();
                singledata.id = i + 1;
                singledata.product_name = obj.Product_name;
                singledata.pricexquantity = obj.Product_price * mnlst[i].Cart_quantity;
                singledata.product_quantity = mnlst[i].Cart_quantity;
                prods.Add(singledata);
            }
            foreach (var item in prods)
            {
                totalamount = Convert.ToInt32( totalamount) + Convert.ToInt32( item.pricexquantity);
            }

            ConfirmOrder order = new ConfirmOrder();
            order.Product = prods;
            order.Totalamount = totalamount;

            return View(order);
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(string email,string pwd)
        {
            
                if(db.users.Any(x => x.User_email == email && x.User_pwd == pwd))
            {
                Session["global_id"] = db.users.Where(x => x.User_email == email && x.User_pwd == pwd).Select(x => x.User_id).FirstOrDefault();
                return RedirectToAction("viewcart");
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult placeorder()
        {
            string uid = DateTime.Now.ToString("ddMMyyyyhhmmssfff");
            long cart_id = Convert.ToInt64(Session["current_cart_id"]);
            int global_id = Convert.ToInt32(Session["global_id"]);
            int total = 0;
            List<Cart> cart = db.carts.Where(x => x.Cart_product_id == cart_id).ToList();
            foreach (var item in cart)
            {
                int iiid = Convert.ToInt32(item.Cart_product_id);
                Product obj = db.products.Where(x => x.Product_id == iiid).FirstOrDefault();
                total = total+obj.Product_price * item.Cart_quantity;
            }
            Order ord = new Order();
            ord.Order_no = uid;
            ord.Order_cart_id = cart_id;
            ord.Order_user_id = global_id;
            ord.Order_total_price = total;
            db.orders.Add(ord);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Myorder()
        {
            return View();
        }
    }

}
