
using Microsoft.AspNet.Identity;
using MyEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.Data.Entity;
using System.Threading.Tasks;
using IdentityModel;
using System.Data.SqlClient;
using System.Configuration;

namespace MyEcommerce.Controllers
{
    public static class CustomRoles
    {
        public const string Administrator = "Admin";
        public const string User = "User";
    }
    public class HomeController : Controller
    {
        //sql
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constring);
        }

        ApplicationDbContext db = new ApplicationDbContext();
        //public ActionResult _Layout()
        //{

        //    var userID = User.Identity.GetUserId();
        //    var userId = userID;
        //    var email = db.Users.Where(s => s.Id == userID).Select(x => x.Email).FirstOrDefault().ToString();
        //    var del = db.UserCards.Where(x => x.email == email).ToList();
        //    return View(del);
        //}
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public ActionResult search(string search)
        {
            return View(db.ProductAdds.Where(x => x.name.Contains(search)).ToList());

            //return View();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AdmiPage()
        {
            return View();
        }
        public ActionResult RemoveProduct(int? i)
        {
            return View(db.ProductAdds.ToList().ToPagedList(i ?? 1, 3));
        }
        [HttpGet]
        public ActionResult RemoveUser()
        {
            var e = db.Users.ToList();
            return View(db.Users.ToList());
        }

        [HttpGet]
        public ActionResult ProductDelete(int id)
        {

            //var user = await db.ProductAdds.FindAsync(id);
            var del = db.ProductAdds.Where(x => x.id == id).FirstOrDefault();
            db.Entry(del).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("RemoveProduct");
        }
        [HttpGet]
        public ActionResult ProductEdit(int id)
        {
            var edit = db.ProductAdds.Where(x => x.id == id).FirstOrDefault();
            return View(edit);
        }
        [HttpPost]
        public ActionResult ProductEdit(ProductAdd edit)
        {
            var itemEdit = db.ProductAdds.Where(x => x.id == edit.id).FirstOrDefault();
            itemEdit.prize = edit.prize;
            itemEdit.details = edit.details;
            itemEdit.flag = edit.flag;
            itemEdit.description = edit.description;
            itemEdit.name = edit.name;
            itemEdit.availability = edit.availability;
            db.Entry(itemEdit).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ProductEdit");
        }
        [HttpGet]
        public ActionResult GetItems(string id, int? i)
        {
            if((id == "men" || id == "women") || id == "baby")
            {
                return View(db.ProductAdds.Where(x => x.categories == id && x.availability == "Yes").ToList().ToPagedList(i ?? 1, 3));
            }
            return View(db.ProductAdds.Where(x => x.flag == id && x.availability == "Yes").ToList().ToPagedList(i ?? 1, 3));
        }
        
        [HttpGet]
        public ActionResult ProductAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(ProductAddModel2 model, HttpPostedFileBase file, string flag)
        {
            if (!ModelState.IsValid)
            {
                
                return View(model);
            }
            if (file != null)
            {
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string PhysicalPath = Server.MapPath("~/Images/" + ImageName);
                file.SaveAs(PhysicalPath);
                ProductAdd far = new ProductAdd();

                far.name = Request.Form["Name"];
                far.prize = Request.Form["Prize"];
                far.availability = Request.Form["Availability"];
                far.details = Request.Form["Details"];
                far.description = Request.Form["Description"];
                far.categories = Request.Form["categories"];
                //far.flag = Request.Form["flag"];
                far.flag = flag;
                far.imageUrl = ImageName;
                far.address = null;
                db.ProductAdds.Add(far);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("About");

        }

        public ActionResult CardView(int id)
        {
            TempData["alertMessage"] = "Hi, User";
            var itemCard = db.ProductAdds.Where(x => x.id == id && x.availability == "Yes").FirstOrDefault();
            //itemCard2 = db.ProductAdds.FirstOrDefault(x => x.id == id && x.availability == "Yes");
            //var itemCard = db.ProductAdds.Where(x => x.id == id && x.availability == "Yes").ToList();
            //return View(Tuple.Create<ProductAdd, IEnumerable<ProductAdd>>(itemCard2, itemCard ));
            ProductAddModel ob = new ProductAddModel();
            ob.imageUrl = itemCard.imageUrl;
            ob.id = itemCard.id;
            ob.prize = itemCard.prize;
            ob.details = itemCard.details;
            ob.description = itemCard.description;
            return View(ob);
        }
        [HttpPost]
        public ActionResult CardView(ProductAddModel UserItem)
        {
            if (ModelState.IsValid)
            {
                UserCard ob = new UserCard();
                ob.id = UserItem.id;
                ob.totalprize = (Int32.Parse(UserItem.prize) * Int32.Parse(UserItem.flag)).ToString();
                int prize = Int32.Parse(UserItem.prize);
                ob.quantity = UserItem.flag;
                ob.imgcardUrl = UserItem.imageUrl;
                ob.address = UserItem.address;
                try
                {
                    var userID = User.Identity.GetUserId();
                    ob.userId = userID;
                    ob.email = db.Users.Where(s => s.Id == userID).Select(x => x.Email).FirstOrDefault().ToString();
                }
                catch
                {

                    //ViewBag.ErrorMessage = "Email not found or matched";
                    ModelState.AddModelError("EmailNotFound", "Please login first");
                    return View(UserItem);
                }
                //if (ob.email == null)
                //{

                //    ModelState.AddModelError("Email", "Please login first");
                //    //TempData["Message"] = "Please login first";
                //    return View(UserItem);
                //}
                
                    db.UserCards.Add(ob);
                    db.SaveChanges();
                    TempData["alertMessage"] = "Item Is Added To Cart";
                    //return RedirectToAction("Index", "Home");
                    return View(UserItem);
                
                //var itemCard = db.ProductAdds.Where(x => x.id == id && x.availability == "Yes").ToList();
                
            }
                return View(UserItem);
        }

        public ActionResult AddToCart(int id)
        {
            UserCard userCard = new UserCard();
            var item = db.ProductAdds.Where(x => x.id == id).FirstOrDefault();
            var user = User.Identity.GetUserId();
            userCard.id = item.id;
            userCard.userId = user;
            userCard.imgcardUrl = item.imageUrl;
            userCard.flag = item.flag;
            userCard.totalprize = Session["prize"].ToString();
            db.UserCards.Add(userCard);
            db.SaveChanges();
            return View();
        }

        [Authorize(Roles = CustomRoles.Administrator + "," + CustomRoles.User)]
        public ActionResult checkout()
        {
            var userID = User.Identity.GetUserId();
            var userId = userID;
            var email = db.Users.Where(s => s.Id == userID).Select(x => x.Email).FirstOrDefault().ToString();
            
            var data = db.UserCards.Where(x => x.email == email).ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult DeleteFromCart(int id, string email)
        {
            var itemTobeDeletedFromCart = db.UserCards.Where(x => x.id == id && x.email == email).FirstOrDefault();
            db.Entry(itemTobeDeletedFromCart).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("checkout");
        }
        [HttpGet]
        public ActionResult CheckOutUser()
        {
            var userID = User.Identity.GetUserId();
            var userId = userID;
            var email = db.UserCards.Where(s => s.userId == userID).Select(x => x.email).FirstOrDefault().ToString();
            var count = db.UserCards.Where(s => s.email == email).ToList();
            int totalIteration = 0;
            foreach (var c in count)
            { totalIteration += 1;
                // adding to itemTobeshipped table
                ItemToBeShipped addtoshipping = new ItemToBeShipped();
                addtoshipping.address = c.address;
                addtoshipping.email = c.email;
                addtoshipping.description = c.description;
                addtoshipping.totalprize = c.totalprize;
                addtoshipping.imgcardUrl = c.imgcardUrl;
                addtoshipping.id = c.id;
                addtoshipping.userId = c.userId;
                addtoshipping.details = c.details;
                db.itemToBeShippeds.Add(addtoshipping);

                // deleting from Usercard table
                var itemTobeDeletedFromUserCart = db.UserCards.Where(x => x.email == email).FirstOrDefault();
                db.Entry(itemTobeDeletedFromUserCart).State = EntityState.Deleted;
                db.SaveChanges();
            }
            if (totalIteration != 0)
            {
                var showInvoice = db.itemToBeShippeds.Where(s => s.email == email).ToList();
                return View(showInvoice);
            }
            //var email = db.UserCards.Single(s => s.userId == userID);
            //db.UserCards.Remove(email);
            //db.SaveChanges();
            return RedirectToAction("checkout");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}