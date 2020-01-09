//Display _UserList on dashboard if logged in user is Admin

[AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]//get method doesn't allow posts, this fixes so that both can be used (used to fix error when admin posting a news story).
[Authorize(Roles = "Admin")]
public ActionResult _UserList(string sortOrder, string currentFilter, string searchStringUL, int? page)
{
    ViewBag.CurrentSort = sortOrder;
    ViewBag.LNameSortParm = String.IsNullOrEmpty(sortOrder) ? "lname_desc" : "";
    ViewBag.FNameSortParm = String.IsNullOrEmpty(sortOrder) ? "fname_desc" : "";
    ViewBag.UNameSortParm = String.IsNullOrEmpty(sortOrder) ? "uname_desc" : "";
    ViewBag.RoleSortParm = String.IsNullOrEmpty(sortOrder) ? "role_desc" : "";

    if (searchStringUL != null)
    {
        page = 1;
    }
    else
    {
        searchStringUL = currentFilter;
    }

    ViewBag.CurrentFilter = searchStringUL;
    //grabs all non-suspended users from database
    var users = from s in db.Users
                where s.Suspended == false
                select s;
    if (!String.IsNullOrEmpty(searchStringUL))
    {
        users = users.Where(s => s.LastName.Contains(searchStringUL)
                               || s.UserName.Contains(searchStringUL)
                               || s.FirstName.Contains(searchStringUL));
    }
    switch (sortOrder)
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
    int pageNumber = (page ?? 1);
    return PartialView(users.ToPagedList(pageNumber, pageSize));
}
