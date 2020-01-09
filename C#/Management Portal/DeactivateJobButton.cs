//update a job to active or inactive from the dashboard
[HttpPost]
[ValidateAntiForgeryToken]
[Authorize(Roles = "Admin")]
public ActionResult UpdateActive(string jobIb) //called with "Activate Job button in _Schedules
{
    var job = db.Jobs.Find(Convert.ToInt32(jobIb)); //gets the job from the database
    if (job != null) //checks if the job exists in the database
    {
        if (job.Active == false)//check to see if the active status is false
        {
            job.Active = true; //change the active property to true
            db.SaveChanges();
            return Json(new { result = "success", JsonRequestBehavior.AllowGet });
        }
        else
        {
            job.Active = false; //change the active property to false
            db.SaveChanges();
            return Json(new { result = "success", JsonRequestBehavior.AllowGet });
        }

    }
    else //return error that job is not in database
    {
        return Json(new { result = "error", message = "This job was not found in the database" });
    }
}
