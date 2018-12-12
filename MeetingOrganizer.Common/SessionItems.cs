using ECommerce.Entity;
using System.Collections.Generic;
using System.Web;

namespace ECommerce.Common.Model
{
    public class SessionItems
    {
        public SessionItems()
        {
            CurrentUser = new User();
            CurrentUserRoles = new string[10];
            Cart = new List<OrderModel>();
            CurrentUserAddress = new List<Address>();
        }

        private static SessionItems _sessionItems;
        public static SessionItems Init()
        {
            if (HttpContext.Current.Session.IsNewSession)
            {
                _sessionItems = new SessionItems();
                return _sessionItems;
            }

            return _sessionItems;
        }

        public static User CurrentUser
        {
            get
            {
                return HttpContext.Current.Session["CurrentUser"] as User;
            }
            set
            {
                HttpContext.Current.Session["CurrentUser"] = value;
            }
        }

        public static string[] CurrentUserRoles
        {
            get
            {
                return (string[])HttpContext.Current.Session["CurrentUserRoles"];
            }
            set
            {
                HttpContext.Current.Session["CurrentUser"] = value;
            }
        }

        public static List<Address> CurrentUserAddress
        {
            get
            {
                return (List<Address>)HttpContext.Current.Session["CurrentUserAddress"];
            }
            set
            {
                HttpContext.Current.Session["CurrentUserAddress"] = value;
            }
        }

        public static List<OrderModel> Cart
        {
            get
            {
                return (List<OrderModel>) HttpContext.Current.Session["OrderDetail"];
            }
            set
            {
                HttpContext.Current.Session["OrderDetail"] = value;
            }
        }
    }
}
