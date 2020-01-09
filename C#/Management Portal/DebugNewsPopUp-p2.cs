//Display _SuspendedUsers on dashboard if logged in user is Admin
[ChildActionOnly]
[AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]//get method doesn't allow posts, this fixes so that both can be used (used to fix error when admin posting a news story).
[Authorize(Roles = "Admin")]
public ActionResult _SuspendedUsers(string sortOrder2, string currentFilter2, string searchString2, int? page2)
{
    ViewBag.CurrentSort = sortOrder2;
    ViewBag.LNameSortParm = String.IsNullOrEmpty(sortOrder2) ? "lname_desc" : "";
    ViewBag.FNameSortParm = String.IsNullOrEmpty(sortOrder2) ? "fname_desc" : "";
    ViewBag.UNameSortParm = String.IsNullOrEmpty(sortOrder2) ? "uname_desc" : "";
    ViewBag.RoleSortParm = String.IsNullOrEmpty(sortOrder2) ? "role_desc" : "";

    if (searchString2 != null)
    {
        page2 = 1;
    }
    else
    {
        searchString2 = currentFilter2;
    }

    ViewBag.CurrentFilter = searchString2;
    //grabs all suspended users from database
    var users = from s in db.Users
                where s.Suspended == true
                select s;
    if (!String.IsNullOrEmpty(searchString2))
    {
        users = users.Where(s => s.LastName.Contains(searchString2)
                               || s.UserName.Contains(searchString2)
                               || s.FirstName.Contains(searchString2));
    }
    switch (sortOrder2)
    {
        case "lname_desc":
            users = users.OrderByDescending(s => s.LastName);
            break;
        case "uname_desc":
            users = users.OrderByDescending(s => s.UserName);
            break;
        case "fname_desc":
            users = users.OrderByDescending(s => s.FirstName);
            break;
        case "role_desc":
            users = users.OrderByDescending(s => s.FirstName);
            break;
        case "uname_asc":
            users = users.OrderBy(s => s.UserName);
            break;
        case "fname_asc":
            users = users.OrderBy(s => s.FirstName);
            break;
        case "role_asc":
            users = users.OrderBy(s => s.Roles);
            break;
        default:
            users = users.OrderBy(s => s.LastName);
            break;
    }
    int pageSize = 3;  //Number of users displayed at a time
    int pageNumber = (page2 ?? 1);
    return PartialView(users.ToPagedList(pageNumber, pageSize));
}
//    var model = db.Users.ToList();
//    return PartialView("_SuspendedUsers", model);
//}

//Display _SuspendedUsers on dashboard if logged in user is Admin
[ChildActionOnly]
[Authorize(Roles = "Admin")]
public ActionResult _SuspendedUsersMobile()
{
    var model = db.Users.ToList();
    return PartialView("_SuspendedUsersMobile", model);
}
